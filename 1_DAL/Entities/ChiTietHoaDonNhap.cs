using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace _1_DAL.Entities
{
    [Table("ChiTietHoaDonNhap")]
    [Index(nameof(IdmatHang), Name = "IX_ChiTietHoaDonNhap_IDMatHang")]
    public partial class ChiTietHoaDonNhap
    {
        [Key]
        [Column("IDChiTietHoaDonNhap")]
        public int IdchiTietHoaDonNhap { get; set; }
        [Column("IDHoaDon")]
        public int IdhoaDon { get; set; }
        [Column("IDMatHang")]
        public int IdmatHang { get; set; }
        public int? SoLuong { get; set; }
        public double? DonGiaNhap { get; set; }
        [Column("IDTranngThai")]
        [StringLength(10)]
        public string IdtranngThai { get; set; }

        [ForeignKey(nameof(IdhoaDon))]
        [InverseProperty(nameof(HoaDonNhap.ChiTietHoaDonNhaps))]
        public virtual HoaDonNhap IdhoaDonNavigation { get; set; }
        [ForeignKey(nameof(IdmatHang))]
        [InverseProperty(nameof(MatHang.ChiTietHoaDonNhaps))]
        public virtual MatHang IdmatHangNavigation { get; set; }
    }
}
