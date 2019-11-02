using EShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace EShop.Client.Controllers
{
    public class SecurityController : Controller
    {
        // GET: Security

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignIn(Kullanici kullanici)
        {
            var db = new DBEntities();

            var userInDb = db.Kullanici.FirstOrDefault(x => x.KullaniciAdi == kullanici.KullaniciAdi && x.Sifre == kullanici.Sifre);

            if (userInDb != null)
            {
                FormsAuthentication.SetAuthCookie(kullanici.KullaniciAdi, false);
                return RedirectToAction("Index", "Home");
            }

            return new HttpUnauthorizedResult();
        }
    }
}