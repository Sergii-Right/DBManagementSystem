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
    public class DBTablesController : Controller
    {
        private DBModel db = new DBModel();

        // GET: DBTables
        public ActionResult Index()
        {
            var dBTables = db.DBTables.Include(d => d.DBases);
            return View(dBTables.ToList());
        }

        // GET: DBTables/Details/5
        public ActionResult Details(int id)
        {
            DBTable dBTable = db.DBTables.Include(c => c.DBColumns).FirstOrDefault(c => c.ID == id);
            if (dBTable == null)
            {
                return HttpNotFound();
            }
            return View(dBTable);
        }

        // GET: DBTables/Create
        public ActionResult Create(int dbID)
        {
            var dbTable = new DBTable();
            dbTable.DBasesID = dbID;
            return PartialView(dbTable);
        }

        // POST: DBTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,DBasesID")] DBTable dBTable)
        {
            if (ModelState.IsValid)
            {
                db.DBTables.Add(dBTable);
                db.SaveChanges();
                return RedirectToAction("Details", "DBases", new { id = dBTable.DBasesID });
            }

            ViewBag.DBasesID = new SelectList(db.DBases, "ID", "Name", dBTable.DBasesID);
            return View(dBTable);
        }

        // GET: DBTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DBTable dBTable = db.DBTables.Find(id);
            if (dBTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.DBasesID = new SelectList(db.DBases, "ID", "Name", dBTable.DBasesID);
            return View(dBTable);
        }

        // POST: DBTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,DBasesID")] DBTable dBTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dBTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DBasesID = new SelectList(db.DBases, "ID", "Name", dBTable.DBasesID);
            return View(dBTable);
        }

        // GET: DBTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DBTable dBTable = db.DBTables.Find(id);
            if (dBTable == null)
            {
                return HttpNotFound();
            }
            return View(dBTable);
        }

        // POST: DBTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DBTable dBTable = db.DBTables.Find(id);
            db.DBTables.Remove(dBTable);
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
