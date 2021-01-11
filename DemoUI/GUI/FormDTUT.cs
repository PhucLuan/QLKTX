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

namespace KTX_DTUT
{
    public partial class FormDTUT : Form
    {
        public FormDTUT()
        {
            InitializeComponent();
            UserProfile.CurrentDGV = null;
            UserProfile.CurrentDGV = dGVdsSinhVien;
            UserProfile.CurrentForm = this;
        }
        
        DEMOQLKTXEntities ktx = MyDb.GetInstance();
        DtutBLL dtutBLL = new DtutBLL();
        
        #region Method
        void LoadDTUT()
        {
            var dsma = ktx.DOITUONGUUTIENs.Select(x => new { x.MaDTUT,x.Mota});
            
            dGVdsDTUT.DataSource = null;
            dGVdsDTUT.DataSource = dsma.ToList();
            dGVdsDTUT.Columns[0].HeaderText = "Mã ĐTƯT ";
            dGVdsDTUT.Columns[1].HeaderText = "Mô tả";
        }


        #endregion

        #region Event
        private void KTX_DTUT_Load(object sender, EventArgs e)
        {
            LoadDTUT();
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtMa.Text = dGVdsDTUT.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtMota.Text = dGVdsDTUT.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
            catch (Exception)
            {
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var result = MyDb.GetInstance().SINHVIENs.Select(x => new { x.MaDTUT, x.Hoten, x.Masv, x.Cmnd, x.Ngaysinh });

            dGVdsSinhVien.DataSource = result.ToList();
        }
        #endregion

        private void dGVdsDTUT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMa.Text = dGVdsDTUT.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtMota.Text = (string)dGVdsDTUT.Rows[e.RowIndex].Cells[1].Value;
            var DataJoin = from sv in ktx.SINHVIENs
                           where sv.MaDTUT == txtMa.Text.Trim()
                           select new
                           {
                               sv.MaDTUT,
                               sv.Masv,
                               sv.Hoten,
                               sv.Gioitinh,
                               sv.Sdt
                           };
            dGVdsSinhVien.DataSource = DataJoin.ToList();
        }

        private void btn_them_Click(object sender, EventArgs e)
        {

            DOITUONGUUTIEN dtut = dtutBLL.Get(x => x.MaDTUT == txtMa.Text);
            if (dtut == null)
            {
                dtut = new DOITUONGUUTIEN();
                dtut.MaDTUT = txtMa.Text;
                dtut.Mota = txtMota.Text;

                dtutBLL.Add(dtut);
            }
            else
            {
                MessageBox.Show("Mã ĐTƯT đã tồn tại");
            }

            LoadDTUT();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            dtutBLL.Delete(dtutBLL.Get(p => p.MaDTUT == txtMa.Text));
            LoadDTUT();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DOITUONGUUTIEN dtut = dtutBLL.Get(p => p.MaDTUT == txtMa.Text);
            dtut.Mota = txtMota.Text;
            dtutBLL.Edit(dtut);

            LoadDTUT();
        }
    }
}
