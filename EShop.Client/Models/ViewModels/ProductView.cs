using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EShop.Client.Models.ViewModels
{
    public class ProductView
    {
        public int UrunID { get; set; }
        [Display(Name ="Ürün Adı")]
        public string UrunAdi { get; set; }
        [Display(Name ="Açıklama")]
        public string UrunAciklamasi { get; set; }
        public decimal? Fiyat { get; set; }
        public int KategoriID { get; set; }
        [Display(Name ="Kategori")]
        public string KategoriAdi { get; set; }
        public int ResimID { get; set; }
        [Display(Name ="Resim")]
        public string ResimUrl { get; set; }
    }
}