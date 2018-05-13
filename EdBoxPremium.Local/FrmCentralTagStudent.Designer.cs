namespace EdBoxPremium.Local
{
    partial class FrmCentralTagStudent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCentralTagStudent));
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblNotify = new System.Windows.Forms.Label();
            this.grpBoxSettingsUpdate = new System.Windows.Forms.GroupBox();
            this.lblCurrentStudentStatus = new System.Windows.Forms.Label();
            this.lblCurrentStudentName = new System.Windows.Forms.Label();
            this.picBxStudentImage = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtStudentMatric = new System.Windows.Forms.TextBox();
            this.btnStudentRequest = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnFormat = new System.Windows.Forms.Button();
            this.lblInfoBody = new System.Windows.Forms.Label();
            this.btnAttach = new System.Windows.Forms.Button();
            this.lblInfoHead = new System.Windows.Forms.Label();
            this.tmrEvents = new System.Windows.Forms.Timer(this.components);
            this.tmrTagMonitor = new System.Windows.Forms.Timer(this.components);
            this.pnlHeader.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.grpBoxSettingsUpdate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBxStudentImage)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.pnlHeader.Controls.Add(this.flowLayoutPanel2);
            this.pnlHeader.Controls.Add(this.lblNotify);
            this.pnlHeader.Location = new System.Drawing.Point(15, 13);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(773, 43);
            this.pnlHeader.TabIndex = 1;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.btnClose);
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(374, 7);
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
            this.grpBoxSettingsUpdate.Controls.Add(this.lblCurrentStudentStatus);
            this.grpBoxSettingsUpdate.Controls.Add(this.lblCurrentStudentName);
            this.grpBoxSettingsUpdate.Controls.Add(this.picBxStudentImage);
            this.grpBoxSettingsUpdate.Controls.Add(this.label1);
            this.grpBoxSettingsUpdate.Controls.Add(this.txtStudentMatric);
            this.grpBoxSettingsUpdate.Controls.Add(this.btnStudentRequest);
            this.grpBoxSettingsUpdate.ForeColor = System.Drawing.Color.Silver;
            this.grpBoxSettingsUpdate.Location = new System.Drawing.Point(15, 71);
            this.grpBoxSettingsUpdate.Margin = new System.Windows.Forms.Padding(4);
            this.grpBoxSettingsUpdate.Name = "grpBoxSettingsUpdate";
            this.grpBoxSettingsUpdate.Padding = new System.Windows.Forms.Padding(4);
            this.grpBoxSettingsUpdate.Size = new System.Drawing.Size(772, 261);
            this.grpBoxSettingsUpdate.TabIndex = 5;
            this.grpBoxSettingsUpdate.TabStop = false;
            this.grpBoxSettingsUpdate.Text = "Student Information";
            this.grpBoxSettingsUpdate.Enter += new System.EventHandler(this.grpBoxSettingsUpdate_Enter);
            // 
            // lblCurrentStudentStatus
            // 
            this.lblCurrentStudentStatus.Font = new System.Drawing.Font("Trebuchet MS", 10F);
            this.lblCurrentStudentStatus.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblCurrentStudentStatus.Location = new System.Drawing.Point(184, 140);
            this.lblCurrentStudentStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCurrentStudentStatus.Name = "lblCurrentStudentStatus";
            this.lblCurrentStudentStatus.Size = new System.Drawing.Size(577, 81);
            this.lblCurrentStudentStatus.TabIndex = 12;
            this.lblCurrentStudentStatus.Text = "...";
            // 
            // lblCurrentStudentName
            // 
            this.lblCurrentStudentName.AutoSize = true;
            this.lblCurrentStudentName.Font = new System.Drawing.Font("Trebuchet MS", 14F);
            this.lblCurrentStudentName.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblCurrentStudentName.Location = new System.Drawing.Point(166, 105);
            this.lblCurrentStudentName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCurrentStudentName.Name = "lblCurrentStudentName";
            this.lblCurrentStudentName.Size = new System.Drawing.Size(40, 29);
            this.lblCurrentStudentName.TabIndex = 11;
            this.lblCurrentStudentName.Text = "...";
            // 
            // picBxStudentImage
            // 
            this.picBxStudentImage.Image = global::EdBoxPremium.Local.Properties.Resources.logo_only_128;
            this.picBxStudentImage.Location = new System.Drawing.Point(11, 83);
            this.picBxStudentImage.Name = "picBxStudentImage";
            this.picBxStudentImage.Size = new System.Drawing.Size(137, 167);
            this.picBxStudentImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBxStudentImage.TabIndex = 9;
            this.picBxStudentImage.TabStop = false;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(94)))));
            this.label1.Location = new System.Drawing.Point(-9, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(791, 3);
            this.label1.TabIndex = 8;
            // 
            // txtStudentMatric
            // 
            this.txtStudentMatric.Font = new System.Drawing.Font("Trebuchet MS", 20F);
            this.txtStudentMatric.Location = new System.Drawing.Point(11, 22);
            this.txtStudentMatric.Name = "txtStudentMatric";
            this.txtStudentMatric.Size = new System.Drawing.Size(540, 46);
            this.txtStudentMatric.TabIndex = 7;
            // 
            // btnStudentRequest
            // 
            this.btnStudentRequest.BackColor = System.Drawing.Color.SteelBlue;
            this.btnStudentRequest.FlatAppearance.BorderSize = 0;
            this.btnStudentRequest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStudentRequest.Font = new System.Drawing.Font("Trebuchet MS", 8F);
            this.btnStudentRequest.ForeColor = System.Drawing.Color.White;
            this.btnStudentRequest.Location = new System.Drawing.Point(558, 22);
            this.btnStudentRequest.Margin = new System.Windows.Forms.Padding(4);
            this.btnStudentRequest.Name = "btnStudentRequest";
            this.btnStudentRequest.Size = new System.Drawing.Size(203, 46);
            this.btnStudentRequest.TabIndex = 6;
            this.btnStudentRequest.Text = "Request for Student\r\n";
            this.btnStudentRequest.UseVisualStyleBackColor = false;
            this.btnStudentRequest.Click += new System.EventHandler(this.btnStudentRequest_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnFormat);
            this.groupBox1.Controls.Add(this.lblInfoBody);
            this.groupBox1.Controls.Add(this.btnAttach);
            this.groupBox1.Controls.Add(this.lblInfoHead);
            this.groupBox1.ForeColor = System.Drawing.Color.Silver;
            this.groupBox1.Location = new System.Drawing.Point(16, 328);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(772, 139);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tag Information";
            // 
            // btnFormat
            // 
            this.btnFormat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(40)))));
            this.btnFormat.FlatAppearance.BorderSize = 0;
            this.btnFormat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFormat.Font = new System.Drawing.Font("Trebuchet MS", 8F);
            this.btnFormat.ForeColor = System.Drawing.Color.White;
            this.btnFormat.Image = global::EdBoxPremium.Local.Properties.Resources.icons8_Eraser_28px;
            this.btnFormat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFormat.Location = new System.Drawing.Point(557, 78);
            this.btnFormat.Margin = new System.Windows.Forms.Padding(4);
            this.btnFormat.Name = "btnFormat";
            this.btnFormat.Size = new System.Drawing.Size(203, 48);
            this.btnFormat.TabIndex = 7;
            this.btnFormat.Text = "Format Tag";
            this.btnFormat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFormat.UseVisualStyleBackColor = false;
            this.btnFormat.Click += new System.EventHandler(this.btnFormat_Click);
            // 
            // lblInfoBody
            // 
            this.lblInfoBody.Font = new System.Drawing.Font("Trebuchet MS", 8F);
            this.lblInfoBody.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblInfoBody.Location = new System.Drawing.Point(43, 63);
            this.lblInfoBody.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInfoBody.Name = "lblInfoBody";
            this.lblInfoBody.Size = new System.Drawing.Size(507, 56);
            this.lblInfoBody.TabIndex = 11;
            this.lblInfoBody.Text = "...";
            // 
            // btnAttach
            // 
            this.btnAttach.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(40)))));
            this.btnAttach.FlatAppearance.BorderSize = 0;
            this.btnAttach.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAttach.Font = new System.Drawing.Font("Trebuchet MS", 8F);
            this.btnAttach.ForeColor = System.Drawing.Color.White;
            this.btnAttach.Image = ((System.Drawing.Image)(resources.GetObject("btnAttach.Image")));
            this.btnAttach.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAttach.Location = new System.Drawing.Point(557, 22);
            this.btnAttach.Margin = new System.Windows.Forms.Padding(4);
            this.btnAttach.Name = "btnAttach";
            this.btnAttach.Size = new System.Drawing.Size(203, 48);
            this.btnAttach.TabIndex = 6;
            this.btnAttach.Text = "Attach Tag to Student";
            this.btnAttach.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAttach.UseVisualStyleBackColor = false;
            this.btnAttach.Click += new System.EventHandler(this.btnAttach_Click);
            // 
            // lblInfoHead
            // 
            this.lblInfoHead.AutoSize = true;
            this.lblInfoHead.Font = new System.Drawing.Font("Trebuchet MS", 14F);
            this.lblInfoHead.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblInfoHead.Location = new System.Drawing.Point(25, 22);
            this.lblInfoHead.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInfoHead.Name = "lblInfoHead";
            this.lblInfoHead.Size = new System.Drawing.Size(40, 29);
            this.lblInfoHead.TabIndex = 10;
            this.lblInfoHead.Text = "...";
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
            // FrmCentralTagStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(44)))));
            this.ClientSize = new System.Drawing.Size(800, 479);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpBoxSettingsUpdate);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCentralTagStudent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EdBox Premium: Synchronize Data";
            this.Load += new System.EventHandler(this.FrmCentralTagStudent_Load);
            this.Shown += new System.EventHandler(this.FrmCentralTagStudent_Shown);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.grpBoxSettingsUpdate.ResumeLayout(false);
            this.grpBoxSettingsUpdate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBxStudentImage)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox grpBoxSettingsUpdate;
        private System.Windows.Forms.Button btnStudentRequest;
        private System.Windows.Forms.Label lblNotify;
        private System.Windows.Forms.TextBox txtStudentMatric;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAttach;
        private System.Windows.Forms.Button btnFormat;
        private System.Windows.Forms.Label lblInfoHead;
        private System.Windows.Forms.Label lblInfoBody;
        private System.Windows.Forms.Timer tmrEvents;
        private System.Windows.Forms.Label lblCurrentStudentStatus;
        private System.Windows.Forms.Label lblCurrentStudentName;
        private System.Windows.Forms.PictureBox picBxStudentImage;
        private System.Windows.Forms.Timer tmrTagMonitor;
    }
}