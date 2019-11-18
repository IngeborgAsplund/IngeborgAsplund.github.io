namespace Troop_Calculator
{
    partial class Mainform
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
            this.grpinput = new System.Windows.Forms.GroupBox();
            this.txtNumOfMinion = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTroopName = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblTotalStregth = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lstArmyTroops = new System.Windows.Forms.ListBox();
            this.evilMenue = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnNew = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExit = new System.Windows.Forms.ToolStripMenuItem();
            this.btnEditTroop = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnInformation = new System.Windows.Forms.Button();
            this.ttpApplicationhint = new System.Windows.Forms.ToolTip(this.components);
            this.grpinput.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.evilMenue.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpinput
            // 
            this.grpinput.Controls.Add(this.txtNumOfMinion);
            this.grpinput.Controls.Add(this.label3);
            this.grpinput.Controls.Add(this.cmbType);
            this.grpinput.Controls.Add(this.label2);
            this.grpinput.Controls.Add(this.label1);
            this.grpinput.Controls.Add(this.txtTroopName);
            this.grpinput.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpinput.ForeColor = System.Drawing.Color.White;
            this.grpinput.Location = new System.Drawing.Point(39, 88);
            this.grpinput.Margin = new System.Windows.Forms.Padding(4);
            this.grpinput.Name = "grpinput";
            this.grpinput.Padding = new System.Windows.Forms.Padding(4);
            this.grpinput.Size = new System.Drawing.Size(423, 237);
            this.grpinput.TabIndex = 0;
            this.grpinput.TabStop = false;
            this.grpinput.Text = "Arrange your troops";
            // 
            // txtNumOfMinion
            // 
            this.txtNumOfMinion.BackColor = System.Drawing.SystemColors.InfoText;
            this.txtNumOfMinion.ForeColor = System.Drawing.SystemColors.Info;
            this.txtNumOfMinion.Location = new System.Drawing.Point(223, 184);
            this.txtNumOfMinion.Name = "txtNumOfMinion";
            this.txtNumOfMinion.Size = new System.Drawing.Size(67, 27);
            this.txtNumOfMinion.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 184);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(151, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Number of soldiers";
            // 
            // cmbType
            // 
            this.cmbType.BackColor = System.Drawing.SystemColors.InfoText;
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.ForeColor = System.Drawing.SystemColors.Info;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Items.AddRange(new object[] {
            "Dynamite Troll (strenght 14)",
            "Deathsister (strenght 18)",
            "Lavaspider (strength 5)",
            "Burning Husk (strenght 20)",
            "Firebird (strenght 15)",
            "Helldragon(strength 25)"});
            this.cmbType.Location = new System.Drawing.Point(46, 121);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(297, 28);
            this.cmbType.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Choose Minion Type";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Enter Troop Name";
            // 
            // txtTroopName
            // 
            this.txtTroopName.BackColor = System.Drawing.SystemColors.InfoText;
            this.txtTroopName.ForeColor = System.Drawing.SystemColors.Info;
            this.txtTroopName.Location = new System.Drawing.Point(46, 57);
            this.txtTroopName.Name = "txtTroopName";
            this.txtTroopName.Size = new System.Drawing.Size(297, 27);
            this.txtTroopName.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblTotalStregth);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.lstArmyTroops);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(483, 60);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(638, 376);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Army";
            // 
            // lblTotalStregth
            // 
            this.lblTotalStregth.BackColor = System.Drawing.SystemColors.ControlText;
            this.lblTotalStregth.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotalStregth.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalStregth.ForeColor = System.Drawing.SystemColors.Info;
            this.lblTotalStregth.Location = new System.Drawing.Point(410, 327);
            this.lblTotalStregth.Name = "lblTotalStregth";
            this.lblTotalStregth.Size = new System.Drawing.Size(175, 35);
            this.lblTotalStregth.TabIndex = 6;
            this.lblTotalStregth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(215, 333);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(156, 20);
            this.label8.TabIndex = 5;
            this.label8.Text = "Total Army strenght";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(534, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 20);
            this.label7.TabIndex = 4;
            this.label7.Text = "Strength";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(418, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 48);
            this.label6.TabIndex = 3;
            this.label6.Text = "NO.\r\nSoldiers";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(236, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "Type";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "Name";
            // 
            // lstArmyTroops
            // 
            this.lstArmyTroops.BackColor = System.Drawing.SystemColors.InfoText;
            this.lstArmyTroops.ForeColor = System.Drawing.SystemColors.Info;
            this.lstArmyTroops.FormattingEnabled = true;
            this.lstArmyTroops.ItemHeight = 20;
            this.lstArmyTroops.Location = new System.Drawing.Point(7, 68);
            this.lstArmyTroops.Name = "lstArmyTroops";
            this.lstArmyTroops.Size = new System.Drawing.Size(624, 244);
            this.lstArmyTroops.TabIndex = 0;
            this.lstArmyTroops.SelectedIndexChanged += new System.EventHandler(this.lstArmyTroops_SelectedIndexChanged);
            // 
            // evilMenue
            // 
            this.evilMenue.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.evilMenue.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.evilMenue.Location = new System.Drawing.Point(0, 0);
            this.evilMenue.Name = "evilMenue";
            this.evilMenue.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.evilMenue.Size = new System.Drawing.Size(1146, 28);
            this.evilMenue.TabIndex = 2;
            this.evilMenue.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnExit,
            this.btnNew});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // btnNew
            // 
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(181, 26);
            this.btnNew.Text = "New(CTRL+N)";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnExit
            // 
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(181, 26);
            this.btnExit.Text = "Exit(ALT+F5)";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnEditTroop
            // 
            this.btnEditTroop.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnEditTroop.Location = new System.Drawing.Point(160, 343);
            this.btnEditTroop.Name = "btnEditTroop";
            this.btnEditTroop.Size = new System.Drawing.Size(111, 38);
            this.btnEditTroop.TabIndex = 4;
            this.btnEditTroop.Text = "Edit troop";
            this.btnEditTroop.UseVisualStyleBackColor = true;
            this.btnEditTroop.Click += new System.EventHandler(this.btnEditTroop_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnDelete.Location = new System.Drawing.Point(300, 343);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(111, 38);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "Delete troop";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCalculate
            // 
            this.btnCalculate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCalculate.Location = new System.Drawing.Point(85, 404);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(192, 51);
            this.btnCalculate.TabIndex = 4;
            this.btnCalculate.Text = "Calculate Strengh";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAdd.Location = new System.Drawing.Point(15, 343);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(111, 38);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "Add troop";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnInformation
            // 
            this.btnInformation.Location = new System.Drawing.Point(170, 51);
            this.btnInformation.Name = "btnInformation";
            this.btnInformation.Size = new System.Drawing.Size(122, 30);
            this.btnInformation.TabIndex = 7;
            this.btnInformation.Text = "Information";
            this.btnInformation.UseVisualStyleBackColor = true;
            this.btnInformation.Click += new System.EventHandler(this.btnInformation_Click);
            // 
            // Mainform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkRed;
            this.ClientSize = new System.Drawing.Size(1146, 485);
            this.Controls.Add(this.btnInformation);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEditTroop);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.grpinput);
            this.Controls.Add(this.evilMenue);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.KeyPreview = true;
            this.MainMenuStrip = this.evilMenue;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Mainform";
            this.Text = "The majestic troop calculator of Michelle Parker The evil overlord";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Mainform_KeyDown);
            this.grpinput.ResumeLayout(false);
            this.grpinput.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.evilMenue.ResumeLayout(false);
            this.evilMenue.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpinput;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.MenuStrip evilMenue;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnNew;
        private System.Windows.Forms.ToolStripMenuItem btnExit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTroopName;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNumOfMinion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox lstArmyTroops;
        private System.Windows.Forms.Button btnEditTroop;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblTotalStregth;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnInformation;
        private System.Windows.Forms.ToolTip ttpApplicationhint;
    }
}

