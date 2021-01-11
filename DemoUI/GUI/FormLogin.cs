using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;

namespace DemoUI
{
    public partial class FormLogin : Form
    {
        public static FormLogin frmLogIn;

        public static FormLogin GetInstance()
        {
            if (frmLogIn == null)
            {
                frmLogIn = new FormLogin();
            }

            return frmLogIn;
        }

        public FormLogin()
        {
            InitializeComponent();
            if (UserProfile.CurrentUser != null)
            {
                txtUser.Text = UserProfile.CurrentUser.UserName;
                txtPassWord.Text = UserProfile.CurrentUser.Password;
            }
        }
        DEMOQLKTXEntities db = MyDb.GetInstance();

        IEnumerable<User> GetUser(IEnumerable<User> users)
        {
            yield return users.FirstOrDefault();
        }

        private void iBtnLogIn_Click(object sender, EventArgs e)
        {
            try
            {
                Expression<Func<User, bool>> expr = i => i.UserName == txtUser.Text && i.Password == txtPassWord.Text;
                User userInfo = db.Users.FirstOrDefault(expr);

                if (userInfo != null)
                {
                    UserProfile.CurrentUser = userInfo;

                    if (checkRemember.Checked)
                    {
                        Properties.Settings.Default.UserName = txtUser.Text;
                        Properties.Settings.Default.Password = txtPassWord.Text;
                        Properties.Settings.Default.Save();
                    }

                    Properties.Settings.Default.isLogin = true;
                    Properties.Settings.Default.Save();

                    MessageBox.Show(userInfo.Quyen);
                    this.Close();

                }
                else
                {
                    txtUser.Clear();
                    txtPassWord.Clear();
                    MessageBox.Show("Đăng nhập sai");
                }
            }
            catch (Exception ex)
            {
                txtUser.Clear();
                txtPassWord.Clear();
                MessageBox.Show("Đăng nhập sai" + " " + ex.Message);
            }
        }

        private void IBtnLogout_Click(object sender, EventArgs e)
        {
            txtUser.Clear();
            txtPassWord.Clear();
            UserProfile.CurrentUser = null;
            if (UserProfile.CurrentForm != null)
            {
                UserProfile.CurrentForm.Hide();
                UserProfile.CurrentForm = null;
            }

            Properties.Settings.Default.isLogin = false;
            Properties.Settings.Default.Save();

            this.Close();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            //txtUser.Text = Properties.Settings.Default.UserName;
        }
    }
}
