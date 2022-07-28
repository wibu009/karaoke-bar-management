using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL.Entities
{
    [Table("DonViTinh")]
    public partial class DonViTinh
    {
        public DonViTinh()
        {
            MatHangs = new HashSet<MatHang>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("TenDVT")]
        [StringLength(50)]
        public string TenDvt { get; set; }
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

        [InverseProperty(nameof(MatHang.IddonViTinhNavigation))]
        public virtual ICollection<MatHang> MatHangs { get; set; }
    }
}
