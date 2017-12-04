using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FlightProject2;

namespace FlightProject2.Controllers
{
    public class ArrivalsTimeTablesController : Controller
    {
        private FlightDB db = new FlightDB();

        // GET: ArrivalsTimeTables
        public ActionResult Index()
        {
            var arrivalsTimeTables = db.ArrivalsTimeTables.Include(a => a.Airlines_Arrivals).Include(a => a.City).Include(a => a.StatusReportArrival).Include(a => a.Terminals_Arrivals);
            return View(arrivalsTimeTables.ToList());
        }

        // GET: ArrivalsTimeTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArrivalsTimeTable arrivalsTimeTable = db.ArrivalsTimeTables.Find(id);
            if (arrivalsTimeTable == null)
            {
                return HttpNotFound();
            }
            return View(arrivalsTimeTable);
        }

        // GET: ArrivalsTimeTables/Create
        public ActionResult Create()
        {
            ViewBag.FlightID = new SelectList(db.Airlines_Arrivals, "FlightID", "Flight");
            ViewBag.CityID = new SelectList(db.Cities, "CityID", "Cities");
            ViewBag.StatusID = new SelectList(db.StatusReportArrivals, "StatusID", "Status");
            ViewBag.Terminal_ID = new SelectList(db.Terminals_Arrivals, "Terminal_ID", "Terminals");
            return View();
        }

        // POST: ArrivalsTimeTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FlightNo,FlightID,CityID,Scheduled,StatusID,ArrivalTime,Terminal_ID")] ArrivalsTimeTable arrivalsTimeTable)
        {
            if (ModelState.IsValid)
            {
                db.ArrivalsTimeTables.Add(arrivalsTimeTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FlightID = new SelectList(db.Airlines_Arrivals, "FlightID", "Flight", arrivalsTimeTable.FlightID);
            ViewBag.CityID = new SelectList(db.Cities, "CityID", "Cities", arrivalsTimeTable.CityID);
            ViewBag.StatusID = new SelectList(db.StatusReportArrivals, "StatusID", "Status", arrivalsTimeTable.StatusID);
            ViewBag.Terminal_ID = new SelectList(db.Terminals_Arrivals, "Terminal_ID", "Terminals", arrivalsTimeTable.Terminal_ID);
            return View(arrivalsTimeTable);
        }

        // GET: ArrivalsTimeTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArrivalsTimeTable arrivalsTimeTable = db.ArrivalsTimeTables.Find(id);
            if (arrivalsTimeTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.FlightID = new SelectList(db.Airlines_Arrivals, "FlightID", "Flight", arrivalsTimeTable.FlightID);
            ViewBag.CityID = new SelectList(db.Cities, "CityID", "Cities", arrivalsTimeTable.CityID);
            ViewBag.StatusID = new SelectList(db.StatusReportArrivals, "StatusID", "Status", arrivalsTimeTable.StatusID);
            ViewBag.Terminal_ID = new SelectList(db.Terminals_Arrivals, "Terminal_ID", "Terminals", arrivalsTimeTable.Terminal_ID);
            return View(arrivalsTimeTable);
        }

        // POST: ArrivalsTimeTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FlightNo,FlightID,CityID,Scheduled,StatusID,ArrivalTime,Terminal_ID")] ArrivalsTimeTable arrivalsTimeTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(arrivalsTimeTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FlightID = new SelectList(db.Airlines_Arrivals, "FlightID", "Flight", arrivalsTimeTable.FlightID);
            ViewBag.CityID = new SelectList(db.Cities, "CityID", "Cities", arrivalsTimeTable.CityID);
            ViewBag.StatusID = new SelectList(db.StatusReportArrivals, "StatusID", "Status", arrivalsTimeTable.StatusID);
            ViewBag.Terminal_ID = new SelectList(db.Terminals_Arrivals, "Terminal_ID", "Terminals", arrivalsTimeTable.Terminal_ID);
            return View(arrivalsTimeTable);
        }

        // GET: ArrivalsTimeTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArrivalsTimeTable arrivalsTimeTable = db.ArrivalsTimeTables.Find(id);
            if (arrivalsTimeTable == null)
            {
                return HttpNotFound();
            }
            return View(arrivalsTimeTable);
        }

        // POST: ArrivalsTimeTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ArrivalsTimeTable arrivalsTimeTable = db.ArrivalsTimeTables.Find(id);
            db.ArrivalsTimeTables.Remove(arrivalsTimeTable);
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
