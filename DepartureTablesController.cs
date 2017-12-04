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
    public class DepartureTablesController : Controller
    {
        private FlightDB db = new FlightDB();

        // GET: DepartureTables
        public ActionResult Index()
        {
            var departureTables = db.DepartureTables.Include(d => d.Airline).Include(d => d.DepartureCity).Include(d => d.StatusReport).Include(d => d.TerminalLookUp);
            return View(departureTables.ToList());
        }

        // GET: DepartureTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepartureTable departureTable = db.DepartureTables.Find(id);
            if (departureTable == null)
            {
                return HttpNotFound();
            }
            return View(departureTable);
        }

        // GET: DepartureTables/Create
        public ActionResult Create()
        {
            ViewBag.FlightID = new SelectList(db.Airlines, "FlightID", "Flight");
            ViewBag.CityID = new SelectList(db.DepartureCities, "CityID", "Cities");
            ViewBag.StatusID = new SelectList(db.StatusReports, "StatusID", "Status");
            ViewBag.Terminal_ID = new SelectList(db.TerminalLookUps, "Terminal_ID", "Terminal");
            return View();
        }

        // POST: DepartureTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,FlightNo,FlightID,CityID,Scheduled,StatusID,DepartureTime,Terminal_ID")] DepartureTable departureTable)
        {
            if (ModelState.IsValid)
            {
                db.DepartureTables.Add(departureTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FlightID = new SelectList(db.Airlines, "FlightID", "Flight", departureTable.FlightID);
            ViewBag.CityID = new SelectList(db.DepartureCities, "CityID", "Cities", departureTable.CityID);
            ViewBag.StatusID = new SelectList(db.StatusReports, "StatusID", "Status", departureTable.StatusID);
            ViewBag.Terminal_ID = new SelectList(db.TerminalLookUps, "Terminal_ID", "Terminal", departureTable.Terminal_ID);
            return View(departureTable);
        }

        // GET: DepartureTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepartureTable departureTable = db.DepartureTables.Find(id);
            if (departureTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.FlightID = new SelectList(db.Airlines, "FlightID", "Flight", departureTable.FlightID);
            ViewBag.CityID = new SelectList(db.DepartureCities, "CityID", "Cities", departureTable.CityID);
            ViewBag.StatusID = new SelectList(db.StatusReports, "StatusID", "Status", departureTable.StatusID);
            ViewBag.Terminal_ID = new SelectList(db.TerminalLookUps, "Terminal_ID", "Terminal", departureTable.Terminal_ID);
            return View(departureTable);
        }

        // POST: DepartureTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,FlightNo,FlightID,CityID,Scheduled,StatusID,DepartureTime,Terminal_ID")] DepartureTable departureTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(departureTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FlightID = new SelectList(db.Airlines, "FlightID", "Flight", departureTable.FlightID);
            ViewBag.CityID = new SelectList(db.DepartureCities, "CityID", "Cities", departureTable.CityID);
            ViewBag.StatusID = new SelectList(db.StatusReports, "StatusID", "Status", departureTable.StatusID);
            ViewBag.Terminal_ID = new SelectList(db.TerminalLookUps, "Terminal_ID", "Terminal", departureTable.Terminal_ID);
            return View(departureTable);
        }

        // GET: DepartureTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepartureTable departureTable = db.DepartureTables.Find(id);
            if (departureTable == null)
            {
                return HttpNotFound();
            }
            return View(departureTable);
        }

        // POST: DepartureTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DepartureTable departureTable = db.DepartureTables.Find(id);
            db.DepartureTables.Remove(departureTable);
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
