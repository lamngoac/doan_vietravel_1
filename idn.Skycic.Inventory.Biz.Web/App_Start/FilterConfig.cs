﻿using System.Web;
using System.Web.Mvc;

namespace idn.Skycic.Inventory.Biz.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}