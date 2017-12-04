using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FlightProject2;

namespace FlightProject2.Controllers.Admin
{
    public class Airlines_ArrivalsController : Controller
    {
        private FlightDB db = new FlightDB();

        // GET: Airlines_Arrivals
        public ActionResult Index()
        {
            return View(db.Airlines_Arrivals.ToList());
        }

        // GET: Airlines_Arrivals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Airlines_Arrivals airlines_Arrivals = db.Airlines_Arrivals.Find(id);
            if (airlines_Arrivals == null)
            {
                return HttpNotFound();
            }
            return View(airlines_Arrivals);
        }

        // GET: Airlines_Arrivals/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Airlines_Arrivals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FlightID,Flight")] Airlines_Arrivals airlines_Arrivals)
        {
            if (ModelState.IsValid)
            {
                db.Airlines_Arrivals.Add(airlines_Arrivals);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(airlines_Arrivals);
        }

        // GET: Airlines_Arrivals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Airlines_Arrivals airlines_Arrivals = db.Airlines_Arrivals.Find(id);
            if (airlines_Arrivals == null)
            {
                return HttpNotFound();
            }
            return View(airlines_Arrivals);
        }

        // POST: Airlines_Arrivals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FlightID,Flight")] Airlines_Arrivals airlines_Arrivals)
        {
            if (ModelState.IsValid)
            {
                db.Entry(airlines_Arrivals).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(airlines_Arrivals);
        }

        // GET: Airlines_Arrivals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Airlines_Arrivals airlines_Arrivals = db.Airlines_Arrivals.Find(id);
            if (airlines_Arrivals == null)
            {
                return HttpNotFound();
            }
            return View(airlines_Arrivals);
        }

        // POST: Airlines_Arrivals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Airlines_Arrivals airlines_Arrivals = db.Airlines_Arrivals.Find(id);
            db.Airlines_Arrivals.Remove(airlines_Arrivals);
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
