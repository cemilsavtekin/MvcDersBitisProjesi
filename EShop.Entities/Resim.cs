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
    
    public partial class Resim
    {
        public int ResimID { get; set; }
        public string ResimUrl { get; set; }
        public Nullable<int> UrunID { get; set; }
    
        public virtual Urun Urun { get; set; }
    }
}
