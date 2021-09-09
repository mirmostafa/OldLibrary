#region Code Identifications

// Created on     2017/12/17
// Last update on 2018/01/03 by Mohammad Mir mostafa 

#endregion

using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using Mohammad.BusinessModel.MessageExchange;
using Mohammad.Helpers;
using Mohammad.Threading.Tasks;
using Mohammad.Web.Api.MessageExchange;

namespace Mohammad.Web.Api
{
    public abstract class LibraryApiControllerBase : ApiController
    {
        protected virtual IActionResult DefaultActionResult { get; } = new OkActionResult();

        /// <summary>
        ///     Gets the default response.
        /// </summary>
        /// <param name="res">The resource.</param>
        /// <returns></returns>
        protected static IResponseMessage GetDefaultResponse(IActionResult res) => new ResponseMessage
                                                                                   {
                                                                                       Message = res.Message,
                                                                                       Code = (HttpStatusCode) res
                                                                                           .StatusCode
                                                                                   };

        /// <summary>
        ///     Gets the empty response.
        /// </summary>
        /// <param name="res">The resource.</param>
        /// <returns></returns>
        protected static IResponseMessage GetEmptyResponse(IActionResult res) => null;

        /// <summary>
        ///     Gets the default response.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        protected static IResponseMessage GetDefaultResponse(string message) => new ResponseMessage
                                                                                {
                                                                                    Message = message
                                                                                };

        /// <summary>
        ///     Parses the HTTP action result.
        /// </summary>
        /// <typeparam name="TResponseMessage">The type of the response message.</typeparam>
        /// <param name="statusCode">The status code.</param>
        /// <param name="message">The message.</param>
        /// <param name="createResponseMessage">The create response message.</param>
        /// <returns></returns>
        protected virtual IHttpActionResult ParseHttpActionResult<TResponseMessage>(int statusCode, string message = null,
            Func<TResponseMessage> createResponseMessage = null)
            where TResponseMessage : IResponseMessage
        {
            switch (statusCode)
            {
                case 200 when createResponseMessage == null && message.IsNullOrEmpty(): return this.Ok();
                case 200 when createResponseMessage == null: return this.Ok(GetDefaultResponse(message));
                case 200:
                    // ReSharper disable once PossibleNullReferenceException
                    var result = createResponseMessage();
                    if (result == null)
                        return this.Ok();
                    result.Message = message;
                    return this.Ok(result);
                default: return new ResponseMessageResult(this.Request.CreateErrorResponse((HttpStatusCode) statusCode, message));
            }
        }

        /// <summary>
        ///     Parses the HTTP action result.
        /// </summary>
        /// <param name="statusCode">The status code.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        protected virtual IHttpActionResult ParseHttpActionResult(int statusCode, string message = null) => this
            .ParseHttpActionResult<IResponseMessage>(statusCode, message);

        /// <summary>
        ///     Creates an <see cref="T:System.Web.Http.Results.OkResult" /> (200 OK) asynchronously.
        /// </summary>
        /// <returns>An <see cref="T:System.Web.Http.Results.OkResult" /></returns>
        protected virtual async Task<IHttpActionResult> OkAsync() => await Async.Run(this.Ok);
    }
}