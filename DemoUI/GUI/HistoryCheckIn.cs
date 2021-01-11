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
    public partial class HistoryCheckIn : Form
    {
        public HistoryCheckIn()
        {
            InitializeComponent();
            UserProfile.CurrentForm = this;
        }
        DEMOQLKTXEntities db = MyDb.GetInstance();
        void LoadSV()
        {
            var result = from checkIn in db.CheckIns
                         join sv in db.SINHVIENs
                            on checkIn.Masv equals sv.Masv
                            orderby checkIn.ThoiGian descending
                         select new
                         {
                             sv.Masv,
                             sv.Hoten,
                             checkIn.ThoiGian
                         };
            dGV_SV.DataSource = null;
            dGV_SV.DataSource = result.ToList();
            #region Header
            dGV_SV.Columns[0].HeaderText = "Mã Số SV";
            dGV_SV.Columns[1].HeaderText = "Họ Tên";
            dGV_SV.Columns[2].HeaderText = "Thời Gian";
            #endregion
        }
        void SearchBaseTime()
        {
            var result = from checkIn in db.CheckIns
                         join sv in db.SINHVIENs
                            on checkIn.Masv equals sv.Masv
                         orderby checkIn.ThoiGian
                         where checkIn.ThoiGian.Year == dtpTgian.Value.Date.Year
                         && checkIn.ThoiGian.Month == dtpTgian.Value.Date.Month
                         && checkIn.ThoiGian.Day == dtpTgian.Value.Date.Day
                         select new
                         {
                             sv.Masv,
                             sv.Hoten,
                             checkIn.ThoiGian
                         };
            dGV_SV.DataSource = null;
            dGV_SV.DataSource = result.ToList();
        }
        private void HistoryCheckIn_Load(object sender, EventArgs e)
        {
            dtpTgian.Value = DateTime.Now;
            LoadSV();
        }

        private void dtpTgian_onValueChanged(object sender, EventArgs e)
        {
            SearchBaseTime();
        }
    }
}
