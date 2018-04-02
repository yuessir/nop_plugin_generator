using Nop.Web.Framework.Mvc.Routes;
using System;
using System.Web;
using System.Collections.Generic;
using System.Text;

namespace BAS.Nop.Plugin.Widgets.WhatCustomersSay.Infrastructure
{
    public class RouteProvider : IRouteProvider
    {
        public void RegisterRoutes(System.Web.Routing.RouteCollection routes)
        {
            //throw new NotImplementedException();
        }

        public int Priority => 1;
    }
}
