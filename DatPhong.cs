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
    
    public partial class DatPhong
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DatPhong()
        {
            this.ChiTietHoaDons = new HashSet<ChiTietHoaDon>();
            this.DatDichVus = new HashSet<DatDichVu>();
        }
    
        public int MADATPHONG { get; set; }
        public Nullable<int> MAPHONG { get; set; }
        public Nullable<int> MAKH { get; set; }
        public Nullable<double> TRATRUOC { get; set; }
        public Nullable<System.DateTime> NGAYO { get; set; }
        public Nullable<System.DateTime> NGAYDI { get; set; }
        public string TrangThaiThanhToan { get; set; }
        public Nullable<double> GiaPhongHienTai { get; set; }
        public Nullable<bool> isDelete { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DatDichVu> DatDichVus { get; set; }
        public virtual KhachHang KhachHang { get; set; }
        public virtual Phong Phong { get; set; }
    }
}