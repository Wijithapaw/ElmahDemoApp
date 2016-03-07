﻿using ElmahDemoApp.Domain.Common;
using ElmahDemoApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;

namespace ElmahDemoApp.Common
{
    public class WebEnvironmentDescriptor : IEnvironmentDescriptor
    {
        public string UserID { get; set; }

        public WebEnvironmentDescriptor()
        {
            UserID = HttpContext.Current.User.Identity.GetUserId();
        }
    }
}