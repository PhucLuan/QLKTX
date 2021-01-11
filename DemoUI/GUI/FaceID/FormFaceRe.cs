using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Face;
using Emgu.CV.CvEnum;
using System.IO;
using System.Threading;
using System.Diagnostics;
using DemoUI;
using System.Reflection;

namespace Simple_Face_Recognition_App
{
    public partial class FormFaceRe : Form
    {
        #region Variables
        //int testid = 0;
        private Capture videoCapture = null;
        private Image<Bgr, Byte> currentFrame = null;
        Mat frame = new Mat();
        private bool facesDetectionEnabled = false;
        CascadeClassifier faceCasacdeClassifier = new CascadeClassifier("haarcascade_frontalface_alt.xml");//File chứa thuật toán
        //Image<Bgr, Byte> faceResult = null;
        List<Image<Gray, Byte>> TrainedFaces = new List<Image<Gray, byte>>();//với emgu 4 thì dùng Mat
        List<int> PersonsLabes = new List<int>();

        bool EnableSaveImage = false;//Đặt cờ cho ảnh đã được lưu
        private bool  isTrained = false;//Đặt cờ cho biết ảnh đã train xong
        EigenFaceRecognizer recognizer;
        LBPHFaceRecognizer recognizerLBPH;
        List<string> PersonsNames = new List<string>();
        List<string> results = new List<string>();//Danh sách mã tìm được từ quét mặt trong 1 frame

        bool Flat = false;//Đóng mở videocapture
        #endregion

        public FormFaceRe()
        {
            InitializeComponent();
            UserProfile.CurrentForm = this;
        }
        DEMOQLKTXEntities db = MyDb.GetInstance();

        //Hàm tìm kiếm sinh viên
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

        private void ShowInfo(SINHVIEN sinhVien)
        {
            try
            {
                if (sinhVien != null)
                {
                    //new Bitmap(Application.StartupPath + "\\Resources\\" + sinhVien.Masv.ToString().Trim() + ".jpg");
                    pictureBox_Hinh.ImageLocation = sinhVien.LinkImage;
                    lbMssv.Text = sinhVien.Masv;
                    lbDiaChi.Text = sinhVien.Diachithuongtru;
                    lbEmail.Text = sinhVien.Email;
                    lbGioiTinh.Text = sinhVien.Gioitinh;
                    lbHoten.Text = sinhVien.Hoten;
                    lbKhoa.Text = sinhVien.Khoa.ToString();
                    lbNgaySinh.Text = sinhVien.Ngaysinh.ToString();
                    lbSDT.Text = sinhVien.Sdt.ToString();
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Không có trong hệ thống");
            }

        }

        void AddCheckIn(SINHVIEN sinhVien)
        {
            try
            {
                if (sinhVien != null)
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

        //Quét mã
        void Scan()
        {
            //MessageBox.Show("Restar");
            Flat = true;
            results = new List<string>();
            if (videoCapture != null) videoCapture.Dispose();
            videoCapture = new Capture();
            videoCapture.ImageGrabbed += ProcessFrame;
            //Application.Idle += ProcessFrame;
            videoCapture.Start();
        }
        private void btnCapture_Click(object sender, EventArgs e)
        {
            //Dispose of Capture if it was created before
            Flat = true;
            timer1.Start();
            if (videoCapture != null) videoCapture.Dispose();
            videoCapture = new Capture();
            videoCapture.ImageGrabbed += ProcessFrame;
            //Application.Idle += ProcessFrame;
            videoCapture.Start();
        }

        private void ProcessFrame(object sender, EventArgs e)
        {
            //1: Bắt hình trên khung picturepox
            if (videoCapture != null && videoCapture.Ptr != IntPtr.Zero)
            {
                videoCapture.Retrieve(frame, 0);
                currentFrame = frame.ToImage<Bgr, Byte>().Resize(picCapture.Width, picCapture.Height, Inter.Cubic);

                //2: Phát hiện gương mặt
                if (facesDetectionEnabled)
                {
                    //Chuyển đổi từ Bgr(màu) sang Gray(trắng đen)
                    Mat grayImage = new Mat();
                    CvInvoke.CvtColor(currentFrame, grayImage, ColorConversion.Bgr2Gray);
                    //Tăng chất lượng ảnh
                    CvInvoke.EqualizeHist(grayImage, grayImage);

                    Rectangle[] faces = faceCasacdeClassifier.DetectMultiScale(grayImage, 1.1, 3, Size.Empty, Size.Empty);
                    //Nếu phát hiện được khuôn mặt
                    if (faces.Length > 0)
                    {

                        foreach (var face in faces)
                        {
                            //Vẽ ô vuông quanh khuôn mặt 
                           CvInvoke.Rectangle(currentFrame, face, new Bgr(Color.Red).MCvScalar, 2);

                            //3: Thêm ảnh để train 
                            //Thêm ảnh vào picturebox đối chiếu
                            Image<Bgr, Byte> resultImage = currentFrame.Convert<Bgr, Byte>();
                            resultImage.ROI = face;
                            picDetected.SizeMode = PictureBoxSizeMode.StretchImage;
                            picDetected.Image = resultImage.Bitmap;

                            if (EnableSaveImage)
                            {
                                //Tạo thư mục lưu hình training nếu thư mục chưa tồn tại
                                string path = Directory.GetCurrentDirectory() + @"\TrainedImages";
                                if (!Directory.Exists(path))
                                    Directory.CreateDirectory(path);
                                //Lưu 10 ảnh cho việc train gương mặt 
                                //Tạo task mới để tránh treo GUI
                                Task.Factory.StartNew(() => {
                                    for (int i = 0; i < 10; i++)
                                    {
                                        //resize hình sau khi lưu
                                        resultImage.Resize(200, 200, Inter.Cubic).Save(path + @"\" + txtPersonName.Text +"_"+ DateTime.Now.ToString("dd-mm-yyyy-hh-mm-ss") + ".jpg");
                                        Thread.Sleep(1000);
                                        if (i == 10)
                                        {
                                            MessageBox.Show("Training hoàn tất");
                                        }
                                    }
                                });

                            }
                            EnableSaveImage = false;

                            if (btnAddPerson.InvokeRequired)
                            {
                                btnAddPerson.Invoke(new ThreadStart(delegate {
                                    btnAddPerson.Enabled = true;
                                }));
                            }

                            // 5: Phát hiện gương mặt 
                            if (isTrained)
                            {
                                Image<Gray, Byte> grayFaceResult = resultImage.Convert<Gray, Byte>().Resize(200,200,Inter.Cubic);
                                CvInvoke.EqualizeHist(grayFaceResult,grayFaceResult);
                                var result = recognizer.Predict(grayFaceResult);
                                var LBPresult = recognizerLBPH.Predict(grayFaceResult);
                                pictureBox1.Image = grayFaceResult.Bitmap;
                                pictureBox2.Image = TrainedFaces[LBPresult.Label].Bitmap;
                                Debug.WriteLine(result.Label+". "+result.Distance);
                                //Kết quả khi phát hiện gương mặt
                                if (LBPresult.Label != -1 && LBPresult.Distance < 500)
                                {
                                    CvInvoke.PutText(currentFrame, PersonsNames[LBPresult.Label], new Point(face.X - 2, face.Y - 2),
                                        FontFace.HersheyComplex, 1.0, new Bgr(Color.Orange).MCvScalar);
                                    CvInvoke.Rectangle(currentFrame, face, new Bgr(Color.Green).MCvScalar, 2);
                                    //MessageBox.Show(PersonsNames[LBPresult.Label]);
                                    if (PersonsNames[LBPresult.Label] != null)
                                    {
                                        txtFaceID.Invoke(new MethodInvoker(delegate ()
                                        {
                                            txtFaceID.Text = PersonsNames[LBPresult.Label].ToString();
                                            results.Add(txtFaceID.Text);
                                        }));
                                        PersonsNames[LBPresult.Label] = null;
                                    }
                                    else
                                    {
                                        if (results.Any())
                                        {
                                            string res = results.FirstOrDefault(x => x != null);
                                            SINHVIEN sv = TimKiem(txtFaceID.Text);
                                            Invoke(new Action(() =>
                                            {
                                                ShowInfo(sv);
                                            }));
                                            AddCheckIn(sv);
                                            Flat = false;
                                            videoCapture.Stop();
                                        }
                                    }
                                }
                                //Nếu mặt không có trong dữ liệu
                                else
                                {
                                    CvInvoke.PutText(currentFrame, "Unknown", new Point(face.X - 2, face.Y - 2),
                                        FontFace.HersheyComplex, 1.0, new Bgr(Color.Orange).MCvScalar);
                                    CvInvoke.Rectangle(currentFrame, face, new Bgr(Color.Red).MCvScalar, 2);

                                }
                            }
                        }
                    }
                }

                //Xuất video capture lên Picture Box picCapture
                picCapture.Image = currentFrame.Bitmap;
            }

            //Dispose Frame hiện tại sau khi chạy processing
            if (currentFrame != null)
                currentFrame.Dispose();
        }

        private void btnDetectFaces_Click(object sender, EventArgs e)
        {
            facesDetectionEnabled = true;
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            btnAddPerson.Enabled = false;
            EnableSaveImage = true;
        }

        private void btnTrain_Click(object sender, EventArgs e)
        {
            TrainImagesFromDir();
        }
        //4: train hình //sử dụng các hình ảnh đã lưu từ bước 3 
        private bool TrainImagesFromDir()
        {
            int ImagesCount = 0;
            double Threshold = 7000;
            TrainedFaces.Clear();
            PersonsLabes.Clear();
            PersonsNames.Clear();
            try
            {
                string path = Directory.GetCurrentDirectory() + @"\TrainedImages";
                string[] files = Directory.GetFiles(path, "*.jpg", SearchOption.AllDirectories);

                foreach (var file in files)
                {
                    Image<Gray, byte> trainedImage = new Image<Gray, byte>(file).Resize(200,200,Inter.Cubic);
                    CvInvoke.EqualizeHist(trainedImage,trainedImage);
                    TrainedFaces.Add(trainedImage);
                    PersonsLabes.Add(ImagesCount);
                    string name = file.Split('\\').Last().Split('_')[0]; 
                    PersonsNames.Add(name);
                    ImagesCount++;
                    Debug.WriteLine(ImagesCount + ". " +name);

                }

                if (TrainedFaces.Count() > 0)
                {
                    // recognizer = new EigenFaceRecognizer(ImagesCount,Threshold);
                    recognizer = new EigenFaceRecognizer(ImagesCount, Threshold);
                    recognizer.Train(TrainedFaces.ToArray(), PersonsLabes.ToArray());
                    recognizerLBPH = new LBPHFaceRecognizer(ImagesCount, 10, 10, 10, Threshold);
                    recognizerLBPH.Train(TrainedFaces.ToArray(), PersonsLabes.ToArray());
                    isTrained = true;
                    //Debug.WriteLine(ImagesCount);
                    //Debug.WriteLine(isTrained);
                    return true;
                }
                else
                {
                    isTrained = false;
                    return false;
                }
            }
            catch (Exception ex)
            {
                isTrained = false;                
                MessageBox.Show("Error in Train Images: " + ex.Message);
                return false;
            }
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void FormFaceRe_FormClosing(object sender, FormClosingEventArgs e)
        {
            //this.Close();
            //Application.Exit();
            if (videoCapture != null)
            {
                videoCapture.Stop();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            if (Flat == false)
            {
                results = new List<string>();
                Scan();
            }
        }

        private void iBtnHistory_Click(object sender, EventArgs e)
        {
            HistoryCheckIn historyCheckIn = new HistoryCheckIn();
            historyCheckIn.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
