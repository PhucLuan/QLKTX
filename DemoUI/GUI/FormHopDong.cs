using DemoUI.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoUI
{
    public partial class FormHopDong : Form
    {
        public FormHopDong()
        {
            InitializeComponent();
            UserProfile.CurrentDGV = null;
            UserProfile.CurrentDGV = dsHD;
            UserProfile.CurrentForm = this;
        }
        DEMOQLKTXEntities db = MyDb.GetInstance();
        HopdongBLL HopdongBLL = new HopdongBLL();

        #region Method
        //Load Sinh viên chưa kí hợp đồng
        void LoadSV()
        {
            var results = from sv in db.SINHVIENs
                        where !db.HOPDONGs.Any(hd=>hd.Masv==sv.Masv)
                        select new { 
                        sv.Masv,sv.Hoten, sv.Gioitinh
                        };

            dGVSv.DataSource = results.ToList();
            #region Header
            dGVSv.Columns[0].HeaderText = "Mã số SV";
            dGVSv.Columns[1].HeaderText = "Họ tên";
            dGVSv.Columns[2].HeaderText = "Giới Tính";
            #endregion
        }

        void LoadHD()
        {
            var results = from hd in db.HOPDONGs
                          join sv in db.SINHVIENs
                          on hd.Masv equals sv.Masv
                          select new { 
                          hd.Mahd,hd.MaNV,hd.Masv, 
                              sv.Hoten,sv.Gioitinh,hd.Ngaybatdau,hd.Ngayketthuc,
                          hd.Sophong
                          };

            dsHD.DataSource = results.ToList();
            #region Header
            dsHD.Columns[0].HeaderText = "Mã HĐ";
            dsHD.Columns[1].HeaderText = "Mã NV";
            dsHD.Columns[2].HeaderText = "Mã số SV";
            dsHD.Columns[3].HeaderText = "Họ tên";
            dsHD.Columns[4].HeaderText = "Giới Tính";
            dsHD.Columns[5].HeaderText = "Ngày Bắt Đầu";
            dsHD.Columns[6].HeaderText = "Ngày Kết Thúc";
            dsHD.Columns[7].HeaderText = "Số Phòng";         
            #endregion
        }

        void AddHD()
        {
            HOPDONG hd = HopdongBLL.Get(x => x.Mahd == txtMaHD.Text);
            if (hd == null)
            {
                hd = new HOPDONG()
                {
                    Mahd = txtMaHD.Text,
                    MaNV = txtMaNV.Text,
                    Masv = txtMaSV.Text,
                    Sophong = txtSoPhong.Text,
                    Ngaybatdau = dtpStart.Value,
                    Ngayketthuc = dtpTheEnd.Value
                };
                HopdongBLL.Add(hd);
            }
            else
            {
                MessageBox.Show("Mã hợp đồng đã tồn tại");
            }
        }

        void DeleteHD()
        {
            HOPDONG hd = HopdongBLL.Get(p => p.Mahd == txtMaHD.Text);

            HopdongBLL.Delete(hd);
        }

        void EditHD()
        {
            HOPDONG hd = db.HOPDONGs.Where(p => p.Mahd == txtMaHD.Text).SingleOrDefault();
            SINHVIEN sv = db.SINHVIENs.Where(p => p.Masv == hd.Masv).SingleOrDefault();
            PHONG phong = db.PHONGs.Where(p => p.Sophong == txtSoPhong.Text).SingleOrDefault();
            MessageBox.Show(sv.Gioitinh+ "chuyển sang phòng" + phong.LoaiPhong);
            if (sv.Gioitinh == phong.LoaiPhong)
            {
                hd.MaNV = txtMaNV.Text;
                hd.Masv = txtMaSV.Text;
                hd.Ngaybatdau = dtpStart.Value;
                hd.Ngayketthuc = dtpTheEnd.Value;
                hd.Sophong = txtSoPhong.Text;
                
                
                MessageBox.Show("Sửa hợp đồng thành công");
            }
            else
                MessageBox.Show("Kiểm tra lại thông tin vừa thay đổi");
        }

        void Search()
        {
            var results = from hd in db.HOPDONGs
                         join sv in db.SINHVIENs on hd.Masv equals sv.Masv
                             where sv.Masv == txtTimkiem.Text
                         select new
                         {
                             hd.Mahd,
                             hd.MaNV,
                             hd.Masv,
                             sv.Hoten,
                             sv.Gioitinh,
                             hd.Ngaybatdau,
                             hd.Ngayketthuc,
                             hd.Sophong
                         };
            
            dsHD.DataSource = results.ToList();
        }
        #endregion

        #region Event
        private void FormHopDong_Load(object sender, EventArgs e)
        {
            LoadSV();
            LoadHD();
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            AddHD();
            LoadHD();
            LoadSV();
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            EditHD();
            LoadHD();
            LoadSV();
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            DeleteHD();
            LoadHD();
            LoadSV();
        }

        private void dsHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtMaHD.Text = (string)dsHD.Rows[e.RowIndex].Cells[0].Value;
                txtMaNV.Text = (string)dsHD.Rows[e.RowIndex].Cells[1].Value;
                txtMaSV.Text = (string)dsHD.Rows[e.RowIndex].Cells[2].Value;
                dtpStart.Value = (DateTime)dsHD.Rows[e.RowIndex].Cells[5].Value;
                dtpTheEnd.Value = (DateTime)dsHD.Rows[e.RowIndex].Cells[6].Value;
                txtSoPhong.Text = (string)dsHD.Rows[e.RowIndex].Cells[7].Value;
                txtTenSV.Text = (string)dsHD.Rows[e.RowIndex].Cells[3].Value;
                txtGender.Text = (string)dsHD.Rows[e.RowIndex].Cells[4].Value;

            }
            catch (Exception)
            {

            }
            
        }

        private void picBoxSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void iBtnRefresh_Click(object sender, EventArgs e)
        {
            LoadHD();
            txtTimkiem.Text = null;
        }
        #endregion


    }
}
