using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL.Entities
{
    [Table("LoaiThietBi")]
    public partial class LoaiThietBi
    {
        public LoaiThietBi()
        {
            ThietBis = new HashSet<ThietBi>();
        }

        [Key]
        [Column("MaLoaiTB")]
        [StringLength(30)]
        public string MaLoaiTb { get; set; }
        [StringLength(100)]
        public string TenLoai { get; set; }
        [StringLength(50)]
        public string XuatXu { get; set; }
        [Column("IDTranngThai")]
        [StringLength(10)]
        public string IdtranngThai { get; set; }

        [InverseProperty(nameof(ThietBi.IdmaLoaiTbNavigation))]
        public virtual ICollection<ThietBi> ThietBis { get; set; }
    }
}
