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
    [Table("NhanVien")]
    [Index(nameof(IdchucVu), Name = "IX_NhanVien_IDChucVu")]
    public partial class NhanVien
    {
        public NhanVien()
        {
            HoaDonBanHangs = new HashSet<HoaDonBanHang>();
            HoaDonNhaps = new HashSet<HoaDonNhap>();
        }

        [Key]
        [Column("MaNV")]
        [StringLength(30)]
        public string MaNv { get; set; }
        [StringLength(30)]
        public string Username { get; set; }
        public string Password { get; set; }
        [Column("IDChucVu")]
        public int? IdchucVu { get; set; }
        [StringLength(20)]
        public string Ho { get; set; }
        [StringLength(20)]
        public string TenDem { get; set; }
        [StringLength(20)]
        public string Ten { get; set; }
        public int? GioiTinh { get; set; }
        [StringLength(20)]
        public string DienThoai { get; set; }
        [Column("CMND")]
        [StringLength(50)]
        public string Cmnd { get; set; }
        [StringLength(150)]
        public string DiaChi { get; set; }
        [Column("IDTranngThai")]
        public int? IdtranngThai { get; set; }

        [ForeignKey(nameof(IdchucVu))]
        [InverseProperty(nameof(ChucVu.NhanViens))]
        public virtual ChucVu IdchucVuNavigation { get; set; }
        [InverseProperty(nameof(HoaDonBanHang.IdmaNvNavigation))]
        public virtual ICollection<HoaDonBanHang> HoaDonBanHangs { get; set; }
        [InverseProperty(nameof(HoaDonNhap.IdnhanVienNhapNavigation))]
        public virtual ICollection<HoaDonNhap> HoaDonNhaps { get; set; }
    }
}
