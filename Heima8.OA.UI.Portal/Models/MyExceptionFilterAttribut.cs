using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Heima8.OA.UI.Portal.Models
{
    public class MyExceptionFilterAttribut : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);

            //接下来就需要自己处理异常


            //直接把错误信息写到日志文件里面。（会出现问题：多个异常出现，都在同时写日志文件，导致错误）
            //解决方案： 搞个错误消息队列，先把错误信息存到队列，再把队列信息依次写入日志

            //写记录日志，直接调用
            Common.LogHelper.WriteLog(filterContext.Exception.ToString());
        }
    }
}