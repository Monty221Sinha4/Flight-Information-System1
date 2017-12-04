using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FlightProject2.Controllers.Home
{
    public class DepartureController : Controller
    {
        private FlightDB db = new FlightDB();
        // GET: Departure
        public ActionResult Departure(string searchBy, string search)
        {
            if (searchBy == "FlightNo")
            {
                return View(db.DepartureTables.Where(x => x.FlightNo == search || search == null).ToList());
            }
            else
            {
                return View(db.DepartureTables.Where(x => x.DepartureCity.Cities.StartsWith(search) || search == null).ToList());
            }
        }
        public ActionResult Flight_Details(int? id)
        {
            DepartureTable departureTable = db.DepartureTables.Find(id);
            if (departureTable == null)
            {
                return HttpNotFound();
            }
            return View(departureTable);
        }
    }
}