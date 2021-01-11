namespace WindowsFormsApp3
{
    partial class FormNV_Buni
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNV_Buni));
            this.dTPNgSinh = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_MaNV = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.txt_sdt = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.txt_diachi = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.txt_Hoten = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.txtTimkiem = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.dGV_NV = new Guna.UI2.WinForms.Guna2DataGridView();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2Elipse2 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtUN = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.txtPW = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboChucVu = new System.Windows.Forms.ComboBox();
            this.iBtnRefresh = new FontAwesome.Sharp.IconButton();
            this.picBoxSearch = new System.Windows.Forms.PictureBox();
            this.btn_them = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btn_xoa = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btn_sua = new Bunifu.Framework.UI.BunifuFlatButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dGV_NV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dTPNgSinh
            // 
            this.dTPNgSinh.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dTPNgSinh.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dTPNgSinh.Location = new System.Drawing.Point(137, 308);
            this.dTPNgSinh.Margin = new System.Windows.Forms.Padding(2);
            this.dTPNgSinh.Name = "dTPNgSinh";
            this.dTPNgSinh.Size = new System.Drawing.Size(152, 26);
            this.dTPNgSinh.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label1.Location = new System.Drawing.Point(19, 225);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = "Mã nhân viên:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label2.Location = new System.Drawing.Point(19, 267);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 18);
            this.label2.TabIndex = 7;
            this.label2.Text = "Họ tên:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label3.Location = new System.Drawing.Point(19, 316);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 18);
            this.label3.TabIndex = 8;
            this.label3.Text = "Ngày sinh:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label4.Location = new System.Drawing.Point(19, 359);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 18);
            this.label4.TabIndex = 9;
            this.label4.Text = "Số điện thoại:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label5.Location = new System.Drawing.Point(21, 397);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 18);
            this.label5.TabIndex = 10;
            this.label5.Text = "Địa chỉ:";
            // 
            // txt_MaNV
            // 
            this.txt_MaNV.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_MaNV.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_MaNV.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_MaNV.HintForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_MaNV.HintText = "Nhap ma nhan vien";
            this.txt_MaNV.isPassword = false;
            this.txt_MaNV.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.txt_MaNV.LineIdleColor = System.Drawing.Color.Gray;
            this.txt_MaNV.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.txt_MaNV.LineThickness = 3;
            this.txt_MaNV.Location = new System.Drawing.Point(137, 209);
            this.txt_MaNV.Margin = new System.Windows.Forms.Padding(4);
            this.txt_MaNV.Name = "txt_MaNV";
            this.txt_MaNV.Size = new System.Drawing.Size(152, 32);
            this.txt_MaNV.TabIndex = 11;
            this.txt_MaNV.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // txt_sdt
            // 
            this.txt_sdt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_sdt.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txt_sdt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_sdt.HintForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_sdt.HintText = "Nhap so dien thoai";
            this.txt_sdt.isPassword = false;
            this.txt_sdt.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.txt_sdt.LineIdleColor = System.Drawing.Color.Gray;
            this.txt_sdt.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.txt_sdt.LineThickness = 3;
            this.txt_sdt.Location = new System.Drawing.Point(137, 345);
            this.txt_sdt.Margin = new System.Windows.Forms.Padding(4);
            this.txt_sdt.Name = "txt_sdt";
            this.txt_sdt.Size = new System.Drawing.Size(152, 32);
            this.txt_sdt.TabIndex = 12;
            this.txt_sdt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // txt_diachi
            // 
            this.txt_diachi.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_diachi.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txt_diachi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_diachi.HintForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_diachi.HintText = "Nhap dia chi";
            this.txt_diachi.isPassword = false;
            this.txt_diachi.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.txt_diachi.LineIdleColor = System.Drawing.Color.Gray;
            this.txt_diachi.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.txt_diachi.LineThickness = 3;
            this.txt_diachi.Location = new System.Drawing.Point(137, 383);
            this.txt_diachi.Margin = new System.Windows.Forms.Padding(4);
            this.txt_diachi.Name = "txt_diachi";
            this.txt_diachi.Size = new System.Drawing.Size(152, 32);
            this.txt_diachi.TabIndex = 13;
            this.txt_diachi.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // txt_Hoten
            // 
            this.txt_Hoten.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_Hoten.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txt_Hoten.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_Hoten.HintForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_Hoten.HintText = "Nhap ho ten";
            this.txt_Hoten.isPassword = false;
            this.txt_Hoten.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.txt_Hoten.LineIdleColor = System.Drawing.Color.Gray;
            this.txt_Hoten.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.txt_Hoten.LineThickness = 3;
            this.txt_Hoten.Location = new System.Drawing.Point(137, 253);
            this.txt_Hoten.Margin = new System.Windows.Forms.Padding(4);
            this.txt_Hoten.Name = "txt_Hoten";
            this.txt_Hoten.Size = new System.Drawing.Size(152, 32);
            this.txt_Hoten.TabIndex = 14;
            this.txt_Hoten.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // txtTimkiem
            // 
            this.txtTimkiem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(235)))), ((int)(((byte)(250)))));
            this.txtTimkiem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.txtTimkiem.BorderColorFocused = System.Drawing.Color.Empty;
            this.txtTimkiem.BorderColorIdle = System.Drawing.Color.Empty;
            this.txtTimkiem.BorderColorMouseHover = System.Drawing.Color.Empty;
            this.txtTimkiem.BorderThickness = 3;
            this.txtTimkiem.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTimkiem.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtTimkiem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtTimkiem.isPassword = false;
            this.txtTimkiem.Location = new System.Drawing.Point(59, 14);
            this.txtTimkiem.Margin = new System.Windows.Forms.Padding(4);
            this.txtTimkiem.Name = "txtTimkiem";
            this.txtTimkiem.Padding = new System.Windows.Forms.Padding(0, 0, 0, 13);
            this.txtTimkiem.Size = new System.Drawing.Size(441, 35);
            this.txtTimkiem.TabIndex = 19;
            this.txtTimkiem.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // dGV_NV
            // 
            this.dGV_NV.AllowUserToAddRows = false;
            this.dGV_NV.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(244)))));
            this.dGV_NV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dGV_NV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dGV_NV.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dGV_NV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dGV_NV.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dGV_NV.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGV_NV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dGV_NV.ColumnHeadersHeight = 50;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(234)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(186)))), ((int)(((byte)(231)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dGV_NV.DefaultCellStyle = dataGridViewCellStyle3;
            this.dGV_NV.EnableHeadersVisualStyles = false;
            this.dGV_NV.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(220)))), ((int)(((byte)(242)))));
            this.dGV_NV.Location = new System.Drawing.Point(23, 54);
            this.dGV_NV.Name = "dGV_NV";
            this.dGV_NV.RowHeadersVisible = false;
            this.dGV_NV.RowHeadersWidth = 62;
            this.dGV_NV.RowTemplate.Height = 33;
            this.dGV_NV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dGV_NV.Size = new System.Drawing.Size(608, 148);
            this.dGV_NV.TabIndex = 21;
            this.dGV_NV.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.FeterRiver;
            this.dGV_NV.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(244)))));
            this.dGV_NV.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dGV_NV.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dGV_NV.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dGV_NV.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dGV_NV.ThemeStyle.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dGV_NV.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(220)))), ((int)(((byte)(242)))));
            this.dGV_NV.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.dGV_NV.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dGV_NV.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dGV_NV.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dGV_NV.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dGV_NV.ThemeStyle.HeaderStyle.Height = 50;
            this.dGV_NV.ThemeStyle.ReadOnly = false;
            this.dGV_NV.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(234)))), ((int)(((byte)(247)))));
            this.dGV_NV.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dGV_NV.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dGV_NV.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dGV_NV.ThemeStyle.RowsStyle.Height = 33;
            this.dGV_NV.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(186)))), ((int)(((byte)(231)))));
            this.dGV_NV.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dGV_NV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGV_NV_CellClick);
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.TargetControl = this.dGV_NV;
            // 
            // guna2Elipse2
            // 
            this.guna2Elipse2.BorderRadius = 30;
            this.guna2Elipse2.TargetControl = this.txtTimkiem;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label6.Location = new System.Drawing.Point(21, 437);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 18);
            this.label6.TabIndex = 24;
            this.label6.Text = "UserName:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label7.Location = new System.Drawing.Point(21, 470);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 18);
            this.label7.TabIndex = 25;
            this.label7.Text = "Password:";
            // 
            // txtUN
            // 
            this.txtUN.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUN.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtUN.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtUN.HintForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtUN.HintText = "Username";
            this.txtUN.isPassword = false;
            this.txtUN.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.txtUN.LineIdleColor = System.Drawing.Color.Gray;
            this.txtUN.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.txtUN.LineThickness = 3;
            this.txtUN.Location = new System.Drawing.Point(137, 423);
            this.txtUN.Margin = new System.Windows.Forms.Padding(4);
            this.txtUN.Name = "txtUN";
            this.txtUN.Size = new System.Drawing.Size(152, 32);
            this.txtUN.TabIndex = 26;
            this.txtUN.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // txtPW
            // 
            this.txtPW.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPW.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtPW.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtPW.HintForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtPW.HintText = "Password";
            this.txtPW.isPassword = false;
            this.txtPW.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.txtPW.LineIdleColor = System.Drawing.Color.Gray;
            this.txtPW.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.txtPW.LineThickness = 3;
            this.txtPW.Location = new System.Drawing.Point(137, 456);
            this.txtPW.Margin = new System.Windows.Forms.Padding(4);
            this.txtPW.Name = "txtPW";
            this.txtPW.Size = new System.Drawing.Size(152, 32);
            this.txtPW.TabIndex = 27;
            this.txtPW.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label8.Location = new System.Drawing.Point(295, 223);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 18);
            this.label8.TabIndex = 28;
            this.label8.Text = "Chức vụ:";
            // 
            // cboChucVu
            // 
            this.cboChucVu.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboChucVu.FormattingEnabled = true;
            this.cboChucVu.Items.AddRange(new object[] {
            "Manage",
            "Accountant",
            "Guard"});
            this.cboChucVu.Location = new System.Drawing.Point(366, 216);
            this.cboChucVu.Name = "cboChucVu";
            this.cboChucVu.Size = new System.Drawing.Size(95, 25);
            this.cboChucVu.TabIndex = 30;
            // 
            // iBtnRefresh
            // 
            this.iBtnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.iBtnRefresh.FlatAppearance.BorderSize = 0;
            this.iBtnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iBtnRefresh.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.iBtnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iBtnRefresh.ForeColor = System.Drawing.Color.White;
            this.iBtnRefresh.IconChar = FontAwesome.Sharp.IconChar.History;
            this.iBtnRefresh.IconColor = System.Drawing.Color.White;
            this.iBtnRefresh.IconSize = 20;
            this.iBtnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iBtnRefresh.Location = new System.Drawing.Point(648, 200);
            this.iBtnRefresh.Name = "iBtnRefresh";
            this.iBtnRefresh.Rotation = 0D;
            this.iBtnRefresh.Size = new System.Drawing.Size(102, 41);
            this.iBtnRefresh.TabIndex = 71;
            this.iBtnRefresh.Text = "Làm mới";
            this.iBtnRefresh.UseVisualStyleBackColor = false;
            this.iBtnRefresh.Click += new System.EventHandler(this.iBtnRefresh_Click);
            // 
            // picBoxSearch
            // 
            this.picBoxSearch.Image = ((System.Drawing.Image)(resources.GetObject("picBoxSearch.Image")));
            this.picBoxSearch.Location = new System.Drawing.Point(507, 14);
            this.picBoxSearch.Name = "picBoxSearch";
            this.picBoxSearch.Size = new System.Drawing.Size(40, 35);
            this.picBoxSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxSearch.TabIndex = 23;
            this.picBoxSearch.TabStop = false;
            this.picBoxSearch.Click += new System.EventHandler(this.picBoxSearch_Click);
            // 
            // btn_them
            // 
            this.btn_them.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btn_them.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btn_them.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_them.BorderRadius = 0;
            this.btn_them.ButtonText = "Thêm";
            this.btn_them.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_them.DisabledColor = System.Drawing.Color.Gray;
            this.btn_them.Iconcolor = System.Drawing.Color.Transparent;
            this.btn_them.Iconimage = ((System.Drawing.Image)(resources.GetObject("btn_them.Iconimage")));
            this.btn_them.Iconimage_right = null;
            this.btn_them.Iconimage_right_Selected = null;
            this.btn_them.Iconimage_Selected = null;
            this.btn_them.IconMarginLeft = 10;
            this.btn_them.IconMarginRight = 0;
            this.btn_them.IconRightVisible = true;
            this.btn_them.IconRightZoom = 0D;
            this.btn_them.IconVisible = true;
            this.btn_them.IconZoom = 40D;
            this.btn_them.IsTab = false;
            this.btn_them.Location = new System.Drawing.Point(648, 54);
            this.btn_them.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_them.Name = "btn_them";
            this.btn_them.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btn_them.OnHovercolor = System.Drawing.Color.SteelBlue;
            this.btn_them.OnHoverTextColor = System.Drawing.Color.White;
            this.btn_them.selected = false;
            this.btn_them.Size = new System.Drawing.Size(102, 41);
            this.btn_them.TabIndex = 18;
            this.btn_them.Text = "Thêm";
            this.btn_them.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_them.Textcolor = System.Drawing.Color.White;
            this.btn_them.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_them.Click += new System.EventHandler(this.btn_them_Click);
            // 
            // btn_xoa
            // 
            this.btn_xoa.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btn_xoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btn_xoa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_xoa.BorderRadius = 0;
            this.btn_xoa.ButtonText = "Xoá";
            this.btn_xoa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_xoa.DisabledColor = System.Drawing.Color.Gray;
            this.btn_xoa.Iconcolor = System.Drawing.Color.Transparent;
            this.btn_xoa.Iconimage = ((System.Drawing.Image)(resources.GetObject("btn_xoa.Iconimage")));
            this.btn_xoa.Iconimage_right = null;
            this.btn_xoa.Iconimage_right_Selected = null;
            this.btn_xoa.Iconimage_Selected = null;
            this.btn_xoa.IconMarginLeft = 10;
            this.btn_xoa.IconMarginRight = 0;
            this.btn_xoa.IconRightVisible = true;
            this.btn_xoa.IconRightZoom = 0D;
            this.btn_xoa.IconVisible = true;
            this.btn_xoa.IconZoom = 40D;
            this.btn_xoa.IsTab = false;
            this.btn_xoa.Location = new System.Drawing.Point(648, 150);
            this.btn_xoa.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_xoa.Name = "btn_xoa";
            this.btn_xoa.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btn_xoa.OnHovercolor = System.Drawing.Color.SteelBlue;
            this.btn_xoa.OnHoverTextColor = System.Drawing.Color.White;
            this.btn_xoa.selected = false;
            this.btn_xoa.Size = new System.Drawing.Size(102, 41);
            this.btn_xoa.TabIndex = 17;
            this.btn_xoa.Text = "Xoá";
            this.btn_xoa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_xoa.Textcolor = System.Drawing.Color.White;
            this.btn_xoa.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_xoa.Click += new System.EventHandler(this.btn_xoa_Click);
            // 
            // btn_sua
            // 
            this.btn_sua.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btn_sua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btn_sua.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_sua.BorderRadius = 0;
            this.btn_sua.ButtonText = "Sửa";
            this.btn_sua.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_sua.DisabledColor = System.Drawing.Color.Gray;
            this.btn_sua.Iconcolor = System.Drawing.Color.Transparent;
            this.btn_sua.Iconimage = ((System.Drawing.Image)(resources.GetObject("btn_sua.Iconimage")));
            this.btn_sua.Iconimage_right = null;
            this.btn_sua.Iconimage_right_Selected = null;
            this.btn_sua.Iconimage_Selected = null;
            this.btn_sua.IconMarginLeft = 10;
            this.btn_sua.IconMarginRight = 0;
            this.btn_sua.IconRightVisible = true;
            this.btn_sua.IconRightZoom = 0D;
            this.btn_sua.IconVisible = true;
            this.btn_sua.IconZoom = 40D;
            this.btn_sua.IsTab = false;
            this.btn_sua.Location = new System.Drawing.Point(648, 101);
            this.btn_sua.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_sua.Name = "btn_sua";
            this.btn_sua.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btn_sua.OnHovercolor = System.Drawing.Color.SteelBlue;
            this.btn_sua.OnHoverTextColor = System.Drawing.Color.White;
            this.btn_sua.selected = false;
            this.btn_sua.Size = new System.Drawing.Size(102, 41);
            this.btn_sua.TabIndex = 15;
            this.btn_sua.Text = "Sửa";
            this.btn_sua.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_sua.Textcolor = System.Drawing.Color.White;
            this.btn_sua.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_sua.Click += new System.EventHandler(this.btn_sua_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(462, 228);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(319, 321);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            // 
            // FormNV_Buni
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(753, 561);
            this.Controls.Add(this.iBtnRefresh);
            this.Controls.Add(this.cboChucVu);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtPW);
            this.Controls.Add(this.txtUN);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.picBoxSearch);
            this.Controls.Add(this.dGV_NV);
            this.Controls.Add(this.txtTimkiem);
            this.Controls.Add(this.btn_them);
            this.Controls.Add(this.btn_xoa);
            this.Controls.Add(this.btn_sua);
            this.Controls.Add(this.txt_Hoten);
            this.Controls.Add(this.txt_diachi);
            this.Controls.Add(this.txt_sdt);
            this.Controls.Add(this.txt_MaNV);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dTPNgSinh);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormNV_Buni";
            this.Text = "Quản Lý Nhân Viên";
            this.Load += new System.EventHandler(this.FormNV_Buni_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dGV_NV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DateTimePicker dTPNgSinh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txt_MaNV;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txt_sdt;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txt_diachi;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txt_Hoten;
        private Bunifu.Framework.UI.BunifuFlatButton btn_sua;
        private Bunifu.Framework.UI.BunifuFlatButton btn_xoa;
        private Bunifu.Framework.UI.BunifuFlatButton btn_them;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtTimkiem;
        private Guna.UI2.WinForms.Guna2DataGridView dGV_NV;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse2;
        private System.Windows.Forms.PictureBox picBoxSearch;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtUN;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtPW;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboChucVu;
        private FontAwesome.Sharp.IconButton iBtnRefresh;
    }
}

