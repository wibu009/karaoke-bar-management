using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL.Entities
{
    [Table("Tang")]
    public partial class Tang
    {
        public Tang()
        {
            Phongs = new HashSet<Phong>();
        }

        [Key]
        [Column("IDTang")]
        public int Idtang { get; set; }
        [StringLength(40)]
        public string TenTang { get; set; }
        public int? SoLuongPhong { get; set; }
        [Column("IDTrangThai")]
        public int? IdtrangThai { get; set; }

        [InverseProperty(nameof(Phong.IdtangNavigation))]
        public virtual ICollection<Phong> Phongs { get; set; }
    }
}
