namespace DemoUI
{
    partial class HistoryCheckIn
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HistoryCheckIn));
            this.dGV_SV = new Guna.UI2.WinForms.Guna2DataGridView();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.dtpTgian = new Bunifu.Framework.UI.BunifuDatepicker();
            this.txtSearchMaSV = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            ((System.ComponentModel.ISupportInitialize)(this.dGV_SV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // dGV_SV
            // 
            this.dGV_SV.AllowUserToAddRows = false;
            this.dGV_SV.AllowUserToOrderColumns = true;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(244)))));
            this.dGV_SV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dGV_SV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dGV_SV.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dGV_SV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dGV_SV.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dGV_SV.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGV_SV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dGV_SV.ColumnHeadersHeight = 50;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(234)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(186)))), ((int)(((byte)(231)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dGV_SV.DefaultCellStyle = dataGridViewCellStyle6;
            this.dGV_SV.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dGV_SV.EnableHeadersVisualStyles = false;
            this.dGV_SV.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(220)))), ((int)(((byte)(242)))));
            this.dGV_SV.Location = new System.Drawing.Point(0, 129);
            this.dGV_SV.Name = "dGV_SV";
            this.dGV_SV.ReadOnly = true;
            this.dGV_SV.RowHeadersVisible = false;
            this.dGV_SV.RowHeadersWidth = 62;
            this.dGV_SV.RowTemplate.Height = 33;
            this.dGV_SV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dGV_SV.Size = new System.Drawing.Size(445, 200);
            this.dGV_SV.TabIndex = 22;
            this.dGV_SV.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.FeterRiver;
            this.dGV_SV.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(244)))));
            this.dGV_SV.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dGV_SV.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dGV_SV.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dGV_SV.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dGV_SV.ThemeStyle.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dGV_SV.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(220)))), ((int)(((byte)(242)))));
            this.dGV_SV.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.dGV_SV.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dGV_SV.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dGV_SV.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dGV_SV.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dGV_SV.ThemeStyle.HeaderStyle.Height = 50;
            this.dGV_SV.ThemeStyle.ReadOnly = true;
            this.dGV_SV.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(234)))), ((int)(((byte)(247)))));
            this.dGV_SV.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dGV_SV.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dGV_SV.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dGV_SV.ThemeStyle.RowsStyle.Height = 33;
            this.dGV_SV.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(186)))), ((int)(((byte)(231)))));
            this.dGV_SV.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(393, 13);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(40, 35);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 25;
            this.pictureBox2.TabStop = false;
            // 
            // dtpTgian
            // 
            this.dtpTgian.BackColor = System.Drawing.Color.SeaGreen;
            this.dtpTgian.BorderRadius = 0;
            this.dtpTgian.ForeColor = System.Drawing.Color.White;
            this.dtpTgian.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpTgian.FormatCustom = null;
            this.dtpTgian.Location = new System.Drawing.Point(35, 66);
            this.dtpTgian.Name = "dtpTgian";
            this.dtpTgian.Size = new System.Drawing.Size(192, 36);
            this.dtpTgian.TabIndex = 26;
            this.dtpTgian.Value = new System.DateTime(2020, 6, 17, 20, 14, 41, 640);
            this.dtpTgian.onValueChanged += new System.EventHandler(this.dtpTgian_onValueChanged);
            // 
            // txtSearchMaSV
            // 
            this.txtSearchMaSV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(235)))), ((int)(((byte)(250)))));
            this.txtSearchMaSV.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearchMaSV.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchMaSV.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtSearchMaSV.HintForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtSearchMaSV.HintText = "Nhập Mã SV";
            this.txtSearchMaSV.isPassword = false;
            this.txtSearchMaSV.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.txtSearchMaSV.LineIdleColor = System.Drawing.Color.Gray;
            this.txtSearchMaSV.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.txtSearchMaSV.LineThickness = 3;
            this.txtSearchMaSV.Location = new System.Drawing.Point(35, 13);
            this.txtSearchMaSV.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearchMaSV.Name = "txtSearchMaSV";
            this.txtSearchMaSV.Size = new System.Drawing.Size(286, 35);
            this.txtSearchMaSV.TabIndex = 27;
            this.txtSearchMaSV.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // HistoryCheckIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 329);
            this.Controls.Add(this.txtSearchMaSV);
            this.Controls.Add(this.dtpTgian);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.dGV_SV);
            this.Name = "HistoryCheckIn";
            this.Text = "HistoryCheckIn";
            this.Load += new System.EventHandler(this.HistoryCheckIn_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dGV_SV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2DataGridView dGV_SV;
        private System.Windows.Forms.PictureBox pictureBox2;
        private Bunifu.Framework.UI.BunifuDatepicker dtpTgian;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtSearchMaSV;
    }
}