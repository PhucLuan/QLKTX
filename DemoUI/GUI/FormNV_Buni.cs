using DemoUI;
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

namespace WindowsFormsApp3
{
    public partial class FormNV_Buni : Form
    {
        public FormNV_Buni()
        {
            InitializeComponent();
            UserProfile.CurrentDGV = null;
            UserProfile.CurrentDGV = dGV_NV;
            UserProfile.CurrentForm = this;
        }

        DEMOQLKTXEntities db = MyDb.GetInstance();
        NhanvienBLL nhanvienBLL = new NhanvienBLL();

        void Shownhanvien(List<NHANVIEN> ListNV)
        {
            dGV_NV.DataSource = ListNV;
            #region Header
            dGV_NV.Columns[0].HeaderText = "Mã NV";
            dGV_NV.Columns[1].HeaderText = "Họ Tên";
            dGV_NV.Columns[2].HeaderText = "Ngày Sinh";
            dGV_NV.Columns[3].HeaderText = "SĐT";
            dGV_NV.Columns[4].HeaderText = "Địa Chỉ";
            dGV_NV.Columns[7].HeaderText = "Chức Vụ";
            #endregion
        }

        private void dGV_NV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txt_MaNV.Text = dGV_NV.Rows[e.RowIndex].Cells[0].Value.ToString();
                txt_Hoten.Text = (string)dGV_NV.Rows[e.RowIndex].Cells[1].Value;
                dTPNgSinh.Value = (DateTime)dGV_NV.Rows[e.RowIndex].Cells[2].Value;
                txt_sdt.Text = (string)dGV_NV.Rows[e.RowIndex].Cells[3].Value;
                txt_diachi.Text = (string)dGV_NV.Rows[e.RowIndex].Cells[4].Value;
                txtUN.Text = (string)dGV_NV.Rows[e.RowIndex].Cells[5].Value;
                txtPW.Text = (string)dGV_NV.Rows[e.RowIndex].Cells[6].Value;
                cboChucVu.Text=(string)dGV_NV.Rows[e.RowIndex].Cells[7].Value;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FormNV_Buni_Load(object sender, EventArgs e)
        {
            Shownhanvien(nhanvienBLL.GetAll());
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            NHANVIEN nhanVien = nhanvienBLL.Get(x => x.MaNV.Trim() == txt_MaNV.Text.Trim());

            if (nhanVien == null)
            {
                nhanVien = new NHANVIEN();
                nhanVien.MaNV = txt_MaNV.Text;
                if (nhanVien.MaNV.Trim() == "")
                {
                    MessageBox.Show("Mã nhân viên không thể bỏ trống");
                }
                else
                {
                    nhanVien.Hoten = txt_Hoten.Text;
                    nhanVien.Sdt = txt_sdt.Text;
                    nhanVien.Diachi = txt_diachi.Text;
                    nhanVien.Ngaysinh = dTPNgSinh.Value;
                    
                    nhanvienBLL.Add(nhanVien);

                    FormCreateUser formCreateUser = new FormCreateUser(txt_MaNV.Text);
                    if (formCreateUser.ShowDialog(this) == DialogResult.OK)
                    {
                        this.Activate();
                    }
                }
            }
            else
            {
                MessageBox.Show("Mã nhân viên đã tồn tại");
            }

            Shownhanvien(nhanvienBLL.GetAll());
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            try
            {
                NHANVIEN nv = nhanvienBLL.Get(x => x.MaNV.Trim() == txt_MaNV.Text.Trim());

                nv.Sdt = txt_sdt.Text;
                nv.Hoten = txt_Hoten.Text;
                nv.MaNV = txt_MaNV.Text;
                nv.Diachi = txt_diachi.Text;
                nv.Ngaysinh = dTPNgSinh.Value;

                nhanvienBLL.Edit(nv);
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần sửa thông tin");
            }

            Shownhanvien(nhanvienBLL.GetAll());
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            NHANVIEN nv = MyDb.GetInstance().NHANVIENs.Where(p => p.MaNV == txt_MaNV.Text.Trim()).SingleOrDefault();
            User user = MyDb.GetInstance().Users.Where(p => p.MaNV == nv.MaNV).SingleOrDefault();   
            MyDb.GetInstance().Users.Remove(user);
            nhanvienBLL.Delete(nv);

            Shownhanvien(nhanvienBLL.GetAll());
        }
        private void picBoxSearch_Click(object sender, EventArgs e)
        {
            dGV_NV.DataSource = nhanvienBLL.Search(txtTimkiem.Text.Trim());
        }

        private void iBtnRefresh_Click(object sender, EventArgs e)
        {
            Shownhanvien(nhanvienBLL.GetAll());
            txtTimkiem.Text = null;
        }
    }
}
