﻿using System.Web;
using System.Web.Mvc;

namespace Ejemplo_ASP_MVC_NETFramework
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
