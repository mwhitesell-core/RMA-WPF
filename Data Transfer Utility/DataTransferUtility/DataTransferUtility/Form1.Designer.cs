namespace DataTransferUtility
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Label5 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.txtDatabase = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.Button1 = new System.Windows.Forms.Button();
            this.txtMinimumYearCutoff = new System.Windows.Forms.TextBox();
            this.lblRead = new System.Windows.Forms.Label();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.lblAdded = new System.Windows.Forms.Label();
            this.lblRejected = new System.Windows.Forms.Label();
            this.chkIsDelimited = new System.Windows.Forms.CheckBox();
            this.txtDelimiter = new System.Windows.Forms.TextBox();
            this.Label7 = new System.Windows.Forms.Label();
            this.chkPortableSubFile = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDatabaseLocation = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lstTables = new System.Windows.Forms.ListBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.chkStructureOnly = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.cmboLegacyDB = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtScriptsLocation = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtSysDebugDate = new System.Windows.Forms.TextBox();
            this.chkSysDebugDate = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Label5
            // 
            this.Label5.Location = new System.Drawing.Point(12, 61);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(70, 16);
            this.Label5.TabIndex = 30;
            this.Label5.Text = "SQL Server:";
            this.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label4
            // 
            this.Label4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Label4.Location = new System.Drawing.Point(12, 35);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(53, 14);
            this.Label4.TabIndex = 29;
            this.Label4.Text = "Password:";
            this.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label3
            // 
            this.Label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Label3.Location = new System.Drawing.Point(12, 6);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(32, 18);
            this.Label3.TabIndex = 28;
            this.Label3.Text = "User:";
            this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(132, 59);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(311, 20);
            this.txtServer.TabIndex = 3;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(132, 33);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(311, 20);
            this.txtPassword.TabIndex = 2;
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(132, 6);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(311, 20);
            this.txtUser.TabIndex = 1;
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(132, 161);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(432, 20);
            this.txtFileName.TabIndex = 7;
            this.txtFileName.LostFocus += new System.EventHandler(this.txtFileName_LostFocus);
            // 
            // txtDatabase
            // 
            this.txtDatabase.Location = new System.Drawing.Point(132, 110);
            this.txtDatabase.Name = "txtDatabase";
            this.txtDatabase.Size = new System.Drawing.Size(246, 20);
            this.txtDatabase.TabIndex = 5;
            // 
            // Label2
            // 
            this.Label2.Location = new System.Drawing.Point(12, 164);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(100, 20);
            this.Label2.TabIndex = 22;
            this.Label2.Text = "dat File Location:";
            // 
            // Label1
            // 
            this.Label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Label1.Location = new System.Drawing.Point(12, 113);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(100, 19);
            this.Label1.TabIndex = 21;
            this.Label1.Text = "Database Name:";
            // 
            // Button1
            // 
            this.Button1.Location = new System.Drawing.Point(472, 8);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(75, 22);
            this.Button1.TabIndex = 18;
            this.Button1.Text = "Import";
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // txtMinimumYearCutoff
            // 
            this.txtMinimumYearCutoff.Location = new System.Drawing.Point(115, 219);
            this.txtMinimumYearCutoff.MaxLength = 2;
            this.txtMinimumYearCutoff.Name = "txtMinimumYearCutoff";
            this.txtMinimumYearCutoff.Size = new System.Drawing.Size(23, 20);
            this.txtMinimumYearCutoff.TabIndex = 9;
            this.txtMinimumYearCutoff.Text = "50";
            this.txtMinimumYearCutoff.LostFocus += new System.EventHandler(this.txtMinimumYearCutoff_LostFocus);
            // 
            // lblRead
            // 
            this.lblRead.Location = new System.Drawing.Point(12, 526);
            this.lblRead.Name = "lblRead";
            this.lblRead.Size = new System.Drawing.Size(536, 20);
            this.lblRead.TabIndex = 31;
            this.lblRead.Text = "Records Read:";
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(12, 608);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLog.Size = new System.Drawing.Size(535, 168);
            this.txtLog.TabIndex = 17;
            // 
            // Label6
            // 
            this.Label6.Location = new System.Drawing.Point(12, 591);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(83, 14);
            this.Label6.TabIndex = 33;
            this.Label6.Text = "Log:";
            // 
            // lblAdded
            // 
            this.lblAdded.Location = new System.Drawing.Point(12, 549);
            this.lblAdded.Name = "lblAdded";
            this.lblAdded.Size = new System.Drawing.Size(536, 20);
            this.lblAdded.TabIndex = 34;
            this.lblAdded.Text = "Records Added:";
            // 
            // lblRejected
            // 
            this.lblRejected.Location = new System.Drawing.Point(12, 571);
            this.lblRejected.Name = "lblRejected";
            this.lblRejected.Size = new System.Drawing.Size(535, 19);
            this.lblRejected.TabIndex = 35;
            this.lblRejected.Text = "Records Rejected:";
            // 
            // chkIsDelimited
            // 
            this.chkIsDelimited.AutoSize = true;
            this.chkIsDelimited.Location = new System.Drawing.Point(15, 17);
            this.chkIsDelimited.Name = "chkIsDelimited";
            this.chkIsDelimited.Size = new System.Drawing.Size(109, 17);
            this.chkIsDelimited.TabIndex = 14;
            this.chkIsDelimited.Text = "Delimited data file";
            this.chkIsDelimited.UseVisualStyleBackColor = true;
            // 
            // txtDelimiter
            // 
            this.txtDelimiter.Location = new System.Drawing.Point(185, 14);
            this.txtDelimiter.MaxLength = 1;
            this.txtDelimiter.Name = "txtDelimiter";
            this.txtDelimiter.Size = new System.Drawing.Size(17, 20);
            this.txtDelimiter.TabIndex = 15;
            this.txtDelimiter.Text = ",";
            // 
            // Label7
            // 
            this.Label7.Location = new System.Drawing.Point(130, 16);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(53, 14);
            this.Label7.TabIndex = 42;
            this.Label7.Text = "Delimiter:";
            this.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkPortableSubFile
            // 
            this.chkPortableSubFile.AutoSize = true;
            this.chkPortableSubFile.Location = new System.Drawing.Point(227, 16);
            this.chkPortableSubFile.Name = "chkPortableSubFile";
            this.chkPortableSubFile.Size = new System.Drawing.Size(106, 17);
            this.chkPortableSubFile.TabIndex = 16;
            this.chkPortableSubFile.Text = "Portable Sub-File";
            this.chkPortableSubFile.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkPortableSubFile);
            this.groupBox1.Controls.Add(this.Label7);
            this.groupBox1.Controls.Add(this.txtDelimiter);
            this.groupBox1.Controls.Add(this.chkIsDelimited);
            this.groupBox1.Location = new System.Drawing.Point(178, 477);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(334, 46);
            this.groupBox1.TabIndex = 36;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Data File Details:";
            this.groupBox1.Visible = false;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(472, 36);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 19;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label9.Location = new System.Drawing.Point(12, 139);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 13);
            this.label9.TabIndex = 51;
            this.label9.Text = "Database Location:";
            // 
            // txtDatabaseLocation
            // 
            this.txtDatabaseLocation.Location = new System.Drawing.Point(132, 135);
            this.txtDatabaseLocation.Name = "txtDatabaseLocation";
            this.txtDatabaseLocation.Size = new System.Drawing.Size(432, 20);
            this.txtDatabaseLocation.TabIndex = 6;
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(11, 505);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(536, 20);
            this.lblStatus.TabIndex = 100;
            this.lblStatus.Text = "Status:";
            // 
            // lstTables
            // 
            this.lstTables.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstTables.FormattingEnabled = true;
            this.lstTables.ItemHeight = 15;
            this.lstTables.Location = new System.Drawing.Point(14, 324);
            this.lstTables.Name = "lstTables";
            this.lstTables.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstTables.Size = new System.Drawing.Size(533, 139);
            this.lstTables.Sorted = true;
            this.lstTables.TabIndex = 13;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(16, 289);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(258, 13);
            this.label11.TabIndex = 103;
            this.label11.Text = "Do not select any files to do a data transfer of all files.";
            // 
            // label8
            // 
            this.label8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label8.Location = new System.Drawing.Point(10, 212);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 31);
            this.label8.TabIndex = 45;
            this.label8.Text = "Default century:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(23, 307);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 13);
            this.label10.TabIndex = 102;
            this.label10.Text = "SQL Server Tables:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(307, 307);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 13);
            this.label12.TabIndex = 104;
            this.label12.Text = "dat File";
            // 
            // chkStructureOnly
            // 
            this.chkStructureOnly.AutoSize = true;
            this.chkStructureOnly.Location = new System.Drawing.Point(354, 220);
            this.chkStructureOnly.Name = "chkStructureOnly";
            this.chkStructureOnly.Size = new System.Drawing.Size(15, 14);
            this.chkStructureOnly.TabIndex = 10;
            this.chkStructureOnly.UseVisualStyleBackColor = true;
            this.chkStructureOnly.CheckedChanged += new System.EventHandler(this.chkStructureOnly_CheckedChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(167, 221);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(181, 13);
            this.label13.TabIndex = 106;
            this.label13.Text = "Create Database Structure (no data):";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(12, 87);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(115, 13);
            this.label14.TabIndex = 107;
            this.label14.Text = "Environment to Create:";
            // 
            // cmboLegacyDB
            // 
            this.cmboLegacyDB.FormattingEnabled = true;
            this.cmboLegacyDB.Items.AddRange(new object[] {
            "101C",
            "MP",
            "SOLO",
            "Logging",
            "Security"});
            this.cmboLegacyDB.Location = new System.Drawing.Point(132, 84);
            this.cmboLegacyDB.Name = "cmboLegacyDB";
            this.cmboLegacyDB.Size = new System.Drawing.Size(121, 21);
            this.cmboLegacyDB.TabIndex = 4;
            this.cmboLegacyDB.SelectedIndexChanged += new System.EventHandler(this.cmboLegacyDB_SelectedIndexChanged);
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(12, 189);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(100, 20);
            this.label15.TabIndex = 108;
            this.label15.Text = "Scripts Location:";
            // 
            // txtScriptsLocation
            // 
            this.txtScriptsLocation.Location = new System.Drawing.Point(132, 186);
            this.txtScriptsLocation.Name = "txtScriptsLocation";
            this.txtScriptsLocation.Size = new System.Drawing.Size(432, 20);
            this.txtScriptsLocation.TabIndex = 8;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(12, 254);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(188, 13);
            this.label17.TabIndex = 110;
            this.label17.Text = "Insert Sys Debug Date (YYYYMMDD):";
            // 
            // txtSysDebugDate
            // 
            this.txtSysDebugDate.Location = new System.Drawing.Point(237, 251);
            this.txtSysDebugDate.Name = "txtSysDebugDate";
            this.txtSysDebugDate.Size = new System.Drawing.Size(72, 20);
            this.txtSysDebugDate.TabIndex = 12;
            // 
            // chkSysDebugDate
            // 
            this.chkSysDebugDate.AutoSize = true;
            this.chkSysDebugDate.Location = new System.Drawing.Point(206, 254);
            this.chkSysDebugDate.Name = "chkSysDebugDate";
            this.chkSysDebugDate.Size = new System.Drawing.Size(15, 14);
            this.chkSysDebugDate.TabIndex = 11;
            this.chkSysDebugDate.UseVisualStyleBackColor = true;
            this.chkSysDebugDate.CheckedChanged += new System.EventHandler(this.chkSysDebugDate_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 787);
            this.Controls.Add(this.chkSysDebugDate);
            this.Controls.Add(this.txtSysDebugDate);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.txtScriptsLocation);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.cmboLegacyDB);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.chkStructureOnly);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lstTables);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.txtDatabaseLocation);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtMinimumYearCutoff);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblRejected);
            this.Controls.Add(this.lblAdded);
            this.Controls.Add(this.Label6);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.lblRead);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.txtServer);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.txtDatabase);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.Button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Data Transfer Utility";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.TextBox txtServer;
        internal System.Windows.Forms.TextBox txtPassword;
        internal System.Windows.Forms.TextBox txtUser;
        internal System.Windows.Forms.TextBox txtFileName;
        internal System.Windows.Forms.TextBox txtDatabase;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Button Button1;
        internal System.Windows.Forms.TextBox txtMinimumYearCutoff;
        internal System.Windows.Forms.Label lblRead;
        internal System.Windows.Forms.TextBox txtLog;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Label lblAdded;
        internal System.Windows.Forms.Label lblRejected;
        internal System.Windows.Forms.CheckBox chkIsDelimited;
        internal System.Windows.Forms.TextBox txtDelimiter;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.CheckBox chkPortableSubFile;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtDatabaseLocation;
        internal System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ListBox lstTables;
        private System.Windows.Forms.Label label11;
        internal System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox chkStructureOnly;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cmboLegacyDB;
        internal System.Windows.Forms.Label label15;
        internal System.Windows.Forms.TextBox txtScriptsLocation;
        private System.Windows.Forms.Label label17;
        internal System.Windows.Forms.TextBox txtSysDebugDate;
        private System.Windows.Forms.CheckBox chkSysDebugDate;
    }
}

