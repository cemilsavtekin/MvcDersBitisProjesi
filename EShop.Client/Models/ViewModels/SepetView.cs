using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EShop.Client.Models.ViewModels
{
    public class SepetView
    {
        public int ResimID { get; set; }
        public string ResimUrl { get; set; }
        public int UrunID { get; set; }
        public int SepetDetayID { get; set; }
        public int SepetID { get; set; }
        public string UrunAdi { get; set; }
        public decimal Fiyat { get; set; }
        public decimal ToplamFiyat { get; set; }
        public int KisiID { get; set; }
        public bool OnayDurumu { get; set; }
        public int Adet { get; set; }
    }
}