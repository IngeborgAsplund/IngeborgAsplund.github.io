namespace EvilOverlordDiagram_Generator
{
    partial class DiagramGenerator
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDiagramTitle = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.txtIntervalY = new System.Windows.Forms.TextBox();
            this.txtIntervalX = new System.Windows.Forms.TextBox();
            this.txtNodivY = new System.Windows.Forms.TextBox();
            this.txtNodivX = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCreatePoint = new System.Windows.Forms.Button();
            this.txtPointYcoord = new System.Windows.Forms.TextBox();
            this.txtPointXCoord = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.PointX = new System.Windows.Forms.Label();
            this.lstPoints = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.dataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSortX = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSortAfterY = new System.Windows.Forms.ToolStripMenuItem();
            this.pan_Diagram = new System.Windows.Forms.Panel();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnHowToUse = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDiagramTitle);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.btnReset);
            this.groupBox1.Controls.Add(this.btnOk);
            this.groupBox1.Controls.Add(this.txtIntervalY);
            this.groupBox1.Controls.Add(this.txtIntervalX);
            this.groupBox1.Controls.Add(this.txtNodivY);
            this.groupBox1.Controls.Add(this.txtNodivX);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox1.Location = new System.Drawing.Point(27, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(379, 251);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // txtDiagramTitle
            // 
            this.txtDiagramTitle.Location = new System.Drawing.Point(170, 36);
            this.txtDiagramTitle.Name = "txtDiagramTitle";
            this.txtDiagramTitle.Size = new System.Drawing.Size(158, 27);
            this.txtDiagramTitle.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(33, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 19);
            this.label6.TabIndex = 10;
            this.label6.Text = " Diagram titel";
            // 
            // btnReset
            // 
            this.btnReset.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnReset.Location = new System.Drawing.Point(211, 201);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(117, 30);
            this.btnReset.TabIndex = 9;
            this.btnReset.Text = "Cancel";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnOk
            // 
            this.btnOk.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnOk.Location = new System.Drawing.Point(33, 201);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(140, 30);
            this.btnOk.TabIndex = 8;
            this.btnOk.Text = "Create Diagram";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // txtIntervalY
            // 
            this.txtIntervalY.Location = new System.Drawing.Point(248, 140);
            this.txtIntervalY.Name = "txtIntervalY";
            this.txtIntervalY.Size = new System.Drawing.Size(80, 27);
            this.txtIntervalY.TabIndex = 7;
            // 
            // txtIntervalX
            // 
            this.txtIntervalX.Location = new System.Drawing.Point(143, 137);
            this.txtIntervalX.Name = "txtIntervalX";
            this.txtIntervalX.Size = new System.Drawing.Size(80, 27);
            this.txtIntervalX.TabIndex = 6;
            // 
            // txtNodivY
            // 
            this.txtNodivY.Location = new System.Drawing.Point(248, 101);
            this.txtNodivY.Name = "txtNodivY";
            this.txtNodivY.Size = new System.Drawing.Size(80, 27);
            this.txtNodivY.TabIndex = 5;
            // 
            // txtNodivX
            // 
            this.txtNodivX.Location = new System.Drawing.Point(143, 101);
            this.txtNodivX.Name = "txtNodivX";
            this.txtNodivX.Size = new System.Drawing.Size(80, 27);
            this.txtNodivX.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(291, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 19);
            this.label4.TabIndex = 3;
            this.label4.Text = "Y";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(167, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "X";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(29, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Interval Value";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "No Divisions";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnCreatePoint);
            this.groupBox2.Controls.Add(this.txtPointYcoord);
            this.groupBox2.Controls.Add(this.txtPointXCoord);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.PointX);
            this.groupBox2.Controls.Add(this.lstPoints);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox2.Location = new System.Drawing.Point(27, 294);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(379, 279);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Generate Points";
            // 
            // btnCreatePoint
            // 
            this.btnCreatePoint.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnCreatePoint.Location = new System.Drawing.Point(16, 169);
            this.btnCreatePoint.Name = "btnCreatePoint";
            this.btnCreatePoint.Size = new System.Drawing.Size(143, 34);
            this.btnCreatePoint.TabIndex = 5;
            this.btnCreatePoint.Text = "Create point";
            this.btnCreatePoint.UseVisualStyleBackColor = true;
            this.btnCreatePoint.Click += new System.EventHandler(this.btnCreatePoint_Click);
            // 
            // txtPointYcoord
            // 
            this.txtPointYcoord.Location = new System.Drawing.Point(81, 109);
            this.txtPointYcoord.Name = "txtPointYcoord";
            this.txtPointYcoord.Size = new System.Drawing.Size(69, 27);
            this.txtPointYcoord.TabIndex = 4;
            // 
            // txtPointXCoord
            // 
            this.txtPointXCoord.Location = new System.Drawing.Point(81, 62);
            this.txtPointXCoord.Name = "txtPointXCoord";
            this.txtPointXCoord.Size = new System.Drawing.Size(69, 27);
            this.txtPointXCoord.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 117);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 19);
            this.label5.TabIndex = 2;
            this.label5.Text = "Point Y";
            // 
            // PointX
            // 
            this.PointX.AutoSize = true;
            this.PointX.Location = new System.Drawing.Point(12, 66);
            this.PointX.Name = "PointX";
            this.PointX.Size = new System.Drawing.Size(62, 19);
            this.PointX.TabIndex = 1;
            this.PointX.Text = "Point X";
            // 
            // lstPoints
            // 
            this.lstPoints.FormattingEnabled = true;
            this.lstPoints.ItemHeight = 19;
            this.lstPoints.Location = new System.Drawing.Point(170, 41);
            this.lstPoints.Name = "lstPoints";
            this.lstPoints.Size = new System.Drawing.Size(184, 213);
            this.lstPoints.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.dataToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1030, 28);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(108, 26);
            this.mnuExit.Text = "Exit";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // dataToolStripMenuItem
            // 
            this.dataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSortX,
            this.mnuSortAfterY});
            this.dataToolStripMenuItem.Name = "dataToolStripMenuItem";
            this.dataToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.dataToolStripMenuItem.Text = "Data";
            // 
            // mnuSortX
            // 
            this.mnuSortX.Name = "mnuSortX";
            this.mnuSortX.Size = new System.Drawing.Size(201, 26);
            this.mnuSortX.Text = "Sort In XDirection";
            this.mnuSortX.Click += new System.EventHandler(this.mnuSortX_Click);
            // 
            // mnuSortAfterY
            // 
            this.mnuSortAfterY.Name = "mnuSortAfterY";
            this.mnuSortAfterY.Size = new System.Drawing.Size(201, 26);
            this.mnuSortAfterY.Text = "Sort In YDirection";
            this.mnuSortAfterY.Click += new System.EventHandler(this.mnuSortAfterY_Click);
            // 
            // pan_Diagram
            // 
            this.pan_Diagram.BackColor = System.Drawing.SystemColors.HighlightText;
            this.pan_Diagram.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pan_Diagram.Location = new System.Drawing.Point(437, 54);
            this.pan_Diagram.Name = "pan_Diagram";
            this.pan_Diagram.Size = new System.Drawing.Size(569, 480);
            this.pan_Diagram.TabIndex = 3;
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(727, 549);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(185, 35);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "Clear dawing";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnHowToUse
            // 
            this.btnHowToUse.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHowToUse.Location = new System.Drawing.Point(530, 549);
            this.btnHowToUse.Name = "btnHowToUse";
            this.btnHowToUse.Size = new System.Drawing.Size(125, 35);
            this.btnHowToUse.TabIndex = 5;
            this.btnHowToUse.Text = "User Manual";
            this.btnHowToUse.UseVisualStyleBackColor = true;
            this.btnHowToUse.Click += new System.EventHandler(this.btnHowToUse_Click);
            // 
            // DiagramGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.ClientSize = new System.Drawing.Size(1030, 596);
            this.Controls.Add(this.btnHowToUse);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.pan_Diagram);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DiagramGenerator";
            this.Text = "Diagram Generator";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.ToolStripMenuItem dataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuSortX;
        private System.Windows.Forms.ToolStripMenuItem mnuSortAfterY;
        private System.Windows.Forms.TextBox txtIntervalY;
        private System.Windows.Forms.TextBox txtIntervalX;
        private System.Windows.Forms.TextBox txtNodivY;
        private System.Windows.Forms.TextBox txtNodivX;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pan_Diagram;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox txtPointYcoord;
        private System.Windows.Forms.TextBox txtPointXCoord;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label PointX;
        private System.Windows.Forms.ListBox lstPoints;
        private System.Windows.Forms.Button btnCreatePoint;
        private System.Windows.Forms.TextBox txtDiagramTitle;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnHowToUse;
    }
}

