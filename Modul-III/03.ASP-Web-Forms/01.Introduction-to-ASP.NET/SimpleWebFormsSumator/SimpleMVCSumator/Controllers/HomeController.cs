using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleMVCSumator.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Index(int? sum)
        {
            this.ViewBag.Sum = sum;
            return this.View();
        }

        public ActionResult Sum(int sumA, int sumB)
        {
            return this.RedirectToAction("Index", new { sum = sumA + sumB });
        }
    }
}