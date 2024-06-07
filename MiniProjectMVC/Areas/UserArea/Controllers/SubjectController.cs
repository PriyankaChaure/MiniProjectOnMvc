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
    public class SubjectController : Controller
    {
        MiniContext p=new MiniContext();
        // GET: UserArea/Subject
        public ActionResult Index()
        {
            var v = this.p.Subjects.ToList();
            return View(v);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Subject rec)
        {
            if (ModelState.IsValid)
            {
                this.p.Subjects.Add(rec);
                this.p.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rec);
        }
        [HttpGet]
        public ActionResult Edit(Int64? id)
        {
            var rec = this.p.Subjects.SingleOrDefault(p => p.SubjectId == id);
            
            return View(rec);
        }
        [HttpPost]
        public ActionResult Edit(Subject rec)
        {
            this.p.Entry(rec).State = System.Data.Entity.EntityState.Modified;
             
            this.p.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(Int64? id)
        {
            var rec = this.p.Subjects.Find(id);
            this.p.Subjects.Remove(rec);
            this.p.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Details(Int64? id)
        {
            var rec = this.p.Subjects.Find(id);
            return View(rec);
        }
    }
}