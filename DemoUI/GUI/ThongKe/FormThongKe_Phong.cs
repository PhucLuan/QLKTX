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
    public partial class FormThongKe_Phong : Form
    {
        DEMOQLKTXEntities db = MyDb.GetInstance();
        public FormThongKe_Phong()
        {
            InitializeComponent();
        }

        private void FormThongKe_Phong_Load(object sender, EventArgs e)
        {
            LoadPhong();
        }

        void LoadPhong()
        {
            var results = from phong in db.PHONGs
                          where phong.ConTrong <= phong.Sluongsv
                          select new { phong.Sophong, phong.LoaiPhong, phong.Sluongsv, phong.ConTrong };
            dgv.DataSource = results.ToList();

            //Cách đổ dữ liệu lên DataGridView Rọn ràng
            for (int i = 0; i <= dgv.Columns.Count - 1; i++)
            {
                if (i < dgv.Columns.Count - 1)
                    dgv.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                else
                    dgv.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            //Header
            dgv.Columns[0].HeaderText = "Số phòng";
            dgv.Columns[1].HeaderText = "Loại phòng";
            dgv.Columns[2].HeaderText = "Sức chứa";
            dgv.Columns[3].HeaderText = "Còn trống";
        }

        

        
    }
}
