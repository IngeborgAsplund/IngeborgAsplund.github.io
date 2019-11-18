namespace APUsZoo
{
    partial class EmplyeeManagementForm
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
            this.lblName = new System.Windows.Forms.Label();
            this.txtEmployerName = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDeleteQual = new System.Windows.Forms.Button();
            this.btnChangeQual = new System.Windows.Forms.Button();
            this.btnAddQual = new System.Windows.Forms.Button();
            this.lstQualifications = new System.Windows.Forms.ListBox();
            this.txtQualification = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddEmployee = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(31, 31);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(53, 20);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name";
            // 
            // txtEmployerName
            // 
            this.txtEmployerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmployerName.Location = new System.Drawing.Point(136, 31);
            this.txtEmployerName.Name = "txtEmployerName";
            this.txtEmployerName.Size = new System.Drawing.Size(265, 27);
            this.txtEmployerName.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDeleteQual);
            this.groupBox1.Controls.Add(this.btnChangeQual);
            this.groupBox1.Controls.Add(this.btnAddQual);
            this.groupBox1.Controls.Add(this.lstQualifications);
            this.groupBox1.Controls.Add(this.txtQualification);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(35, 99);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(487, 399);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Qualifications";
            // 
            // btnDeleteQual
            // 
            this.btnDeleteQual.Location = new System.Drawing.Point(6, 259);
            this.btnDeleteQual.Name = "btnDeleteQual";
            this.btnDeleteQual.Size = new System.Drawing.Size(107, 51);
            this.btnDeleteQual.TabIndex = 5;
            this.btnDeleteQual.Text = "Delete";
            this.btnDeleteQual.UseVisualStyleBackColor = true;
            this.btnDeleteQual.Click += new System.EventHandler(this.btnDeleteQual_Click);
            // 
            // btnChangeQual
            // 
            this.btnChangeQual.Location = new System.Drawing.Point(6, 179);
            this.btnChangeQual.Name = "btnChangeQual";
            this.btnChangeQual.Size = new System.Drawing.Size(107, 51);
            this.btnChangeQual.TabIndex = 4;
            this.btnChangeQual.Text = "Change";
            this.btnChangeQual.UseVisualStyleBackColor = true;
            this.btnChangeQual.Click += new System.EventHandler(this.btnChangeQual_Click);
            // 
            // btnAddQual
            // 
            this.btnAddQual.Location = new System.Drawing.Point(6, 101);
            this.btnAddQual.Name = "btnAddQual";
            this.btnAddQual.Size = new System.Drawing.Size(107, 51);
            this.btnAddQual.TabIndex = 3;
            this.btnAddQual.Text = "Add";
            this.btnAddQual.UseVisualStyleBackColor = true;
            this.btnAddQual.Click += new System.EventHandler(this.btnAddQual_Click);
            // 
            // lstQualifications
            // 
            this.lstQualifications.FormattingEnabled = true;
            this.lstQualifications.ItemHeight = 20;
            this.lstQualifications.Location = new System.Drawing.Point(119, 101);
            this.lstQualifications.Name = "lstQualifications";
            this.lstQualifications.Size = new System.Drawing.Size(342, 264);
            this.lstQualifications.TabIndex = 2;
            this.lstQualifications.SelectedIndexChanged += new System.EventHandler(this.lstQualifications_SelectedIndexChanged);
            // 
            // txtQualification
            // 
            this.txtQualification.Location = new System.Drawing.Point(151, 48);
            this.txtQualification.Name = "txtQualification";
            this.txtQualification.Size = new System.Drawing.Size(300, 27);
            this.txtQualification.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Qualification";
            // 
            // btnAddEmployee
            // 
            this.btnAddEmployee.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAddEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddEmployee.Location = new System.Drawing.Point(35, 522);
            this.btnAddEmployee.Name = "btnAddEmployee";
            this.btnAddEmployee.Size = new System.Drawing.Size(161, 33);
            this.btnAddEmployee.TabIndex = 3;
            this.btnAddEmployee.Text = "Add this employee";
            this.btnAddEmployee.UseVisualStyleBackColor = true;
            this.btnAddEmployee.Click += new System.EventHandler(this.btnAddEmployee_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(266, 522);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(161, 33);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // EmplyeeManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.ClientSize = new System.Drawing.Size(534, 588);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAddEmployee);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtEmployerName);
            this.Controls.Add(this.lblName);
            this.Name = "EmplyeeManagementForm";
            this.Text = "Staff planning";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtEmployerName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnDeleteQual;
        private System.Windows.Forms.Button btnChangeQual;
        private System.Windows.Forms.Button btnAddQual;
        private System.Windows.Forms.ListBox lstQualifications;
        private System.Windows.Forms.TextBox txtQualification;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddEmployee;
        private System.Windows.Forms.Button btnCancel;
    }
}