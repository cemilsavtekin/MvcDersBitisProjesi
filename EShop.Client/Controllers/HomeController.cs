using EShop.Business;
using EShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EShop.Client.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [Authorize(Roles ="Admin,User")]
        public ActionResult Index()
        {
          
            return View();
        }
        [Authorize(Roles ="User")]
        public ActionResult About()
        {
            return View();
        }
    }
}