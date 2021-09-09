#region Code Identifications

// Created on     2017/12/17
// Last update on 2018/01/03 by Mohammad Mir mostafa 

#endregion

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Filters;
using Mohammad.DesignPatterns.Creational;
using Mohammad.Diagnostics;
using Mohammad.EventsArgs;
using Mohammad.Exceptions;
using Mohammad.Helpers;
using Mohammad.Logging;
using Mohammad.Web.Api.Exceptions;

namespace Mohammad.Web.Api
{
    public abstract class WebApiConfigBase<TWebApiConfig> : Singleton<TWebApiConfig>
        where TWebApiConfig : WebApiConfigBase<TWebApiConfig>
    {
        //! Singltone App
        // ReSharper disable once StaticMemberInGenericType
        private static readonly object _WebApiConfigHelperLockObject = new object();

        public DateTime AppStartTime { get; private set; }

        public static void Register(HttpConfiguration config)
        {
            Instance.AppStartTime = DateTime.Now;
            Diag.RedirectDebugsToOutputPane(true);

            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute("DefaultApi",
                "api/{controller}/{id}",
                new
                {
                    id = RouteParameter.Optional
                });

            Instance.OnInitializing(config);
        }

        protected virtual void OnInitializing(HttpConfiguration config)
        {
            config.Initialize(this.ApiExecuting, this.ApiExecuted, this.HandleException, LogException);
        }

        private void ApiExecuted(HttpActionExecutedContext httpActionExecutedContext) { this.OnApiExecuted(httpActionExecutedContext); }

        protected virtual void OnApiExecuted(HttpActionExecutedContext httpActionExecutedContext) { }

        private void ApiExecuting(HttpActionContext actionContext)
        {
            this.OnApiExecuting(actionContext);
            try
            {
                this.OnRequestRecieved(actionContext.Request);

                if (actionContext.ActionArguments != null)
                    foreach (var argument in actionContext.ActionArguments)
                    {
                        var e =
                            new ItemActingEventArgs<(IEnumerable<KeyValuePair<string, object>> Arguments, KeyValuePair<string, object>
                                CurrentArgument)>((actionContext.ActionArguments, argument));
                        this.OnValidatingArgument(e);
                        if (e.Handled)
                            continue;

                        if (argument.Value != null)
                            continue;

                        var argumentBinding =
                            actionContext.ActionDescriptor?.ActionBinding.ParameterBindings.FirstOrDefault(
                                pb => pb.Descriptor.ParameterName == argument.Key);

                        if (argumentBinding?.Descriptor?.IsOptional ?? true)
                            continue;

                        actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                            $"Arguments value for {argument.Key} cannot be null");
                        return;
                    }

                if (actionContext.ModelState.IsValid)
                    return;
                actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.BadRequest, actionContext.ModelState);
                foreach (var state in actionContext.ModelState.Values)
                foreach (var error in state.Errors)
                    Debug.WriteLine($"Validator: {error.ErrorMessage}");
            }
            finally
            {
                this.OnResponseRecieved(actionContext.Response);
            }
        }

        protected virtual void OnApiExecuting(HttpActionContext actionContext) { }

        private void HandleException(HttpActionExecutedContext actionExecutedContext)
        {
            (HttpStatusCode code, string message) error = (HttpStatusCode.BadRequest, actionExecutedContext.Exception?.Message);

            switch (actionExecutedContext.Exception)
            {
                case ApiExceptionBase ex:
                    error = ex.Info;
                    break;
                case ExceptionBase ex:
                    error = (HttpStatusCode.BadRequest, ex.Message);
                    break;
                case NotImplementedException ex:
                    error = (HttpStatusCode.NotImplemented, ex.Message);
                    break;
            }
            actionExecutedContext.Response = actionExecutedContext.Request.CreateErrorResponse(error.code, error.message);

            this.OnHandedException(actionExecutedContext);
        }

        protected virtual void OnHandedException(HttpActionExecutedContext actionExecutedContext) { }

        private static void LogException(ExceptionLoggerContext context)
        {
            var exception = context.Exception;
            if (!(exception is ExceptionBase))
                CodeHelper.LockAndCatch(() =>
                    {
                        var filePath = $@"Logs\WebAPI.Bugs.{DateTime.Now.ToShortDateString().Replace("\\", "-").Replace("/", "-")}.log";
                        filePath = string.Concat(Debugger.IsAttached ? HttpRuntime.AppDomainAppPath : @".\", filePath);
                        var logFile = new FileInfo(filePath);
                        if (!logFile.Directory.Exists)
                            logFile.Directory.Create();
                        File.AppendAllText(logFile.FullName,
                            $@"[{DateTime.Now}]
            {context.Request.RequestUri}
            {Environment.NewLine}{exception}");
                    },
                    _WebApiConfigHelperLockObject);
            Log(exception.GetBaseException().Message);
        }

        protected virtual void OnValidatingArgument(
            ItemActingEventArgs<(IEnumerable<KeyValuePair<string, object>> Arguments, KeyValuePair<string, object> CurrentArgument)> e) { }

        protected virtual void OnRequestRecieved(HttpRequestMessage request) { }

        protected virtual void OnResponseRecieved(HttpResponseMessage response) { }

        public static void Log(string log, LogLevel level = LogLevel.Debug) { Instance.OnLogging(log, level); }

        protected virtual void OnLogging(string log, LogLevel level) { Debug.WriteLine($"[{DateTime.Now}] {log}"); }
    }
}