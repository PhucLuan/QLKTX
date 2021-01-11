namespace DemoUI
{
    partial class FormThongKe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormThongKe));
            this.btnPhong = new Guna.UI2.WinForms.Guna2Button();
            this.btnPhiKTX = new Guna.UI2.WinForms.Guna2Button();
            this.btnHDDiennuoc = new Guna.UI2.WinForms.Guna2Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPhong
            // 
            this.btnPhong.CheckedState.Parent = this.btnPhong;
            this.btnPhong.CustomImages.Parent = this.btnPhong;
            this.btnPhong.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnPhong.ForeColor = System.Drawing.Color.White;
            this.btnPhong.HoverState.Parent = this.btnPhong;
            this.btnPhong.Image = ((System.Drawing.Image)(resources.GetObject("btnPhong.Image")));
            this.btnPhong.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnPhong.ImageSize = new System.Drawing.Size(50, 50);
            this.btnPhong.Location = new System.Drawing.Point(24, 127);
            this.btnPhong.Name = "btnPhong";
            this.btnPhong.ShadowDecoration.Parent = this.btnPhong;
            this.btnPhong.Size = new System.Drawing.Size(199, 67);
            this.btnPhong.TabIndex = 0;
            this.btnPhong.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnPhong.Click += new System.EventHandler(this.btnPhong_Click);
            // 
            // btnPhiKTX
            // 
            this.btnPhiKTX.CheckedState.Parent = this.btnPhiKTX;
            this.btnPhiKTX.CustomImages.Parent = this.btnPhiKTX;
            this.btnPhiKTX.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnPhiKTX.ForeColor = System.Drawing.Color.White;
            this.btnPhiKTX.HoverState.Parent = this.btnPhiKTX;
            this.btnPhiKTX.Image = ((System.Drawing.Image)(resources.GetObject("btnPhiKTX.Image")));
            this.btnPhiKTX.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnPhiKTX.ImageSize = new System.Drawing.Size(50, 50);
            this.btnPhiKTX.Location = new System.Drawing.Point(24, 228);
            this.btnPhiKTX.Name = "btnPhiKTX";
            this.btnPhiKTX.ShadowDecoration.Parent = this.btnPhiKTX;
            this.btnPhiKTX.Size = new System.Drawing.Size(199, 67);
            this.btnPhiKTX.TabIndex = 0;
            this.btnPhiKTX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnPhiKTX.Click += new System.EventHandler(this.btnPhiKTX_Click);
            // 
            // btnHDDiennuoc
            // 
            this.btnHDDiennuoc.CheckedState.Parent = this.btnHDDiennuoc;
            this.btnHDDiennuoc.CustomImages.Parent = this.btnHDDiennuoc;
            this.btnHDDiennuoc.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnHDDiennuoc.ForeColor = System.Drawing.Color.White;
            this.btnHDDiennuoc.HoverState.Parent = this.btnHDDiennuoc;
            this.btnHDDiennuoc.Image = ((System.Drawing.Image)(resources.GetObject("btnHDDiennuoc.Image")));
            this.btnHDDiennuoc.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnHDDiennuoc.ImageSize = new System.Drawing.Size(35, 35);
            this.btnHDDiennuoc.Location = new System.Drawing.Point(24, 331);
            this.btnHDDiennuoc.Name = "btnHDDiennuoc";
            this.btnHDDiennuoc.ShadowDecoration.Parent = this.btnHDDiennuoc;
            this.btnHDDiennuoc.Size = new System.Drawing.Size(199, 67);
            this.btnHDDiennuoc.TabIndex = 0;
            this.btnHDDiennuoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnHDDiennuoc.Click += new System.EventHandler(this.btnHDDiennuoc_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(229, -28);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(575, 569);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // FormThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 534);
            this.Controls.Add(this.btnHDDiennuoc);
            this.Controls.Add(this.btnPhiKTX);
            this.Controls.Add(this.btnPhong);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormThongKe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thống kê Kí túc xá";
            this.Load += new System.EventHandler(this.FormThongKe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnPhong;
        private Guna.UI2.WinForms.Guna2Button btnPhiKTX;
        private Guna.UI2.WinForms.Guna2Button btnHDDiennuoc;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}