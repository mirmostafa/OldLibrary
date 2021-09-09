#region Code Identifications

// Created on     2017/11/11
// Last update on 2017/11/11 by Mohammad Mir mostafa 

#endregion

using System.Net;

namespace Mohammad.Web.Api.MessageExchange
{
    public interface IResponseMessage : IResponse
    {
        string Message { get; set; }

        HttpStatusCode Code { get; set; }
    }
}