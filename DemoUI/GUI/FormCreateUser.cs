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
    public partial class FormCreateUser : Form
    {
        public FormCreateUser(string textMaNV)
        {
            InitializeComponent();
            _textMaNV = textMaNV;
            UserProfile.CurrentForm = this;
        }
        DEMOQLKTXEntities db = MyDb.GetInstance();
        string _textMaNV;
        void AddUser()
        {
            User user_check = db.Users.Where(p => p.UserName.Trim() == txtUN.Text.Trim()).SingleOrDefault();
            if (user_check == null)
            {
                try
                {
                    User user = new User();
                    user.IDUser = txtIDuser.Text;
                    user.MaNV = txtMaNV.Text;
                    user.UserName = txtUN.Text;
                    user.Password = txtPW.Text;
                    user.Quyen = cboChucVu.Text;
                    db.Users.Add(user);
                    db.SaveChanges();
                }
                catch (Exception)
                {
                    MessageBox.Show("Nhân viên đã có tài khoản trước đó");
                }
            }
            else
                MessageBox.Show("Username đã tồn tại");
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            AddUser();
            this.Hide();
        }

        private void FormCreateUser_Load(object sender, EventArgs e)
        {
            txtMaNV.Text = _textMaNV;
        }
    }
}
