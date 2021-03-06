﻿using System;
using System.Web.Mvc;

namespace HWSample.ActionFilters
{
    public class ActionTimeAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //記錄開始時間

            base.OnActionExecuting(filterContext);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            //記錄結束時間

            //計算執行時間
            TimeSpan exectuionTime = TimeSpan.FromHours(1);

            filterContext.Controller.ViewBag.執行時間 = exectuionTime;

            base.OnActionExecuted(filterContext);
        }
    }
}