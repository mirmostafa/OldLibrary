#region Code Identifications

// Created on     2018/03/05
// Last update on 2018/03/05 by Mohammad Mir mostafa 

#endregion

using System.Net;

namespace Mohammad.Web.Api.Exceptions
{
    public class InternalServerErrorException : ApiExceptionBase
    {
        public InternalServerErrorException(string message)
            : base(message, HttpStatusCode.InternalServerError) { }

        public InternalServerErrorException()
            : base(string.Empty, HttpStatusCode.InternalServerError) { }
    }
}