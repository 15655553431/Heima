using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Heima8.OA.UI.Portal.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        
        public ActionResult Index()
        {
            //当前页面校验用户是否登录,比较low的校验，过于重复。改用拦截器进行校验
            //if (Session["loginUser"] == null)
            //{
            //    return RedirectToAction("Index","UserLogin");
            //}
            
            return View();
        }

    }
}
