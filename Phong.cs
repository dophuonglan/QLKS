//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KS
{
    using System;
    using System.Collections.Generic;
    
    public partial class Phong
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Phong()
        {
            this.DatPhongs = new HashSet<DatPhong>();
        }
    
        public int MAPHONG { get; set; }
        public string TENPHONG { get; set; }
        public string TINHTRANGPHONG { get; set; }
        public Nullable<int> MALOAIPHONG { get; set; }
        public Nullable<double> GIAPHONG { get; set; }
        public string DONVITIENTE { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DatPhong> DatPhongs { get; set; }
        public virtual LoaiPhong LoaiPhong { get; set; }
    }
}