namespace APUsZoo
{
    partial class RecipeForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtRecipeName = new System.Windows.Forms.TextBox();
            this.grpAddingredient = new System.Windows.Forms.GroupBox();
            this.btnDeleteIngredient = new System.Windows.Forms.Button();
            this.btnChangeIngredient = new System.Windows.Forms.Button();
            this.btnAddIngredient = new System.Windows.Forms.Button();
            this.lstIngredients = new System.Windows.Forms.ListBox();
            this.txtIngredients = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnFinish = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grpAddingredient.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(49, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // txtRecipeName
            // 
            this.txtRecipeName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRecipeName.Location = new System.Drawing.Point(139, 47);
            this.txtRecipeName.Name = "txtRecipeName";
            this.txtRecipeName.Size = new System.Drawing.Size(247, 27);
            this.txtRecipeName.TabIndex = 1;
            // 
            // grpAddingredient
            // 
            this.grpAddingredient.Controls.Add(this.btnDeleteIngredient);
            this.grpAddingredient.Controls.Add(this.btnChangeIngredient);
            this.grpAddingredient.Controls.Add(this.btnAddIngredient);
            this.grpAddingredient.Controls.Add(this.lstIngredients);
            this.grpAddingredient.Controls.Add(this.txtIngredients);
            this.grpAddingredient.Controls.Add(this.label2);
            this.grpAddingredient.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpAddingredient.Location = new System.Drawing.Point(53, 105);
            this.grpAddingredient.Name = "grpAddingredient";
            this.grpAddingredient.Size = new System.Drawing.Size(490, 284);
            this.grpAddingredient.TabIndex = 2;
            this.grpAddingredient.TabStop = false;
            this.grpAddingredient.Text = "Add ingredients";
            // 
            // btnDeleteIngredient
            // 
            this.btnDeleteIngredient.Location = new System.Drawing.Point(11, 232);
            this.btnDeleteIngredient.Name = "btnDeleteIngredient";
            this.btnDeleteIngredient.Size = new System.Drawing.Size(87, 36);
            this.btnDeleteIngredient.TabIndex = 5;
            this.btnDeleteIngredient.Text = "Delete";
            this.btnDeleteIngredient.UseVisualStyleBackColor = true;
            this.btnDeleteIngredient.Click += new System.EventHandler(this.btnDeleteIngredient_Click);
            // 
            // btnChangeIngredient
            // 
            this.btnChangeIngredient.Location = new System.Drawing.Point(11, 168);
            this.btnChangeIngredient.Name = "btnChangeIngredient";
            this.btnChangeIngredient.Size = new System.Drawing.Size(87, 36);
            this.btnChangeIngredient.TabIndex = 4;
            this.btnChangeIngredient.Text = "Change";
            this.btnChangeIngredient.UseVisualStyleBackColor = true;
            this.btnChangeIngredient.Click += new System.EventHandler(this.btnChangeIngredient_Click);
            // 
            // btnAddIngredient
            // 
            this.btnAddIngredient.Location = new System.Drawing.Point(11, 104);
            this.btnAddIngredient.Name = "btnAddIngredient";
            this.btnAddIngredient.Size = new System.Drawing.Size(87, 36);
            this.btnAddIngredient.TabIndex = 3;
            this.btnAddIngredient.Text = "Add";
            this.btnAddIngredient.UseVisualStyleBackColor = true;
            this.btnAddIngredient.Click += new System.EventHandler(this.btnAddIngredient_Click);
            // 
            // lstIngredients
            // 
            this.lstIngredients.FormattingEnabled = true;
            this.lstIngredients.ItemHeight = 20;
            this.lstIngredients.Location = new System.Drawing.Point(114, 104);
            this.lstIngredients.Name = "lstIngredients";
            this.lstIngredients.Size = new System.Drawing.Size(347, 164);
            this.lstIngredients.TabIndex = 2;
            this.lstIngredients.SelectedIndexChanged += new System.EventHandler(this.lstIngredients_SelectedIndexChanged);
            // 
            // txtIngredients
            // 
            this.txtIngredients.Location = new System.Drawing.Point(134, 39);
            this.txtIngredients.Name = "txtIngredients";
            this.txtIngredients.Size = new System.Drawing.Size(284, 27);
            this.txtIngredients.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.DarkViolet;
            this.label2.Location = new System.Drawing.Point(7, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Ingredients";
            // 
            // btnFinish
            // 
            this.btnFinish.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnFinish.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinish.Location = new System.Drawing.Point(69, 408);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(196, 35);
            this.btnFinish.TabIndex = 3;
            this.btnFinish.Text = "Finish";
            this.btnFinish.UseVisualStyleBackColor = true;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(317, 408);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(197, 35);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // RecipeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaShell;
            this.ClientSize = new System.Drawing.Size(572, 455);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnFinish);
            this.Controls.Add(this.grpAddingredient);
            this.Controls.Add(this.txtRecipeName);
            this.Controls.Add(this.label1);
            this.Name = "RecipeForm";
            this.Text = "Recipe Register";
            this.grpAddingredient.ResumeLayout(false);
            this.grpAddingredient.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRecipeName;
        private System.Windows.Forms.GroupBox grpAddingredient;
        private System.Windows.Forms.Button btnDeleteIngredient;
        private System.Windows.Forms.Button btnChangeIngredient;
        private System.Windows.Forms.Button btnAddIngredient;
        private System.Windows.Forms.ListBox lstIngredients;
        private System.Windows.Forms.TextBox txtIngredients;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnFinish;
        private System.Windows.Forms.Button btnCancel;
    }
}