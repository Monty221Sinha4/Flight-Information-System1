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
    public class DepartureCitiesController : Controller
    {
        private FlightDB db = new FlightDB();

        // GET: DepartureCities
        public ActionResult Index()
        {
            return View(db.DepartureCities.ToList());
        }

        // GET: DepartureCities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepartureCity departureCity = db.DepartureCities.Find(id);
            if (departureCity == null)
            {
                return HttpNotFound();
            }
            return View(departureCity);
        }

        // GET: DepartureCities/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DepartureCities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CityID,Cities")] DepartureCity departureCity)
        {
            if (ModelState.IsValid)
            {
                db.DepartureCities.Add(departureCity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(departureCity);
        }

        // GET: DepartureCities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepartureCity departureCity = db.DepartureCities.Find(id);
            if (departureCity == null)
            {
                return HttpNotFound();
            }
            return View(departureCity);
        }

        // POST: DepartureCities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CityID,Cities")] DepartureCity departureCity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(departureCity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(departureCity);
        }

        // GET: DepartureCities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepartureCity departureCity = db.DepartureCities.Find(id);
            if (departureCity == null)
            {
                return HttpNotFound();
            }
            return View(departureCity);
        }

        // POST: DepartureCities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DepartureCity departureCity = db.DepartureCities.Find(id);
            db.DepartureCities.Remove(departureCity);
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
