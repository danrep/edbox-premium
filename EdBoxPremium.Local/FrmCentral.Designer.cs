namespace EdBoxPremium.Local
{
    partial class FrmCentral
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCentral));
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblInfo = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.btnUpdateSettings = new System.Windows.Forms.Button();
            this.btnLogIn = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnTakeAtten = new System.Windows.Forms.Button();
            this.btnTagAssignment = new System.Windows.Forms.Button();
            this.btnSync = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlAuthentication = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tmrNotify = new System.Windows.Forms.Timer(this.components);
            this.tmrProceed = new System.Windows.Forms.Timer(this.components);
            this.pnlHeader.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlBody.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.flowLayoutPanel3.SuspendLayout();
            this.pnlAuthentication.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.pnlHeader.Controls.Add(this.lblInfo);
            this.pnlHeader.Controls.Add(this.flowLayoutPanel2);
            this.pnlHeader.Location = new System.Drawing.Point(15, 13);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(942, 43);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblInfo
            // 
            this.lblInfo.Font = new System.Drawing.Font("Trebuchet MS", 8F);
            this.lblInfo.ForeColor = System.Drawing.Color.White;
            this.lblInfo.Location = new System.Drawing.Point(9, 3);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(513, 36);
            this.lblInfo.TabIndex = 5;
            this.lblInfo.Text = "label1";
            this.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblInfo.Visible = false;
            this.lblInfo.Click += new System.EventHandler(this.lblInfo_Click);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.btnClose);
            this.flowLayoutPanel2.Controls.Add(this.btnLogOut);
            this.flowLayoutPanel2.Controls.Add(this.btnUpdateSettings);
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(552, 7);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(387, 30);
            this.flowLayoutPanel2.TabIndex = 4;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Maroon;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Trebuchet MS", 8F);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(279, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(105, 25);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close && Exit";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnLogOut
            // 
            this.btnLogOut.BackColor = System.Drawing.Color.SteelBlue;
            this.btnLogOut.FlatAppearance.BorderSize = 0;
            this.btnLogOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogOut.Font = new System.Drawing.Font("Trebuchet MS", 8F);
            this.btnLogOut.ForeColor = System.Drawing.Color.White;
            this.btnLogOut.Location = new System.Drawing.Point(168, 3);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(105, 25);
            this.btnLogOut.TabIndex = 4;
            this.btnLogOut.Text = "Log Out";
            this.btnLogOut.UseVisualStyleBackColor = false;
            this.btnLogOut.Visible = false;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // btnUpdateSettings
            // 
            this.btnUpdateSettings.BackColor = System.Drawing.Color.SteelBlue;
            this.btnUpdateSettings.FlatAppearance.BorderSize = 0;
            this.btnUpdateSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateSettings.Font = new System.Drawing.Font("Trebuchet MS", 8F);
            this.btnUpdateSettings.ForeColor = System.Drawing.Color.White;
            this.btnUpdateSettings.Location = new System.Drawing.Point(57, 3);
            this.btnUpdateSettings.Name = "btnUpdateSettings";
            this.btnUpdateSettings.Size = new System.Drawing.Size(105, 25);
            this.btnUpdateSettings.TabIndex = 5;
            this.btnUpdateSettings.Text = "Update Settings";
            this.btnUpdateSettings.UseVisualStyleBackColor = false;
            this.btnUpdateSettings.Click += new System.EventHandler(this.btnUpdateSettings_Click);
            // 
            // btnLogIn
            // 
            this.btnLogIn.BackColor = System.Drawing.Color.DarkGreen;
            this.btnLogIn.FlatAppearance.BorderSize = 0;
            this.btnLogIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogIn.Font = new System.Drawing.Font("Trebuchet MS", 8F);
            this.btnLogIn.ForeColor = System.Drawing.Color.White;
            this.btnLogIn.Location = new System.Drawing.Point(296, 201);
            this.btnLogIn.Name = "btnLogIn";
            this.btnLogIn.Size = new System.Drawing.Size(80, 25);
            this.btnLogIn.TabIndex = 4;
            this.btnLogIn.Text = "Log In";
            this.btnLogIn.UseVisualStyleBackColor = false;
            this.btnLogIn.Click += new System.EventHandler(this.btnLogIn_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnTakeAtten);
            this.flowLayoutPanel1.Controls.Add(this.btnTagAssignment);
            this.flowLayoutPanel1.Controls.Add(this.btnSync);
            this.flowLayoutPanel1.Controls.Add(this.btnReports);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.BottomUp;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(6, 4);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(159, 389);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // btnTakeAtten
            // 
            this.btnTakeAtten.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(40)))));
            this.btnTakeAtten.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnTakeAtten.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTakeAtten.Font = new System.Drawing.Font("Trebuchet MS", 9F);
            this.btnTakeAtten.ForeColor = System.Drawing.Color.Silver;
            this.btnTakeAtten.Image = global::EdBoxPremium.Local.Properties.Resources.icons8_Name_Tag_40px;
            this.btnTakeAtten.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnTakeAtten.Location = new System.Drawing.Point(3, 315);
            this.btnTakeAtten.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnTakeAtten.Name = "btnTakeAtten";
            this.btnTakeAtten.Size = new System.Drawing.Size(150, 70);
            this.btnTakeAtten.TabIndex = 1;
            this.btnTakeAtten.Text = "Take Attendance";
            this.btnTakeAtten.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnTakeAtten.UseVisualStyleBackColor = false;
            this.btnTakeAtten.Click += new System.EventHandler(this.btnTakeAtten_Click);
            // 
            // btnTagAssignment
            // 
            this.btnTagAssignment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(40)))));
            this.btnTagAssignment.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnTagAssignment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTagAssignment.Font = new System.Drawing.Font("Trebuchet MS", 9F);
            this.btnTagAssignment.ForeColor = System.Drawing.Color.Silver;
            this.btnTagAssignment.Image = global::EdBoxPremium.Local.Properties.Resources.icons8_People_40px;
            this.btnTagAssignment.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnTagAssignment.Location = new System.Drawing.Point(3, 237);
            this.btnTagAssignment.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnTagAssignment.Name = "btnTagAssignment";
            this.btnTagAssignment.Size = new System.Drawing.Size(150, 70);
            this.btnTagAssignment.TabIndex = 0;
            this.btnTagAssignment.Text = "Tags && Students";
            this.btnTagAssignment.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnTagAssignment.UseVisualStyleBackColor = false;
            this.btnTagAssignment.Visible = false;
            this.btnTagAssignment.Click += new System.EventHandler(this.btnTagAssignment_Click);
            // 
            // btnSync
            // 
            this.btnSync.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(40)))));
            this.btnSync.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnSync.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSync.Font = new System.Drawing.Font("Trebuchet MS", 9F);
            this.btnSync.ForeColor = System.Drawing.Color.Silver;
            this.btnSync.Image = global::EdBoxPremium.Local.Properties.Resources.icons8_Synchronize_40px;
            this.btnSync.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSync.Location = new System.Drawing.Point(3, 159);
            this.btnSync.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSync.Name = "btnSync";
            this.btnSync.Size = new System.Drawing.Size(150, 70);
            this.btnSync.TabIndex = 2;
            this.btnSync.Text = "Synchronize Data";
            this.btnSync.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSync.UseVisualStyleBackColor = false;
            this.btnSync.Click += new System.EventHandler(this.btnSync_Click);
            // 
            // btnReports
            // 
            this.btnReports.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(40)))));
            this.btnReports.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReports.Font = new System.Drawing.Font("Trebuchet MS", 9F);
            this.btnReports.ForeColor = System.Drawing.Color.Silver;
            this.btnReports.Image = global::EdBoxPremium.Local.Properties.Resources.icons8_News_40px;
            this.btnReports.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnReports.Location = new System.Drawing.Point(3, 81);
            this.btnReports.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(150, 70);
            this.btnReports.TabIndex = 3;
            this.btnReports.Text = "Reports";
            this.btnReports.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnReports.UseVisualStyleBackColor = false;
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::EdBoxPremium.Local.Properties.Resources.logo_full_black_128;
            this.pictureBox1.Location = new System.Drawing.Point(3, 353);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(258, 85);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // pnlBody
            // 
            this.pnlBody.Controls.Add(this.flowLayoutPanel1);
            this.pnlBody.Location = new System.Drawing.Point(3, 3);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(936, 399);
            this.pnlBody.TabIndex = 3;
            this.pnlBody.Visible = false;
            this.pnlBody.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlBody_Paint);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(687, -13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(264, 526);
            this.panel1.TabIndex = 4;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::EdBoxPremium.Local.Properties.Resources.school_logo;
            this.pictureBox3.Location = new System.Drawing.Point(29, 113);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(208, 192);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 3;
            this.pictureBox3.TabStop = false;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.pnlBody);
            this.flowLayoutPanel3.Controls.Add(this.pnlAuthentication);
            this.flowLayoutPanel3.Location = new System.Drawing.Point(15, 64);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(942, 404);
            this.flowLayoutPanel3.TabIndex = 4;
            // 
            // pnlAuthentication
            // 
            this.pnlAuthentication.Controls.Add(this.groupBox1);
            this.pnlAuthentication.Location = new System.Drawing.Point(3, 408);
            this.pnlAuthentication.Name = "pnlAuthentication";
            this.pnlAuthentication.Size = new System.Drawing.Size(936, 350);
            this.pnlAuthentication.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnLogIn);
            this.groupBox1.Controls.Add(this.pictureBox2);
            this.groupBox1.Controls.Add(this.txtUsername);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtPassword);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(277, 55);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(382, 240);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::EdBoxPremium.Local.Properties.Resources.school_logo;
            this.pictureBox2.Location = new System.Drawing.Point(140, 17);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(102, 76);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            // 
            // txtUsername
            // 
            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsername.Font = new System.Drawing.Font("Trebuchet MS", 12F);
            this.txtUsername.Location = new System.Drawing.Point(6, 112);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(370, 31);
            this.txtUsername.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Trebuchet MS", 8F);
            this.label3.ForeColor = System.Drawing.Color.CadetBlue;
            this.label3.Location = new System.Drawing.Point(6, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 18);
            this.label3.TabIndex = 6;
            this.label3.Text = "Password";
            // 
            // txtPassword
            // 
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.Font = new System.Drawing.Font("Trebuchet MS", 12F);
            this.txtPassword.Location = new System.Drawing.Point(6, 165);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(370, 31);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Trebuchet MS", 8F);
            this.label2.ForeColor = System.Drawing.Color.CadetBlue;
            this.label2.Location = new System.Drawing.Point(6, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 18);
            this.label2.TabIndex = 5;
            this.label2.Text = "Username";
            // 
            // tmrNotify
            // 
            this.tmrNotify.Enabled = true;
            this.tmrNotify.Tick += new System.EventHandler(this.tmrNotify_Tick);
            // 
            // tmrProceed
            // 
            this.tmrProceed.Interval = 3000;
            this.tmrProceed.Tick += new System.EventHandler(this.tmrProceed_Tick);
            // 
            // FrmCentral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(44)))));
            this.ClientSize = new System.Drawing.Size(969, 479);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flowLayoutPanel3);
            this.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCentral";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Central";
            this.Activated += new System.EventHandler(this.FrmCentral_Activated);
            this.Deactivate += new System.EventHandler(this.FrmCentral_Deactivate);
            this.Click += new System.EventHandler(this.FrmCentral_Click);
            this.pnlHeader.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlBody.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.pnlAuthentication.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnLogIn;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnTagAssignment;
        private System.Windows.Forms.Button btnTakeAtten;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Button btnSync;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Panel pnlAuthentication;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Button btnUpdateSettings;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Timer tmrNotify;
        private System.Windows.Forms.Timer tmrProceed;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Panel panel1;
    }
}