﻿#region Code Identifications

// Created on     2018/01/03
// Last update on 2018/01/03 by Mohammad Mir mostafa 

#endregion

using System.Net;
using Mohammad.BusinessModel.MessageExchange.PrimaryActionResults;
using Mohammad.Helpers;

namespace Mohammad.Web.Api.MessageExchange
{
    public sealed class OkActionResult : ActionResultBase
    {
        /// <inheritdoc />
        public OkActionResult()
            : base(("Succeed", HttpStatusCode.OK.ToInt())) { }
    }
}