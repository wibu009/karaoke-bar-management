using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL.Entities
{
    [Table("KhachHang")]
    public partial class KhachHang
    {
        public KhachHang()
        {
            HoaDonBanHangs = new HashSet<HoaDonBanHang>();
        }

        [Key]
        [Column("MaKH")]
        [StringLength(30)]
        public string MaKh { get; set; }
        [StringLength(50)]
        public string Ho { get; set; }
        [StringLength(50)]
        public string TenDem { get; set; }
        [StringLength(50)]
        public string Ten { get; set; }
        public int? GioiTinh { get; set; }
        [StringLength(12)]
        public string DienThoai { get; set; }
        [Column("IDTranngThai")]
        public int? IdtranngThai { get; set; }

        [InverseProperty(nameof(HoaDonBanHang.IdmaKhNavigation))]
        public virtual ICollection<HoaDonBanHang> HoaDonBanHangs { get; set; }
    }
}
