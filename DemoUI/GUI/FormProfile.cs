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
    public partial class FormProfile : Form
    {
        public FormProfile(SINHVIEN sinhVien)
        {
            InitializeComponent();
            lbMssv.Text = sinhVien.Masv;
            lbCMND.Text = sinhVien.Cmnd;
            lbDanToc.Text = sinhVien.Dantoc;
            lbDiaChi.Text = sinhVien.Diachithuongtru;
            lbEmail.Text = sinhVien.Email;
            lbGioiTinh.Text = sinhVien.Gioitinh;
            lbHoten.Text = sinhVien.Hoten;
            lbKhoa.Text = sinhVien.Khoa.ToString();
            lbNgaySinh.Text = sinhVien.Ngaysinh.ToString();
            lbNoiCap.Text = sinhVien.Noicap;
            lbSDT.Text = sinhVien.Sdt.ToString();
            lbTonGiao.Text = sinhVien.Tongiao;
            UserProfile.CurrentForm = this;
        }

        private void FormProfile_Load(object sender, EventArgs e)
        {
            //SINHVIEN
        }
    }
}
