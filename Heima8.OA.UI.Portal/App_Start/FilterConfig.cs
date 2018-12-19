using Heima8.OA.UI.Portal.Models;
using System.Web;
using System.Web.Mvc;

namespace Heima8.OA.UI.Portal
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //把原本的注释掉，加上自己写的日志信息
            //filters.Add(new HandleErrorAttribute());
            //使用拦截器做日志记录
            filters.Add(new MyExceptionFilterAttribut());

            //使用拦截器校验用户是否登录
            //用来做用户校验，放到了Models文件夹里
            filters.Add(new LoginCheckFilterAttribute() { IsCheck = true });

        }
    }
}