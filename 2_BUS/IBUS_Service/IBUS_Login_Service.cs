using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS.IBUS_Service
{
    public interface IBUS_Login_Service
    {
        public bool NhanVienLogin(string email, string pass);
        public string MaHoaPass(string passwword);
    }
}
