namespace EdBoxPremium.Local
{
    partial class FrmCentralReporting
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCentralReporting));
            this.grpBoxSettingsUpdate = new System.Windows.Forms.GroupBox();
            this.dgvAttendanceSessions = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Select = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Course = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Reason = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.lblNotify = new System.Windows.Forms.Label();
            this.tmrProcesses = new System.Windows.Forms.Timer(this.components);
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnClose = new System.Windows.Forms.Button();
            this.dateRecordedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.attendanceDescriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.schoolAttendanceSessionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.edboxDbDataSet = new EdBoxPremium.Local.EdboxDbDataSet();
            this.school_AttendanceSessionTableAdapter = new EdBoxPremium.Local.EdboxDbDataSetTableAdapters.School_AttendanceSessionTableAdapter();
            this.fldDialogFileLocation = new System.Windows.Forms.FolderBrowserDialog();
            this.grpBoxSettingsUpdate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttendanceSessions)).BeginInit();
            this.pnlHeader.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.schoolAttendanceSessionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edboxDbDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // grpBoxSettingsUpdate
            // 
            this.grpBoxSettingsUpdate.Controls.Add(this.dgvAttendanceSessions);
            this.grpBoxSettingsUpdate.Controls.Add(this.label5);
            this.grpBoxSettingsUpdate.ForeColor = System.Drawing.Color.Silver;
            this.grpBoxSettingsUpdate.Location = new System.Drawing.Point(9, 66);
            this.grpBoxSettingsUpdate.Margin = new System.Windows.Forms.Padding(4);
            this.grpBoxSettingsUpdate.Name = "grpBoxSettingsUpdate";
            this.grpBoxSettingsUpdate.Padding = new System.Windows.Forms.Padding(4);
            this.grpBoxSettingsUpdate.Size = new System.Drawing.Size(710, 283);
            this.grpBoxSettingsUpdate.TabIndex = 4;
            this.grpBoxSettingsUpdate.TabStop = false;
            this.grpBoxSettingsUpdate.Text = "Reporting";
            // 
            // dgvAttendanceSessions
            // 
            this.dgvAttendanceSessions.AllowUserToAddRows = false;
            this.dgvAttendanceSessions.AllowUserToDeleteRows = false;
            this.dgvAttendanceSessions.AutoGenerateColumns = false;
            this.dgvAttendanceSessions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAttendanceSessions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Select,
            this.dateRecordedDataGridViewTextBoxColumn,
            this.Course,
            this.Reason,
            this.attendanceDescriptionDataGridViewTextBoxColumn});
            this.dgvAttendanceSessions.DataSource = this.schoolAttendanceSessionBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(54)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAttendanceSessions.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvAttendanceSessions.Location = new System.Drawing.Point(11, 84);
            this.dgvAttendanceSessions.Name = "dgvAttendanceSessions";
            this.dgvAttendanceSessions.ReadOnly = true;
            this.dgvAttendanceSessions.RowTemplate.Height = 24;
            this.dgvAttendanceSessions.Size = new System.Drawing.Size(690, 192);
            this.dgvAttendanceSessions.TabIndex = 8;
            this.dgvAttendanceSessions.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAttendanceSessions_CellClick);
            this.dgvAttendanceSessions.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvAttendanceSessions_DataBindingComplete);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.Frozen = true;
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Width = 5;
            // 
            // Select
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Trebuchet MS", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.Select.DefaultCellStyle = dataGridViewCellStyle1;
            this.Select.Frozen = true;
            this.Select.HeaderText = "...";
            this.Select.Name = "Select";
            this.Select.ReadOnly = true;
            this.Select.Text = "export";
            this.Select.UseColumnTextForButtonValue = true;
            this.Select.Width = 80;
            // 
            // Course
            // 
            this.Course.HeaderText = "Course";
            this.Course.Name = "Course";
            this.Course.ReadOnly = true;
            this.Course.Width = 200;
            // 
            // Reason
            // 
            this.Reason.HeaderText = "Reason";
            this.Reason.Name = "Reason";
            this.Reason.ReadOnly = true;
            this.Reason.Width = 200;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Trebuchet MS", 8F);
            this.label5.ForeColor = System.Drawing.Color.SteelBlue;
            this.label5.Location = new System.Drawing.Point(11, 24);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(690, 48);
            this.label5.TabIndex = 7;
            this.label5.Text = "Enter the Url of the Server you wish to Pull Settings and Authentication Data fro" +
    "m. Proceed if the Url is the same. Previously saved date will be deleted.";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNotify
            // 
            this.lblNotify.AutoSize = true;
            this.lblNotify.Font = new System.Drawing.Font("Trebuchet MS", 8F);
            this.lblNotify.ForeColor = System.Drawing.Color.Orange;
            this.lblNotify.Location = new System.Drawing.Point(11, 13);
            this.lblNotify.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNotify.Name = "lblNotify";
            this.lblNotify.Size = new System.Drawing.Size(77, 18);
            this.lblNotify.TabIndex = 9;
            this.lblNotify.Text = "Working ...";
            this.lblNotify.Visible = false;
            // 
            // tmrProcesses
            // 
            this.tmrProcesses.Enabled = true;
            this.tmrProcesses.Tick += new System.EventHandler(this.tmrProcesses_Tick);
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.pnlHeader.Controls.Add(this.flowLayoutPanel2);
            this.pnlHeader.Controls.Add(this.lblNotify);
            this.pnlHeader.Location = new System.Drawing.Point(9, 13);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(710, 43);
            this.pnlHeader.TabIndex = 12;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.btnClose);
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(350, 7);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(351, 30);
            this.flowLayoutPanel2.TabIndex = 4;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Maroon;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Trebuchet MS", 8F);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(243, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(105, 25);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close && Exit";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dateRecordedDataGridViewTextBoxColumn
            // 
            this.dateRecordedDataGridViewTextBoxColumn.DataPropertyName = "DateRecorded";
            this.dateRecordedDataGridViewTextBoxColumn.Frozen = true;
            this.dateRecordedDataGridViewTextBoxColumn.HeaderText = "Date Taken";
            this.dateRecordedDataGridViewTextBoxColumn.Name = "dateRecordedDataGridViewTextBoxColumn";
            this.dateRecordedDataGridViewTextBoxColumn.ReadOnly = true;
            this.dateRecordedDataGridViewTextBoxColumn.Width = 120;
            // 
            // attendanceDescriptionDataGridViewTextBoxColumn
            // 
            this.attendanceDescriptionDataGridViewTextBoxColumn.DataPropertyName = "AttendanceDescription";
            this.attendanceDescriptionDataGridViewTextBoxColumn.HeaderText = "Attendance Description";
            this.attendanceDescriptionDataGridViewTextBoxColumn.Name = "attendanceDescriptionDataGridViewTextBoxColumn";
            this.attendanceDescriptionDataGridViewTextBoxColumn.ReadOnly = true;
            this.attendanceDescriptionDataGridViewTextBoxColumn.Width = 500;
            // 
            // schoolAttendanceSessionBindingSource
            // 
            this.schoolAttendanceSessionBindingSource.DataMember = "School_AttendanceSession";
            this.schoolAttendanceSessionBindingSource.DataSource = this.edboxDbDataSet;
            // 
            // edboxDbDataSet
            // 
            this.edboxDbDataSet.DataSetName = "EdboxDbDataSet";
            this.edboxDbDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // school_AttendanceSessionTableAdapter
            // 
            this.school_AttendanceSessionTableAdapter.ClearBeforeFill = true;
            // 
            // FrmCentralReporting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(54)))));
            this.ClientSize = new System.Drawing.Size(729, 362);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.grpBoxSettingsUpdate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmCentralReporting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.FrmCentralReporting_Load);
            this.Shown += new System.EventHandler(this.FrmSettings_Shown);
            this.grpBoxSettingsUpdate.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttendanceSessions)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.schoolAttendanceSessionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edboxDbDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBoxSettingsUpdate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblNotify;
        private System.Windows.Forms.Timer tmrProcesses;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button btnClose;
        private EdboxDbDataSet edboxDbDataSet;
        private System.Windows.Forms.BindingSource schoolAttendanceSessionBindingSource;
        private EdboxDbDataSetTableAdapters.School_AttendanceSessionTableAdapter school_AttendanceSessionTableAdapter;
        private System.Windows.Forms.DataGridView dgvAttendanceSessions;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewButtonColumn Select;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateRecordedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Course;
        private System.Windows.Forms.DataGridViewTextBoxColumn Reason;
        private System.Windows.Forms.DataGridViewTextBoxColumn attendanceDescriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.FolderBrowserDialog fldDialogFileLocation;
    }
}