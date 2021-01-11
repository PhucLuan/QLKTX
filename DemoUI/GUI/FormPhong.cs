using DemoUI;
using DemoUI.BLL;
using FontAwesome.Sharp;
using Microsoft.ReportingServices.ReportProcessing.OnDemandReportObjectModel;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Pipes;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTX_PHONG
{
    public partial class FormPhong : Form
    {
        DEMOQLKTXEntities ktx = MyDb.GetInstance();
        PhongBLL PhongBLL = new PhongBLL();
        public FormPhong()
        {
            InitializeComponent();
            UserProfile.CurrentDGV = null;
            UserProfile.CurrentDGV = dGVdssv;
            UserProfile.CurrentForm = this;
        }
        int count = 0;//Dùng để trờ về trang ds phòng sau khi xem ds sv mỗi phòng
        
        #region Method
        void LoadPhong()
        {
            List<PHONG> dsp = PhongBLL.GetAll();

            foreach (PHONG item in ktx.PHONGs)
            {
                var dssv = MyDb.GetInstance().HOPDONGs.Where(x => x.Sophong == item.Sophong).Count();

                Button button1 = new Button();
                // 
                // button1
                // 
                button1.BackColor = System.Drawing.Color.DarkRed;
                button1.ForeColor = System.Drawing.Color.Coral;
                button1.Location = new System.Drawing.Point(463, 10);
                button1.Name = "button1";
                button1.Size = new System.Drawing.Size(75, 23);
                button1.TabIndex = 40;
                button1.Text = "button1";
                button1.UseVisualStyleBackColor = false;
                IconButton iBtnPhong = new IconButton();
                if (item.LoaiPhong == "Nam")
                {
                    #region Phòng Nam
                    //Design button bằng code
                    iBtnPhong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(137)))), ((int)(((byte)(255)))));
                    iBtnPhong.FlatAppearance.BorderSize = 0;
                    iBtnPhong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                    iBtnPhong.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
                    iBtnPhong.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    iBtnPhong.ForeColor = System.Drawing.Color.White;
                    iBtnPhong.IconChar = FontAwesome.Sharp.IconChar.Male;
                    iBtnPhong.IconColor = System.Drawing.Color.White;
                    iBtnPhong.IconSize = 40;
                    iBtnPhong.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
                    iBtnPhong.Location = new System.Drawing.Point(403, 245);
                    iBtnPhong.Name = "iconButton1";
                    iBtnPhong.Rotation = 0D;
                    iBtnPhong.Size = new System.Drawing.Size(123, 70);
                    iBtnPhong.TabIndex = 15;
                    iBtnPhong.Text = item.Sophong + "\r\n"+dssv.ToString()+"/"+item.Sluongsv.ToString()+" SV\r\n";
                    iBtnPhong.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                    iBtnPhong.UseVisualStyleBackColor = false;
                    #endregion
                }
                else
                {
                    #region Phòng Nữ
                    iBtnPhong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(77)))), ((int)(((byte)(214)))));
                    iBtnPhong.FlatAppearance.BorderSize = 0;
                    iBtnPhong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                    iBtnPhong.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
                    iBtnPhong.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    iBtnPhong.ForeColor = System.Drawing.Color.White;
                    iBtnPhong.IconChar = FontAwesome.Sharp.IconChar.Female;
                    iBtnPhong.IconColor = System.Drawing.Color.White;
                    iBtnPhong.IconSize = 40;
                    iBtnPhong.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
                    iBtnPhong.Location = new System.Drawing.Point(403, 245);
                    iBtnPhong.Name = "iconButton1";
                    iBtnPhong.Rotation = 0D;
                    iBtnPhong.Size = new System.Drawing.Size(123, 70);
                    iBtnPhong.TabIndex = 15;
                    iBtnPhong.Text = item.Sophong + "\r\n" + dssv.ToString() + "/" + item.Sluongsv.ToString() + " SV\r\n";
                    iBtnPhong.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                    iBtnPhong.UseVisualStyleBackColor = false;
                    #endregion
                }
                iBtnPhong.Click += IBtnPhong_Click;
                //Design button phòng --> gắn event
                button1.Click += Button1_Click;
                button1.Tag = item;
                //
                iBtnPhong.Tag = item;
                PanelPhong.Controls.Add(iBtnPhong);
            }
            
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        void ThongTinSVphong()
        {
            if (count == 0)
            {
                var result = from sv in ktx.SINHVIENs
                             join hd in ktx.HOPDONGs on sv.Masv equals hd.Masv
                             join p in ktx.PHONGs on hd.Sophong equals p.Sophong
                             where p.Sophong == txtSP.Text
                             select new { sv.Hoten, sv.Gioitinh, sv.Khoa, sv.Masv };

                dGVdssv.DataSource = result.ToList();
                
                count++;
            }
            else
            {
                LoadPhong();
                count = 0;
            }
            

        }
        void ClearpanelDSPhong()
        {
            PanelPhong.Controls.Clear();
        }
        void LoadDssvPhong(int soPhong)
        {
            var dssv = from sv in ktx.SINHVIENs
                       join hd in ktx.HOPDONGs on sv.Masv equals hd.Masv
                       where hd.Sophong == soPhong.ToString()
                       select new
                       {
                           hd.Sophong,sv.Masv,sv.Hoten,sv.Sdt,sv.Gioitinh,sv.MaDTUT,sv.Mahb
                       };
            //dGVdssv.DataSource = null;
            dGVdssv.DataSource = dssv.ToList();
            #region Header
            dGVdssv.Columns[0].HeaderText = "Số Phòng";
            dGVdssv.Columns[1].HeaderText = "Mã số SV";
            dGVdssv.Columns[2].HeaderText = "Họ Tên";
            dGVdssv.Columns[3].HeaderText = "SĐT";
            dGVdssv.Columns[4].HeaderText = "Giới Tính";
            dGVdssv.Columns[5].HeaderText = "Mã ĐTƯT";
            dGVdssv.Columns[6].HeaderText = "Mã HB";
            #endregion
        }
        #endregion

        #region Event
        private void FormPhong_Load(object sender, EventArgs e)
        {
            LoadPhong();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            //ThemPhong();
            PHONG phong = new PHONG();
            phong.Sophong = txtSP.Text;
            phong.Sluongsv = Convert.ToInt32(cboSL.Text);
            phong.LoaiPhong = cboLoaiPhong.Text;

            PhongBLL.Add(phong);
            ClearpanelDSPhong();
            LoadPhong();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            PHONG phong = PhongBLL.Get(p => p.Sophong == txtSP.Text);
            PhongBLL.Delete(phong);
            ClearpanelDSPhong();
            LoadPhong();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            PHONG phong = PhongBLL.Get(x => x.Sophong == txtSP.Text);
            phong.Sluongsv = Convert.ToInt32(cboSL.Text);
            phong.LoaiPhong = cboLoaiPhong.Text;

            PhongBLL.Edit(phong);

            LoadPhong();
        }


        private void btnTim_Click(object sender, EventArgs e)
        {
            dGVdssv.DataSource = PhongBLL.Search(txtNhap.Text);
        }

        private void IBtnPhong_Click(object sender, EventArgs e)
        {
            IconButton currentButton = (IconButton)sender;
            int soPhong = Convert.ToInt32(currentButton.Text.Substring(0, 3));
            txtSP.Text = soPhong.ToString();
            LoadDssvPhong(soPhong);
            PHONG phong = ktx.PHONGs.Find(soPhong.ToString());
            cboSL.Text = phong.Sluongsv.ToString();
            cboLoaiPhong.Text = phong.LoaiPhong.ToString();
        }

        #endregion

    }
}
