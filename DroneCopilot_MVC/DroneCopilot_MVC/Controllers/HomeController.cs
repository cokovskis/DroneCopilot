using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DroneCopilotServices;

namespace DroneCopilot_MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult Settings()
        {
            //ViewBag.Message = "Settings";
            WeatherData x = new WeatherData();
            ViewBag.Message = x.receiveData();

            return View();
        }

        public ActionResult Data()
        {
            ViewBag.Message = "Numeric view";

            return View();
        }
    }
}