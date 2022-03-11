using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ApiCrud.Models;

namespace ApiCrud.Controllers
{
    public class Emp1Controller : Controller
    {
        private CurdApiEntities1 db = new CurdApiEntities1();

        // GET: Emp1
        public ActionResult Index()
        {
            return View(db.Emp1.ToList());
        }

        // GET: Emp1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emp1 emp1 = db.Emp1.Find(id);
            if (emp1 == null)
            {
                return HttpNotFound();
            }
            return View(emp1);
        }

        // GET: Emp1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Emp1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmpID,EmpName,EmpSal,EmpCity")] Emp1 emp1)
        {
            if (ModelState.IsValid)
            {
                db.Emp1.Add(emp1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(emp1);
        }

        // GET: Emp1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emp1 emp1 = db.Emp1.Find(id);
            if (emp1 == null)
            {
                return HttpNotFound();
            }
            return View(emp1);
        }

        // POST: Emp1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmpID,EmpName,EmpSal,EmpCity")] Emp1 emp1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(emp1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(emp1);
        }

        // GET: Emp1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emp1 emp1 = db.Emp1.Find(id);
            if (emp1 == null)
            {
                return HttpNotFound();
            }
            return View(emp1);
        }

        // POST: Emp1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Emp1 emp1 = db.Emp1.Find(id);
            db.Emp1.Remove(emp1);
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
