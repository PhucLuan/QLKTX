using DemoUI;
using DemoUI.DAL;
using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;
using Z.Dapper.Plus;

namespace DemoUI
{
    public partial class FormInfoSV : Form
    {
        public FormInfoSV()
        {
            InitializeComponent();
            UserProfile.CurrentDGV = null;
            UserProfile.CurrentDGV = dGVdsSinhVien;
            UserProfile.CurrentForm = this;
        }
        DEMOQLKTXEntities db = MyDb.GetInstance();
        DataTableCollection tableCollection;
        GenericUnitOfWork unitOfWorkNV = new GenericUnitOfWork(MyDb.GetInstance());
        bool Flag = true;
        string connectionString;
        #region Method
        void LoadSV()
        {
            var result = from sv in db.SINHVIENs
                         select new
                         {
                             sv.Masv,
                             sv.Ngaysinh,
                             sv.Email,
                             sv.Hoten,
                             sv.Khoa,
                             sv.Gioitinh,
                             sv.Cmnd,
                             sv.Ngaycap,
                             sv.Noicap,
                             sv.Dantoc,
                             sv.Tongiao,
                             sv.Sdt,
                             sv.Diachithuongtru,
                             sv.Mahb,
                             sv.MaDTUT,
                             sv.LinkImage
                         };
            dGVdsSinhVien.DataSource = null;
            dGVdsSinhVien.DataSource = result.ToList();

        }

        void AddSV()
        {
            SINHVIEN sv = unitOfWorkNV.Repository<SINHVIEN>().Get(i => i.Masv == txtMasv.Text);
            if (sv == null)
            {
                sv = new SINHVIEN();
                sv.Masv = txtMasv.Text;
                sv.Ngaysinh = dtpNgaysinh.Value;
                sv.Email = txtEmail.Text;
                sv.Hoten = txtHoten.Text;
                sv.Khoa = Convert.ToInt32(txtKhoa.Text);
                sv.Gioitinh = cbbGioitinh.Text;
                sv.Cmnd = txtCmnd.Text;
                sv.Ngaycap = dtpNgaycap.Value;
                sv.Noicap = txtNoicap.Text;
                sv.Dantoc = txtDantoc.Text;
                sv.Tongiao = txtTongiao.Text;
                sv.Sdt = txtSdt.Text;
                sv.Diachithuongtru = txtDiachi.Text;
                sv.Mahb = default(string);
                if (txtMaDTUT == null) sv.MaDTUT = null;
                else sv.MaDTUT = txtMaDTUT.Text;
                sv.LinkImage = txtLinkImage.Text;
                db.SINHVIENs.Add(sv);
                db.SaveChanges();
            }
            else
            {
                MessageBox.Show("Mã sinh viên đã tồn tại");
            }
        }

        void DeleteSV()
        {
            SINHVIEN sv = unitOfWorkNV.Repository<SINHVIEN>().Get(s => s.Masv == txtMasv.Text.Trim());
            unitOfWorkNV.Repository<SINHVIEN>().Delete(sv);
        }

        void EditSv()
        {
            SINHVIEN sv = unitOfWorkNV.Repository<SINHVIEN>().Get(s => s.Masv == txtMasv.Text.Trim());
            sv.Ngaysinh = dtpNgaysinh.Value;
            sv.Email = txtEmail.Text;
            sv.Hoten = txtHoten.Text;
            sv.Khoa = Convert.ToInt32(txtKhoa.Text);
            sv.Gioitinh = cbbGioitinh.Text;
            sv.Cmnd = txtCmnd.Text;
            sv.Ngaycap = dtpNgaycap.Value;
            sv.Noicap = txtNoicap.Text;
            sv.Dantoc = txtDantoc.Text;
            sv.Tongiao = txtTongiao.Text;
            sv.Sdt = txtSdt.Text;
            sv.Diachithuongtru = txtDiachi.Text;
            if (txtMaHB.Text == "") sv.Mahb = null;
            else sv.Mahb = txtMaHB.Text;
            if (txtMaDTUT.Text == "") sv.MaDTUT = null;
            else sv.MaDTUT = txtMaDTUT.Text;
            sv.LinkImage = txtLinkImage.Text;
            db.SaveChanges();
            MessageBox.Show("done");
        }
        #endregion

        #region Event
        #region Kết nối với excel
        private void cbxSheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = tableCollection[cbxSheet.SelectedItem.ToString()];
            //dataGridView1.DataSource = dt;
            if (dt != null)
            {
                List<SINHVIEN> sinhViens = new List<SINHVIEN>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    SINHVIEN sinhvien = new SINHVIEN();
                    sinhvien.Masv = dt.Rows[i]["Masv"].ToString();
                    sinhvien.Ngaysinh = (DateTime)dt.Rows[i]["Ngaysinh"];
                    sinhvien.Email = dt.Rows[i]["Email"].ToString();
                    sinhvien.Hoten = dt.Rows[i]["Hoten"].ToString();
                    sinhvien.Khoa = Convert.ToInt32(dt.Rows[i]["Khoa"]);
                    sinhvien.Gioitinh = dt.Rows[i]["Gioitinh"].ToString();
                    sinhvien.Cmnd = dt.Rows[i]["Cmnd"].ToString();
                    sinhvien.Ngaycap = (DateTime)dt.Rows[i]["Ngaycap"];
                    sinhvien.Noicap = dt.Rows[i]["Noicap"].ToString();
                    sinhvien.Dantoc = dt.Rows[i]["Dantoc"].ToString();
                    sinhvien.Tongiao = dt.Rows[i]["Tongiao"].ToString();
                    sinhvien.Sdt = dt.Rows[i]["Sdt"].ToString();
                    sinhvien.Diachithuongtru = dt.Rows[i]["Diachithuongtru"].ToString();
                    sinhvien.LinkImage = dt.Rows[i]["LinkHinh"].ToString();
                    if (dt.Rows[i]["Mahb"] != null)
                    {
                        sinhvien.Mahb = dt.Rows[i]["Mahb"].ToString();
                    }

                    sinhvien.MaDTUT = dt.Rows[i]["MaDTUT"].ToString();
                    sinhvien.LinkImage = dt.Rows[i]["LinkHinh"].ToString();
                    sinhViens.Add(sinhvien);
                }

                sINHVIENBindingSource2.DataSource = null;
                sINHVIENBindingSource2.DataSource = sinhViens;
                dGVdsSinhVien.DataSource = null;
                dGVdsSinhVien.DataSource = sINHVIENBindingSource2.DataSource;
            }
        }
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            Flag = true;
            //dGVdsSinhVien.DataSource = null;
            using (OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "Excel worksheet|*.xlsx|Excel 2007-2010 workbook|*.xls" })
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtFileName.Text = openFileDialog.FileName;
                    using (var stream = File.Open(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
                    {
                        using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                        {
                            DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
                            {
                                ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }
                            });
                            tableCollection = result.Tables;
                            cbxSheet.Items.Clear();
                            foreach (DataTable table in tableCollection)
                                cbxSheet.Items.Add(table.TableName);
                        }
                    }
                }
            }
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Flag = false;
            //dGVdsSinhVien.DataSource = null;
            //this.sINHVIENTableAdapter.Fill(this.dEMOQLKTXDataSet.SINHVIEN);
            LoadSV();
            #region Header
            dGVdsSinhVien.Columns[0].HeaderText = "Mã SV";
            dGVdsSinhVien.Columns[1].HeaderText = "Ngày sinh";
            dGVdsSinhVien.Columns[2].HeaderText = "Email";
            dGVdsSinhVien.Columns[3].HeaderText = "Họ tên";
            dGVdsSinhVien.Columns[4].HeaderText = "Khóa";
            dGVdsSinhVien.Columns[5].HeaderText = "Giới tính";
            dGVdsSinhVien.Columns[6].HeaderText = "CMND";
            dGVdsSinhVien.Columns[7].HeaderText = "Ngày cấp";
            dGVdsSinhVien.Columns[8].HeaderText = "Nơi cấp";
            dGVdsSinhVien.Columns[9].HeaderText = "Dân tộc";
            dGVdsSinhVien.Columns[10].HeaderText = "Tôn giáo";
            dGVdsSinhVien.Columns[11].HeaderText = "SĐT";
            dGVdsSinhVien.Columns[12].HeaderText = "Địa chỉ";
            dGVdsSinhVien.Columns[13].HeaderText = "Mã HB";
            dGVdsSinhVien.Columns[14].HeaderText = "Mã ĐTƯT";
            #endregion
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                DapperPlusManager.Entity<SINHVIEN>().Table("SINHVIEN");
                List<SINHVIEN> sINHVIENs = sINHVIENBindingSource2.DataSource as List<SINHVIEN>;

                sINHVIENs.ForEach(x => x.Mahb = string.IsNullOrWhiteSpace(x.Mahb) ? null : x.Mahb);

                if (sINHVIENs != null)
                {
                    using (IDbConnection dbConnection = new SqlConnection(connectionString))
                    {
                        //Update & Insert
                        dbConnection.BulkMerge(sINHVIENs.ToArray());
                    }
                }
                MessageBox.Show("Thêm thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        private void FormInfoSV_Load(object sender, EventArgs e)
        {
            string dataSource = db.Database.Connection.DataSource;
            //string
            connectionString = $"Data Source={dataSource};Initial Catalog=DEMOQLKTX;Integrated Security=True";
            Properties.Settings.Default["DEMOQLKTXConnectionString"] = connectionString;
            // TODO: This line of code loads data into the 'dEMOQLKTXDataSet1.SINHVIEN' table. You can move, or remove it, as needed.
            this.sINHVIENTableAdapter1.Fill(this.dEMOQLKTXDataSet1.SINHVIEN);
            #region Header
            dGVdsSinhVien.Columns[0].HeaderText = "Mã SV";
            dGVdsSinhVien.Columns[1].HeaderText = "Ngày sinh";
            dGVdsSinhVien.Columns[2].HeaderText = "Email";
            dGVdsSinhVien.Columns[3].HeaderText = "Họ tên";
            dGVdsSinhVien.Columns[4].HeaderText = "Khóa";
            dGVdsSinhVien.Columns[5].HeaderText = "Giới tính";
            dGVdsSinhVien.Columns[6].HeaderText = "CMND";
            dGVdsSinhVien.Columns[7].HeaderText = "Ngày cấp";
            dGVdsSinhVien.Columns[8].HeaderText = "Nơi cấp";
            dGVdsSinhVien.Columns[9].HeaderText = "Dân tộc";
            dGVdsSinhVien.Columns[10].HeaderText = "Tôn giáo";
            dGVdsSinhVien.Columns[11].HeaderText = "SĐT";
            dGVdsSinhVien.Columns[12].HeaderText = "Địa chỉ";
            dGVdsSinhVien.Columns[13].HeaderText = "Mã HB";
            dGVdsSinhVien.Columns[14].HeaderText = "Mã ĐTƯT";
            #endregion
        }

        private void dGVdsSinhVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (Flag == false)
                {
                    #region Case 1
                    txtMasv.Text = dGVdsSinhVien.Rows[e.RowIndex].Cells[0].Value.ToString();
                    dtpNgaysinh.Value = (DateTime)dGVdsSinhVien.Rows[e.RowIndex].Cells[1].Value;
                    txtEmail.Text = (string)dGVdsSinhVien.Rows[e.RowIndex].Cells[2].Value;
                    txtHoten.Text = (string)dGVdsSinhVien.Rows[e.RowIndex].Cells[3].Value;
                    txtKhoa.Text = (string)dGVdsSinhVien.Rows[e.RowIndex].Cells[4].Value.ToString();
                    cbbGioitinh.Text = (string)dGVdsSinhVien.Rows[e.RowIndex].Cells[5].Value;
                    txtCmnd.Text = (string)dGVdsSinhVien.Rows[e.RowIndex].Cells[6].Value;
                    dtpNgaycap.Value = (DateTime)dGVdsSinhVien.Rows[e.RowIndex].Cells[7].Value;
                    txtNoicap.Text = (string)dGVdsSinhVien.Rows[e.RowIndex].Cells[8].Value;
                    txtDantoc.Text = (string)dGVdsSinhVien.Rows[e.RowIndex].Cells[9].Value;
                    txtTongiao.Text = (string)dGVdsSinhVien.Rows[e.RowIndex].Cells[10].Value;
                    txtSdt.Text = (string)dGVdsSinhVien.Rows[e.RowIndex].Cells[11].Value;
                    txtDiachi.Text = (string)dGVdsSinhVien.Rows[e.RowIndex].Cells[12].Value;
                    txtMaHB.Text = (string)dGVdsSinhVien.Rows[e.RowIndex].Cells[13].Value;
                    txtMaDTUT.Text = (string)dGVdsSinhVien.Rows[e.RowIndex].Cells[14].Value;
                    txtLinkImage.Text = (string)dGVdsSinhVien.Rows[e.RowIndex].Cells[15].Value;
                    #endregion
                }
                else
                {
                    #region Case 2
                    if (dGVdsSinhVien.Rows.Count > 0 && dGVdsSinhVien.Rows[e.RowIndex].Cells[e.ColumnIndex] != null)
                    {
                        if (!String.IsNullOrEmpty(dGVdsSinhVien.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()))
                        {
                            txtMasv.Text = dGVdsSinhVien.Rows[e.RowIndex].Cells[0].Value.ToString();
                            dtpNgaysinh.Text = dGVdsSinhVien.Rows[e.RowIndex].Cells[1].Value.ToString();
                            txtEmail.Text = dGVdsSinhVien.Rows[e.RowIndex].Cells[2].Value.ToString();
                            txtHoten.Text = dGVdsSinhVien.Rows[e.RowIndex].Cells[3].Value.ToString();
                            txtKhoa.Text = dGVdsSinhVien.Rows[e.RowIndex].Cells[4].Value.ToString();
                            cbbGioitinh.Text = dGVdsSinhVien.Rows[e.RowIndex].Cells[5].Value.ToString();
                            txtCmnd.Text = dGVdsSinhVien.Rows[e.RowIndex].Cells[6].Value.ToString();
                            dtpNgaycap.Text = dGVdsSinhVien.Rows[e.RowIndex].Cells[7].Value.ToString();
                            txtNoicap.Text = dGVdsSinhVien.Rows[e.RowIndex].Cells[8].Value.ToString();
                            txtDantoc.Text = dGVdsSinhVien.Rows[e.RowIndex].Cells[9].Value.ToString();
                            txtTongiao.Text = dGVdsSinhVien.Rows[e.RowIndex].Cells[10].Value.ToString();
                            txtSdt.Text = dGVdsSinhVien.Rows[e.RowIndex].Cells[11].Value.ToString();
                            txtDiachi.Text = dGVdsSinhVien.Rows[e.RowIndex].Cells[12].Value.ToString();
                            if (dGVdsSinhVien.Rows[e.RowIndex].Cells[13].Value != null)
                            {
                                txtMaHB.Text = dGVdsSinhVien.Rows[e.RowIndex].Cells[13].Value.ToString();
                            }
                            else
                                txtMaHB.Text = "";
                            if (dGVdsSinhVien.Rows[e.RowIndex].Cells[14].Value != null)
                            {
                                txtMaDTUT.Text = dGVdsSinhVien.Rows[e.RowIndex].Cells[14].Value.ToString();
                            }
                            else
                                txtMaDTUT.Text = "";
                            if (dGVdsSinhVien.Rows[e.RowIndex].Cells[15].Value != null)
                            {
                                txtLinkImage.Text = dGVdsSinhVien.Rows[e.RowIndex].Cells[15].Value.ToString();
                            }
                            else
                                txtLinkImage.Text = "";
                            //txtMaDTUT.Text = (string)dGVdsSinhVien.Rows[e.RowIndex].Cells[14].Value.ToString();
                            //txtLinkImage.Text = (string)dGVdsSinhVien.Rows[e.RowIndex].Cells[15].Value.ToString();
                        }
                    }
                    #endregion
                }

            }
            catch (Exception)
            {
            }

            //if (dGVdsSinhVien.Rows[e.RowIndex].Cells[13].Value != null)
            //    txtMaHB.Text = dGVdsSinhVien.Rows[e.RowIndex].Cells[13].Value.ToString();
            //else txtMaHB.Text = "";
            //if (dGVdsSinhVien.Rows[e.RowIndex].Cells[14].Value != null)
            //    txtMaDTUT.Text = dGVdsSinhVien.Rows[e.RowIndex].Cells[14].Value.ToString();
            //else txtMaDTUT.Text = "";


        }
        #region Thêm, xóa, sửa, tìm kiếm
        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddSV();
            LoadSV();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteSV();
            LoadSV();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditSv();
            LoadSV();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var result = from sv in db.SINHVIENs
                         where sv.Masv == txtTimkiem.Text
                         select new
                         {
                             sv.Masv,
                             sv.Ngaysinh,
                             sv.Email,
                             sv.Hoten,
                             sv.Khoa,
                             sv.Gioitinh,
                             sv.Cmnd,
                             sv.Ngaycap,
                             sv.Noicap,
                             sv.Dantoc,
                             sv.Tongiao,
                             sv.Sdt,
                             sv.Diachithuongtru,
                             sv.Mahb,
                             sv.MaDTUT
                         };
            dGVdsSinhVien.DataSource = result.ToList();
        }
        #endregion

        #endregion


    }
}
