using GentrificationCalc.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GentrificationCalc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            var repo = new CalcRepository();
            int myCount = repo.GetDemographicDataCount();
            return View();
        }
    }
}
