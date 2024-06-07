using MiniProjectMVC.CustFilter;
using MiniProjectMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiniProjectMVC.Areas.UserArea.Controllers
{
    [UserAuth]
    public class AuthorController : Controller
    {
        MiniContext p=new MiniContext();
        // GET: UserArea/Author
        public ActionResult Index()
        {
            return View(this.p.Authors.ToList());
        }
        
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Author rec)
        {
            if (ModelState.IsValid)
            {
                this.p.Authors.Add(rec);
                this.p.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rec);
        }
        [HttpGet]
        public ActionResult Edit(Int64? id)
        {
            var rec = this.p.Authors.SingleOrDefault(p => p.AuthorId== id);
             
            return View(rec);
        }
        [HttpPost]
        public ActionResult Edit(Author rec)
        {
            this.p.Entry(rec).State = System.Data.Entity.EntityState.Modified;
             
            this.p.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(Int64? id)
        {
            var rec = this.p.Authors.Find(id);
            this.p.Authors.Remove(rec);
            this.p.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Details(Int64? id)
        {
            var rec = this.p.Authors.Find(id);
            return View(rec);
        }
    }
}