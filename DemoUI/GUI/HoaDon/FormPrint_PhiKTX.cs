using DemoUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rpt_Receipt_KTX
{
    public partial class FormPrint_PhiKTX : Form
    {
        PHIKTX _phiKTX;
        SINHVIEN _sinhVien;
        public FormPrint_PhiKTX(PHIKTX phiKTX, SINHVIEN sinhVien)
        {
            InitializeComponent();
            _phiKTX = phiKTX;
            _sinhVien = sinhVien;
            //UserProfile.CurrentForm = this;
        }

        private void FormPrint_Load(object sender, EventArgs e)
        {
            Microsoft.Reporting.WinForms.ReportParameter[] p =
                new Microsoft.Reporting.WinForms.ReportParameter[]
                {
                    new Microsoft.Reporting.WinForms.ReportParameter("pMaBienLai", _phiKTX.Mabienlai.ToString()),
                    new Microsoft.Reporting.WinForms.ReportParameter("pNgayThu", _phiKTX.Ngaythu.ToString()),
                    new Microsoft.Reporting.WinForms.ReportParameter("pNamHoc", _phiKTX.Namhoc.ToString()),
                    new Microsoft.Reporting.WinForms.ReportParameter("pSoPhong", _phiKTX.Sophong.ToString()),
                    new Microsoft.Reporting.WinForms.ReportParameter("pSoTien", _phiKTX.Sotien.ToString()),
                    new Microsoft.Reporting.WinForms.ReportParameter("pSoThang", _phiKTX.Sothang.ToString()),
                    new Microsoft.Reporting.WinForms.ReportParameter("pMaSV", _phiKTX.Masv.ToString()),
                    new Microsoft.Reporting.WinForms.ReportParameter("pTenSV", _sinhVien.Hoten.ToString())
                };
            this.rptPhiKTX.LocalReport.SetParameters(p);
            this.rptPhiKTX.RefreshReport();
        }
    }
}
