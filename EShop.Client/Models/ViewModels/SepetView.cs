using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EShop.Client.Models.ViewModels
{
    public class SepetView
    {
        public int SepetID { get; set; }
        public int KisiID { get; set; }
        public bool OnayDurumu { get; set; }
        public int Adet { get; set; }
    }
}