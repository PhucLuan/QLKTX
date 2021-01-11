using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using DemoUI.BLL;

namespace DemoUI
{
    public partial class FormCalendar : Form
    {
        public FormCalendar()
        {
            InitializeComponent();
        }
        CalendarBLL CalendarBLL = new CalendarBLL();
        ChromiumWebBrowser chrome;

        private void FormCalendar_Load(object sender, EventArgs e)
        {
            CalendarBLL.openCalendar(chrome,"https://calendar.google.com/",this);
        }

        private void FormCalendar_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Cef.();
            //Cef.
            //this.Dispose();
        }
    }
}
