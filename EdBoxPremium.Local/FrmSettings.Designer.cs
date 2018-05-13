namespace EdBoxPremium.Local
{
    partial class FrmSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSettings));
            this.grpBoxSettingsUpdate = new System.Windows.Forms.GroupBox();
            this.picNotify = new System.Windows.Forms.PictureBox();
            this.lblNotify = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnUpdateSettingsConfirm = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.tmrProcesses = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnUpdateDevices = new System.Windows.Forms.Button();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnClose = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grpBoxSettingsUpdate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picNotify)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpBoxSettingsUpdate
            // 
            this.grpBoxSettingsUpdate.Controls.Add(this.picNotify);
            this.grpBoxSettingsUpdate.Controls.Add(this.label5);
            this.grpBoxSettingsUpdate.Controls.Add(this.btnUpdateSettingsConfirm);
            this.grpBoxSettingsUpdate.Controls.Add(this.label4);
            this.grpBoxSettingsUpdate.Controls.Add(this.txtUrl);
            this.grpBoxSettingsUpdate.ForeColor = System.Drawing.Color.Silver;
            this.grpBoxSettingsUpdate.Location = new System.Drawing.Point(9, 66);
            this.grpBoxSettingsUpdate.Margin = new System.Windows.Forms.Padding(4);
            this.grpBoxSettingsUpdate.Name = "grpBoxSettingsUpdate";
            this.grpBoxSettingsUpdate.Padding = new System.Windows.Forms.Padding(4);
            this.grpBoxSettingsUpdate.Size = new System.Drawing.Size(448, 191);
            this.grpBoxSettingsUpdate.TabIndex = 4;
            this.grpBoxSettingsUpdate.TabStop = false;
            this.grpBoxSettingsUpdate.Text = "Authentication && Settings Update";
            // 
            // picNotify
            // 
            this.picNotify.BackColor = System.Drawing.Color.White;
            this.picNotify.Image = global::EdBoxPremium.Local.Properties.Resources.icons8_Ok_20px;
            this.picNotify.Location = new System.Drawing.Point(417, 118);
            this.picNotify.Margin = new System.Windows.Forms.Padding(4);
            this.picNotify.Name = "picNotify";
            this.picNotify.Size = new System.Drawing.Size(20, 20);
            this.picNotify.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picNotify.TabIndex = 10;
            this.picNotify.TabStop = false;
            this.picNotify.Visible = false;
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
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Trebuchet MS", 8F);
            this.label5.ForeColor = System.Drawing.Color.SteelBlue;
            this.label5.Location = new System.Drawing.Point(12, 25);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(429, 57);
            this.label5.TabIndex = 7;
            this.label5.Text = "Enter the Url of the Server you wish to Pull Settings and Authentication Data fro" +
    "m. Proceed if the Url is the same. Previously saved date will be deleted.";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnUpdateSettingsConfirm
            // 
            this.btnUpdateSettingsConfirm.BackColor = System.Drawing.Color.SteelBlue;
            this.btnUpdateSettingsConfirm.FlatAppearance.BorderSize = 0;
            this.btnUpdateSettingsConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateSettingsConfirm.Font = new System.Drawing.Font("Trebuchet MS", 8F);
            this.btnUpdateSettingsConfirm.ForeColor = System.Drawing.Color.White;
            this.btnUpdateSettingsConfirm.Location = new System.Drawing.Point(301, 148);
            this.btnUpdateSettingsConfirm.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdateSettingsConfirm.Name = "btnUpdateSettingsConfirm";
            this.btnUpdateSettingsConfirm.Size = new System.Drawing.Size(140, 31);
            this.btnUpdateSettingsConfirm.TabIndex = 6;
            this.btnUpdateSettingsConfirm.Text = "Update Settings";
            this.btnUpdateSettingsConfirm.UseVisualStyleBackColor = false;
            this.btnUpdateSettingsConfirm.Click += new System.EventHandler(this.btnUpdateSettingsConfirm_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Trebuchet MS", 8F);
            this.label4.Location = new System.Drawing.Point(8, 90);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 18);
            this.label4.TabIndex = 5;
            this.label4.Text = "Remote Url";
            // 
            // txtUrl
            // 
            this.txtUrl.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUrl.Location = new System.Drawing.Point(12, 114);
            this.txtUrl.Margin = new System.Windows.Forms.Padding(4);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(429, 29);
            this.txtUrl.TabIndex = 0;
            // 
            // tmrProcesses
            // 
            this.tmrProcesses.Enabled = true;
            this.tmrProcesses.Tick += new System.EventHandler(this.tmrProcesses_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnUpdateDevices);
            this.groupBox1.ForeColor = System.Drawing.Color.Silver;
            this.groupBox1.Location = new System.Drawing.Point(465, 66);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(448, 191);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Devices && Pheripherals";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Trebuchet MS", 8F);
            this.label2.ForeColor = System.Drawing.Color.SteelBlue;
            this.label2.Location = new System.Drawing.Point(15, 25);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(423, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Ensure the Devices are Valid && Responsive";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnUpdateDevices
            // 
            this.btnUpdateDevices.BackColor = System.Drawing.Color.SteelBlue;
            this.btnUpdateDevices.FlatAppearance.BorderSize = 0;
            this.btnUpdateDevices.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateDevices.Font = new System.Drawing.Font("Trebuchet MS", 8F);
            this.btnUpdateDevices.ForeColor = System.Drawing.Color.White;
            this.btnUpdateDevices.Location = new System.Drawing.Point(298, 148);
            this.btnUpdateDevices.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdateDevices.Name = "btnUpdateDevices";
            this.btnUpdateDevices.Size = new System.Drawing.Size(140, 31);
            this.btnUpdateDevices.TabIndex = 6;
            this.btnUpdateDevices.Text = "Update Devices";
            this.btnUpdateDevices.UseVisualStyleBackColor = false;
            this.btnUpdateDevices.Click += new System.EventHandler(this.btnUpdateDevices_Click);
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.pnlHeader.Controls.Add(this.flowLayoutPanel2);
            this.pnlHeader.Controls.Add(this.lblNotify);
            this.pnlHeader.Location = new System.Drawing.Point(9, 13);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(904, 43);
            this.pnlHeader.TabIndex = 12;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.btnClose);
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(374, 7);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(523, 30);
            this.flowLayoutPanel2.TabIndex = 4;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Maroon;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Trebuchet MS", 8F);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(415, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(105, 25);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close && Exit";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Trebuchet MS", 11.25F);
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(15, 111);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(423, 32);
            this.comboBox1.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 8F);
            this.label1.Location = new System.Drawing.Point(12, 90);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 18);
            this.label1.TabIndex = 9;
            this.label1.Text = "NFC Devices";
            // 
            // FrmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(54)))));
            this.ClientSize = new System.Drawing.Size(923, 265);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpBoxSettingsUpdate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.Shown += new System.EventHandler(this.FrmSettings_Shown);
            this.grpBoxSettingsUpdate.ResumeLayout(false);
            this.grpBoxSettingsUpdate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picNotify)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBoxSettingsUpdate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnUpdateSettingsConfirm;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Label lblNotify;
        private System.Windows.Forms.Timer tmrProcesses;
        private System.Windows.Forms.PictureBox picNotify;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnUpdateDevices;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
    }
}