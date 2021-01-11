using AForge.Video;
using AForge.Video.DirectShow;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using System.Data.SqlClient;
using DemoUI;

namespace ScanBarCode
{
    public partial class FormScanCode : Form
    {
        public FormScanCode()
        {
            InitializeComponent();
            UserProfile.CurrentForm = this;
        }

        FilterInfoCollection FilterInfoCollection;
        VideoCaptureDevice VideoCaptureDevice;
        private FormProfile activeForm = null;//Đóng mở form con
        DEMOQLKTXEntities db = MyDb.GetInstance();
        
        #region Method
        //Load form 
        void LoadFormScan()
        {
            FilterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo device in FilterInfoCollection)
                cbCamera.Items.Add(device.Name);
            cbCamera.SelectedIndex = 0;
            VideoCaptureDevice = new VideoCaptureDevice(FilterInfoCollection[cbCamera.SelectedIndex].MonikerString);
            VideoCaptureDevice.NewFrame += VideoCaptureDevice_NewFrame;
        }

        //Quét mã
        void Scan()
        {
            results = new List<string>();
            VideoCaptureDevice.Start();
        }

        //Mở form con
        private void openChildForm(FormProfile childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = childForm;
            childForm.FormBorderStyle = FormBorderStyle.FixedDialog;
            childForm.BringToFront();
            childForm.ShowDialog();

        }

        public SINHVIEN TimKiem(string valueToSearch)
        {
            SINHVIEN sinhVien = db.SINHVIENs.Where(p => p.Masv == valueToSearch).SingleOrDefault();
            if (sinhVien != null)
            {
                return sinhVien;
            }
            else
                MessageBox.Show("Không có trong hệ thống");
            return sinhVien;
        }

        //Show thông tin sinh viên tìm được lên màn hình
        private void ShowInfo(SINHVIEN sinhVien)
        {
            try
            {
                if (sinhVien != null)
                {
                    pictureBox_Hinh.ImageLocation = sinhVien.LinkImage;
                    lbMssv.Text = sinhVien.Masv;
                    lbCMND.Text = sinhVien.Cmnd;
                    lbDanToc.Text = sinhVien.Dantoc;
                    lbDiaChi.Text = sinhVien.Diachithuongtru;
                    lbEmail.Text = sinhVien.Email;
                    lbGioiTinh.Text = sinhVien.Gioitinh;
                    lbHoten.Text = sinhVien.Hoten;
                    lbKhoa.Text = sinhVien.Khoa.ToString();
                    lbNgaySinh.Text = sinhVien.Ngaysinh.ToString();
                    lbNoiCap.Text = sinhVien.Noicap;
                    lbSDT.Text = sinhVien.Sdt.ToString();
                    lbTonGiao.Text = sinhVien.Tongiao;
                    lbMaDTUT.Text = sinhVien.MaDTUT;
                    lbNgayCap.Text = sinhVien.Ngaycap.ToString();
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Không có trong hệ thống");
            }
            
        }

        //Thêm vào lịch sử check in
        void AddCheckIn(SINHVIEN sinhVien)
        {
            try
            {
                if (sinhVien!=null)
                {
                    CheckIn checkIn = new CheckIn();
                    checkIn.Masv = sinhVien.Masv;
                    checkIn.ThoiGian = DateTime.Now;
                    //MessageBox.Show(DateTime.Now.ToString());                
                    db.CheckIns.Add(checkIn);
                    db.SaveChanges();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        #endregion

        #region Event
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadFormScan();
        }

        //Danh sách các mã code quét được trong thời gian quét-Do trong tgian ngắn có thể quét nhiều frame
        List<string> results = null;
       
        //Bắt frame mới từ camera
        private void VideoCaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            try
            {
                Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
                BarcodeReader reader = new BarcodeReader();
                Result result = reader.Decode(bitmap);
                //Kiểm tra nếu quét được barcode thì thêm barcode vào ds nếu ko thì load sv và thêm vào bảng check in
                if (result != null)
                {
                    txtBarcode.Invoke(new MethodInvoker(delegate ()
                    {
                        txtBarcode.Text = result.ToString();
                        results.Add(txtBarcode.Text);
                    }));
                    result = null;
                }
                else
                {
                    if (results.Any())
                    {
                        string res = results.FirstOrDefault(x => x != null);
                        SINHVIEN sv = TimKiem(res);
                        Invoke(new Action(() =>
                        {
                            ShowInfo(sv);
                        }));
                        AddCheckIn(sv);
                        VideoCaptureDevice.SignalToStop();//Dừng quét mã
                    }
                }

                pictureBox1.Image = bitmap;

            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (VideoCaptureDevice != null)
            {
                if (VideoCaptureDevice.IsRunning)
                {
                    VideoCaptureDevice.Stop();

                }
            }
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            timer1.Start();
            Scan();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void iBtnHistory_Click(object sender, EventArgs e)
        {
            HistoryCheckIn historyCheckIn = new HistoryCheckIn();
            historyCheckIn.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!VideoCaptureDevice.IsRunning)
            {
                Scan();
            }
        }
        #endregion


    }
}
