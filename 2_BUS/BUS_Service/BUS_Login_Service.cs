using _1_DAL.DAL_Service;
using _1_DAL.IDAL_Service;
using _2_BUS.IBUS_Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS.BUS_Service
{
    public class BUS_Login_Service: IBUS_Login_Service
    {
        private IDAL_NhanVien_Service _idal_NhanVien_Service;
        public BUS_Login_Service()
        {
            _idal_NhanVien_Service = new DAL_NhanVien_Service();
        }

        public string MaHoaPass(string passwword)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] encrypt;
            UTF8Encoding encode = new UTF8Encoding();
            encrypt = md5.ComputeHash(encode.GetBytes(passwword));
            StringBuilder encryptdata = new StringBuilder();
            for (int i = 0; i < encrypt.Length; i++)
            {
                encryptdata.Append(encrypt[i].ToString());
            }
            return encryptdata.ToString();
        }

        public bool NhanVienLogin(string email, string pass)
        {
            foreach (var x in _idal_NhanVien_Service.GetlstNhanViens().Where(c=>c.Username == email 
                                                                            && c.Password == pass))
            {
                return true;
            }
            return false;
        }
    }
}
