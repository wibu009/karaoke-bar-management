using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL.Entities
{
    [Table("NhaCungCap")]
    public partial class NhaCungCap
    {
        public NhaCungCap()
        {
            HoaDonNhaps = new HashSet<HoaDonNhap>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [Column("TenNCC")]
        [StringLength(150)]
        public string TenNcc { get; set; }
        [StringLength(20)]
        public string DienThoai { get; set; }
        [StringLength(150)]
        public string DiaChi { get; set; }
        [StringLength(150)]
        public string Email { get; set; }
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

        [InverseProperty(nameof(HoaDonNhap.IdnhaCcNavigation))]
        public virtual ICollection<HoaDonNhap> HoaDonNhaps { get; set; }
    }
}
