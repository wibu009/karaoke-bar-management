using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1_DAL.DBContext;
using _1_DAL.Entities;
using _1_DAL.IDAL_Service;
using Microsoft.EntityFrameworkCore;

namespace _1_DAL.DAL_Service
{
    public class DAL_DonViTinh_Service:IDAL_DonViTinh_Service
    {
        private DatabaseContext db;
        private List<DonViTinh> DvTinh;
        public DAL_DonViTinh_Service()
        {
            db = new DatabaseContext();
            DvTinh = new List<DonViTinh>();
            GetlstDvTinh();
        }

        private void GetlstDvTinh()
        {
            DvTinh = db.DonViTinhs.ToList();
        }

        public List<DonViTinh> sendlstDvTinh()
        {
            return DvTinh;
        }

        public bool AddDVT(DonViTinh dvt)
        {
            db.DonViTinhs.Add(dvt);
            DvTinh.Add(dvt);
            db.SaveChanges();
            return true;
        }
        public bool EditDVT(DonViTinh dvt)
        {
            db.DonViTinhs.Update(dvt);
            DvTinh[DvTinh.FindIndex(x=>x.Id == dvt.Id)] = dvt;
            db.SaveChanges();
            return true;
        }
        public bool RemoveDVT(DonViTinh dvt)
        {
            db.DonViTinhs.Remove(dvt);
            DvTinh.Remove(dvt);
            db.SaveChanges();
            return true;
        }
    }
}
