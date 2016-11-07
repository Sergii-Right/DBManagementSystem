using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DBManagementSystem.Models;

namespace DBManagementSystem.Controllers
{
    public class DBRowsController : Controller
    {
        private DBModel db = new DBModel();

        // GET: DBRows
        public ActionResult Index()
        {
            return View(db.DBRows.ToList());
        }

        // GET: DBRows/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DBRow dBRow = db.DBRows.Find(id);
            if (dBRow == null)
            {
                return HttpNotFound();
            }
            return View(dBRow);
        }

        // GET: DBRows/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: DBRows/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Number,Content,DBRowID")] DBRow dBRow)
        {
            if (ModelState.IsValid)
            {
                db.DBRows.Add(dBRow);
                db.SaveChanges();
                return PartialView("_Table", db.DBRows.ToList());
            }

            return PartialView(dBRow);
        }

        // GET: DBRows/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DBRow dBRow = db.DBRows.Find(id);
            if (dBRow == null)
            {
                return HttpNotFound();
            }
            return View(dBRow);
        }

        // POST: DBRows/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Number,Content,DBRowID")] DBRow dBRow)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dBRow).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dBRow);
        }

        // GET: DBRows/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DBRow dBRow = db.DBRows.Find(id);
            if (dBRow == null)
            {
                return HttpNotFound();
            }
            return View(dBRow);
        }

        // POST: DBRows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DBRow dBRow = db.DBRows.Find(id);
            db.DBRows.Remove(dBRow);
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
