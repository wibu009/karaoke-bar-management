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
    [Table("ChiTietHoaDonBan")]
    [Index(nameof(IdmatHang), Name = "IX_ChiTietHoaDonBan_IDMatHang")]
    public partial class ChiTietHoaDonBan
    {
        [Key]
        [Column("IDChiTietHoaDonBan")]
        public int IdchiTietHoaDonBan { get; set; }
        [Column("IDHoaDon")]
        public int IdhoaDon { get; set; }
        [Column("IDMatHang")]
        public int IdmatHang { get; set; }
        [Column("IDUsername")]
        [StringLength(30)]
        public string Idusername { get; set; }
        public int? SoLuong { get; set; }
        public double? DonGia { get; set; }
        [Column("IDTranngThai")]
        [StringLength(10)]
        public string IdtranngThai { get; set; }

        [ForeignKey(nameof(IdhoaDon))]
        [InverseProperty(nameof(HoaDonBanHang.ChiTietHoaDonBans))]
        public virtual HoaDonBanHang IdhoaDonNavigation { get; set; }
        [ForeignKey(nameof(IdmatHang))]
        [InverseProperty(nameof(MatHang.ChiTietHoaDonBans))]
        public virtual MatHang IdmatHangNavigation { get; set; }
    }
}
