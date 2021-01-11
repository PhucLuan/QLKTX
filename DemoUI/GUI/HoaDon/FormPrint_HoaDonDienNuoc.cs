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
    public partial class FormPrint_HoaDonDienNuoc : Form
    {
        HOADONDIENNUOC _hoaDONDIENNUOC;
        public FormPrint_HoaDonDienNuoc(HOADONDIENNUOC hoaDONDIENNUOC)
        {
            InitializeComponent();
            _hoaDONDIENNUOC = hoaDONDIENNUOC;
            //UserProfile.CurrentForm = this;
        }

        private void FormPrint_HoaDonDienNuoc_Load(object sender, EventArgs e)
        {
            Microsoft.Reporting.WinForms.ReportParameter[] p =
                new Microsoft.Reporting.WinForms.ReportParameter[]
                {
                    new Microsoft.Reporting.WinForms.ReportParameter("pMaHD",_hoaDONDIENNUOC.Mahdn.ToString()),
                    new Microsoft.Reporting.WinForms.ReportParameter("pNgayLap",_hoaDONDIENNUOC.Ngaylap.ToString()),
                    new Microsoft.Reporting.WinForms.ReportParameter("pSoPhong",_hoaDONDIENNUOC.Sophong.ToString()),
                    new Microsoft.Reporting.WinForms.ReportParameter("pHDThang",_hoaDONDIENNUOC.HDThang.ToString()),
                    new Microsoft.Reporting.WinForms.ReportParameter("pSokidien",_hoaDONDIENNUOC.Sokidien.ToString()),
                    new Microsoft.Reporting.WinForms.ReportParameter("pSokhoinuoc",_hoaDONDIENNUOC.Sokhoinuoc.ToString()),
                    new Microsoft.Reporting.WinForms.ReportParameter("pDongiaDien",_hoaDONDIENNUOC.Dongiadien.ToString()),
                    new Microsoft.Reporting.WinForms.ReportParameter("pDongiaNuoc",_hoaDONDIENNUOC.Dongianuoc.ToString()),
                    new Microsoft.Reporting.WinForms.ReportParameter("pTongTien",_hoaDONDIENNUOC.Tongtien.ToString()),
                    new Microsoft.Reporting.WinForms.ReportParameter("pTienNuoc",(_hoaDONDIENNUOC.Sokhoinuoc*_hoaDONDIENNUOC.Dongianuoc).ToString()),
                    new Microsoft.Reporting.WinForms.ReportParameter("pTienDien",(_hoaDONDIENNUOC.Sokidien*_hoaDONDIENNUOC.Dongiadien).ToString()),
                };
            this.rptHDDienNuoc.LocalReport.SetParameters(p);
            this.rptHDDienNuoc.RefreshReport();
        }
    }
}
