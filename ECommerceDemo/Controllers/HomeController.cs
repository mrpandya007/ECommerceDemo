using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerceDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult Product()
        {
            ViewBag.Title = "Product List";

            return View();
        }

        public ActionResult ProductCreate()
        {
            return View();
        }
    }
}
