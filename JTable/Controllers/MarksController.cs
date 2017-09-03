using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JTable.DataAccess;
using JTable.Models;

namespace JTable.Controllers
{
    public class MarksController : Controller
    {
        private MarksEntities db = new MarksEntities();

        // GET: Marks
        public ActionResult Index()
        {
            return View(db.Marks.ToList());
        }

        // GET: Marks/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mark marks = db.Marks.Find(id);
            if (marks == null)
            {
                return HttpNotFound();
            }
            return View(marks);
        }

        // GET: Marks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Marks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,RollNumber,Name,MarksObtained,TotalMarks")] Mark marks)
        {
            if (ModelState.IsValid)
            {
                db.Marks.Add(marks);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(marks);
        }

        // GET: Marks/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mark marks = db.Marks.Find(id);
            if (marks == null)
            {
                return HttpNotFound();
            }
            return View(marks);
        }

        // POST: Marks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,RollNumber,Name,MarksObtained,TotalMarks")] Mark marks)
        {
            if (ModelState.IsValid)
            {
                db.Entry(marks).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(marks);
        }

        // GET: Marks/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mark marks = db.Marks.Find(id);
            if (marks == null)
            {
                return HttpNotFound();
            }
            return View(marks);
        }

        // POST: Marks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Mark marks = db.Marks.Find(id);
            db.Marks.Remove(marks);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
