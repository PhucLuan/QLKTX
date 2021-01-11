using DemoUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rpt_Receipt_KTX
{
    public partial class FormPhiKTX : Form
    {
        DEMOQLKTXEntities db = MyDb.GetInstance();
        public FormPhiKTX()
        {
            InitializeComponent();
            UserProfile.CurrentDGV = null;
            UserProfile.CurrentDGV = dgvPhi;
            UserProfile.CurrentForm = this;
        }

        private void FormPhiKTX_Load(object sender, EventArgs e)
        { 
            LoadPhiKTX();
        }

        void LoadPhiKTX()
        {
            var result = from ph in db.PHIKTXes
                         join sv in db.SINHVIENs on ph.Masv equals sv.Masv
                         select new 
                         { 
                             ph.Mabienlai, 
                             sv.Masv, 
                             sv.Hoten, 
                             ph.Namhoc, 
                             ph.Ngaythu, 
                             ph.Sophong, 
                             ph.Sothang, 
                             ph.Sotien 
                         };
            dgvPhi.DataSource = null;
            dgvPhi.DataSource = result.ToList();

            //Cách đổ dữ liệu lên DataGridView Rọn ràng
            for (int i = 0; i <= dgvPhi.Columns.Count - 1; i++)
            {
                if (i < dgvPhi.Columns.Count - 1)
                    dgvPhi.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                else
                    dgvPhi.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            //Header
            dgvPhi.Columns[0].HeaderText = "Mã Biên lai";
            dgvPhi.Columns[1].HeaderText = "Mã Sinh viên";
            dgvPhi.Columns[2].HeaderText = "Họ Tên";
            dgvPhi.Columns[3].HeaderText = "Năm học";
            dgvPhi.Columns[4].HeaderText = "Ngày thu";
            dgvPhi.Columns[5].HeaderText = "Phòng";
            dgvPhi.Columns[6].HeaderText = "Số tháng";
            dgvPhi.Columns[7].HeaderText = "Tiền phòng";
        }

        private void dgv_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtMaBL.Text = dgvPhi.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtMaSV.Text = dgvPhi.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtTenSV.Text = dgvPhi.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtNamHoc.Text = dgvPhi.Rows[e.RowIndex].Cells[3].Value.ToString();
            dtpNgayThu.Text = dgvPhi.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtSoPhong.Text = dgvPhi.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtSoThang.Text = dgvPhi.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtSoTien.Text = dgvPhi.Rows[e.RowIndex].Cells[7].Value.ToString();
        }

        #region Button
        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            PHIKTX ph = new PHIKTX();
            ph.Mabienlai = txtMaBL.Text;
            ph.Ngaythu = dtpNgayThu.Value;
            ph.Sothang = Convert.ToInt32(txtSoThang.Text);
            ph.Namhoc = Convert.ToInt16(txtNamHoc.Text);
            ph.Sophong = txtSoPhong.Text;
            ph.Sotien = Convert.ToDecimal(txtSoTien.Text);
            ph.Masv = txtMaSV.Text;
            db.PHIKTXes.Add(ph);
            db.SaveChanges();
            LoadPhiKTX();
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            PHIKTX ph = (from p in db.PHIKTXes
                         where p.Mabienlai == txtMaBL.Text.Trim()
                         select p).Single<PHIKTX>();
            ph.Ngaythu = dtpNgayThu.Value;
            ph.Sothang = Convert.ToInt32(txtSoThang.Text);
            ph.Namhoc = Convert.ToInt16(txtNamHoc.Text);
            ph.Sophong = txtSoPhong.Text;
            ph.Sotien = Convert.ToDecimal(txtSoTien.Text);
            ph.Masv = txtMaSV.Text;
            db.SaveChanges();
            LoadPhiKTX();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            PHIKTX ph = (from p in db.PHIKTXes
                         where p.Mabienlai == txtMaBL.Text.Trim()
                         select p).Single<PHIKTX>();
            db.PHIKTXes.Remove(ph);
            db.SaveChanges();
            LoadPhiKTX();
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            PHIKTX BienLai = db.PHIKTXes.Where(p => p.Mabienlai == txtMaBL.Text).SingleOrDefault();
            SINHVIEN sinhVien = db.SINHVIENs.Where(p => p.Masv == txtMaSV.Text).SingleOrDefault();
            using (FormPrint_PhiKTX frm = new FormPrint_PhiKTX(BienLai, sinhVien))
            {
                frm.ShowDialog();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        #endregion

        
    }
}
