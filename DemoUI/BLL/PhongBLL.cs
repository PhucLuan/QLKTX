using DemoUI.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoUI.BLL
{
    class PhongBLL
    {
        private GenericUnitOfWork unitOfWork = new GenericUnitOfWork(MyDb.GetInstance());

        public void Add(PHONG entity)
        {
            if (entity.Sophong != null || unitOfWork.Repository<PHONG>().Get(x => x.Sophong == entity.Sophong) == null)
            {
                unitOfWork.Repository<PHONG>().Add(entity);
                unitOfWork.SaveChanges();
            }
            else
                MessageBox.Show("Phòng đã tồn tại");
        }

        public void Delete(PHONG entity)
        {
            unitOfWork.Repository<PHONG>().Delete(entity);
            unitOfWork.SaveChanges();
        }

        public void Edit(PHONG entity)
        {
            unitOfWork.SaveChanges();
        }

        public PHONG Get(Func<PHONG, bool> predicate)
        {
            return unitOfWork.Repository<PHONG>().Get(predicate);
        }

        public List<PHONG> GetAll(Func<PHONG, bool> predicate = null)
        {
            return unitOfWork.Repository<PHONG>().GetAll(predicate);
        }

        public IEnumerable<PHONG> Search(string keyvalue)
        {
            return unitOfWork.Repository<PHONG>().GetAll(x => x.Sophong.Contains(keyvalue));
        }
    }
}
