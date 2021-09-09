#region Code Identifications

// Created on     2017/12/17
// Last update on 2018/03/05 by Mohammad Mir mostafa 

#endregion

using System;
using System.Net;
using System.Runtime.Serialization;
using Mohammad.Exceptions;

namespace Mohammad.Web.Api.Exceptions
{
    [Serializable]
    public abstract class ApiExceptionBase : PairMessageStatusCodeExceptionBase<HttpStatusCode>
    {
        /// <inheritdoc />
        protected ApiExceptionBase(string message, HttpStatusCode statusCode)
            : base(message, statusCode) { }

        /// <inheritdoc />
        protected ApiExceptionBase() { }

        /// <inheritdoc />
        protected ApiExceptionBase(string message)
            : base(message) { }

        /// <inheritdoc />
        protected ApiExceptionBase(string message, Exception inner)
            : base(message, inner) { }

        /// <inheritdoc />
        protected ApiExceptionBase(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
    }
}