using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL.Entities
{
    [Table("CongThucTinh")]
    public partial class CongThucTinh
    {
        public CongThucTinh()
        {
            HoaDonBanHangs = new HashSet<HoaDonBanHang>();
        }

        [Key]
        [Column("IDCongThucTinh")]
        public int IdcongThucTinh { get; set; }
        public double? UuDai1 { get; set; }
        public double? UuDai2 { get; set; }
        public double? UuDai3 { get; set; }
        public double? ThoiGianNhanUuDai1 { get; set; }
        public double? ThoiGianNhanUuDai2 { get; set; }
        public double? ThoiGianNhanUuDai3 { get; set; }
        public string GhiChu { get; set; }
        public double? GiaPhong { get; set; }
        public double? GiaPhongVIP { get; set; }
        public int? IdtrangThai { get; set; }

        [InverseProperty(nameof(HoaDonBanHang.IdcongThucTinhNavigation))]
        public virtual ICollection<HoaDonBanHang> HoaDonBanHangs { get; set; }
    }
}
