namespace EdBoxPremium.Local
{
    partial class FrmCentralSyncData
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCentralSyncData));
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblNotify = new System.Windows.Forms.Label();
            this.grpBoxSettingsUpdate = new System.Windows.Forms.GroupBox();
            this.rTxtBox = new System.Windows.Forms.RichTextBox();
            this.btnProceed = new System.Windows.Forms.Button();
            this.tmrConsole = new System.Windows.Forms.Timer(this.components);
            this.pnlHeader.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.grpBoxSettingsUpdate.SuspendLayout();
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
            this.grpBoxSettingsUpdate.Controls.Add(this.rTxtBox);
            this.grpBoxSettingsUpdate.Controls.Add(this.btnProceed);
            this.grpBoxSettingsUpdate.ForeColor = System.Drawing.Color.Silver;
            this.grpBoxSettingsUpdate.Location = new System.Drawing.Point(15, 71);
            this.grpBoxSettingsUpdate.Margin = new System.Windows.Forms.Padding(4);
            this.grpBoxSettingsUpdate.Name = "grpBoxSettingsUpdate";
            this.grpBoxSettingsUpdate.Padding = new System.Windows.Forms.Padding(4);
            this.grpBoxSettingsUpdate.Size = new System.Drawing.Size(772, 203);
            this.grpBoxSettingsUpdate.TabIndex = 5;
            this.grpBoxSettingsUpdate.TabStop = false;
            this.grpBoxSettingsUpdate.Text = "Synchronization Log";
            // 
            // rTxtBox
            // 
            this.rTxtBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.rTxtBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rTxtBox.ForeColor = System.Drawing.Color.Silver;
            this.rTxtBox.Location = new System.Drawing.Point(11, 61);
            this.rTxtBox.Name = "rTxtBox";
            this.rTxtBox.Size = new System.Drawing.Size(750, 124);
            this.rTxtBox.TabIndex = 10;
            this.rTxtBox.Text = "";
            // 
            // btnProceed
            // 
            this.btnProceed.BackColor = System.Drawing.Color.SteelBlue;
            this.btnProceed.FlatAppearance.BorderSize = 0;
            this.btnProceed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProceed.Font = new System.Drawing.Font("Trebuchet MS", 8F);
            this.btnProceed.ForeColor = System.Drawing.Color.White;
            this.btnProceed.Location = new System.Drawing.Point(621, 16);
            this.btnProceed.Margin = new System.Windows.Forms.Padding(4);
            this.btnProceed.Name = "btnProceed";
            this.btnProceed.Size = new System.Drawing.Size(140, 31);
            this.btnProceed.TabIndex = 6;
            this.btnProceed.Text = "Proceed";
            this.btnProceed.UseVisualStyleBackColor = false;
            this.btnProceed.Click += new System.EventHandler(this.btnProceed_Click);
            // 
            // tmrConsole
            // 
            this.tmrConsole.Enabled = true;
            this.tmrConsole.Interval = 1;
            this.tmrConsole.Tick += new System.EventHandler(this.tmrConsole_Tick);
            // 
            // FrmCentralSyncData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(44)))));
            this.ClientSize = new System.Drawing.Size(800, 287);
            this.Controls.Add(this.grpBoxSettingsUpdate);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCentralSyncData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EdBox Premium: Synchronize Data";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.grpBoxSettingsUpdate.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox grpBoxSettingsUpdate;
        private System.Windows.Forms.RichTextBox rTxtBox;
        private System.Windows.Forms.Button btnProceed;
        private System.Windows.Forms.Label lblNotify;
        private System.Windows.Forms.Timer tmrConsole;
    }
}