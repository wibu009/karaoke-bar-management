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
    [Table("ChiTietThietBi")]
    [Index(nameof(IdmaTb), Name = "IX_ChiTietThietBi_IDMaTB")]
    public partial class ChiTietThietBi
    {
        [Key]
        [Column("IDChiTietThietBi")]
        public int IdchiTietThietBi { get; set; }
        [Column("IDPhong")]
        public int Idphong { get; set; }
        [Required]
        [Column("IDMaTB")]
        [StringLength(30)]
        public string IdmaTb { get; set; }
        public double? DonGia { get; set; }
        public int? SoLuong { get; set; }
        [Column("IDTranngThai")]
        public int? IdtranngThai { get; set; }

        [ForeignKey(nameof(IdmaTb))]
        [InverseProperty(nameof(ThietBi.ChiTietThietBis))]
        public virtual ThietBi IdmaTbNavigation { get; set; }
        [ForeignKey(nameof(Idphong))]
        [InverseProperty(nameof(Phong.ChiTietThietBis))]
        public virtual Phong IdphongNavigation { get; set; }
    }
}
