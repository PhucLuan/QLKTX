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
    public partial class FormThongKe_PhiKTX : Form
    {
        DEMOQLKTXEntities db = MyDb.GetInstance();
        public FormThongKe_PhiKTX()
        {
            InitializeComponent();
        }

        int k;
        private void FormThongKe_PhiKTX_Load(object sender, EventArgs e)
        {
            if (Convert.ToInt32(DateTime.Now.Month) <= 6) k = 1;
            else k = 2;
            LoadSV(k);
            //cbbPhi.Text = k.ToString();
        }

        void LoadSV(int ki)
        {
            var results = from sv in db.SINHVIENs
                          where !db.PHIKTXes.Any(phi => phi.Masv == sv.Masv)
                          select new {sv.Masv, sv.Hoten, sv.Gioitinh, sv.Ngaysinh, sv.Sdt, sv.Diachithuongtru};
            dgv.DataSource = results.ToList();

            //Cách đổ dữ liệu lên DataGridView Rọn ràng
            for (int i = 0; i <= dgv.Columns.Count - 1; i++)
            {
                if (i < dgv.Columns.Count - 1)
                    dgv.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                else
                    dgv.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            //Header
            dgv.Columns[0].HeaderText = "MSSV";
            dgv.Columns[1].HeaderText = "Họ tên";
            dgv.Columns[2].HeaderText = "Giới tính";
            dgv.Columns[3].HeaderText = "Ngày sinh";
            dgv.Columns[4].HeaderText = "Điện Thoại";
            dgv.Columns[5].HeaderText = "Địa chỉ";
        }

        private void cbbPhi_SelectedIndexChanged(object sender, EventArgs e)
        {
            //LoadSV(Convert.ToInt32(cbbPhi.Text));
        }
    }
}
