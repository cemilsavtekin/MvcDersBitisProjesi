using EShop.Business;
using EShop.Client.Models.ViewModels;
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
        DBEntities dB = new DBEntities();
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

            List<ProductView> pw = new List<ProductView>();
            pw = (from u in dB.Urun
                  join k in dB.Kategori on u.KategoriID equals k.KategoriID
                  join r in dB.Resim on u.UrunID equals r.UrunID
                  select new ProductView()
                  {
                      UrunID = u.UrunID,
                      UrunAdi = u.UrunAdi,
                      UrunAciklamasi = u.UrunAciklamasi,
                      KategoriID = k.KategoriID,
                      KategoriAdi = k.KategoriAdi,
                      Fiyat = u.Fiyat,
                      ResimID = r.ResimID,
                      ResimUrl = r.ResimUrl
                  }).ToList();
            return View(pw);
        }

        public ActionResult ProductDetail(int? id)
        {
            ProductView pw = new ProductView();
            if (id != null)
            {

                pw = (from u in dB.Urun
                      join k in dB.Kategori on u.KategoriID equals k.KategoriID
                      join r in dB.Resim on u.UrunID equals r.UrunID
                      where u.UrunID == id
                      select new ProductView()
                      {
                          UrunID = u.UrunID,
                          UrunAdi = u.UrunAdi,
                          UrunAciklamasi = u.UrunAciklamasi,
                          KategoriID = k.KategoriID,
                          KategoriAdi = k.KategoriAdi,
                          Fiyat = u.Fiyat,
                          ResimID = r.ResimID,
                          ResimUrl = r.ResimUrl
                      }).FirstOrDefault();
            }
            return View(pw);
        }

        public JsonResult AddToCart(int urunID, int adet, string UserName)
        {
            Sepet sepet = null;
            SepetDetay sepetDetay = null;
            var kisiID = (from k in dB.Kisiler
                          join kul in dB.Kullanici on k.KisiID equals kul.KisiID
                          where kul.KullaniciAdi == UserName
                          select k.KisiID).FirstOrDefault();


            if (!string.IsNullOrEmpty(UserName))
            {
                sepet = (from k in dB.Kisiler
                         join s in dB.Sepet on k.KisiID equals s.KisiID
                         where s.OnayDurumu == false && k.KisiID==kisiID
                         select s).FirstOrDefault();
                if (sepet != null)
                {
                    sepetDetay = DBHelper<SepetDetay>.GetEntity(x => x.SepetID == sepet.SepetID && x.UrunID == urunID);
                    if (sepetDetay != null)
                    {
                        sepetDetay.Adet += adet;
                        DBHelper<SepetDetay> dbh=new DBHelper<SepetDetay>();
                        DBHelper<SepetDetay>.Update(sepetDetay);
                        DBHelper<SepetDetay>.Commit();
                    }
                    else
                    {
                        sepetDetay = new SepetDetay();
                        sepetDetay.SepetID = sepet.SepetID;
                        sepetDetay.UrunID = urunID;
                        sepetDetay.Adet = adet;

                        DBHelper<SepetDetay>.Insert(sepetDetay);
                        DBHelper<SepetDetay>.Commit();
                    }
                }
                else
                {
                    sepet = new Sepet();
                    sepet.KisiID = kisiID;
                    sepet.OnayDurumu = false;
                    DBHelper<Sepet>.Insert(sepet);
                    DBHelper<Sepet>.Commit();

                    sepetDetay = new SepetDetay();
                    sepetDetay.SepetID = sepet.SepetID;
                    sepetDetay.UrunID = urunID;
                    sepetDetay.Adet = adet;

                    DBHelper<SepetDetay>.Insert(sepetDetay);
                    DBHelper<SepetDetay>.Commit();
                }
            }
            var toplamAdet = DBHelper<SepetDetay>.GetList(s=>s.SepetID==sepet.SepetID).Sum(x => x.Adet);
            SepetView sw = (from s in DBHelper<Sepet>.GetList()
                            join sd in DBHelper<SepetDetay>.GetList() on s.SepetID equals sd.SepetID
                            where s.KisiID==kisiID && s.OnayDurumu==false
                            select new SepetView()
                            {
                                KisiID = kisiID,
                                SepetID = s.SepetID,
                                Adet = toplamAdet??0,
                                OnayDurumu = s.OnayDurumu ?? false
                            }).FirstOrDefault();

            return Json(new { data = sw }, JsonRequestBehavior.AllowGet);
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