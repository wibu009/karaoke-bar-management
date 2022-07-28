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
    [Table("MatHang")]
    [Index(nameof(IddonViTinh), Name = "IX_MatHang_IDDonViTinh")]
    public partial class MatHang
    {
        public MatHang()
        {
            ChiTietHoaDonBans = new HashSet<ChiTietHoaDonBan>();
            ChiTietHoaDonNhaps = new HashSet<ChiTietHoaDonNhap>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string TenMatHang { get; set; }
        [Column("IDDonViTinh")]
        public int? IddonViTinh { get; set; }
        public int? SoLuong { get; set; }
        public double DonGia { get; set; }
        [StringLength(50)]
        public string NguoiTao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? NgayTao { get; set; }
        [StringLength(50)]
        public string NguoiCapNhap { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? NgayCapNhap { get; set; }
        [Column("IDTranngThai")]
        public int? IdtranngThai { get; set; }

        [ForeignKey(nameof(IddonViTinh))]
        [InverseProperty(nameof(DonViTinh.MatHangs))]
        public virtual DonViTinh IddonViTinhNavigation { get; set; }
        [InverseProperty(nameof(ChiTietHoaDonBan.IdmatHangNavigation))]
        public virtual ICollection<ChiTietHoaDonBan> ChiTietHoaDonBans { get; set; }
        [InverseProperty(nameof(ChiTietHoaDonNhap.IdmatHangNavigation))]
        public virtual ICollection<ChiTietHoaDonNhap> ChiTietHoaDonNhaps { get; set; }
    }
}
