using DemoUI.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoUI.BLL
{
    class HocbongBLL
    {
        private GenericUnitOfWork unitOfWorkNV = new GenericUnitOfWork(MyDb.GetInstance());
       
        public void Add(HOCBONG entity)
        {

            unitOfWorkNV.Repository<HOCBONG>().Add(entity);
            unitOfWorkNV.SaveChanges();
        }

        public void Delete(HOCBONG entity)
        {
            unitOfWorkNV.Repository<HOCBONG>().Delete(entity);
            unitOfWorkNV.SaveChanges();
        }

        public void Edit(HOCBONG entity)
        {
            unitOfWorkNV.SaveChanges();
        }

        public HOCBONG Get(Func<HOCBONG, bool> predicate)
        {
            return unitOfWorkNV.Repository<HOCBONG>().Get(predicate);
        }

        public List<HOCBONG> GetAll(Func<HOCBONG, bool> predicate = null)
        {
            return unitOfWorkNV.Repository<HOCBONG>().GetAll(predicate);
        }

    }
}
