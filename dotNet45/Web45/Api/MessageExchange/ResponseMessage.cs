#region Code Identifications

// Created on     2017/11/22
// Last update on 2017/11/26 by Mohammad Mir mostafa 

#endregion

using System.Net;
using Mohammad.Helpers;
using Newtonsoft.Json;

namespace Mohammad.Web.Api.MessageExchange
{
    //[Serializable]
    public class ResponseMessage : IResponseMessage
    {
        private readonly string DefaultMessage = "Succeed";

        public ResponseMessage() { }

        /// <inheritdoc />
        public ResponseMessage(string message)
            : this(HttpStatusCode.OK, message) { }

        /// <inheritdoc />
        public ResponseMessage(HttpStatusCode code, string message)
        {
            this.Code = code;
            this.Message = message.IfNullOrEmpty(this.DefaultMessage);
        }

        /// <inheritdoc />
        public ResponseMessage(HttpStatusCode code)
            : this(code, string.Empty) { }

        public string Message { get; set; }

        /// <inheritdoc />
        [JsonIgnore]
        public HttpStatusCode Code { get; set; }
    }
}