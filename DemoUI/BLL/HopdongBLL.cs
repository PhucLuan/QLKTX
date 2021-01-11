using DemoUI.DAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoUI.BLL
{
    class HopdongBLL
    {
        private GenericUnitOfWork unitOfWorkNV = new GenericUnitOfWork(MyDb.GetInstance());

        public void Add(HOPDONG entity)
        {

            unitOfWorkNV.Repository<HOPDONG>().Add(entity);
            unitOfWorkNV.SaveChanges();
        }

        public void Delete(HOPDONG entity)
        {
            unitOfWorkNV.Repository<HOPDONG>().Delete(entity);
            unitOfWorkNV.SaveChanges();
        }

        public void Edit(HOPDONG entity)
        {
            unitOfWorkNV.SaveChanges();
        }

        public HOPDONG Get(Func<HOPDONG, bool> predicate)
        {
            return unitOfWorkNV.Repository<HOPDONG>().Get(predicate);
        }

        public List<HOPDONG> GetAll(Func<HOPDONG, bool> predicate = null)
        {
            return unitOfWorkNV.Repository<HOPDONG>().GetAll(predicate);
        }
    }
}
