namespace APUsZoo
{
    partial class MainForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.ptbAnimalpic = new System.Windows.Forms.PictureBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.lstAnimalObject = new System.Windows.Forms.ListBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.gpbSpecifications = new System.Windows.Forms.GroupBox();
            this.txtAttribute3 = new System.Windows.Forms.TextBox();
            this.txtAttribute2 = new System.Windows.Forms.TextBox();
            this.txtAttribute1 = new System.Windows.Forms.TextBox();
            this.lblAttribute3 = new System.Windows.Forms.Label();
            this.lblAttribute2 = new System.Windows.Forms.Label();
            this.lblAttribute1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cmbDiet = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbGender = new System.Windows.Forms.ComboBox();
            this.lblDietType = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.gpbFeedingSchedule = new System.Windows.Forms.GroupBox();
            this.lstFeedingSchedule = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnDeleteAnimal = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.rbtnSortByPetName = new System.Windows.Forms.RadioButton();
            this.rbtnSortByID = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelN = new System.Windows.Forms.Label();
            this.lstAnimalList = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tspAnimalMotel = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNew = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSave = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuXMLRead = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuImportXML = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExportXML = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.MainFormttp = new System.Windows.Forms.ToolTip(this.components);
            this.opfAnimal = new System.Windows.Forms.OpenFileDialog();
            this.grpFood_StaffInfo = new System.Windows.Forms.GroupBox();
            this.btnAddRecipe = new System.Windows.Forms.Button();
            this.btnAddEmployee = new System.Windows.Forms.Button();
            this.lstinformation = new System.Windows.Forms.ListBox();
            this.opfLoading = new System.Windows.Forms.OpenFileDialog();
            this.sfdSave_Saveas = new System.Windows.Forms.SaveFileDialog();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbAnimalpic)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.gpbSpecifications.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.gpbFeedingSchedule.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.grpFood_StaffInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Beige;
            this.groupBox1.Controls.Add(this.btnBrowse);
            this.groupBox1.Controls.Add(this.ptbAnimalpic);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.txtAge);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.gpbSpecifications);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Green;
            this.groupBox1.Location = new System.Drawing.Point(52, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1080, 423);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Animal specification";
            // 
            // btnBrowse
            // 
            this.btnBrowse.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnBrowse.Location = new System.Drawing.Point(865, 243);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(156, 35);
            this.btnBrowse.TabIndex = 10;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // ptbAnimalpic
            // 
            this.ptbAnimalpic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ptbAnimalpic.Location = new System.Drawing.Point(854, 53);
            this.ptbAnimalpic.Name = "ptbAnimalpic";
            this.ptbAnimalpic.Size = new System.Drawing.Size(184, 184);
            this.ptbAnimalpic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbAnimalpic.TabIndex = 9;
            this.ptbAnimalpic.TabStop = false;
            // 
            // btnAdd
            // 
            this.btnAdd.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAdd.Location = new System.Drawing.Point(602, 345);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(157, 33);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "Add this animal";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtAge
            // 
            this.txtAge.Location = new System.Drawing.Point(93, 72);
            this.txtAge.Name = "txtAge";
            this.txtAge.Size = new System.Drawing.Size(62, 27);
            this.txtAge.TabIndex = 7;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(93, 38);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(189, 27);
            this.txtName.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(33, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Age";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(33, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Name";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.lstAnimalObject);
            this.groupBox5.Location = new System.Drawing.Point(551, 26);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(287, 313);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Animal Object";
            // 
            // lstAnimalObject
            // 
            this.lstAnimalObject.FormattingEnabled = true;
            this.lstAnimalObject.ItemHeight = 20;
            this.lstAnimalObject.Location = new System.Drawing.Point(21, 27);
            this.lstAnimalObject.Name = "lstAnimalObject";
            this.lstAnimalObject.Size = new System.Drawing.Size(237, 264);
            this.lstAnimalObject.TabIndex = 0;
            this.lstAnimalObject.SelectedIndexChanged += new System.EventHandler(this.lstAnimalObject_SelectedIndexChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cmbCategory);
            this.groupBox4.Location = new System.Drawing.Point(313, 27);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(232, 210);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Category";
            // 
            // cmbCategory
            // 
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Items.AddRange(new object[] {
            "Reptile",
            "Bird"});
            this.cmbCategory.Location = new System.Drawing.Point(7, 26);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(219, 28);
            this.cmbCategory.TabIndex = 0;
            this.cmbCategory.SelectedIndexChanged += new System.EventHandler(this.cmbCategory_SelectedIndexChanged);
            // 
            // gpbSpecifications
            // 
            this.gpbSpecifications.Controls.Add(this.txtAttribute3);
            this.gpbSpecifications.Controls.Add(this.txtAttribute2);
            this.gpbSpecifications.Controls.Add(this.txtAttribute1);
            this.gpbSpecifications.Controls.Add(this.lblAttribute3);
            this.gpbSpecifications.Controls.Add(this.lblAttribute2);
            this.gpbSpecifications.Controls.Add(this.lblAttribute1);
            this.gpbSpecifications.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gpbSpecifications.Location = new System.Drawing.Point(17, 243);
            this.gpbSpecifications.Name = "gpbSpecifications";
            this.gpbSpecifications.Size = new System.Drawing.Size(513, 154);
            this.gpbSpecifications.TabIndex = 1;
            this.gpbSpecifications.TabStop = false;
            this.gpbSpecifications.Text = "Specifications";
            // 
            // txtAttribute3
            // 
            this.txtAttribute3.Location = new System.Drawing.Point(340, 118);
            this.txtAttribute3.Name = "txtAttribute3";
            this.txtAttribute3.Size = new System.Drawing.Size(167, 27);
            this.txtAttribute3.TabIndex = 5;
            // 
            // txtAttribute2
            // 
            this.txtAttribute2.Location = new System.Drawing.Point(340, 73);
            this.txtAttribute2.Name = "txtAttribute2";
            this.txtAttribute2.Size = new System.Drawing.Size(167, 27);
            this.txtAttribute2.TabIndex = 4;
            // 
            // txtAttribute1
            // 
            this.txtAttribute1.Location = new System.Drawing.Point(340, 27);
            this.txtAttribute1.Name = "txtAttribute1";
            this.txtAttribute1.Size = new System.Drawing.Size(167, 27);
            this.txtAttribute1.TabIndex = 3;
            // 
            // lblAttribute3
            // 
            this.lblAttribute3.Location = new System.Drawing.Point(20, 118);
            this.lblAttribute3.Name = "lblAttribute3";
            this.lblAttribute3.Size = new System.Drawing.Size(314, 33);
            this.lblAttribute3.TabIndex = 2;
            this.lblAttribute3.Text = "Test";
            // 
            // lblAttribute2
            // 
            this.lblAttribute2.Location = new System.Drawing.Point(20, 76);
            this.lblAttribute2.Name = "lblAttribute2";
            this.lblAttribute2.Size = new System.Drawing.Size(314, 31);
            this.lblAttribute2.TabIndex = 1;
            this.lblAttribute2.Text = "Test";
            // 
            // lblAttribute1
            // 
            this.lblAttribute1.Location = new System.Drawing.Point(20, 37);
            this.lblAttribute1.Name = "lblAttribute1";
            this.lblAttribute1.Size = new System.Drawing.Size(314, 27);
            this.lblAttribute1.TabIndex = 0;
            this.lblAttribute1.Text = "Test";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cmbDiet);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.cmbGender);
            this.groupBox3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox3.Location = new System.Drawing.Point(17, 104);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(265, 123);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Gender";
            // 
            // cmbDiet
            // 
            this.cmbDiet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDiet.FormattingEnabled = true;
            this.cmbDiet.Items.AddRange(new object[] {
            "MeatEater",
            "AllEater",
            "PlantEater"});
            this.cmbDiet.Location = new System.Drawing.Point(20, 82);
            this.cmbDiet.Name = "cmbDiet";
            this.cmbDiet.Size = new System.Drawing.Size(239, 28);
            this.cmbDiet.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 20);
            this.label6.TabIndex = 1;
            this.label6.Text = "Diet";
            // 
            // cmbGender
            // 
            this.cmbGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGender.FormattingEnabled = true;
            this.cmbGender.Items.AddRange(new object[] {
            "Male",
            "Female",
            "Unknown"});
            this.cmbGender.Location = new System.Drawing.Point(20, 27);
            this.cmbGender.Name = "cmbGender";
            this.cmbGender.Size = new System.Drawing.Size(239, 28);
            this.cmbGender.TabIndex = 0;
            // 
            // lblDietType
            // 
            this.lblDietType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDietType.Location = new System.Drawing.Point(82, 28);
            this.lblDietType.Name = "lblDietType";
            this.lblDietType.Size = new System.Drawing.Size(219, 28);
            this.lblDietType.TabIndex = 13;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(36, 36);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 20);
            this.label9.TabIndex = 11;
            this.label9.Text = "Diet";
            // 
            // gpbFeedingSchedule
            // 
            this.gpbFeedingSchedule.Controls.Add(this.lblDietType);
            this.gpbFeedingSchedule.Controls.Add(this.lstFeedingSchedule);
            this.gpbFeedingSchedule.Controls.Add(this.label9);
            this.gpbFeedingSchedule.Location = new System.Drawing.Point(27, 276);
            this.gpbFeedingSchedule.Name = "gpbFeedingSchedule";
            this.gpbFeedingSchedule.Size = new System.Drawing.Size(912, 151);
            this.gpbFeedingSchedule.TabIndex = 14;
            this.gpbFeedingSchedule.TabStop = false;
            this.gpbFeedingSchedule.Text = "Feeding Schedule";
            // 
            // lstFeedingSchedule
            // 
            this.lstFeedingSchedule.BackColor = System.Drawing.Color.Beige;
            this.lstFeedingSchedule.FormattingEnabled = true;
            this.lstFeedingSchedule.ItemHeight = 20;
            this.lstFeedingSchedule.Location = new System.Drawing.Point(307, 26);
            this.lstFeedingSchedule.Name = "lstFeedingSchedule";
            this.lstFeedingSchedule.Size = new System.Drawing.Size(564, 104);
            this.lstFeedingSchedule.TabIndex = 12;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Beige;
            this.groupBox2.Controls.Add(this.btnDeleteAnimal);
            this.groupBox2.Controls.Add(this.groupBox6);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.labelN);
            this.groupBox2.Controls.Add(this.lstAnimalList);
            this.groupBox2.Controls.Add(this.gpbFeedingSchedule);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Green;
            this.groupBox2.Location = new System.Drawing.Point(47, 457);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1452, 451);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "List of registered animals";
            // 
            // btnDeleteAnimal
            // 
            this.btnDeleteAnimal.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnDeleteAnimal.Location = new System.Drawing.Point(962, 288);
            this.btnDeleteAnimal.Name = "btnDeleteAnimal";
            this.btnDeleteAnimal.Size = new System.Drawing.Size(165, 28);
            this.btnDeleteAnimal.TabIndex = 15;
            this.btnDeleteAnimal.Text = "Delete";
            this.btnDeleteAnimal.UseVisualStyleBackColor = true;
            this.btnDeleteAnimal.Click += new System.EventHandler(this.btnDeleteAnimal_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.rbtnSortByPetName);
            this.groupBox6.Controls.Add(this.rbtnSortByID);
            this.groupBox6.Location = new System.Drawing.Point(1273, 66);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(149, 154);
            this.groupBox6.TabIndex = 7;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Sort by";
            // 
            // rbtnSortByPetName
            // 
            this.rbtnSortByPetName.AutoSize = true;
            this.rbtnSortByPetName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rbtnSortByPetName.Location = new System.Drawing.Point(8, 77);
            this.rbtnSortByPetName.Name = "rbtnSortByPetName";
            this.rbtnSortByPetName.Size = new System.Drawing.Size(104, 24);
            this.rbtnSortByPetName.TabIndex = 1;
            this.rbtnSortByPetName.TabStop = true;
            this.rbtnSortByPetName.Text = "Pet Name";
            this.rbtnSortByPetName.UseVisualStyleBackColor = true;
            this.rbtnSortByPetName.CheckedChanged += new System.EventHandler(this.rbtnSortByID_CheckedChanged);
            // 
            // rbtnSortByID
            // 
            this.rbtnSortByID.AutoSize = true;
            this.rbtnSortByID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rbtnSortByID.Location = new System.Drawing.Point(8, 33);
            this.rbtnSortByID.Name = "rbtnSortByID";
            this.rbtnSortByID.Size = new System.Drawing.Size(47, 24);
            this.rbtnSortByID.TabIndex = 0;
            this.rbtnSortByID.TabStop = true;
            this.rbtnSortByID.Text = "ID";
            this.rbtnSortByID.UseVisualStyleBackColor = true;
            this.rbtnSortByID.CheckedChanged += new System.EventHandler(this.rbtnSortByID_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(294, 43);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 20);
            this.label8.TabIndex = 6;
            this.label8.Text = "DietType";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(23, 43);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(26, 20);
            this.label7.TabIndex = 5;
            this.label7.Text = "ID";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(513, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(144, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Specific attributes";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(409, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Gender";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(203, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Age";
            // 
            // labelN
            // 
            this.labelN.AutoSize = true;
            this.labelN.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelN.Location = new System.Drawing.Point(94, 43);
            this.labelN.Name = "labelN";
            this.labelN.Size = new System.Drawing.Size(53, 20);
            this.labelN.TabIndex = 1;
            this.labelN.Text = "Name";
            // 
            // lstAnimalList
            // 
            this.lstAnimalList.FormattingEnabled = true;
            this.lstAnimalList.ItemHeight = 20;
            this.lstAnimalList.Location = new System.Drawing.Point(22, 66);
            this.lstAnimalList.Name = "lstAnimalList";
            this.lstAnimalList.Size = new System.Drawing.Size(1245, 204);
            this.lstAnimalList.TabIndex = 0;
            this.lstAnimalList.SelectedIndexChanged += new System.EventHandler(this.lstAnimalList_SelectedIndexChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspAnimalMotel});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1721, 28);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tspAnimalMotel
            // 
            this.tspAnimalMotel.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNew,
            this.mnuOpen,
            this.mnuSave,
            this.mnuSaveAs,
            this.mnuXMLRead,
            this.mnuExit});
            this.tspAnimalMotel.Name = "tspAnimalMotel";
            this.tspAnimalMotel.Size = new System.Drawing.Size(44, 24);
            this.tspAnimalMotel.Text = "File";
            // 
            // mnuNew
            // 
            this.mnuNew.Name = "mnuNew";
            this.mnuNew.Size = new System.Drawing.Size(181, 26);
            this.mnuNew.Text = "New  Ctrl-N";
            this.mnuNew.Click += new System.EventHandler(this.MnuNew_Click);
            // 
            // mnuOpen
            // 
            this.mnuOpen.Name = "mnuOpen";
            this.mnuOpen.Size = new System.Drawing.Size(181, 26);
            this.mnuOpen.Text = "Open  Ctrl-O";
            this.mnuOpen.Click += new System.EventHandler(this.mnuOpen_Click);
            // 
            // mnuSave
            // 
            this.mnuSave.Name = "mnuSave";
            this.mnuSave.Size = new System.Drawing.Size(181, 26);
            this.mnuSave.Text = "Save  Ctrl-S";
            this.mnuSave.Click += new System.EventHandler(this.mnuSave_Click);
            // 
            // mnuSaveAs
            // 
            this.mnuSaveAs.Name = "mnuSaveAs";
            this.mnuSaveAs.Size = new System.Drawing.Size(181, 26);
            this.mnuSaveAs.Text = "Save As";
            this.mnuSaveAs.Click += new System.EventHandler(this.mnuSaveAs_Click);
            // 
            // mnuXMLRead
            // 
            this.mnuXMLRead.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuImportXML,
            this.mnuExportXML});
            this.mnuXMLRead.Name = "mnuXMLRead";
            this.mnuXMLRead.Size = new System.Drawing.Size(181, 26);
            this.mnuXMLRead.Text = "XML";
            // 
            // mnuImportXML
            // 
            this.mnuImportXML.Name = "mnuImportXML";
            this.mnuImportXML.Size = new System.Drawing.Size(220, 26);
            this.mnuImportXML.Text = "Import From XMlFile";
            this.mnuImportXML.Click += new System.EventHandler(this.mnuImportXML_Click);
            // 
            // mnuExportXML
            // 
            this.mnuExportXML.Name = "mnuExportXML";
            this.mnuExportXML.Size = new System.Drawing.Size(220, 26);
            this.mnuExportXML.Text = "Export To XMLFile";
            this.mnuExportXML.Click += new System.EventHandler(this.mnuExportXML_Click);
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(181, 26);
            this.mnuExit.Text = "Exit   Alt-X";
            this.mnuExit.Click += new System.EventHandler(this.MnuExit_Click);
            // 
            // opfAnimal
            // 
            this.opfAnimal.FileName = "openfileAnimal";
            // 
            // grpFood_StaffInfo
            // 
            this.grpFood_StaffInfo.Controls.Add(this.btnAddRecipe);
            this.grpFood_StaffInfo.Controls.Add(this.btnAddEmployee);
            this.grpFood_StaffInfo.Controls.Add(this.lstinformation);
            this.grpFood_StaffInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpFood_StaffInfo.Location = new System.Drawing.Point(1138, 31);
            this.grpFood_StaffInfo.Name = "grpFood_StaffInfo";
            this.grpFood_StaffInfo.Size = new System.Drawing.Size(571, 420);
            this.grpFood_StaffInfo.TabIndex = 3;
            this.grpFood_StaffInfo.TabStop = false;
            this.grpFood_StaffInfo.Text = "Food/Employee details";
            // 
            // btnAddRecipe
            // 
            this.btnAddRecipe.Location = new System.Drawing.Point(6, 187);
            this.btnAddRecipe.Name = "btnAddRecipe";
            this.btnAddRecipe.Size = new System.Drawing.Size(129, 68);
            this.btnAddRecipe.TabIndex = 2;
            this.btnAddRecipe.Text = "Add a recipe";
            this.btnAddRecipe.UseVisualStyleBackColor = true;
            this.btnAddRecipe.Click += new System.EventHandler(this.btnAddRecipe_Click);
            // 
            // btnAddEmployee
            // 
            this.btnAddEmployee.Location = new System.Drawing.Point(6, 90);
            this.btnAddEmployee.Name = "btnAddEmployee";
            this.btnAddEmployee.Size = new System.Drawing.Size(129, 66);
            this.btnAddEmployee.TabIndex = 1;
            this.btnAddEmployee.Text = "Add an employee";
            this.btnAddEmployee.UseVisualStyleBackColor = true;
            this.btnAddEmployee.Click += new System.EventHandler(this.btnAddEmployee_Click);
            // 
            // lstinformation
            // 
            this.lstinformation.FormattingEnabled = true;
            this.lstinformation.ItemHeight = 20;
            this.lstinformation.Location = new System.Drawing.Point(141, 36);
            this.lstinformation.Name = "lstinformation";
            this.lstinformation.Size = new System.Drawing.Size(413, 344);
            this.lstinformation.TabIndex = 0;
            // 
            // opfLoading
            // 
            this.opfLoading.FileName = "opfLoading";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Beige;
            this.ClientSize = new System.Drawing.Size(1721, 920);
            this.Controls.Add(this.grpFood_StaffInfo);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "APU Zoo application";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbAnimalpic)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.gpbSpecifications.ResumeLayout(false);
            this.gpbSpecifications.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.gpbFeedingSchedule.ResumeLayout(false);
            this.gpbFeedingSchedule.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.grpFood_StaffInfo.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox gpbSpecifications;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListBox lstAnimalList;
        private System.Windows.Forms.ComboBox cmbGender;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtAge;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ListBox lstAnimalObject;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.TextBox txtAttribute3;
        private System.Windows.Forms.TextBox txtAttribute2;
        private System.Windows.Forms.TextBox txtAttribute1;
        private System.Windows.Forms.Label lblAttribute3;
        private System.Windows.Forms.Label lblAttribute2;
        private System.Windows.Forms.Label lblAttribute1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelN;
        private System.Windows.Forms.ComboBox cmbDiet;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.PictureBox ptbAnimalpic;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tspAnimalMotel;
        private System.Windows.Forms.ToolTip MainFormttp;
        private System.Windows.Forms.OpenFileDialog opfAnimal;
        private System.Windows.Forms.Label lblDietType;
        private System.Windows.Forms.ListBox lstFeedingSchedule;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox gpbFeedingSchedule;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.RadioButton rbtnSortByPetName;
        private System.Windows.Forms.RadioButton rbtnSortByID;
        private System.Windows.Forms.GroupBox grpFood_StaffInfo;
        private System.Windows.Forms.Button btnDeleteAnimal;
        private System.Windows.Forms.Button btnAddRecipe;
        private System.Windows.Forms.Button btnAddEmployee;
        private System.Windows.Forms.ListBox lstinformation;
        private System.Windows.Forms.ToolStripMenuItem mnuNew;
        private System.Windows.Forms.ToolStripMenuItem mnuOpen;
        private System.Windows.Forms.ToolStripMenuItem mnuSave;
        private System.Windows.Forms.ToolStripMenuItem mnuSaveAs;
        private System.Windows.Forms.ToolStripMenuItem mnuXMLRead;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.OpenFileDialog opfLoading;
        private System.Windows.Forms.SaveFileDialog sfdSave_Saveas;
        private System.Windows.Forms.ToolStripMenuItem mnuImportXML;
        private System.Windows.Forms.ToolStripMenuItem mnuExportXML;
    }
}

