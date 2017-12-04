using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FlightProject2.Controllers.Home
{
    public class FlightInformationController : Controller
    {
        private FlightDB db = new FlightDB();
        // GET: FlightInformation
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Departure(string searchBy, string search)
        {
            if (searchBy == "FlightNo")
            {
                return View(db.DepartureTables.Where(x => x.FlightNo == search||search==null).ToList());
            }
            else
            {
                return View(db.DepartureTables.Where(x => x.DepartureCity.Cities .StartsWith(search)||search==null).ToList());
            }

           
        }
        public ActionResult FlightDetails_Departure(int? id)
        {
            DepartureTable departureTable = db.DepartureTables.Find(id);
            if (departureTable == null)
            {
                return HttpNotFound();
            }
            return View(departureTable);
        }
        public ActionResult Arrivals(string searchBy,string search)
        {
            if (searchBy == "FlightNo")
            {
                return View(db.ArrivalsTimeTables.Where(x => x.FlightNo == search||search==null).ToList());
            }
            else
            {
                return View(db.ArrivalsTimeTables.Where(x => x.City.Cities.StartsWith(search)||search==null).ToList());
            }
            
          
            
        }
        public ActionResult FlightDetails_Arrivals(int? id)
        {
            ArrivalsTimeTable arrivalsTable = db.ArrivalsTimeTables.Find(id);
            if (arrivalsTable == null)
            {
                return HttpNotFound();
            }
            return View(arrivalsTable);
        }
    }
}