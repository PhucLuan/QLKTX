using DemoUI.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoUI.BLL
{
    class DtutBLL
    {
        private GenericUnitOfWork unitOfWork = new GenericUnitOfWork(MyDb.GetInstance());

        public void Add(DOITUONGUUTIEN entity)
        {
            if (entity.MaDTUT != null || unitOfWork.Repository<DOITUONGUUTIEN>().Get(x => x.MaDTUT == entity.MaDTUT) == null)
            {
                unitOfWork.Repository<DOITUONGUUTIEN>().Add(entity);
                unitOfWork.SaveChanges();
            }
            else
                MessageBox.Show("Đối tượng ưu tiên đã tồn tại");
        }

        public void Delete(DOITUONGUUTIEN entity)
        {
            unitOfWork.Repository<DOITUONGUUTIEN>().Delete(entity);
            unitOfWork.SaveChanges();
        }

        public void Edit(DOITUONGUUTIEN entity)
        {
            unitOfWork.SaveChanges();
        }

        public DOITUONGUUTIEN Get(Func<DOITUONGUUTIEN, bool> predicate)
        {
            return unitOfWork.Repository<DOITUONGUUTIEN>().Get(predicate);
        }

        public List<DOITUONGUUTIEN> GetAll(Func<DOITUONGUUTIEN, bool> predicate = null)
        {
            return unitOfWork.Repository<DOITUONGUUTIEN>().GetAll(predicate);
        }

    }
}
