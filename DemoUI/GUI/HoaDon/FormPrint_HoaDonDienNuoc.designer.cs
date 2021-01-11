namespace Rpt_Receipt_KTX
{
    partial class FormPrint_HoaDonDienNuoc
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrint_HoaDonDienNuoc));
            this.rptHDDienNuoc = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rptHDDienNuoc
            // 
            this.rptHDDienNuoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rptHDDienNuoc.LocalReport.ReportEmbeddedResource = "DemoUI.HoaDon.HoaDonDienNuoc.rdlc";
            this.rptHDDienNuoc.Location = new System.Drawing.Point(0, 0);
            this.rptHDDienNuoc.Name = "rptHDDienNuoc";
            this.rptHDDienNuoc.ServerReport.BearerToken = null;
            this.rptHDDienNuoc.Size = new System.Drawing.Size(649, 511);
            this.rptHDDienNuoc.TabIndex = 0;
            // 
            // FormPrint_HoaDonDienNuoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 511);
            this.Controls.Add(this.rptHDDienNuoc);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormPrint_HoaDonDienNuoc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hóa Đơn Điện Nước";
            this.Load += new System.EventHandler(this.FormPrint_HoaDonDienNuoc_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rptHDDienNuoc;
    }
}