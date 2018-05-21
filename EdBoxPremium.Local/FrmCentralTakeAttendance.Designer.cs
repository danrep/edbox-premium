namespace EdBoxPremium.Local
{
    partial class FrmCentralTakeAttendance
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCentralTakeAttendance));
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTime = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblNotify = new System.Windows.Forms.Label();
            this.grpBoxSettingsUpdate = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAcceptAttendance = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lstTakenAttendance = new System.Windows.Forms.ListBox();
            this.btnFinalizeAttendance = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblInfoBody = new System.Windows.Forms.Label();
            this.lblInfoHead = new System.Windows.Forms.Label();
            this.lblCurrentStudentStatus = new System.Windows.Forms.Label();
            this.lblCurrentStudentName = new System.Windows.Forms.Label();
            this.picBxStudentImage = new System.Windows.Forms.PictureBox();
            this.tmrEvents = new System.Windows.Forms.Timer(this.components);
            this.tmrTagMonitor = new System.Windows.Forms.Timer(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbAttendanceReason = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbCourse = new System.Windows.Forms.ComboBox();
            this.tmrTime = new System.Windows.Forms.Timer(this.components);
            this.picBxStudentImageDup = new System.Windows.Forms.PictureBox();
            this.pnlHeader.SuspendLayout();
            this.grpBoxSettingsUpdate.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBxStudentImage)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBxStudentImageDup)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.pnlHeader.Controls.Add(this.lblTime);
            this.pnlHeader.Controls.Add(this.btnClose);
            this.pnlHeader.Controls.Add(this.lblNotify);
            this.pnlHeader.Location = new System.Drawing.Point(12, 13);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(956, 43);
            this.pnlHeader.TabIndex = 1;
            // 
            // lblTime
            // 
            this.lblTime.Font = new System.Drawing.Font("Trebuchet MS", 8F);
            this.lblTime.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblTime.Location = new System.Drawing.Point(145, 12);
            this.lblTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(667, 18);
            this.lblTime.TabIndex = 10;
            this.lblTime.Text = "...";
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Maroon;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Trebuchet MS", 8F);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(843, 10);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(105, 25);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close && Exit";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblNotify
            // 
            this.lblNotify.AutoSize = true;
            this.lblNotify.Font = new System.Drawing.Font("Trebuchet MS", 8F);
            this.lblNotify.ForeColor = System.Drawing.Color.Orange;
            this.lblNotify.Location = new System.Drawing.Point(8, 13);
            this.lblNotify.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNotify.Name = "lblNotify";
            this.lblNotify.Size = new System.Drawing.Size(77, 18);
            this.lblNotify.TabIndex = 9;
            this.lblNotify.Text = "Working ...";
            this.lblNotify.Visible = false;
            // 
            // grpBoxSettingsUpdate
            // 
            this.grpBoxSettingsUpdate.Controls.Add(this.label4);
            this.grpBoxSettingsUpdate.Controls.Add(this.btnAcceptAttendance);
            this.grpBoxSettingsUpdate.Controls.Add(this.groupBox2);
            this.grpBoxSettingsUpdate.Controls.Add(this.groupBox1);
            this.grpBoxSettingsUpdate.Controls.Add(this.lblCurrentStudentStatus);
            this.grpBoxSettingsUpdate.Controls.Add(this.lblCurrentStudentName);
            this.grpBoxSettingsUpdate.Controls.Add(this.picBxStudentImage);
            this.grpBoxSettingsUpdate.ForeColor = System.Drawing.Color.Silver;
            this.grpBoxSettingsUpdate.Location = new System.Drawing.Point(12, 239);
            this.grpBoxSettingsUpdate.Margin = new System.Windows.Forms.Padding(4);
            this.grpBoxSettingsUpdate.Name = "grpBoxSettingsUpdate";
            this.grpBoxSettingsUpdate.Padding = new System.Windows.Forms.Padding(4);
            this.grpBoxSettingsUpdate.Size = new System.Drawing.Size(955, 336);
            this.grpBoxSettingsUpdate.TabIndex = 5;
            this.grpBoxSettingsUpdate.TabStop = false;
            this.grpBoxSettingsUpdate.Text = "Student Information (click image to enlarge)";
            this.grpBoxSettingsUpdate.Enter += new System.EventHandler(this.grpBoxSettingsUpdate_Enter);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Trebuchet MS", 8F);
            this.label4.ForeColor = System.Drawing.Color.Orange;
            this.label4.Location = new System.Drawing.Point(327, 162);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(283, 51);
            this.label4.TabIndex = 11;
            this.label4.Text = "Warning: You cannot remove an Attendance Record after acceptance!";
            // 
            // btnAcceptAttendance
            // 
            this.btnAcceptAttendance.BackColor = System.Drawing.Color.SteelBlue;
            this.btnAcceptAttendance.FlatAppearance.BorderSize = 0;
            this.btnAcceptAttendance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAcceptAttendance.Font = new System.Drawing.Font("Trebuchet MS", 8F);
            this.btnAcceptAttendance.ForeColor = System.Drawing.Color.White;
            this.btnAcceptAttendance.Location = new System.Drawing.Point(154, 162);
            this.btnAcceptAttendance.Name = "btnAcceptAttendance";
            this.btnAcceptAttendance.Size = new System.Drawing.Size(166, 38);
            this.btnAcceptAttendance.TabIndex = 13;
            this.btnAcceptAttendance.Text = "Accept Attendance";
            this.btnAcceptAttendance.UseVisualStyleBackColor = false;
            this.btnAcceptAttendance.Visible = false;
            this.btnAcceptAttendance.Click += new System.EventHandler(this.btnAcceptAttendance_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lstTakenAttendance);
            this.groupBox2.Controls.Add(this.btnFinalizeAttendance);
            this.groupBox2.ForeColor = System.Drawing.Color.Silver;
            this.groupBox2.Location = new System.Drawing.Point(618, 0);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(337, 335);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Attendance Taken";
            // 
            // lstTakenAttendance
            // 
            this.lstTakenAttendance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(40)))));
            this.lstTakenAttendance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstTakenAttendance.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lstTakenAttendance.Font = new System.Drawing.Font("Trebuchet MS", 10F);
            this.lstTakenAttendance.ForeColor = System.Drawing.Color.Gainsboro;
            this.lstTakenAttendance.FormattingEnabled = true;
            this.lstTakenAttendance.ItemHeight = 23;
            this.lstTakenAttendance.Location = new System.Drawing.Point(9, 22);
            this.lstTakenAttendance.Name = "lstTakenAttendance";
            this.lstTakenAttendance.ScrollAlwaysVisible = true;
            this.lstTakenAttendance.Size = new System.Drawing.Size(321, 255);
            this.lstTakenAttendance.TabIndex = 5;
            // 
            // btnFinalizeAttendance
            // 
            this.btnFinalizeAttendance.BackColor = System.Drawing.Color.DarkGreen;
            this.btnFinalizeAttendance.FlatAppearance.BorderSize = 0;
            this.btnFinalizeAttendance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFinalizeAttendance.Font = new System.Drawing.Font("Trebuchet MS", 8F);
            this.btnFinalizeAttendance.ForeColor = System.Drawing.Color.White;
            this.btnFinalizeAttendance.Location = new System.Drawing.Point(9, 290);
            this.btnFinalizeAttendance.Name = "btnFinalizeAttendance";
            this.btnFinalizeAttendance.Size = new System.Drawing.Size(321, 38);
            this.btnFinalizeAttendance.TabIndex = 4;
            this.btnFinalizeAttendance.Text = "Finalize Attendance Session";
            this.btnFinalizeAttendance.UseVisualStyleBackColor = false;
            this.btnFinalizeAttendance.Click += new System.EventHandler(this.btnFinalizeAttendance_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblInfoBody);
            this.groupBox1.Controls.Add(this.lblInfoHead);
            this.groupBox1.ForeColor = System.Drawing.Color.Silver;
            this.groupBox1.Location = new System.Drawing.Point(0, 207);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(618, 128);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tag Information";
            // 
            // lblInfoBody
            // 
            this.lblInfoBody.Font = new System.Drawing.Font("Trebuchet MS", 8F);
            this.lblInfoBody.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblInfoBody.Location = new System.Drawing.Point(30, 60);
            this.lblInfoBody.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInfoBody.Name = "lblInfoBody";
            this.lblInfoBody.Size = new System.Drawing.Size(580, 56);
            this.lblInfoBody.TabIndex = 11;
            this.lblInfoBody.Text = "...";
            // 
            // lblInfoHead
            // 
            this.lblInfoHead.AutoSize = true;
            this.lblInfoHead.Font = new System.Drawing.Font("Trebuchet MS", 14F);
            this.lblInfoHead.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblInfoHead.Location = new System.Drawing.Point(25, 21);
            this.lblInfoHead.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInfoHead.Name = "lblInfoHead";
            this.lblInfoHead.Size = new System.Drawing.Size(40, 29);
            this.lblInfoHead.TabIndex = 10;
            this.lblInfoHead.Text = "...";
            // 
            // lblCurrentStudentStatus
            // 
            this.lblCurrentStudentStatus.Font = new System.Drawing.Font("Trebuchet MS", 8F);
            this.lblCurrentStudentStatus.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblCurrentStudentStatus.Location = new System.Drawing.Point(154, 51);
            this.lblCurrentStudentStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCurrentStudentStatus.Name = "lblCurrentStudentStatus";
            this.lblCurrentStudentStatus.Size = new System.Drawing.Size(456, 100);
            this.lblCurrentStudentStatus.TabIndex = 12;
            this.lblCurrentStudentStatus.Text = "...";
            // 
            // lblCurrentStudentName
            // 
            this.lblCurrentStudentName.AutoSize = true;
            this.lblCurrentStudentName.Font = new System.Drawing.Font("Trebuchet MS", 14F);
            this.lblCurrentStudentName.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblCurrentStudentName.Location = new System.Drawing.Point(149, 22);
            this.lblCurrentStudentName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCurrentStudentName.Name = "lblCurrentStudentName";
            this.lblCurrentStudentName.Size = new System.Drawing.Size(40, 29);
            this.lblCurrentStudentName.TabIndex = 11;
            this.lblCurrentStudentName.Text = "...";
            // 
            // picBxStudentImage
            // 
            this.picBxStudentImage.Image = global::EdBoxPremium.Local.Properties.Resources.logo_only_128;
            this.picBxStudentImage.Location = new System.Drawing.Point(11, 22);
            this.picBxStudentImage.Name = "picBxStudentImage";
            this.picBxStudentImage.Size = new System.Drawing.Size(137, 178);
            this.picBxStudentImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBxStudentImage.TabIndex = 9;
            this.picBxStudentImage.TabStop = false;
            this.picBxStudentImage.Click += new System.EventHandler(this.picBxStudentImage_Click);
            // 
            // tmrEvents
            // 
            this.tmrEvents.Enabled = true;
            this.tmrEvents.Interval = 500;
            this.tmrEvents.Tick += new System.EventHandler(this.tmrEvents_Tick);
            // 
            // tmrTagMonitor
            // 
            this.tmrTagMonitor.Enabled = true;
            this.tmrTagMonitor.Interval = 500;
            this.tmrTagMonitor.Tick += new System.EventHandler(this.tmrTagMonitor_Tick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.cmbAttendanceReason);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.txtDesc);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.cmbCourse);
            this.groupBox3.ForeColor = System.Drawing.Color.Silver;
            this.groupBox3.Location = new System.Drawing.Point(12, 68);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(956, 163);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Attendance Session Data";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(154, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Reason for Attendance";
            // 
            // cmbAttendanceReason
            // 
            this.cmbAttendanceReason.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAttendanceReason.Font = new System.Drawing.Font("Trebuchet MS", 10F);
            this.cmbAttendanceReason.FormattingEnabled = true;
            this.cmbAttendanceReason.Location = new System.Drawing.Point(12, 119);
            this.cmbAttendanceReason.Name = "cmbAttendanceReason";
            this.cmbAttendanceReason.Size = new System.Drawing.Size(463, 31);
            this.cmbAttendanceReason.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(478, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Description (optional)";
            // 
            // txtDesc
            // 
            this.txtDesc.Font = new System.Drawing.Font("Trebuchet MS", 10F);
            this.txtDesc.Location = new System.Drawing.Point(481, 49);
            this.txtDesc.Multiline = true;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(468, 101);
            this.txtDesc.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Course";
            // 
            // cmbCourse
            // 
            this.cmbCourse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCourse.Font = new System.Drawing.Font("Trebuchet MS", 10F);
            this.cmbCourse.FormattingEnabled = true;
            this.cmbCourse.Location = new System.Drawing.Point(12, 49);
            this.cmbCourse.Name = "cmbCourse";
            this.cmbCourse.Size = new System.Drawing.Size(463, 31);
            this.cmbCourse.TabIndex = 0;
            // 
            // tmrTime
            // 
            this.tmrTime.Enabled = true;
            this.tmrTime.Interval = 1000;
            this.tmrTime.Tick += new System.EventHandler(this.tmrTime_Tick);
            // 
            // picBxStudentImageDup
            // 
            this.picBxStudentImageDup.Image = global::EdBoxPremium.Local.Properties.Resources.logo_only_128;
            this.picBxStudentImageDup.Location = new System.Drawing.Point(352, 116);
            this.picBxStudentImageDup.Name = "picBxStudentImageDup";
            this.picBxStudentImageDup.Size = new System.Drawing.Size(274, 356);
            this.picBxStudentImageDup.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBxStudentImageDup.TabIndex = 14;
            this.picBxStudentImageDup.TabStop = false;
            this.picBxStudentImageDup.Visible = false;
            this.picBxStudentImageDup.Click += new System.EventHandler(this.picBxStudentImageDup_Click);
            // 
            // FrmCentralTakeAttendance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(979, 588);
            this.Controls.Add(this.picBxStudentImageDup);
            this.Controls.Add(this.grpBoxSettingsUpdate);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.groupBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCentralTakeAttendance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EdBox Premium: Synchronize Data";
            this.Load += new System.EventHandler(this.FrmCentralTagStudent_Load);
            this.Shown += new System.EventHandler(this.FrmCentralTagStudent_Shown);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.grpBoxSettingsUpdate.ResumeLayout(false);
            this.grpBoxSettingsUpdate.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBxStudentImage)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBxStudentImageDup)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox grpBoxSettingsUpdate;
        private System.Windows.Forms.Label lblNotify;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblInfoHead;
        private System.Windows.Forms.Label lblInfoBody;
        private System.Windows.Forms.Timer tmrEvents;
        private System.Windows.Forms.Label lblCurrentStudentStatus;
        private System.Windows.Forms.Label lblCurrentStudentName;
        private System.Windows.Forms.PictureBox picBxStudentImage;
        private System.Windows.Forms.Timer tmrTagMonitor;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnFinalizeAttendance;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListBox lstTakenAttendance;
        private System.Windows.Forms.Button btnAcceptAttendance;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbCourse;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbAttendanceReason;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Timer tmrTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox picBxStudentImageDup;
    }
}