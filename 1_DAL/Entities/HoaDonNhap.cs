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
    [Table("HoaDonNhap")]
    [Index(nameof(IdnhaCc), Name = "IX_HoaDonNhap_IDNhaCC")]
    [Index(nameof(IdnhanVienNhap), Name = "IX_HoaDonNhap_IDNhanVienNhap")]
    public partial class HoaDonNhap
    {
        public HoaDonNhap()
        {
            ChiTietHoaDonNhaps = new HashSet<ChiTietHoaDonNhap>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [Column("IDNhanVienNhap")]
        [StringLength(30)]
        public string IdnhanVienNhap { get; set; }
        [Column("IDNhaCC")]
        public int? IdnhaCc { get; set; }
        [Required]
        [StringLength(10)]
        public string NgayNhap { get; set; }
        public double? TienThanhToan { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime NgayTao { get; set; }
        [StringLength(50)]
        public string NguoiTao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? NgayCapNhap { get; set; }
        [StringLength(50)]
        public string NguoiCapNhap { get; set; }
        [Column("IDTranngThai")]
        [StringLength(10)]
        public string IdtranngThai { get; set; }

        [ForeignKey(nameof(IdnhaCc))]
        [InverseProperty(nameof(NhaCungCap.HoaDonNhaps))]
        public virtual NhaCungCap IdnhaCcNavigation { get; set; }
        [ForeignKey(nameof(IdnhanVienNhap))]
        [InverseProperty(nameof(NhanVien.HoaDonNhaps))]
        public virtual NhanVien IdnhanVienNhapNavigation { get; set; }
        [InverseProperty(nameof(ChiTietHoaDonNhap.IdhoaDonNavigation))]
        public virtual ICollection<ChiTietHoaDonNhap> ChiTietHoaDonNhaps { get; set; }
    }
}
