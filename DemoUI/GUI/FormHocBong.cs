using DemoUI;
using DemoUI.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FormHocBong : Form
    {
        HocbongBLL hocbongBLL = new HocbongBLL();

        public FormHocBong()
        {
            InitializeComponent();
            LoadData();
            AddBinding();
            UserProfile.CurrentDGV = null;
            UserProfile.CurrentDGV = dtgvSV;
            UserProfile.CurrentForm = this;
        }

        void AddBinding()
        {
            txbID.DataBindings.Add(new Binding("Text", dtgvHB.DataSource, "Mahb", true, DataSourceUpdateMode.Never));
            txbName.DataBindings.Add(new Binding("Text", dtgvHB.DataSource, "Tenhb", true, DataSourceUpdateMode.Never));
            txbSoTien.DataBindings.Add(new Binding("Text", dtgvHB.DataSource, "Sotien", true, DataSourceUpdateMode.Never));
        }

        #region Methods
        void LoadData()
        {
            var result = MyDb.GetInstance().HOCBONGs.Select(a => new { a.Mahb, a.Tenhb, a.Sotien });

            dtgvHB.DataSource = result.ToList();

            dtgvHB.Columns[0].HeaderText = "Mã HB";
            dtgvHB.Columns[1].HeaderText = "Tên HB";
            dtgvHB.Columns[2].HeaderText = "Số tiền";
        }

        #endregion

        #region Events
        private void btnShow_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        #endregion

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dtgvData1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var DataJoin = from sv in MyDb.GetInstance().SINHVIENs
                           where sv.Mahb == txbID.Text
                           select new
                           {
                               sv.Mahb,
                               sv.Masv,
                               sv.Hoten,
                               sv.Gioitinh,
                               sv.Sdt
                           };
            dtgvSV.DataSource = DataJoin.ToList();
            dtgvSV.Columns[0].HeaderText = "Mã HB";
            dtgvSV.Columns[1].HeaderText = "Mã số SV";
            dtgvSV.Columns[2].HeaderText = "Họ Tên";
            dtgvSV.Columns[3].HeaderText = "Giới Tính";
            dtgvSV.Columns[4].HeaderText = "SĐT";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            HOCBONG hb = hocbongBLL.Get(i => i.Mahb == txbID.Text);
            if (hb == null)
            {
                hb = new HOCBONG() { Mahb = txbID.Text, Tenhb = txbName.Text, Sotien = Convert.ToDecimal(txbSoTien.Text) };

                hocbongBLL.Add(hb);
            }
            else
            {
                MessageBox.Show("Mã học bổng đã tồn tại");
            }

            LoadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            HOCBONG hb = hocbongBLL.Get(p => p.Mahb == txbID.Text);
            hocbongBLL.Delete(hb);

            LoadData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            HOCBONG hb = hocbongBLL.Get(p => p.Mahb == txbID.Text);
            hb.Sotien = Convert.ToDecimal(txbSoTien.Text);
            hb.Tenhb = txbName.Text;
            hocbongBLL.Edit(hb);

            LoadData();
        }
    }
}