using MiniProjectMVC.CustFilter;
using MiniProjectMVC.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace MiniProjectMVC.Areas.UserArea.Controllers
{
    [UserAuth]
    public class BookController : Controller
    {
        MiniContext p = new MiniContext();
        // GET: UserArea/Book
        public ActionResult Index()

        {
            ViewBag.AuthorId = new SelectList(this.p.Authors.ToList(), "AuthorId", "AuthorName");
            ViewBag.SubjectId = new SelectList(this.p.Subjects.ToList(), "SubjectId", "SubjectName");
            return View(this.p.Books.ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.AuthorId = new SelectList(this.p.Authors.ToList(), "AuthorId", "AuthorName");
            ViewBag.SubjectId = new SelectList(this.p.Subjects.ToList(), "SubjectId", "SubjectName");
            return View();
        }
        [HttpPost]
        public ActionResult Create(Book rec)
        {
            ViewBag.AuthorId = new SelectList(this.p.Authors.ToList(), "AuthorId", "AuthorName");
            ViewBag.SubjectId = new SelectList(this.p.Subjects.ToList(), "SubjectId", "SubjectName");
            if (ModelState.IsValid)
            {
                this.p.Books.Add(rec);
                this.p.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rec);
        }
        [HttpGet]
        public ActionResult Edit(Int64? id)
        {
            ViewBag.AuthorId = new SelectList(this.p.Authors.ToList(), "AuthorId", "AuthorName");
            ViewBag.SubjectId = new SelectList(this.p.Subjects.ToList(), "SubjectId", "SubjectName");
            var rec = this.p.Books.SingleOrDefault(p => p.BookId == id);
             
            return View(rec);
        }
        [HttpPost]
        public ActionResult Edit(Book rec)
        {
            ViewBag.AuthorId=new SelectList(this.p.Authors.ToList(),"AuthorId","AuthorName");
            ViewBag.SubjectId = new SelectList(this.p.Subjects.ToList(), "SubjectId", "SubjectName");
            this.p.Entry(rec).State = System.Data.Entity.EntityState.Modified;
             
            this.p.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(Int64? id)
        {
            var rec = this.p.Books.Find(id);
            this.p.Books.Remove(rec);
            this.p.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Details(Int64? id)
        {
            var rec = this.p.Books.Find(id);
            return View(rec);
        }
    }
}