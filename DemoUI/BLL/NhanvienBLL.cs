using DemoUI.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp3;

namespace DemoUI.BLL
{
    class NhanvienBLL
    {
        private GenericUnitOfWork unitOfWorkNV = new GenericUnitOfWork(MyDb.GetInstance());

        public void Add(NHANVIEN entity)
        {

            unitOfWorkNV.Repository<NHANVIEN>().Add(entity);
            unitOfWorkNV.SaveChanges();
        }

        public void Delete(NHANVIEN entity)
        {
            unitOfWorkNV.Repository<NHANVIEN>().Delete(entity);
            unitOfWorkNV.SaveChanges();
        }

        public void Edit(NHANVIEN entity)
        {
            unitOfWorkNV.SaveChanges();
        }

        public NHANVIEN Get(Func<NHANVIEN, bool> predicate)
        {
            return unitOfWorkNV.Repository<NHANVIEN>().Get(predicate);
        }

        public List<NHANVIEN> GetAll(Func<NHANVIEN, bool> predicate = null)
        {
            return unitOfWorkNV.Repository<NHANVIEN>().GetAll(predicate);
        }

        public IEnumerable<NHANVIEN> Search(string keyvalue)
        {
            return unitOfWorkNV.Repository<NHANVIEN>().GetAll(x => x.Hoten.Contains(keyvalue));
        }
    }
}
