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
    [Table("Phong")]
    [Index(nameof(IdloaiPhong), Name = "IX_Phong_IDLoaiPhong")]
    public partial class Phong
    {
        public Phong()
        {
            ChiTietThietBis = new HashSet<ChiTietThietBi>();
            HoaDonBanHangs = new HashSet<HoaDonBanHang>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("IDTang")]
        public int? Idtang { get; set; }
        [Column("IDLoaiPhong")]
        public int? IdloaiPhong { get; set; }
        [Required]
        [StringLength(100)]
        public string TenPhong { get; set; }
        public byte? TrangThai { get; set; }
        public int? SucChua { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? NgayTao { get; set; }
        [StringLength(50)]
        public string NguoiTao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? NgayCapNhap { get; set; }
        [StringLength(50)]
        public string NguoiCapNhap { get; set; }
        [Column("IDTranngThai")]
        [StringLength(10)]
        public string IdtranngThai { get; set; }

        [ForeignKey(nameof(IdloaiPhong))]
        [InverseProperty(nameof(LoaiPhong.Phongs))]
        public virtual LoaiPhong IdloaiPhongNavigation { get; set; }
        [ForeignKey(nameof(Idtang))]
        [InverseProperty(nameof(Tang.Phongs))]
        public virtual Tang IdtangNavigation { get; set; }
        [InverseProperty(nameof(ChiTietThietBi.IdphongNavigation))]
        public virtual ICollection<ChiTietThietBi> ChiTietThietBis { get; set; }
        [InverseProperty(nameof(HoaDonBanHang.IdphongNavigation))]
        public virtual ICollection<HoaDonBanHang> HoaDonBanHangs { get; set; }
    }
}
