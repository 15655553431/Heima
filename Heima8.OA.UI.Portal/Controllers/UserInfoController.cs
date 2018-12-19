using Heima8.OA.BLL;
using Heima8.OA.IBLL;
using Heima8.OA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Heima8.OA.UI.Portal.Controllers
{
    public class UserInfoController : Controller
    {
        //
        // GET: /UserInfo/
        //抽象工厂的方式
        //IUserInfoService userInfoService = StaticBllFactory.GetUserInfoService();
        
        
        //spring.net属性注入方式
        //public IUserInfoService userInfoService { get { return StaticBllFactory.GetUserInfoService(); } }

        //这里使用spring.net属性注入方式
        public IUserInfoService userInfoService { get; set; }

        public ActionResult Index(int pageIndex = 1, int pageSize = 3)
        {
            ViewData["pageIndex"] = pageIndex;
            ViewData["pageSize"] = pageSize;
            int count = userInfoService.GetEntities(u => true).Count();
            ViewData["total"] = count;
            ViewData.Model = userInfoService.GetPageEntities<int>(pageSize, pageIndex,out count,u => true,u=>u.ID,true);
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(UserInfo userInfo)
        {
            if (ModelState.IsValid)
            {
                userInfoService.Add(userInfo);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            ViewData.Model = userInfoService.GetEntities(u => u.ID == id).First();
            return View();
        }
        [HttpPost]
        public ActionResult Delete(UserInfo userinfo)
        {
            if (ModelState.IsValid)
            {
                userInfoService.Delete(userinfo);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            ViewData.Model = userInfoService.GetEntities(u => u.ID == id).First();
            return View();
        }


        public ActionResult Edit(int id)
        {
            ViewData.Model = userInfoService.GetEntities(u => u.ID == id).First();
            return View();
        }
        [HttpPost]
        public ActionResult Edit(UserInfo userinfo)
        {
            if (ModelState.IsValid)
            {
                userInfoService.Update(userinfo);
            }
            return RedirectToAction("Index");
        }


    }
}
