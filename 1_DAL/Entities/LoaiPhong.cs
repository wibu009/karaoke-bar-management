using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL.Entities
{
    [Table("LoaiPhong")]
    public partial class LoaiPhong
    {
        public LoaiPhong()
        {
            Phongs = new HashSet<Phong>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string TenLoaiPhong { get; set; }
        public double? DonGia { get; set; }
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

        [InverseProperty(nameof(Phong.IdloaiPhongNavigation))]
        public virtual ICollection<Phong> Phongs { get; set; }
    }
}
