using Heima8.OA.Common.Cache;
using Heima8.OA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Heima8.OA.UI.Portal.Controllers
{
    public class BaseController : Controller
    {
        //这个当其他类继承这个基类，就可以完成验证，
        //如果你继承基类，又不需要校验，就可以这样操作
        //BaseController
        //public UserLoginController()
        //{
        //    this.IsCheckUserLogin = false;
        //}
        public bool IsCheckUserLogin = true;

        public UserInfo LoginUser { get; set; }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            if (IsCheckUserLogin)
            {
                //如果没有记录的id，直接跳转到登陆界面
                if (filterContext.HttpContext.Request.Cookies["userLoginId"] == null)
                {
                    filterContext.HttpContext.Response.Redirect("/UserLogin/Index");
                    return;
                }

                //从缓存里面拿到userLoginId信息
                string userLoginId = filterContext.HttpContext.Request.Cookies["userLoginId"].Value.ToString();

                UserInfo userInfo = CacheHelper.GetCache(userLoginId) as UserInfo;

                if (userInfo == null)
                {
                    //用户长时间不操作，超时了
                    filterContext.HttpContext.Response.Redirect("/UserLogin/Index");
                    return;
                }
                else
                {
                    LoginUser = userInfo;
                    //滑动窗口机制（就是延长缓存时间,重新延长20分钟）
                    CacheHelper.SetCache(userLoginId, userLoginId,DateTime.Now.AddMinutes(20));
                }
            }

        }
    }
}