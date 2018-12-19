
using Heima8.OA.Common;
using Heima8.OA.Common.Cache;
using Heima8.OA.IBLL;
using Heima8.OA.Model.Enum;
using Heima8.OA.UI.Portal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Heima8.OA.UI.Portal.Controllers
{
    [LoginCheckFilterAttribute(IsCheck=false)]
    public class UserLoginController : Controller
    {
        //如果你继承基类，又不需要校验，就可以这样操作
        //BaseController
        //public UserLoginController()
        //{
        //    this.IsCheckUserLogin = false;
        //}


        //
        // GET: /UserLogin/


        //使用抽象工厂
        //public IUserInfoService userInfoService { get { return StaticBllFactory.GetUserInfoService(); } }
        
        //这里使用spring.net属性注入方式
        public IUserInfoService userInfoService { get; set; }



        //如果需要让某个方法视图需要校验
        //[LoginCheckFilterAttribute(IsCheck=true)]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ShowVCode()
        {
            VCodeHelper validateCode = new VCodeHelper();
            string strCode = validateCode.RandomCode(4);

            //把验证码放到session中
            Session["VCode"] = strCode;

            byte[] imgBytes = validateCode.CreatVCodeImgs(strCode);

            return File(imgBytes,"image/jpeg");
        }

        /// <summary>
        /// 处理登录的表单
        /// </summary>
        /// <returns></returns>
        public ActionResult ProcessLogin()
        {

            //1 处理验证码

            string strCode = Request["vcode"];
            //拿到session中的验证码做对比
            string sessionCode = Session["VCode"] as string;

            //取过验证码，马上置空
            Session["VCode"] = null;

            if (string.IsNullOrEmpty(sessionCode) || strCode != sessionCode)
            {
               // "alert('ok！');", "text/javascript"
                return Json("验证码错误！");
            }
            

            //2 处理用户名和密码
            string name = Request["uname"];
            string pwd = Request["pwd"];
            short delNormal = (short)DelFlagEnum.Normal;

            var userinfo = userInfoService.GetEntities(u => u.UName == name && u.Pwd == pwd && u.DelFlag == delNormal).FirstOrDefault();

            if (userinfo == null)
            {
                return Json("用户名或密码错误!");
            }


            //登录成功，把用户信息放到session里
            //Session["loginUser"] = userinfo;

            //用memcached+cookie代替session

            //1,立即分配一个标志，guid，作为key存入mm，同时把这个key存入客户端cookie
            string userLoginId = Guid.NewGuid().ToString();

            //把用户数据写入缓存
            CacheHelper.AddCache(userLoginId, userinfo, DateTime.Now.AddMinutes(20));
             
            //往客户端写入cookie
            Response.Cookies["userLoginId"].Value = userLoginId;
           

            //正确跳转到首页

            return Json("ok");
        }
    }
}
