using DemoUI.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoUI
{
    public partial class FormConnectDB : Form
    {
        ConnectdbBLL connectdbBLL = new ConnectdbBLL();
        public FormConnectDB()
        {
            InitializeComponent();
            cbServerName.DropDownStyle = ComboBoxStyle.DropDownList;
            cbAuthen.DropDownStyle = ComboBoxStyle.DropDownList;
            cbDataBase.DropDownStyle = ComboBoxStyle.DropDownList;
            txtUserName.Enabled = false;
            txtPassWord.Enabled = false;
            cbDataBase.Enabled = false;
        }

        private void FormConnectDB_Load(object sender, EventArgs e)
        {
            foreach (var item in SqlHelper.ListLocalSqlInstances())
            {
                cbServerName.Items.Add(item);
            }
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            connectdbBLL.saveConnectionstring(cbDataBase.Text, cbServerName.Text, txtUserName.Text, txtPassWord.Text);
            
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //txtReadFromText.Text = System.IO.File.ReadAllText(@"D:\HỌC TẬP\PTUDDesktop\ConnectString.txt");
            //SqlHelper.ChangeDatabase
        }
        
        private void cbAuthen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbAuthen.SelectedIndex == 0)
            {
                cbDataBase.Enabled = true;
                foreach (var item in SqlHelper.GetDatabases(cbServerName.Text))
                {
                    cbDataBase.Items.Add(item);
                }
            }
            else
            {
                txtUserName.Enabled = true;
                txtPassWord.Enabled = true;
            }
        }

        private void btnGetDB_Click(object sender, EventArgs e)
        {
            cbDataBase.Items.Clear();
            foreach (var item in SqlHelper.GetDatabases(cbServerName.Text, txtUserName.Text, txtPassWord.Text))
            {
                cbDataBase.Items.Add(item);
            }

            cbDataBase.Enabled = true;
        }
    }
}
