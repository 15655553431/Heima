using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Heima8.OA.Model;

namespace Heima8.OA.UI.Portal.Controllers
{
    public class UserInfoNewController : Controller
    {
        private DataModelContainer db = new DataModelContainer();

        //
        // GET: /UserInfoNew/

        public ActionResult Index()
        {
            return View(db.UserInfo.ToList());
        }

        //
        // GET: /UserInfoNew/Details/5

        public ActionResult Details(int id = 0)
        {
            UserInfo userinfo = db.UserInfo.Find(id);
            if (userinfo == null)
            {
                return HttpNotFound();
            }
            return View(userinfo);
        }

        //
        // GET: /UserInfoNew/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /UserInfoNew/Create

        [HttpPost]
        public ActionResult Create(UserInfo userinfo)
        {
            if (ModelState.IsValid)
            {
                db.UserInfo.Add(userinfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userinfo);
        }

        //
        // GET: /UserInfoNew/Edit/5

        public ActionResult Edit(int id = 0)
        {
            UserInfo userinfo = db.UserInfo.Find(id);
            if (userinfo == null)
            {
                return HttpNotFound();
            }
            return View(userinfo);
        }

        //
        // POST: /UserInfoNew/Edit/5

        [HttpPost]
        public ActionResult Edit(UserInfo userinfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userinfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userinfo);
        }

        //
        // GET: /UserInfoNew/Delete/5

        public ActionResult Delete(int id = 0)
        {
            UserInfo userinfo = db.UserInfo.Find(id);
            if (userinfo == null)
            {
                return HttpNotFound();
            }
            return View(userinfo);
        }

        //
        // POST: /UserInfoNew/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            UserInfo userinfo = db.UserInfo.Find(id);
            db.UserInfo.Remove(userinfo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}