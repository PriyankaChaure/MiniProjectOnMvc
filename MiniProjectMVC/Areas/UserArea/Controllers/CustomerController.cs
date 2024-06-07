using MiniProjectMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiniProjectMVC.Areas.UserArea.Controllers
{
    public class CustomerController : Controller
    {
        MiniContext p=new MiniContext();
        // GET: UserArea/Customer
        public ActionResult Index()
        {
            return View(this.p.Customers.ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Customer rec)
        {
          if(ModelState.IsValid)
            {
                this.p.Customers.Add(rec);
                this.p.SaveChanges();
                return RedirectToAction("Index");
            }
          return View(rec);
        }
        [HttpGet]
        public ActionResult Edit(Int64? id)
        {
            var rec = this.p.Customers.SingleOrDefault(p => p.CustomerId == id);

            return View(rec);
        }
        [HttpPost]
        public ActionResult Edit(Customer rec)
        {
            this.p.Entry(rec).State = System.Data.Entity.EntityState.Modified;

            this.p.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(Int64? id)
        {
            var rec = this.p.Customers.Find(id);
            this.p.Customers.Remove(rec);
            this.p.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Details(Int64? id)
        {
            var rec = this.p.Customers.Find(id);
            return View(rec);
        }
    }
}