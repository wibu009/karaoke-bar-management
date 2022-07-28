using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS.Model
{
    public class GoodPhong
    {
        public int Gio { get; set; }
        public int Phut { get; set; }
        public GoodPhong()
        {

        }
        public GoodPhong(double thoigian)
        {
            var tg = LayGio(thoigian);
            Gio = (int)tg;
            Phut = (int)((tg - Math.Truncate(tg)) * 60);
        }
        public double LayGio(double thoigian)
        {
            return Math.Round(thoigian, 1);
        }
        public override string ToString()
        {
            return string.Format("{0}:{1}", Gio, Phut);
        }
    }
}
