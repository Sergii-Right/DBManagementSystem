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
    public class DBasesController : Controller
    {
        private DBModel db = new DBModel();

        // GET: DBases
        public ActionResult Index()
        {
            return View(db.DBases.Include(i => i.DBTables).ToList());
        }

        public ActionResult _Table()
        {
            return PartialView(db.DBases.Include(i => i.DBTables).ToList());
        }

        // GET: DBases/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DBases dBases = db.DBases.Include(c => c.DBTables).FirstOrDefault(c => c.ID == id);
            if (dBases == null)
            {
                return HttpNotFound();
            }
            return View(dBases);
        }

        // GET: DBases/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DBases/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name")] DBases dBases)
        {
            if (ModelState.IsValid)
            {
                db.DBases.Add(dBases);
                db.SaveChanges();
                return PartialView("_Table", db.DBases.ToList());
            }

            return View(dBases);
        }

        // GET: DBases/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DBases dBases = db.DBases.Find(id);
            if (dBases == null)
            {
                return HttpNotFound();
            }
            return View(dBases);
        }

        // POST: DBases/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name")] DBases dBases)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dBases).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dBases);
        }

        // GET: DBases/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DBases dBases = db.DBases.Find(id);
            if (dBases == null)
            {
                return HttpNotFound();
            }
            return View(dBases);
        }

        // POST: DBases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DBases dBases = db.DBases.Find(id);
            db.DBases.Remove(dBases);
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
