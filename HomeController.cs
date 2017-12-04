using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FlightProject2;

namespace FlightProject2.Controllers.Home
{
    public class HomeController : Controller
    {

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ContactUs()
        {
            return View();
        }
        public ActionResult FoodCourt()
        {
            return View();
        }
        public ActionResult Customs()
        {
            return View();
        }
        public ActionResult Hotels()
        {
            return View();
        }
    }
}