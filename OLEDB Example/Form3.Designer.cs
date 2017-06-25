namespace OLEDB_Example
{
    partial class Form3
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
            this.label23 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonStartLatest = new System.Windows.Forms.RadioButton();
            this.radioButtonStartEarliest = new System.Windows.Forms.RadioButton();
            this.radioButtonStartCustom = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButtonEndLatest = new System.Windows.Forms.RadioButton();
            this.radioButtonEndCustom = new System.Windows.Forms.RadioButton();
            this.dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.listBoxSelected = new System.Windows.Forms.ListBox();
            this.listBoxCollection = new System.Windows.Forms.ListBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.buttonRemoveAll = new System.Windows.Forms.Button();
            this.buttonTable = new System.Windows.Forms.Button();
            this.buttonAddAll = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radioButtonStationAmbient = new System.Windows.Forms.RadioButton();
            this.radioButtonStationRoadside = new System.Windows.Forms.RadioButton();
            this.radioButtonStationAll = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxReading = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBoxIncludeForecasts = new System.Windows.Forms.CheckBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonMakeChart = new System.Windows.Forms.Button();
            this.listBoxNotes = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonCopyNotes = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.panelFilterControls = new System.Windows.Forms.Panel();
            this.buttonFilterCheck = new System.Windows.Forms.Button();
            this.checkBoxFilterUnhealthy = new System.Windows.Forms.CheckBox();
            this.checkBoxFilterHazardous = new System.Windows.Forms.CheckBox();
            this.checkBoxFilterVeryUnhealthy = new System.Windows.Forms.CheckBox();
            this.checkBoxFilterSensitive = new System.Windows.Forms.CheckBox();
            this.checkBoxFilterModerate = new System.Windows.Forms.CheckBox();
            this.checkBoxFilterGood = new System.Windows.Forms.CheckBox();
            this.radioButtonFilterEnable = new System.Windows.Forms.RadioButton();
            this.radioButtonFilterDisable = new System.Windows.Forms.RadioButton();
            this.panelControls = new System.Windows.Forms.Panel();
            this.panelLegend = new System.Windows.Forms.Panel();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.panelFilterControls.SuspendLayout();
            this.panelControls.SuspendLayout();
            this.panelLegend.SuspendLayout();
            this.SuspendLayout();
            // 
            // label23
            // 
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(55, 6);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(140, 30);
            this.label23.TabIndex = 44;
            this.label23.Text = "Air Pollution Level";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label22);
            this.groupBox4.Controls.Add(this.label21);
            this.groupBox4.Controls.Add(this.label20);
            this.groupBox4.Controls.Add(this.label19);
            this.groupBox4.Controls.Add(this.label18);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Location = new System.Drawing.Point(12, 20);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(219, 129);
            this.groupBox4.TabIndex = 43;
            this.groupBox4.TabStop = false;
            // 
            // label22
            // 
            this.label22.BackColor = System.Drawing.Color.Firebrick;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(6, 104);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(208, 17);
            this.label22.TabIndex = 40;
            this.label22.Text = "Hazardous";
            // 
            // label21
            // 
            this.label21.BackColor = System.Drawing.Color.MediumVioletRed;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(6, 87);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(208, 17);
            this.label21.TabIndex = 39;
            this.label21.Text = "Very Unhealthy";
            // 
            // label20
            // 
            this.label20.BackColor = System.Drawing.Color.OrangeRed;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(6, 70);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(208, 17);
            this.label20.TabIndex = 38;
            this.label20.Text = "Unhealthy";
            // 
            // label19
            // 
            this.label19.BackColor = System.Drawing.Color.Orange;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(6, 53);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(208, 17);
            this.label19.TabIndex = 37;
            this.label19.Text = "Unhealthy for Sensitive Groups";
            // 
            // label18
            // 
            this.label18.BackColor = System.Drawing.Color.Yellow;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(6, 34);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(208, 19);
            this.label18.TabIndex = 36;
            this.label18.Text = "Moderate";
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.Color.Lime;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(6, 16);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(208, 18);
            this.label17.TabIndex = 35;
            this.label17.Text = "Good";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 27);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(757, 408);
            this.dataGridView1.TabIndex = 9;
            // 
            // dateTimePickerStart
            // 
            this.dateTimePickerStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerStart.Location = new System.Drawing.Point(46, 21);
            this.dateTimePickerStart.Name = "dateTimePickerStart";
            this.dateTimePickerStart.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerStart.TabIndex = 46;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonStartLatest);
            this.groupBox1.Controls.Add(this.radioButtonStartEarliest);
            this.groupBox1.Controls.Add(this.radioButtonStartCustom);
            this.groupBox1.Controls.Add(this.dateTimePickerStart);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(36, 237);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(260, 98);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Start Date";
            // 
            // radioButtonStartLatest
            // 
            this.radioButtonStartLatest.AutoSize = true;
            this.radioButtonStartLatest.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonStartLatest.Location = new System.Drawing.Point(26, 70);
            this.radioButtonStartLatest.Name = "radioButtonStartLatest";
            this.radioButtonStartLatest.Size = new System.Drawing.Size(131, 17);
            this.radioButtonStartLatest.TabIndex = 49;
            this.radioButtonStartLatest.TabStop = true;
            this.radioButtonStartLatest.Text = "Latest Recorded Entry";
            this.radioButtonStartLatest.UseVisualStyleBackColor = true;
            this.radioButtonStartLatest.CheckedChanged += new System.EventHandler(this.radioButtonStartLatest_CheckedChanged);
            // 
            // radioButtonStartEarliest
            // 
            this.radioButtonStartEarliest.AutoSize = true;
            this.radioButtonStartEarliest.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonStartEarliest.Location = new System.Drawing.Point(26, 47);
            this.radioButtonStartEarliest.Name = "radioButtonStartEarliest";
            this.radioButtonStartEarliest.Size = new System.Drawing.Size(136, 17);
            this.radioButtonStartEarliest.TabIndex = 48;
            this.radioButtonStartEarliest.TabStop = true;
            this.radioButtonStartEarliest.Text = "Earliest Recorded Entry";
            this.radioButtonStartEarliest.UseVisualStyleBackColor = true;
            this.radioButtonStartEarliest.CheckedChanged += new System.EventHandler(this.radioButtonStartEarliest_CheckedChanged);
            // 
            // radioButtonStartCustom
            // 
            this.radioButtonStartCustom.AutoSize = true;
            this.radioButtonStartCustom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonStartCustom.Location = new System.Drawing.Point(26, 21);
            this.radioButtonStartCustom.Name = "radioButtonStartCustom";
            this.radioButtonStartCustom.Size = new System.Drawing.Size(14, 13);
            this.radioButtonStartCustom.TabIndex = 47;
            this.radioButtonStartCustom.TabStop = true;
            this.radioButtonStartCustom.UseVisualStyleBackColor = true;
            this.radioButtonStartCustom.CheckedChanged += new System.EventHandler(this.radioButtonStartCustom_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButtonEndLatest);
            this.groupBox2.Controls.Add(this.radioButtonEndCustom);
            this.groupBox2.Controls.Add(this.dateTimePickerEnd);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(36, 341);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(260, 74);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "End Date";
            // 
            // radioButtonEndLatest
            // 
            this.radioButtonEndLatest.AutoSize = true;
            this.radioButtonEndLatest.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonEndLatest.Location = new System.Drawing.Point(26, 47);
            this.radioButtonEndLatest.Name = "radioButtonEndLatest";
            this.radioButtonEndLatest.Size = new System.Drawing.Size(131, 17);
            this.radioButtonEndLatest.TabIndex = 48;
            this.radioButtonEndLatest.TabStop = true;
            this.radioButtonEndLatest.Text = "Latest Recorded Entry";
            this.radioButtonEndLatest.UseVisualStyleBackColor = true;
            this.radioButtonEndLatest.CheckedChanged += new System.EventHandler(this.radioButtonEndLatest_CheckedChanged);
            // 
            // radioButtonEndCustom
            // 
            this.radioButtonEndCustom.AutoSize = true;
            this.radioButtonEndCustom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonEndCustom.Location = new System.Drawing.Point(26, 21);
            this.radioButtonEndCustom.Name = "radioButtonEndCustom";
            this.radioButtonEndCustom.Size = new System.Drawing.Size(14, 13);
            this.radioButtonEndCustom.TabIndex = 47;
            this.radioButtonEndCustom.TabStop = true;
            this.radioButtonEndCustom.UseVisualStyleBackColor = true;
            this.radioButtonEndCustom.CheckedChanged += new System.EventHandler(this.radioButtonEndCustom_CheckedChanged);
            // 
            // dateTimePickerEnd
            // 
            this.dateTimePickerEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerEnd.Location = new System.Drawing.Point(46, 21);
            this.dateTimePickerEnd.Name = "dateTimePickerEnd";
            this.dateTimePickerEnd.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerEnd.TabIndex = 46;
            // 
            // listBoxSelected
            // 
            this.listBoxSelected.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxSelected.FormattingEnabled = true;
            this.listBoxSelected.Location = new System.Drawing.Point(12, 40);
            this.listBoxSelected.Name = "listBoxSelected";
            this.listBoxSelected.Size = new System.Drawing.Size(120, 121);
            this.listBoxSelected.TabIndex = 3;
            this.listBoxSelected.SelectedIndexChanged += new System.EventHandler(this.listBoxSelected_SelectedIndexChanged);
            // 
            // listBoxCollection
            // 
            this.listBoxCollection.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxCollection.FormattingEnabled = true;
            this.listBoxCollection.Location = new System.Drawing.Point(175, 40);
            this.listBoxCollection.Name = "listBoxCollection";
            this.listBoxCollection.Size = new System.Drawing.Size(120, 121);
            this.listBoxCollection.TabIndex = 0;
            this.listBoxCollection.SelectedIndexChanged += new System.EventHandler(this.listBoxCollection_SelectedIndexChanged);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(138, 40);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(31, 23);
            this.buttonAdd.TabIndex = 1;
            this.buttonAdd.Text = "<";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonRemove
            // 
            this.buttonRemove.Location = new System.Drawing.Point(138, 69);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(31, 23);
            this.buttonRemove.TabIndex = 2;
            this.buttonRemove.Text = ">";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // buttonRemoveAll
            // 
            this.buttonRemoveAll.Location = new System.Drawing.Point(138, 138);
            this.buttonRemoveAll.Name = "buttonRemoveAll";
            this.buttonRemoveAll.Size = new System.Drawing.Size(31, 23);
            this.buttonRemoveAll.TabIndex = 5;
            this.buttonRemoveAll.Text = ">>";
            this.buttonRemoveAll.UseVisualStyleBackColor = true;
            this.buttonRemoveAll.Click += new System.EventHandler(this.buttonRemoveAll_Click);
            // 
            // buttonTable
            // 
            this.buttonTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTable.Location = new System.Drawing.Point(10, 608);
            this.buttonTable.Name = "buttonTable";
            this.buttonTable.Size = new System.Drawing.Size(144, 30);
            this.buttonTable.TabIndex = 6;
            this.buttonTable.Text = "Generate Table";
            this.buttonTable.UseVisualStyleBackColor = true;
            this.buttonTable.Click += new System.EventHandler(this.buttonTable_Click);
            // 
            // buttonAddAll
            // 
            this.buttonAddAll.Location = new System.Drawing.Point(138, 109);
            this.buttonAddAll.Name = "buttonAddAll";
            this.buttonAddAll.Size = new System.Drawing.Size(31, 23);
            this.buttonAddAll.TabIndex = 4;
            this.buttonAddAll.Text = "<<";
            this.buttonAddAll.UseVisualStyleBackColor = true;
            this.buttonAddAll.Click += new System.EventHandler(this.buttonAddAll_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radioButtonStationAmbient);
            this.groupBox3.Controls.Add(this.radioButtonStationRoadside);
            this.groupBox3.Controls.Add(this.radioButtonStationAll);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.buttonAddAll);
            this.groupBox3.Controls.Add(this.buttonRemoveAll);
            this.groupBox3.Controls.Add(this.buttonRemove);
            this.groupBox3.Controls.Add(this.buttonAdd);
            this.groupBox3.Controls.Add(this.listBoxCollection);
            this.groupBox3.Controls.Add(this.listBoxSelected);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(10, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(304, 195);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Stations";
            // 
            // radioButtonStationAmbient
            // 
            this.radioButtonStationAmbient.AutoSize = true;
            this.radioButtonStationAmbient.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonStationAmbient.Location = new System.Drawing.Point(183, 167);
            this.radioButtonStationAmbient.Name = "radioButtonStationAmbient";
            this.radioButtonStationAmbient.Size = new System.Drawing.Size(103, 17);
            this.radioButtonStationAmbient.TabIndex = 8;
            this.radioButtonStationAmbient.TabStop = true;
            this.radioButtonStationAmbient.Text = "General Ambient";
            this.radioButtonStationAmbient.UseVisualStyleBackColor = true;
            this.radioButtonStationAmbient.CheckedChanged += new System.EventHandler(this.radioButtonStationAmbient_CheckedChanged);
            // 
            // radioButtonStationRoadside
            // 
            this.radioButtonStationRoadside.AutoSize = true;
            this.radioButtonStationRoadside.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonStationRoadside.Location = new System.Drawing.Point(94, 167);
            this.radioButtonStationRoadside.Name = "radioButtonStationRoadside";
            this.radioButtonStationRoadside.Size = new System.Drawing.Size(70, 17);
            this.radioButtonStationRoadside.TabIndex = 7;
            this.radioButtonStationRoadside.TabStop = true;
            this.radioButtonStationRoadside.Text = "Roadside";
            this.radioButtonStationRoadside.UseVisualStyleBackColor = true;
            this.radioButtonStationRoadside.CheckedChanged += new System.EventHandler(this.radioButtonStationRoadside_CheckedChanged);
            // 
            // radioButtonStationAll
            // 
            this.radioButtonStationAll.AutoSize = true;
            this.radioButtonStationAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonStationAll.Location = new System.Drawing.Point(30, 167);
            this.radioButtonStationAll.Name = "radioButtonStationAll";
            this.radioButtonStationAll.Size = new System.Drawing.Size(36, 17);
            this.radioButtonStationAll.TabIndex = 6;
            this.radioButtonStationAll.TabStop = true;
            this.radioButtonStationAll.Text = "All";
            this.radioButtonStationAll.UseVisualStyleBackColor = true;
            this.radioButtonStationAll.CheckedChanged += new System.EventHandler(this.radioButtonStationAll_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(49, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 59;
            this.label1.Text = "Selected";
            // 
            // comboBoxReading
            // 
            this.comboBoxReading.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxReading.FormattingEnabled = true;
            this.comboBoxReading.Location = new System.Drawing.Point(148, 206);
            this.comboBoxReading.Name = "comboBoxReading";
            this.comboBoxReading.Size = new System.Drawing.Size(121, 21);
            this.comboBoxReading.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(70, 206);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 16);
            this.label2.TabIndex = 61;
            this.label2.Text = "Reading";
            // 
            // checkBoxIncludeForecasts
            // 
            this.checkBoxIncludeForecasts.AutoSize = true;
            this.checkBoxIncludeForecasts.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxIncludeForecasts.Location = new System.Drawing.Point(99, 579);
            this.checkBoxIncludeForecasts.Name = "checkBoxIncludeForecasts";
            this.checkBoxIncludeForecasts.Size = new System.Drawing.Size(133, 20);
            this.checkBoxIncludeForecasts.TabIndex = 5;
            this.checkBoxIncludeForecasts.Text = "Include Forecasts";
            this.checkBoxIncludeForecasts.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.testToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1104, 24);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.testToolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.testToolStripMenuItem.Text = "File";
            // 
            // testToolStripMenuItem1
            // 
            this.testToolStripMenuItem1.Name = "testToolStripMenuItem1";
            this.testToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.testToolStripMenuItem1.Size = new System.Drawing.Size(238, 22);
            this.testToolStripMenuItem1.Text = "Database Management";
            this.testToolStripMenuItem1.Click += new System.EventHandler(this.testToolStripMenuItem1_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(455, 438);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(317, 15);
            this.label3.TabIndex = 64;
            this.label3.Text = "*Numbers in boldface type are forecasted values";
            // 
            // buttonMakeChart
            // 
            this.buttonMakeChart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMakeChart.Location = new System.Drawing.Point(170, 608);
            this.buttonMakeChart.Name = "buttonMakeChart";
            this.buttonMakeChart.Size = new System.Drawing.Size(144, 30);
            this.buttonMakeChart.TabIndex = 7;
            this.buttonMakeChart.Text = "Generate Graph";
            this.buttonMakeChart.UseVisualStyleBackColor = true;
            this.buttonMakeChart.Click += new System.EventHandler(this.buttonMakeChart_Click);
            // 
            // listBoxNotes
            // 
            this.listBoxNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxNotes.FormattingEnabled = true;
            this.listBoxNotes.HorizontalScrollbar = true;
            this.listBoxNotes.Location = new System.Drawing.Point(12, 461);
            this.listBoxNotes.Name = "listBoxNotes";
            this.listBoxNotes.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listBoxNotes.Size = new System.Drawing.Size(459, 212);
            this.listBoxNotes.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 442);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 15);
            this.label4.TabIndex = 67;
            this.label4.Text = "Reports";
            // 
            // buttonCopyNotes
            // 
            this.buttonCopyNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCopyNotes.Image = global::OLEDB_Example.Properties.Resources.clip_icon;
            this.buttonCopyNotes.Location = new System.Drawing.Point(477, 614);
            this.buttonCopyNotes.Name = "buttonCopyNotes";
            this.buttonCopyNotes.Size = new System.Drawing.Size(31, 59);
            this.buttonCopyNotes.TabIndex = 8;
            this.buttonCopyNotes.UseVisualStyleBackColor = true;
            this.buttonCopyNotes.Click += new System.EventHandler(this.buttonCopyNotes_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.panelFilterControls);
            this.groupBox5.Controls.Add(this.radioButtonFilterEnable);
            this.groupBox5.Controls.Add(this.radioButtonFilterDisable);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(36, 421);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(260, 149);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Filter by Air Pollution Level";
            // 
            // panelFilterControls
            // 
            this.panelFilterControls.Controls.Add(this.buttonFilterCheck);
            this.panelFilterControls.Controls.Add(this.checkBoxFilterUnhealthy);
            this.panelFilterControls.Controls.Add(this.checkBoxFilterHazardous);
            this.panelFilterControls.Controls.Add(this.checkBoxFilterVeryUnhealthy);
            this.panelFilterControls.Controls.Add(this.checkBoxFilterSensitive);
            this.panelFilterControls.Controls.Add(this.checkBoxFilterModerate);
            this.panelFilterControls.Controls.Add(this.checkBoxFilterGood);
            this.panelFilterControls.Location = new System.Drawing.Point(18, 45);
            this.panelFilterControls.Name = "panelFilterControls";
            this.panelFilterControls.Size = new System.Drawing.Size(241, 103);
            this.panelFilterControls.TabIndex = 9;
            // 
            // buttonFilterCheck
            // 
            this.buttonFilterCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFilterCheck.Location = new System.Drawing.Point(139, 74);
            this.buttonFilterCheck.Name = "buttonFilterCheck";
            this.buttonFilterCheck.Size = new System.Drawing.Size(89, 19);
            this.buttonFilterCheck.TabIndex = 0;
            this.buttonFilterCheck.Text = "Uncheck all";
            this.buttonFilterCheck.UseVisualStyleBackColor = true;
            this.buttonFilterCheck.Click += new System.EventHandler(this.buttonFilterCheck_Click);
            // 
            // checkBoxFilterUnhealthy
            // 
            this.checkBoxFilterUnhealthy.AutoSize = true;
            this.checkBoxFilterUnhealthy.Checked = true;
            this.checkBoxFilterUnhealthy.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxFilterUnhealthy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxFilterUnhealthy.Location = new System.Drawing.Point(18, 74);
            this.checkBoxFilterUnhealthy.Name = "checkBoxFilterUnhealthy";
            this.checkBoxFilterUnhealthy.Size = new System.Drawing.Size(74, 17);
            this.checkBoxFilterUnhealthy.TabIndex = 4;
            this.checkBoxFilterUnhealthy.Text = "Unhealthy";
            this.checkBoxFilterUnhealthy.UseVisualStyleBackColor = true;
            // 
            // checkBoxFilterHazardous
            // 
            this.checkBoxFilterHazardous.AutoSize = true;
            this.checkBoxFilterHazardous.Checked = true;
            this.checkBoxFilterHazardous.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxFilterHazardous.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxFilterHazardous.Location = new System.Drawing.Point(116, 28);
            this.checkBoxFilterHazardous.Name = "checkBoxFilterHazardous";
            this.checkBoxFilterHazardous.Size = new System.Drawing.Size(77, 17);
            this.checkBoxFilterHazardous.TabIndex = 6;
            this.checkBoxFilterHazardous.Text = "Hazardous";
            this.checkBoxFilterHazardous.UseVisualStyleBackColor = true;
            // 
            // checkBoxFilterVeryUnhealthy
            // 
            this.checkBoxFilterVeryUnhealthy.AutoSize = true;
            this.checkBoxFilterVeryUnhealthy.Checked = true;
            this.checkBoxFilterVeryUnhealthy.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxFilterVeryUnhealthy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxFilterVeryUnhealthy.Location = new System.Drawing.Point(116, 5);
            this.checkBoxFilterVeryUnhealthy.Name = "checkBoxFilterVeryUnhealthy";
            this.checkBoxFilterVeryUnhealthy.Size = new System.Drawing.Size(98, 17);
            this.checkBoxFilterVeryUnhealthy.TabIndex = 5;
            this.checkBoxFilterVeryUnhealthy.Text = "Very Unhealthy";
            this.checkBoxFilterVeryUnhealthy.UseVisualStyleBackColor = true;
            // 
            // checkBoxFilterSensitive
            // 
            this.checkBoxFilterSensitive.AutoSize = true;
            this.checkBoxFilterSensitive.Checked = true;
            this.checkBoxFilterSensitive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxFilterSensitive.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxFilterSensitive.Location = new System.Drawing.Point(18, 51);
            this.checkBoxFilterSensitive.Name = "checkBoxFilterSensitive";
            this.checkBoxFilterSensitive.Size = new System.Drawing.Size(172, 17);
            this.checkBoxFilterSensitive.TabIndex = 3;
            this.checkBoxFilterSensitive.Text = "Unhealthy for Sensitive Groups";
            this.checkBoxFilterSensitive.UseVisualStyleBackColor = true;
            // 
            // checkBoxFilterModerate
            // 
            this.checkBoxFilterModerate.AutoSize = true;
            this.checkBoxFilterModerate.Checked = true;
            this.checkBoxFilterModerate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxFilterModerate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxFilterModerate.Location = new System.Drawing.Point(18, 28);
            this.checkBoxFilterModerate.Name = "checkBoxFilterModerate";
            this.checkBoxFilterModerate.Size = new System.Drawing.Size(71, 17);
            this.checkBoxFilterModerate.TabIndex = 2;
            this.checkBoxFilterModerate.Text = "Moderate";
            this.checkBoxFilterModerate.UseVisualStyleBackColor = true;
            // 
            // checkBoxFilterGood
            // 
            this.checkBoxFilterGood.AutoSize = true;
            this.checkBoxFilterGood.Checked = true;
            this.checkBoxFilterGood.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxFilterGood.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxFilterGood.Location = new System.Drawing.Point(18, 5);
            this.checkBoxFilterGood.Name = "checkBoxFilterGood";
            this.checkBoxFilterGood.Size = new System.Drawing.Size(52, 17);
            this.checkBoxFilterGood.TabIndex = 1;
            this.checkBoxFilterGood.Text = "Good";
            this.checkBoxFilterGood.UseVisualStyleBackColor = true;
            // 
            // radioButtonFilterEnable
            // 
            this.radioButtonFilterEnable.AutoSize = true;
            this.radioButtonFilterEnable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonFilterEnable.Location = new System.Drawing.Point(98, 25);
            this.radioButtonFilterEnable.Name = "radioButtonFilterEnable";
            this.radioButtonFilterEnable.Size = new System.Drawing.Size(148, 17);
            this.radioButtonFilterEnable.TabIndex = 7;
            this.radioButtonFilterEnable.TabStop = true;
            this.radioButtonFilterEnable.Text = "Use filters (disables graph)";
            this.radioButtonFilterEnable.UseVisualStyleBackColor = true;
            this.radioButtonFilterEnable.CheckedChanged += new System.EventHandler(this.radioButtonFilterEnable_CheckedChanged);
            // 
            // radioButtonFilterDisable
            // 
            this.radioButtonFilterDisable.AutoSize = true;
            this.radioButtonFilterDisable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonFilterDisable.Location = new System.Drawing.Point(26, 25);
            this.radioButtonFilterDisable.Name = "radioButtonFilterDisable";
            this.radioButtonFilterDisable.Size = new System.Drawing.Size(66, 17);
            this.radioButtonFilterDisable.TabIndex = 6;
            this.radioButtonFilterDisable.TabStop = true;
            this.radioButtonFilterDisable.Text = "No filters";
            this.radioButtonFilterDisable.UseVisualStyleBackColor = true;
            this.radioButtonFilterDisable.CheckedChanged += new System.EventHandler(this.radioButtonFilterDisable_CheckedChanged);
            // 
            // panelControls
            // 
            this.panelControls.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.panelControls.Controls.Add(this.groupBox5);
            this.panelControls.Controls.Add(this.buttonMakeChart);
            this.panelControls.Controls.Add(this.checkBoxIncludeForecasts);
            this.panelControls.Controls.Add(this.label2);
            this.panelControls.Controls.Add(this.comboBoxReading);
            this.panelControls.Controls.Add(this.groupBox3);
            this.panelControls.Controls.Add(this.buttonTable);
            this.panelControls.Controls.Add(this.groupBox2);
            this.panelControls.Controls.Add(this.groupBox1);
            this.panelControls.Location = new System.Drawing.Point(778, 27);
            this.panelControls.Name = "panelControls";
            this.panelControls.Size = new System.Drawing.Size(325, 656);
            this.panelControls.TabIndex = 0;
            // 
            // panelLegend
            // 
            this.panelLegend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelLegend.Controls.Add(this.label23);
            this.panelLegend.Controls.Add(this.groupBox4);
            this.panelLegend.Location = new System.Drawing.Point(524, 478);
            this.panelLegend.Name = "panelLegend";
            this.panelLegend.Size = new System.Drawing.Size(244, 157);
            this.panelLegend.TabIndex = 69;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1104, 686);
            this.Controls.Add(this.panelLegend);
            this.Controls.Add(this.panelControls);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.listBoxNotes);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.buttonCopyNotes);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tabular View";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form3_FormClosing);
            this.Load += new System.EventHandler(this.Form3_Load);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.panelFilterControls.ResumeLayout(false);
            this.panelFilterControls.PerformLayout();
            this.panelControls.ResumeLayout(false);
            this.panelControls.PerformLayout();
            this.panelLegend.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DateTimePicker dateTimePickerStart;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonStartEarliest;
        private System.Windows.Forms.RadioButton radioButtonStartCustom;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButtonEndLatest;
        private System.Windows.Forms.RadioButton radioButtonEndCustom;
        private System.Windows.Forms.DateTimePicker dateTimePickerEnd;
        private System.Windows.Forms.ListBox listBoxSelected;
        private System.Windows.Forms.ListBox listBoxCollection;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.Button buttonRemoveAll;
        private System.Windows.Forms.Button buttonTable;
        private System.Windows.Forms.Button buttonAddAll;
        private System.Windows.Forms.RadioButton radioButtonStartLatest;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxReading;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBoxIncludeForecasts;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Button buttonMakeChart;
        private System.Windows.Forms.ListBox listBoxNotes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonCopyNotes;
        private System.Windows.Forms.RadioButton radioButtonStationAmbient;
        private System.Windows.Forms.RadioButton radioButtonStationRoadside;
        private System.Windows.Forms.RadioButton radioButtonStationAll;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton radioButtonFilterEnable;
        private System.Windows.Forms.RadioButton radioButtonFilterDisable;
        private System.Windows.Forms.CheckBox checkBoxFilterUnhealthy;
        private System.Windows.Forms.CheckBox checkBoxFilterHazardous;
        private System.Windows.Forms.CheckBox checkBoxFilterVeryUnhealthy;
        private System.Windows.Forms.CheckBox checkBoxFilterSensitive;
        private System.Windows.Forms.CheckBox checkBoxFilterModerate;
        private System.Windows.Forms.CheckBox checkBoxFilterGood;
        private System.Windows.Forms.Button buttonFilterCheck;
        private System.Windows.Forms.Panel panelFilterControls;
        private System.Windows.Forms.Panel panelControls;
        private System.Windows.Forms.Panel panelLegend;
    }
}