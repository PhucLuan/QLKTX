using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoUI
{
    public partial class FormThongKe : Form
    {
        DEMOQLKTXEntities db = MyDb.GetInstance();
        public FormThongKe()
        {
            InitializeComponent();
            UserProfile.CurrentForm = this;
        }

        private void FormThongKe_Load(object sender, EventArgs e)
        {
            btnPhong.Text = "               " + CountPhong()  + " phòng còn chỗ";

            
            btnPhiKTX.Text = "              " + CountSV() + " sinh viên chưa đóng Phí KTX";

            btnHDDiennuoc.Text = "         " + CountDienNuoc(DateTime.Now.Month) + " phòng chưa đóng Điện-Nước Tháng " + DateTime.Now.Month.ToString();
        }

        #region Count
        string CountPhong()
        {
            
            var results = (from phong in db.PHONGs
                           where phong.ConTrong <= phong.Sluongsv
                           select phong).Count();
            return results.ToString();
        }

        string CountSV()
        {
            var results = (from sv in db.SINHVIENs
                           where !db.PHIKTXes.Any(phi => phi.Masv == sv.Masv)
                           select sv).Count();
            return results.ToString();
        }

        string CountDienNuoc(int thang)
        {
            
            var results = (from phong in db.PHONGs
                           where !db.HOADONDIENNUOCs.Any(hd => hd.Sophong == phong.Sophong
                           & hd.Sophong == thang.ToString())
                           select phong).Count();
            return results.ToString();
        }
        #endregion

        #region Button
        private void btnPhong_Click(object sender, EventArgs e)
        {
            FormThongKe_Phong f = new FormThongKe_Phong();
            f.ShowDialog();
        }

        private void btnPhiKTX_Click(object sender, EventArgs e)
        {
            FormThongKe_PhiKTX f = new FormThongKe_PhiKTX();
            f.ShowDialog();
        }

        private void btnHDDiennuoc_Click(object sender, EventArgs e)
        {
            FormThongKe_HDDienNuoc f = new FormThongKe_HDDienNuoc();
            f.ShowDialog();
        }
        #endregion
    }
}
