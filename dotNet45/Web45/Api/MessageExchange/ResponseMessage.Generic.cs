#region Code Identifications

// Created on     2017/11/22
// Last update on 2017/11/22 by Mohammad Mir mostafa 

#endregion

using System;
using System.Net;
using System.Runtime.Serialization;
using Mohammad.Helpers;
using Newtonsoft.Json;

namespace Mohammad.Web.Api.MessageExchange
{
    [Serializable]
    public sealed class ResponseMessage<TResult> : ResponseMessage, ISerializable
    {
        public TResult ActionResult { get; set; }

        [JsonIgnore]
        public string PropName { get; set; } = "Result";

        public ResponseMessage() { }

        /// <inheritdoc />
        public ResponseMessage(TResult actionResult, string propName = null)
        {
            this.InitializeVariables(actionResult, propName);
        }

        /// <inheritdoc />
        public ResponseMessage(string message, TResult actionResult, string propName = null)
            : base(message)
        {
            this.InitializeVariables(actionResult, propName);
        }

        /// <inheritdoc />
        public ResponseMessage(HttpStatusCode code, string message, TResult actionResult, string propName = null)
            : base(code, message)
        {
            this.InitializeVariables(actionResult, propName);
        }

        /// <inheritdoc />
        public ResponseMessage(HttpStatusCode code, TResult actionResult, string propName = null)
            : base(code)
        {
            this.InitializeVariables(actionResult, propName);
        }

        private void InitializeVariables(TResult actionResult, string propName = null)
        {
            this.ActionResult = actionResult;
            if (!propName.IsNullOrEmpty())
                this.PropName = propName;
        }

        /// <inheritdoc />
        /// <inheritdoc />
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(this.PropName, this.ActionResult, typeof(TResult));
        }
    }
}