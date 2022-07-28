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
    [Table("HoaDonBanHang")]
    [Index(nameof(IdmaKh), Name = "IX_HoaDonBanHang_IDMaKH")]
    [Index(nameof(IdmaNv), Name = "IX_HoaDonBanHang_IDMaNV")]
    [Index(nameof(Idphong), Name = "IX_HoaDonBanHang_IDPhong")]
    public partial class HoaDonBanHang
    {
        public HoaDonBanHang()
        {
            ChiTietHoaDonBans = new HashSet<ChiTietHoaDonBan>();
        }

        [Key]
        [Column("IDHoaDon")]
        public int IdhoaDon { get; set; }
        [Column("IDMaKH")]
        [StringLength(30)]
        public string IdmaKh { get; set; }
        [Column("IDPhong")]
        public int? Idphong { get; set; }
        [Column("IDMaNV")]
        [StringLength(30)]
        public string IdmaNv { get; set; }
        [Column("IDCongThucTinh")]
        public int? IdcongThucTinh { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ThoiGianBatDau { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ThoiGianKetThuc { get; set; }
        public double? DonGiaPhong { get; set; }
        [StringLength(50)]
        public string NguoiBan { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? NgayTao { get; set; }
        [StringLength(50)]
        public string NguoiTao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? NgayCapNhap { get; set; }
        [StringLength(50)]
        public string NguoiCapNhap { get; set; }
        [Column("IDTranngThai")]
        public int? IdtranngThai { get; set; }

        [ForeignKey(nameof(IdcongThucTinh))]
        [InverseProperty(nameof(CongThucTinh.HoaDonBanHangs))]
        public virtual CongThucTinh IdcongThucTinhNavigation { get; set; }
        [ForeignKey(nameof(IdmaKh))]
        [InverseProperty(nameof(KhachHang.HoaDonBanHangs))]
        public virtual KhachHang IdmaKhNavigation { get; set; }
        [ForeignKey(nameof(IdmaNv))]
        [InverseProperty(nameof(NhanVien.HoaDonBanHangs))]
        public virtual NhanVien IdmaNvNavigation { get; set; }
        [ForeignKey(nameof(Idphong))]
        [InverseProperty(nameof(Phong.HoaDonBanHangs))]
        public virtual Phong IdphongNavigation { get; set; }
        [InverseProperty(nameof(ChiTietHoaDonBan.IdhoaDonNavigation))]
        public virtual ICollection<ChiTietHoaDonBan> ChiTietHoaDonBans { get; set; }
    }
}
