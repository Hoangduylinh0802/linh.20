//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QLPHANMEM.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class HoSo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HoSo()
        {
            this.ViPhams = new HashSet<ViPham>();
        }
    
        public string MSHS { get; set; }
        public string MSNV { get; set; }
        public string TENHS { get; set; }
        public string NgayLapHS { get; set; }
        public decimal SLHS { get; set; }
    
        public virtual NhanVien NhanVien { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ViPham> ViPhams { get; set; }
    }
}