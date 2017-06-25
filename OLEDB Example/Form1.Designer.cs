namespace OLEDB_Example
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buttonAddSpreadsheet = new System.Windows.Forms.Button();
            this.buttonTruncate = new System.Windows.Forms.Button();
            this.comboBoxDatabaseReading = new System.Windows.Forms.ComboBox();
            this.buttonOpenSpreadsheet = new System.Windows.Forms.Button();
            this.groupBoxDebug = new System.Windows.Forms.GroupBox();
            this.buttonDeauthorize = new System.Windows.Forms.Button();
            this.buttonDeleteStation = new System.Windows.Forms.Button();
            this.textBoxDeauthorize = new System.Windows.Forms.TextBox();
            this.buttonAddStation = new System.Windows.Forms.Button();
            this.groupBoxAddStation = new System.Windows.Forms.GroupBox();
            this.labelStationLoading = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panelStation = new System.Windows.Forms.Panel();
            this.radioButtonStationAmbient = new System.Windows.Forms.RadioButton();
            this.radioButtonStationRoadside = new System.Windows.Forms.RadioButton();
            this.textBoxStationName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.labelLoading = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.panelMiscControls = new System.Windows.Forms.Panel();
            this.groupBoxRegister = new System.Windows.Forms.GroupBox();
            this.labelRegisterError = new System.Windows.Forms.Label();
            this.buttonRegister = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxRegisterRePassword = new System.Windows.Forms.TextBox();
            this.textBoxRegisterPassword = new System.Windows.Forms.TextBox();
            this.textBoxRegisterUsername = new System.Windows.Forms.TextBox();
            this.buttonClose = new System.Windows.Forms.Button();
            this.labelFileName = new System.Windows.Forms.Label();
            this.groupBoxAddSpreadsheet = new System.Windows.Forms.GroupBox();
            this.panelDGV = new System.Windows.Forms.Panel();
            this.panelSpreadsheetControls = new System.Windows.Forms.Panel();
            this.panelAddSpreadsheet = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBoxDebug.SuspendLayout();
            this.groupBoxAddStation.SuspendLayout();
            this.panelStation.SuspendLayout();
            this.panelMiscControls.SuspendLayout();
            this.groupBoxRegister.SuspendLayout();
            this.groupBoxAddSpreadsheet.SuspendLayout();
            this.panelDGV.SuspendLayout();
            this.panelSpreadsheetControls.SuspendLayout();
            this.panelAddSpreadsheet.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Location = new System.Drawing.Point(10, 11);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(639, 298);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.TabStop = false;
            // 
            // buttonAddSpreadsheet
            // 
            this.buttonAddSpreadsheet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddSpreadsheet.Location = new System.Drawing.Point(20, 42);
            this.buttonAddSpreadsheet.Name = "buttonAddSpreadsheet";
            this.buttonAddSpreadsheet.Size = new System.Drawing.Size(160, 27);
            this.buttonAddSpreadsheet.TabIndex = 3;
            this.buttonAddSpreadsheet.Text = "Add Spreadsheet";
            this.buttonAddSpreadsheet.UseVisualStyleBackColor = true;
            this.buttonAddSpreadsheet.Click += new System.EventHandler(this.buttonAddSpreadsheet_Click);
            // 
            // buttonTruncate
            // 
            this.buttonTruncate.BackColor = System.Drawing.SystemColors.Control;
            this.buttonTruncate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTruncate.Location = new System.Drawing.Point(6, 71);
            this.buttonTruncate.Name = "buttonTruncate";
            this.buttonTruncate.Size = new System.Drawing.Size(194, 23);
            this.buttonTruncate.TabIndex = 2;
            this.buttonTruncate.Text = "Truncate Readings Tables";
            this.buttonTruncate.UseVisualStyleBackColor = false;
            this.buttonTruncate.Click += new System.EventHandler(this.buttonTruncate_Click);
            // 
            // comboBoxDatabaseReading
            // 
            this.comboBoxDatabaseReading.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDatabaseReading.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxDatabaseReading.FormattingEnabled = true;
            this.comboBoxDatabaseReading.Location = new System.Drawing.Point(20, 12);
            this.comboBoxDatabaseReading.Name = "comboBoxDatabaseReading";
            this.comboBoxDatabaseReading.Size = new System.Drawing.Size(160, 24);
            this.comboBoxDatabaseReading.TabIndex = 2;
            this.comboBoxDatabaseReading.DropDown += new System.EventHandler(this.comboBoxDatabaseReading_DropDown);
            this.comboBoxDatabaseReading.SelectionChangeCommitted += new System.EventHandler(this.comboBoxDatabaseReading_SelectionChangeCommitted);
            // 
            // buttonOpenSpreadsheet
            // 
            this.buttonOpenSpreadsheet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOpenSpreadsheet.Location = new System.Drawing.Point(33, 45);
            this.buttonOpenSpreadsheet.Name = "buttonOpenSpreadsheet";
            this.buttonOpenSpreadsheet.Size = new System.Drawing.Size(174, 32);
            this.buttonOpenSpreadsheet.TabIndex = 1;
            this.buttonOpenSpreadsheet.Text = "Open Spreadsheet File";
            this.buttonOpenSpreadsheet.UseVisualStyleBackColor = true;
            this.buttonOpenSpreadsheet.Click += new System.EventHandler(this.buttonOpenSpreadsheet_Click);
            // 
            // groupBoxDebug
            // 
            this.groupBoxDebug.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxDebug.Controls.Add(this.buttonDeauthorize);
            this.groupBoxDebug.Controls.Add(this.buttonDeleteStation);
            this.groupBoxDebug.Controls.Add(this.buttonTruncate);
            this.groupBoxDebug.Controls.Add(this.textBoxDeauthorize);
            this.groupBoxDebug.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxDebug.Location = new System.Drawing.Point(358, 3);
            this.groupBoxDebug.Name = "groupBoxDebug";
            this.groupBoxDebug.Size = new System.Drawing.Size(206, 127);
            this.groupBoxDebug.TabIndex = 0;
            this.groupBoxDebug.TabStop = false;
            this.groupBoxDebug.Text = "Debug";
            this.groupBoxDebug.Visible = false;
            // 
            // buttonDeauthorize
            // 
            this.buttonDeauthorize.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDeauthorize.Location = new System.Drawing.Point(87, 45);
            this.buttonDeauthorize.Name = "buttonDeauthorize";
            this.buttonDeauthorize.Size = new System.Drawing.Size(113, 23);
            this.buttonDeauthorize.TabIndex = 1;
            this.buttonDeauthorize.Text = "Deauthorize User";
            this.buttonDeauthorize.UseVisualStyleBackColor = true;
            this.buttonDeauthorize.Click += new System.EventHandler(this.buttonDeauthorize_Click);
            // 
            // buttonDeleteStation
            // 
            this.buttonDeleteStation.BackColor = System.Drawing.SystemColors.Control;
            this.buttonDeleteStation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDeleteStation.Location = new System.Drawing.Point(6, 99);
            this.buttonDeleteStation.Name = "buttonDeleteStation";
            this.buttonDeleteStation.Size = new System.Drawing.Size(194, 23);
            this.buttonDeleteStation.TabIndex = 3;
            this.buttonDeleteStation.Text = "Delete All Stations";
            this.buttonDeleteStation.UseVisualStyleBackColor = false;
            this.buttonDeleteStation.Click += new System.EventHandler(this.buttonDeleteStation_Click);
            // 
            // textBoxDeauthorize
            // 
            this.textBoxDeauthorize.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDeauthorize.Location = new System.Drawing.Point(6, 19);
            this.textBoxDeauthorize.Name = "textBoxDeauthorize";
            this.textBoxDeauthorize.Size = new System.Drawing.Size(194, 20);
            this.textBoxDeauthorize.TabIndex = 0;
            this.textBoxDeauthorize.TextChanged += new System.EventHandler(this.textBoxDeauthorize_TextChanged);
            // 
            // buttonAddStation
            // 
            this.buttonAddStation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddStation.Location = new System.Drawing.Point(39, 68);
            this.buttonAddStation.Name = "buttonAddStation";
            this.buttonAddStation.Size = new System.Drawing.Size(151, 28);
            this.buttonAddStation.TabIndex = 25;
            this.buttonAddStation.Text = "Add New Station";
            this.buttonAddStation.UseVisualStyleBackColor = true;
            this.buttonAddStation.Click += new System.EventHandler(this.buttonAddStation_Click);
            // 
            // groupBoxAddStation
            // 
            this.groupBoxAddStation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxAddStation.Controls.Add(this.labelStationLoading);
            this.groupBoxAddStation.Controls.Add(this.label3);
            this.groupBoxAddStation.Controls.Add(this.panelStation);
            this.groupBoxAddStation.Controls.Add(this.label2);
            this.groupBoxAddStation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxAddStation.Location = new System.Drawing.Point(578, 390);
            this.groupBoxAddStation.Name = "groupBoxAddStation";
            this.groupBoxAddStation.Size = new System.Drawing.Size(349, 127);
            this.groupBoxAddStation.TabIndex = 20;
            this.groupBoxAddStation.TabStop = false;
            this.groupBoxAddStation.Text = "Add New Station";
            // 
            // labelStationLoading
            // 
            this.labelStationLoading.AutoSize = true;
            this.labelStationLoading.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStationLoading.Location = new System.Drawing.Point(24, 92);
            this.labelStationLoading.Name = "labelStationLoading";
            this.labelStationLoading.Size = new System.Drawing.Size(100, 16);
            this.labelStationLoading.TabIndex = 54;
            this.labelStationLoading.Text = "Please wait...";
            this.labelStationLoading.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(24, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 16);
            this.label3.TabIndex = 21;
            this.label3.Text = "Station type";
            // 
            // panelStation
            // 
            this.panelStation.Controls.Add(this.radioButtonStationAmbient);
            this.panelStation.Controls.Add(this.radioButtonStationRoadside);
            this.panelStation.Controls.Add(this.textBoxStationName);
            this.panelStation.Controls.Add(this.buttonAddStation);
            this.panelStation.Location = new System.Drawing.Point(116, 22);
            this.panelStation.Name = "panelStation";
            this.panelStation.Size = new System.Drawing.Size(227, 99);
            this.panelStation.TabIndex = 20;
            // 
            // radioButtonStationAmbient
            // 
            this.radioButtonStationAmbient.AutoSize = true;
            this.radioButtonStationAmbient.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonStationAmbient.Location = new System.Drawing.Point(98, 38);
            this.radioButtonStationAmbient.Name = "radioButtonStationAmbient";
            this.radioButtonStationAmbient.Size = new System.Drawing.Size(126, 20);
            this.radioButtonStationAmbient.TabIndex = 23;
            this.radioButtonStationAmbient.TabStop = true;
            this.radioButtonStationAmbient.Text = "General Ambient";
            this.radioButtonStationAmbient.UseVisualStyleBackColor = true;
            // 
            // radioButtonStationRoadside
            // 
            this.radioButtonStationRoadside.AutoSize = true;
            this.radioButtonStationRoadside.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonStationRoadside.Location = new System.Drawing.Point(6, 38);
            this.radioButtonStationRoadside.Name = "radioButtonStationRoadside";
            this.radioButtonStationRoadside.Size = new System.Drawing.Size(86, 20);
            this.radioButtonStationRoadside.TabIndex = 22;
            this.radioButtonStationRoadside.TabStop = true;
            this.radioButtonStationRoadside.Text = "Roadside";
            this.radioButtonStationRoadside.UseVisualStyleBackColor = true;
            // 
            // textBoxStationName
            // 
            this.textBoxStationName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxStationName.Location = new System.Drawing.Point(6, 6);
            this.textBoxStationName.Name = "textBoxStationName";
            this.textBoxStationName.Size = new System.Drawing.Size(218, 22);
            this.textBoxStationName.TabIndex = 21;
            this.textBoxStationName.TextChanged += new System.EventHandler(this.textBoxStationName_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 16);
            this.label2.TabIndex = 17;
            this.label2.Text = "Station name";
            // 
            // labelLoading
            // 
            this.labelLoading.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelLoading.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.labelLoading.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLoading.Location = new System.Drawing.Point(211, 163);
            this.labelLoading.Name = "labelLoading";
            this.labelLoading.Size = new System.Drawing.Size(225, 20);
            this.labelLoading.TabIndex = 16;
            this.labelLoading.Text = "Loading...";
            this.labelLoading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelLoading.Visible = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.progressBar1.Location = new System.Drawing.Point(211, 137);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(225, 23);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 17;
            this.progressBar1.Visible = false;
            // 
            // panelMiscControls
            // 
            this.panelMiscControls.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMiscControls.Controls.Add(this.groupBoxRegister);
            this.panelMiscControls.Controls.Add(this.groupBoxDebug);
            this.panelMiscControls.Controls.Add(this.buttonClose);
            this.panelMiscControls.Location = new System.Drawing.Point(2, 387);
            this.panelMiscControls.Name = "panelMiscControls";
            this.panelMiscControls.Size = new System.Drawing.Size(570, 137);
            this.panelMiscControls.TabIndex = 50;
            // 
            // groupBoxRegister
            // 
            this.groupBoxRegister.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxRegister.Controls.Add(this.labelRegisterError);
            this.groupBoxRegister.Controls.Add(this.buttonRegister);
            this.groupBoxRegister.Controls.Add(this.label5);
            this.groupBoxRegister.Controls.Add(this.label4);
            this.groupBoxRegister.Controls.Add(this.label1);
            this.groupBoxRegister.Controls.Add(this.textBoxRegisterRePassword);
            this.groupBoxRegister.Controls.Add(this.textBoxRegisterPassword);
            this.groupBoxRegister.Controls.Add(this.textBoxRegisterUsername);
            this.groupBoxRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxRegister.Location = new System.Drawing.Point(67, 3);
            this.groupBoxRegister.Name = "groupBoxRegister";
            this.groupBoxRegister.Size = new System.Drawing.Size(285, 127);
            this.groupBoxRegister.TabIndex = 1;
            this.groupBoxRegister.TabStop = false;
            this.groupBoxRegister.Text = "Register New User";
            // 
            // labelRegisterError
            // 
            this.labelRegisterError.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRegisterError.Location = new System.Drawing.Point(6, 104);
            this.labelRegisterError.Name = "labelRegisterError";
            this.labelRegisterError.Size = new System.Drawing.Size(149, 13);
            this.labelRegisterError.TabIndex = 7;
            this.labelRegisterError.Text = "Passwords don\'t match";
            this.labelRegisterError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelRegisterError.Visible = false;
            // 
            // buttonRegister
            // 
            this.buttonRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRegister.Location = new System.Drawing.Point(161, 99);
            this.buttonRegister.Name = "buttonRegister";
            this.buttonRegister.Size = new System.Drawing.Size(113, 23);
            this.buttonRegister.TabIndex = 6;
            this.buttonRegister.Text = "Register User";
            this.buttonRegister.UseVisualStyleBackColor = true;
            this.buttonRegister.Click += new System.EventHandler(this.buttonRegister_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(11, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Retype Password";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(48, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(46, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Username";
            // 
            // textBoxRegisterRePassword
            // 
            this.textBoxRegisterRePassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxRegisterRePassword.Location = new System.Drawing.Point(107, 73);
            this.textBoxRegisterRePassword.Name = "textBoxRegisterRePassword";
            this.textBoxRegisterRePassword.PasswordChar = '*';
            this.textBoxRegisterRePassword.Size = new System.Drawing.Size(167, 20);
            this.textBoxRegisterRePassword.TabIndex = 2;
            this.textBoxRegisterRePassword.TextChanged += new System.EventHandler(this.textBoxRegisterRePassword_TextChanged);
            // 
            // textBoxRegisterPassword
            // 
            this.textBoxRegisterPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxRegisterPassword.Location = new System.Drawing.Point(107, 47);
            this.textBoxRegisterPassword.Name = "textBoxRegisterPassword";
            this.textBoxRegisterPassword.PasswordChar = '*';
            this.textBoxRegisterPassword.Size = new System.Drawing.Size(167, 20);
            this.textBoxRegisterPassword.TabIndex = 1;
            this.textBoxRegisterPassword.TextChanged += new System.EventHandler(this.textBoxRegisterPassword_TextChanged);
            // 
            // textBoxRegisterUsername
            // 
            this.textBoxRegisterUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxRegisterUsername.Location = new System.Drawing.Point(107, 19);
            this.textBoxRegisterUsername.Name = "textBoxRegisterUsername";
            this.textBoxRegisterUsername.Size = new System.Drawing.Size(167, 20);
            this.textBoxRegisterUsername.TabIndex = 0;
            this.textBoxRegisterUsername.TextChanged += new System.EventHandler(this.textBoxRegisterUsername_TextChanged);
            // 
            // buttonClose
            // 
            this.buttonClose.BackgroundImage = global::OLEDB_Example.Properties.Resources._return;
            this.buttonClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonClose.Location = new System.Drawing.Point(10, 79);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(51, 51);
            this.buttonClose.TabIndex = 99;
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // labelFileName
            // 
            this.labelFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFileName.Location = new System.Drawing.Point(13, 25);
            this.labelFileName.Name = "labelFileName";
            this.labelFileName.Size = new System.Drawing.Size(642, 32);
            this.labelFileName.TabIndex = 16;
            this.labelFileName.Text = "No file selected";
            this.labelFileName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBoxAddSpreadsheet
            // 
            this.groupBoxAddSpreadsheet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxAddSpreadsheet.Controls.Add(this.panelDGV);
            this.groupBoxAddSpreadsheet.Controls.Add(this.panelSpreadsheetControls);
            this.groupBoxAddSpreadsheet.Controls.Add(this.labelFileName);
            this.groupBoxAddSpreadsheet.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxAddSpreadsheet.Location = new System.Drawing.Point(13, 12);
            this.groupBoxAddSpreadsheet.Name = "groupBoxAddSpreadsheet";
            this.groupBoxAddSpreadsheet.Size = new System.Drawing.Size(914, 369);
            this.groupBoxAddSpreadsheet.TabIndex = 1;
            this.groupBoxAddSpreadsheet.TabStop = false;
            this.groupBoxAddSpreadsheet.Text = "Add Spreadsheet";
            // 
            // panelDGV
            // 
            this.panelDGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelDGV.Controls.Add(this.progressBar1);
            this.panelDGV.Controls.Add(this.labelLoading);
            this.panelDGV.Controls.Add(this.dataGridView1);
            this.panelDGV.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelDGV.Location = new System.Drawing.Point(6, 54);
            this.panelDGV.Name = "panelDGV";
            this.panelDGV.Size = new System.Drawing.Size(662, 314);
            this.panelDGV.TabIndex = 20;
            // 
            // panelSpreadsheetControls
            // 
            this.panelSpreadsheetControls.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelSpreadsheetControls.Controls.Add(this.panelAddSpreadsheet);
            this.panelSpreadsheetControls.Controls.Add(this.buttonOpenSpreadsheet);
            this.panelSpreadsheetControls.Location = new System.Drawing.Point(668, 72);
            this.panelSpreadsheetControls.Name = "panelSpreadsheetControls";
            this.panelSpreadsheetControls.Size = new System.Drawing.Size(245, 206);
            this.panelSpreadsheetControls.TabIndex = 1;
            // 
            // panelAddSpreadsheet
            // 
            this.panelAddSpreadsheet.Controls.Add(this.comboBoxDatabaseReading);
            this.panelAddSpreadsheet.Controls.Add(this.buttonAddSpreadsheet);
            this.panelAddSpreadsheet.Location = new System.Drawing.Point(23, 90);
            this.panelAddSpreadsheet.Name = "panelAddSpreadsheet";
            this.panelAddSpreadsheet.Size = new System.Drawing.Size(197, 83);
            this.panelAddSpreadsheet.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonClose;
            this.ClientSize = new System.Drawing.Size(939, 529);
            this.Controls.Add(this.groupBoxAddStation);
            this.Controls.Add(this.groupBoxAddSpreadsheet);
            this.Controls.Add(this.panelMiscControls);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Database Management";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBoxDebug.ResumeLayout(false);
            this.groupBoxDebug.PerformLayout();
            this.groupBoxAddStation.ResumeLayout(false);
            this.groupBoxAddStation.PerformLayout();
            this.panelStation.ResumeLayout(false);
            this.panelStation.PerformLayout();
            this.panelMiscControls.ResumeLayout(false);
            this.groupBoxRegister.ResumeLayout(false);
            this.groupBoxRegister.PerformLayout();
            this.groupBoxAddSpreadsheet.ResumeLayout(false);
            this.panelDGV.ResumeLayout(false);
            this.panelSpreadsheetControls.ResumeLayout(false);
            this.panelAddSpreadsheet.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonAddSpreadsheet;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonTruncate;
        private System.Windows.Forms.ComboBox comboBoxDatabaseReading;
        private System.Windows.Forms.Button buttonOpenSpreadsheet;
        private System.Windows.Forms.GroupBox groupBoxDebug;
        private System.Windows.Forms.Button buttonAddStation;
        private System.Windows.Forms.GroupBox groupBoxAddStation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxStationName;
        private System.Windows.Forms.Label labelLoading;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Panel panelMiscControls;
        private System.Windows.Forms.Label labelFileName;
        private System.Windows.Forms.GroupBox groupBoxAddSpreadsheet;
        private System.Windows.Forms.Panel panelAddSpreadsheet;
        private System.Windows.Forms.Panel panelSpreadsheetControls;
        private System.Windows.Forms.Panel panelDGV;
        private System.Windows.Forms.Panel panelStation;
        private System.Windows.Forms.Label labelStationLoading;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton radioButtonStationAmbient;
        private System.Windows.Forms.RadioButton radioButtonStationRoadside;
        private System.Windows.Forms.Button buttonDeleteStation;
        private System.Windows.Forms.GroupBox groupBoxRegister;
        private System.Windows.Forms.Label labelRegisterError;
        private System.Windows.Forms.Button buttonRegister;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxRegisterRePassword;
        private System.Windows.Forms.TextBox textBoxRegisterPassword;
        private System.Windows.Forms.TextBox textBoxRegisterUsername;
        private System.Windows.Forms.Button buttonDeauthorize;
        private System.Windows.Forms.TextBox textBoxDeauthorize;
    }
}

