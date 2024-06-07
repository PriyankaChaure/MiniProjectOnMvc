using MiniProjectMVC.Models;
using MiniProjectMVC.Models.LoginVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiniProjectMVC.Controllers
{
    public class ManageUserController : Controller
    {
         MiniContext p=new MiniContext();

        [HttpGet]
        public ActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignIn(UserLoginVM rec)
        {
            if (ModelState.IsValid)
            {
                var userrec = this.p.Admins.SingleOrDefault(p => p.UserName == rec.UserName && p.Password == rec.Password);
                if (userrec != null)
                {
                    Session["AdminId"] = userrec.AdminId;
                    Session["UserName"] = userrec.FristName;
                    return RedirectToAction("Index", "UserAreaHome", new {area="UserArea"});
                }
                ModelState.AddModelError("", "Invalid EmailId & Password");
                return View(rec);
            }
            return View(rec);
        }
        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(Admin rec)
        {
            if (ModelState.IsValid)
            {
                this.p.Admins.Add(rec);
                this.p.SaveChanges();
                return RedirectToAction("SignIn");

            }
            return View(rec);
        }
        public ActionResult LogOut()
        {
            Session.Clear();
            Session.Abandon();
            return View();
        }
    }
}