//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EShop.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Siparis
    {
        public int SiparisID { get; set; }
        public Nullable<int> SepetID { get; set; }
        public Nullable<System.DateTime> SiparisTarihi { get; set; }
        public Nullable<System.DateTime> TeslimTarihi { get; set; }
        public Nullable<bool> TeslimDurumu { get; set; }
    
        public virtual Sepet Sepet { get; set; }
    }
}
