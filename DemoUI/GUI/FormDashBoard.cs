using FontAwesome.Sharp;
using KTX_DTUT;
using KTX_PHONG;
using Rpt_Receipt_KTX;
using ScanBarCode;
using Simple_Face_Recognition_App;
using System;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsApp1;
using WindowsFormsApp3;

namespace DemoUI
{
    public partial class FormDashBoard : Form
    {
        FormLogin formLogin = null;
        DEMOQLKTXEntities dbContext;

        public FormDashBoard()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            costomizeDesing();
            foreach (Panel item in this.Controls)
            {
                if (item.Name.Trim() == "panelSideMenu" || item.Name.Trim() == "panelBV")
                {
                    item.Enabled = false;
                }
            }

            dbContext = MyDb.GetInstance();
        }

        #region Method
        private void costomizeDesing()
        {
            panelSV.Visible = false;
            panelVB.Visible = false;
            //panelTools.Visible = false;

        }

        private void hideSubMenu()
        {
            if (panelSV.Visible == true)
                panelSV.Visible = false;
            if (panelVB.Visible == true)
                panelVB.Visible = false;
            //if (panelTools.Visible == true)
            //    panelTools.Visible = false;
        }

        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }

        private Form activeForm = null;
        IconButton pre_iconButton = null;
        private void openChildForm(Form childForm, IconButton iconButton)
        {
            UserProfile.CurrentForm = childForm;
            UserProfile.CurrentBtn = iconButton;
            if (activeForm != null)
            {
                if (pre_iconButton.Text.Trim() == "CHECK IN")
                {
                    pre_iconButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(9)))), ((int)(((byte)(20)))));
                }
                else if (pre_iconButton.Text.Trim() == "CAMERA")
                {
                    pre_iconButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(178)))), ((int)(((byte)(51)))));
                }
                else
                    pre_iconButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(54)))), ((int)(((byte)(136)))));
                activeForm.Close();
            }
            activeForm = childForm;
            UserProfile.CurrentBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(135)))), ((int)(((byte)(236)))));
            pre_iconButton = iconButton;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

        }
        #region Phân quyền sử dụng form
        private void ManageLogIn(Form childForm, IconButton iconButton)
        {

            if (UserProfile.CurrentUser.Quyen.Trim() == "Manage")
            {
                openChildForm(childForm, iconButton);
            }
            else
                MessageBox.Show("Tài khoản của bạn không thể sử dụng chức năng này");
        }
        private void AccountantLogIn(Form childForm, IconButton iconButton)
        {

            if (UserProfile.CurrentUser.Quyen.Trim() == "Manage"
                || UserProfile.CurrentUser.Quyen.Trim() == "Accountant")
            {
                openChildForm(childForm, iconButton);
            }
            else
                MessageBox.Show("Tài khoản của bạn không thể sử dụng chức năng này");
        }
        private void GuardLogIn(Form childForm, IconButton iconButton)
        {
            if (UserProfile.CurrentUser != null)
            {
                if (UserProfile.CurrentUser.Quyen.Trim() == "Manage"
                || UserProfile.CurrentUser.Quyen.Trim() == "Guard")
                {
                    openChildForm(childForm, iconButton);
                }
                else
                    MessageBox.Show("Tài khoản của bạn không thể sử dụng chức năng này");
            }
            else
                MessageBox.Show("Đăng nhập để sử dụng chức năng");
        }
        #endregion
        //Xuất datagridview ở từng form ra file excel
        void XuatExcel()
        {
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;
            worksheet.Name = "DanhSach";

            for (int i = 1; i < UserProfile.CurrentDGV.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = UserProfile.CurrentDGV.Columns[i - 1].HeaderText;
            }
            for (int i = 0; i < UserProfile.CurrentDGV.Rows.Count; i++)
            {
                for (int j = 0; j < UserProfile.CurrentDGV.Columns.Count; j++)
                {
                    if (UserProfile.CurrentDGV.Rows[i].Cells[j].Value != null)
                    {
                        worksheet.Cells[i + 2, j + 1] = UserProfile.CurrentDGV.Rows[i].Cells[j].Value.ToString();
                    }

                }
            }

            var saveFileDialoge = new SaveFileDialog();
            saveFileDialoge.FileName = "output";
            saveFileDialoge.DefaultExt = ".xlsx";
            if (saveFileDialoge.ShowDialog() == DialogResult.OK)
            {
                workbook.SaveAs(saveFileDialoge.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            }
            app.Quit();
        }
        #endregion

        #region Sinh Viên
        private void iBtnSV_Click(object sender, EventArgs e)
        {
            showSubMenu(panelSV);
        }
        //Đối tượng Ưu tiên
        private void iBtnDTUT_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            ManageLogIn(new FormDTUT(), (IconButton)sender);
        }
        //Danh sách sinh viên
        private void iBtnDSSV_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            ManageLogIn(new FormInfoSV(), (IconButton)sender);
        }
        #endregion

        #region Phòng
        //Phòng
        private void iBtnPhong_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            ManageLogIn(new FormPhong(), (IconButton)sender);
        }
        #endregion

        //Thông tin học bổng và sinh viên có học bổng
        private void iBtnHocBong_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            AccountantLogIn(new FormHocBong(), (IconButton)sender);
        }

        #region Văn Bản
        //Văn bản gồm : Hóa đơn điện nước, hóa đơn phí KTX, Hợp đồng KTX
        private void iBtnVanBan_Click(object sender, EventArgs e)
        {
            showSubMenu(panelVB);
        }

        //Mở hợp đồng
        private void iBtnHD_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            ManageLogIn(new FormHopDong(), (IconButton)sender);
        }
        //Mở Hóa đơn điện nước
        private void iBtnDienNuoc_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            AccountantLogIn(new FormHoaDonDienNuoc(), (IconButton)sender);
        }
        //Mở HĐ phí nội trú
        private void iBtnNoiTru_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            AccountantLogIn(new FormPhiKTX(), (IconButton)sender);
        }
        #endregion

        #region Nhân viên
        //Mở form Nhân viên
        private void iBtnNV_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            ManageLogIn(new FormNV_Buni(), (IconButton)sender);
        }
        #endregion

        #region Đồng hồ
        //Load đồng hồ và username đăng nhập
        private void timer1_Tick(object sender, EventArgs e)
        {
            labelTime.Text = DateTime.Now.ToString("HH:mm");
            labelSecond.Text = DateTime.Now.ToString("ss");
            labelDate.Text = DateTime.Now.ToString("MMM dd yyyy");
            labelDay.Text = DateTime.Now.ToString("dddd");
            if (UserProfile.CurrentUser != null)
            {

                this.iBtnLogin.Text = "   " + UserProfile.CurrentUser.UserName;
                this.iBtnLogin.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            }
            else
            {
                this.iBtnLogin.Text = "Đăng Nhập";
                this.iBtnLogin.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            }
        }
        #endregion
        string _ConnectStr;
        //Load form
        private void FormDashBoard_Load(object sender, EventArgs e)
        {
            timer1.Start();
            bool isConnected = false;
            try
            {
                _ConnectStr = System.IO.File.ReadAllText("ConnectString.txt");
                if (!string.IsNullOrEmpty(_ConnectStr))
                {
                    // bùa để giữ kết nối
                    dbContext.ChangeDatabase(_ConnectStr);
                    User users = dbContext.Users.FirstOrDefault(x => x.IDUser == "");
                    isConnected = true;
                }
            }
            catch (Exception)
            {

            }
            finally
            {
                if (!isConnected)
                {
                    FormConnectDB formConnectDB = new FormConnectDB();
                    formConnectDB.TopMost = true;
                    formConnectDB.StartPosition = FormStartPosition.CenterScreen;
                    formConnectDB.Show();
                }
            }
        }

        #region CheckIn
        //Quét mã barcode check iN
        private void iBtn_Checkin_Click(object sender, EventArgs e)
        {
            GuardLogIn(new FormScanCode(), (IconButton)sender);
            hideSubMenu();
        }
        //Nhận diện gương mặt
        private void iBtn_Camera_Click(object sender, EventArgs e)
        {
            GuardLogIn(new FormFaceRe(), (IconButton)sender);
            hideSubMenu();
        }
        #endregion

        //Tắt form
        private void iPBox_Poweroff_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //Đổi màu button đang click
        private void pictureBoxLogo_Click(object sender, EventArgs e)
        {
            if (UserProfile.CurrentForm != null)
            {
                UserProfile.CurrentForm.Close();
                UserProfile.CurrentBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(54)))), ((int)(((byte)(136)))));
            }

        }
        //Đăng nhập
        private void iBtnLogin_Click(object sender, EventArgs e)
        {
            UserProfile.CurrentBtn = (IconButton)sender;
            FormLogin.frmLogIn = null;
            formLogin = FormLogin.GetInstance();
            formLogin.TopMost = true;
            formLogin.Show();
            formLogin.FormClosed += OnLogInFormClosed;
        }

        private void OnLogInFormClosed(object sender, FormClosedEventArgs e)
        {
            foreach (Panel item in this.Controls)
            {
                if (item.Name == "panelSideMenu")
                {
                    item.Enabled = Properties.Settings.Default.isLogin;
                    break;
                }
            }
        }

        private void iBtnExport_Click(object sender, EventArgs e)
        {
            if (UserProfile.CurrentDGV != null)
            {
                XuatExcel();
            }
            else
                MessageBox.Show("Chưa có bảng để xuất file");
        }

        private void iBtn_Calendar_Click(object sender, EventArgs e)
        {
            FormCalendar formCalendar = new FormCalendar();
            formCalendar.Show();
        }

        private void iBtn_ThongKe_Click(object sender, EventArgs e)
        {
            ManageLogIn(new FormThongKe(), (IconButton)sender);
            hideSubMenu();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
