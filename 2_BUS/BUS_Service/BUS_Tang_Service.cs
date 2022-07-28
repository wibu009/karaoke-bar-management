using _1_DAL.DAL_Service;
using _1_DAL.Entities;
using _1_DAL.IDAL_Service;
using _2_BUS.IBUS_Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS.BUS_Service
{
    public class BUS_Tang_Service : IBUS_Tang_Service
    {
        private IDAL_Tang_Service _iDAL_Tang_Service;
        public BUS_Tang_Service()
        {
            _iDAL_Tang_Service = new DAL_Tang_Service();
        }
        public bool Add(Tang Tang)
        {
            return _iDAL_Tang_Service.Add(Tang);
        }

        public List<Tang> Find(int id)
        {
            return _iDAL_Tang_Service.Find(id);
        }

        public List<Tang> FindName(string name)
        {
             return _iDAL_Tang_Service.FindName(name);
        }

        public void GetlstTang()
        {
            _iDAL_Tang_Service.GetlstTang();
        }

        public bool Remove(int idTang)
        {
            return _iDAL_Tang_Service.Remove(idTang);
        }

        public bool Save()
        {
            return _iDAL_Tang_Service.Save();
        }

        public List<Tang> sendlstTang()
        {
            return _iDAL_Tang_Service.sendlstTang();
        }

        public bool Update(Tang Tang)
        {
            return _iDAL_Tang_Service.Update(Tang);
        }
    }
}
