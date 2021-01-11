using DemoUI;
using Microsoft.Reporting.WinForms.Internal.Soap.ReportingServices2005.Execution;
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
    public partial class FormHoaDonDienNuoc : Form
    {
        DEMOQLKTXEntities db = MyDb.GetInstance();
        public FormHoaDonDienNuoc()
        {
            InitializeComponent();
            UserProfile.CurrentDGV = null;
            UserProfile.CurrentDGV = dgvHĐDien;
            UserProfile.CurrentForm = this;
        }
        
        private void FormHoaDonDienNuoc_Load(object sender, EventArgs e)
        {
            LoadHoaDonDienNuoc();
        }
        
        void LoadHoaDonDienNuoc()
        {
            var result = from hd in db.HOADONDIENNUOCs
                         join nv in db.NHANVIENs on hd.MaNV equals nv.MaNV
                         select new
                         {
                             hd.Mahdn,
                             hd.MaNV,
                             hd.Ngaylap,
                             hd.HDThang,
                             hd.Sophong,
                             hd.Sokhoinuoc,
                             hd.Dongianuoc,
                             hd.Sokidien,
                             hd.Dongiadien,
                             hd.Tongtien
                         };
            dgvHĐDien.DataSource = result.ToList();

            //Cách đổ dữ liệu lên DataGridView Rọn ràng 
            //for (int i = 0; i <= dgv.Columns.Count - 1; i++)
            //{
            //    if (i < dgv.Columns.Count - 1)
            //        dgv.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //    else
            //        dgv.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //}

            //Header
            dgvHĐDien.Columns[0].HeaderText = "Hóa đơn";
            dgvHĐDien.Columns[1].HeaderText = "Nhân viên";
            dgvHĐDien.Columns[2].HeaderText = "Ngày lập";
            dgvHĐDien.Columns[3].HeaderText = "Tháng";
            dgvHĐDien.Columns[4].HeaderText = "Phòng";
            dgvHĐDien.Columns[5].HeaderText = "Khối Nước";
            dgvHĐDien.Columns[6].HeaderText = "ĐGiá Nước";
            dgvHĐDien.Columns[7].HeaderText = "Kwh Điện";
            dgvHĐDien.Columns[8].HeaderText = "ĐGiá Điện";
            dgvHĐDien.Columns[9].HeaderText = "Tổng tiền";
        }

        private void dgv_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtMaHD.Text = dgvHĐDien.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtNhanVien.Text = dgvHĐDien.Rows[e.RowIndex].Cells[1].Value.ToString();
            dtpNgaylap.Text = dgvHĐDien.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtHDThang.Text = dgvHĐDien.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtSophong.Text = dgvHĐDien.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtSokhoinuoc.Text = dgvHĐDien.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtDongiaNuoc.Text = dgvHĐDien.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtSokidien.Text = dgvHĐDien.Rows[e.RowIndex].Cells[7].Value.ToString();
            txtDongiaDien.Text = dgvHĐDien.Rows[e.RowIndex].Cells[8].Value.ToString();
            txtTongtien.Text = dgvHĐDien.Rows[e.RowIndex].Cells[9].Value.ToString();
        }

        #region Button
        private void btnAdd_Click(object sender, EventArgs e)
        {
            HOADONDIENNUOC hd = new HOADONDIENNUOC();
            hd.Mahdn = txtMaHD.Text;
            hd.MaNV = txtNhanVien.Text;
            hd.Ngaylap = dtpNgaylap.Value;
            hd.HDThang = Convert.ToInt32(txtHDThang.Text);
            hd.Sophong = txtSophong.Text;
            hd.Sokhoinuoc = Convert.ToInt32(txtSokhoinuoc.Text);
            hd.Dongianuoc = Convert.ToDecimal(txtDongiaNuoc.Text);
            hd.Sokidien = Convert.ToInt32(txtSokidien.Text);
            hd.Dongiadien = Convert.ToDecimal(txtDongiaDien.Text);
            hd.Tongtien = Convert.ToDecimal(txtTongtien.Text);
            db.HOADONDIENNUOCs.Add(hd);
            db.SaveChanges();
            LoadHoaDonDienNuoc();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            HOADONDIENNUOC hd = (from h in db.HOADONDIENNUOCs
                                 where h.Mahdn == txtMaHD.Text.Trim()
                                 select h).Single<HOADONDIENNUOC>();
            hd.MaNV = txtNhanVien.Text;
            hd.Ngaylap = dtpNgaylap.Value;
            hd.HDThang = Convert.ToInt32(txtHDThang.Text);
            hd.Sophong = txtSophong.Text;
            hd.Sokhoinuoc = Convert.ToInt32(txtSokhoinuoc.Text);
            hd.Dongianuoc = Convert.ToDecimal(txtDongiaNuoc.Text);
            hd.Sokidien = Convert.ToInt32(txtSokidien.Text);
            hd.Dongiadien = Convert.ToDecimal(txtDongiaDien.Text);
            hd.Tongtien = Convert.ToDecimal(txtTongtien.Text);
            db.SaveChanges();
            LoadHoaDonDienNuoc();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            HOADONDIENNUOC hd = (from h in db.HOADONDIENNUOCs
                                 where h.Mahdn == txtMaHD.Text.Trim()
                                 select h).Single<HOADONDIENNUOC>();
            db.HOADONDIENNUOCs.Remove(hd);
            db.SaveChanges();
            LoadHoaDonDienNuoc();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            HOADONDIENNUOC HoaDon = db.HOADONDIENNUOCs.Where(p => p.Mahdn == txtMaHD.Text).SingleOrDefault();
            using (FormPrint_HoaDonDienNuoc frm = new FormPrint_HoaDonDienNuoc(HoaDon))
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
