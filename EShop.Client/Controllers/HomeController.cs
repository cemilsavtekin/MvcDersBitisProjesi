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
      
        public ActionResult Index()
        {
          
            return View();
        }
       
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Shop()
        {
            return View();
        }

        public ActionResult ProductDetail(int? id)
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult Cart()
        {
            return View();
        }
    }
}