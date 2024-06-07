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
    public class SalesController : Controller
    {
        MiniContext p=new MiniContext();
        // GET: UserArea/Sales
        public ActionResult Index()
        {
             
            ViewBag .CustomerId = new SelectList(this.p.Customers.ToList(), " CustomerId ", "CustomerName");
            ViewBag.BookId = new SelectList(this.p.Books.ToList(), "BookId", "BookName");
            var v = this.p.Sales.ToList();
            return View(v.ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.CustomerId = new SelectList(this.p.Customers.ToList(), " CustomerId ", "CustomerName");
            ViewBag.BookId=new SelectList(this.p.Books.ToList(),"BookId","BookName");
            return View();
        }
        [HttpPost]
        public ActionResult Create(custsalVM rec)
        { 

            if (ModelState.IsValid)
            {
                Sales s = new Sales();
                rec.SalesDate = DateTime.Now;
                s.SalesDate = rec.SalesDate;
                s.CustomerId= rec.CustomerId;
                s.BookId = rec.BookId;
                s.Qty= rec.Qty;
                s.Price= rec.Price;
                this.p.Sales.Add(s);

                Customer c= new Customer();
                c.CustomerName= rec.CustomerName;
                c.CustomerAddress= rec.CustomerAddress;
                c.CustomerEmail= rec.CustomerEmail;
                c.CustomerPhone= rec.CustomerPhone;
                this.p.Customers.Add(c);
                this.p.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(rec);
        }
        [HttpGet]
        public ActionResult Edit(Int64? id)
        {
            var rec = (from t1 in this.p.Sales
                       join t2 in this.p.Customers
                       on t1.CustomerId equals t2.CustomerId
                       join t3 in this.p.Books
                       on  t1.BookId equals t3.BookId
                       where t1.SalesId == id

                       select new custsalVM
                       {
                           SalesId = t1.SalesId,
                           //SalesDate = t1.SalesDate,
                           CustomerId = t2.CustomerId,
                           CustomerName = t2.CustomerName,                                                                                                                                                                                              
                           CustomerAddress = t2.CustomerAddress,
                           CustomerEmail = t2.CustomerEmail,
                           CustomerPhone = t2.CustomerPhone,
                           BookId = t1.BookId,
                           BookName=t3.BookName,
                           Qty = t1.Qty,
                           Price = t1.Price,
                       }).FirstOrDefault();

            ViewBag.BookId = new SelectList(this.p.Books.ToList(), "BookId", "BookName",rec.BookId);
            ViewBag.CustomerId = new SelectList(this.p.Customers.ToList(), " CustomerId ", "CustomerName",rec.CustomerId);
            
            return View(rec);
        }
        [HttpPost]
        public ActionResult Edit(custsalVM rec)
        {
            //this.p.Entry(rec).State = System.Data.Entity.EntityState.Modified;
            
            if (ModelState.IsValid)
            {
                Sales s = this.p.Sales.Find(rec.SalesId);
                rec.SalesDate = DateTime.Now;
                s.SalesDate = rec.SalesDate;
                s.CustomerId = rec.CustomerId;
                s.BookId = rec.BookId;
                s.Qty = rec.Qty;
                s.Price = rec.Price;
               

                Customer c = this.p.Customers.Find(rec.CustomerId);
                c.CustomerName = rec.CustomerName;
                c.CustomerAddress = rec.CustomerAddress;
                c.CustomerEmail = rec.CustomerEmail;
                c.CustomerPhone = rec.CustomerPhone;

                Book b = this.p.Books.Find(rec.BookId);
                b.BookId = rec.BookId;
                b.BookName = rec.BookName;
               
            }
            ViewBag.BookId = new SelectList(this.p.Books.ToList(), "BookId", "BooKName", rec.BookId);
            ViewBag.CustomerId = new SelectList(this.p.Customers.ToList(), " CustomerId ", "CustomerName", rec.CustomerId);
            this.p.SaveChanges();
            return RedirectToAction("Index");


        }
        [HttpGet]
        public ActionResult Delete(Int64? id)
        {
            var rec = this.p.Sales.Find(id);
            this.p.Sales.Remove(rec);
            this.p.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Details(Int64? id)
        {
            var rec = this.p.Sales.Find(id);
            return View(rec);
        }
    }
}