using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL.Entities
{
    [Table("ChucVu")]
    public partial class ChucVu
    {
        public ChucVu()
        {
            NhanViens = new HashSet<NhanVien>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [StringLength(50)]
        public string TenChucVu { get; set; }
        [Column("IDTrangThai")]
        [StringLength(10)]
        public string IdtrangThai { get; set; }

        [InverseProperty(nameof(NhanVien.IdchucVuNavigation))]
        public virtual ICollection<NhanVien> NhanViens { get; set; }
    }
}
