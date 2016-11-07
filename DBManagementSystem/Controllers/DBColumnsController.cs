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
    public class DBColumnsController : Controller
    {
        private DBModel db = new DBModel();

        // GET: DBColumns
        public ActionResult Index()
        {
            return View(db.DbColumns.ToList());
        }

        // GET: DBColumns/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DBColumn dBColumn = db.DbColumns.Find(id);
            if (dBColumn == null)
            {
                return HttpNotFound();
            }
            return View(dBColumn);
        }

        // GET: DBColumns/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DBColumns/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name")] DBColumn dBColumn)
        {
            if (ModelState.IsValid)
            {
                db.DbColumns.Add(dBColumn);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dBColumn);
        }

        // GET: DBColumns/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DBColumn dBColumn = db.DbColumns.Find(id);
            if (dBColumn == null)
            {
                return HttpNotFound();
            }
            return View(dBColumn);
        }

        // POST: DBColumns/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name")] DBColumn dBColumn)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dBColumn).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dBColumn);
        }

        // GET: DBColumns/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DBColumn dBColumn = db.DbColumns.Find(id);
            if (dBColumn == null)
            {
                return HttpNotFound();
            }
            return View(dBColumn);
        }

        // POST: DBColumns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DBColumn dBColumn = db.DbColumns.Find(id);
            db.DbColumns.Remove(dBColumn);
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
