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
    [Table("ThietBi")]
    [Index(nameof(IdmaLoaiTb), Name = "IX_ThietBi_IDMaLoaiTB")]
    public partial class ThietBi
    {
        public ThietBi()
        {
            ChiTietThietBis = new HashSet<ChiTietThietBi>();
        }

        [Key]
        [Column("MaTB")]
        [StringLength(30)]
        public string MaTb { get; set; }
        [Column("IDMaLoaiTB")]
        [StringLength(30)]
        public string IdmaLoaiTb { get; set; }
        [Column("TenTB")]
        [StringLength(100)]
        public string TenTb { get; set; }
        public double? DonGia { get; set; }
        public int? SoLuong { get; set; }
        public int? TinhTrang { get; set; }
        [Column("IDTranngThai")]
        [StringLength(10)]
        public string IdtranngThai { get; set; }

        [ForeignKey(nameof(IdmaLoaiTb))]
        [InverseProperty(nameof(LoaiThietBi.ThietBis))]
        public virtual LoaiThietBi IdmaLoaiTbNavigation { get; set; }
        [InverseProperty(nameof(ChiTietThietBi.IdmaTbNavigation))]
        public virtual ICollection<ChiTietThietBi> ChiTietThietBis { get; set; }
    }
}
