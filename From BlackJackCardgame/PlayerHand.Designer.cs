namespace BlackJackSimple
{
    partial class PlayerHand
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
            this.lblScore = new System.Windows.Forms.Label();
            this.lblPlayerName = new System.Windows.Forms.Label();
            this.playerCard = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNumOfCard = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lblRemainingDraws = new System.Windows.Forms.Label();
            this.btnDrawCard = new System.Windows.Forms.Button();
            this.btnSwapCard = new System.Windows.Forms.Button();
            this.btnDiscard = new System.Windows.Forms.Button();
            this.btnTurnOver = new System.Windows.Forms.Button();
            this.lblVictories = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.playerCard)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(412, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Score";
            // 
            // lblScore
            // 
            this.lblScore.BackColor = System.Drawing.Color.Cornsilk;
            this.lblScore.Location = new System.Drawing.Point(482, 17);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(46, 34);
            this.lblScore.TabIndex = 1;
            // 
            // lblPlayerName
            // 
            this.lblPlayerName.BackColor = System.Drawing.Color.Cornsilk;
            this.lblPlayerName.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayerName.Location = new System.Drawing.Point(204, 19);
            this.lblPlayerName.Name = "lblPlayerName";
            this.lblPlayerName.Size = new System.Drawing.Size(180, 32);
            this.lblPlayerName.TabIndex = 2;
            // 
            // playerCard
            // 
            this.playerCard.Location = new System.Drawing.Point(193, 126);
            this.playerCard.Name = "playerCard";
            this.playerCard.Size = new System.Drawing.Size(139, 232);
            this.playerCard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.playerCard.TabIndex = 3;
            this.playerCard.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 22);
            this.label2.TabIndex = 4;
            this.label2.Text = "Cards on hand";
            // 
            // lblNumOfCard
            // 
            this.lblNumOfCard.BackColor = System.Drawing.Color.Cornsilk;
            this.lblNumOfCard.Location = new System.Drawing.Point(142, 19);
            this.lblNumOfCard.Name = "lblNumOfCard";
            this.lblNumOfCard.Size = new System.Drawing.Size(46, 34);
            this.lblNumOfCard.TabIndex = 5;
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(338, 213);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(109, 44);
            this.btnNext.TabIndex = 6;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Location = new System.Drawing.Point(77, 213);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(109, 44);
            this.btnPrevious.TabIndex = 7;
            this.btnPrevious.Text = "Pevious";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(142, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 22);
            this.label3.TabIndex = 8;
            this.label3.Text = "Remaining draws";
            // 
            // lblRemainingDraws
            // 
            this.lblRemainingDraws.BackColor = System.Drawing.Color.Cornsilk;
            this.lblRemainingDraws.Location = new System.Drawing.Point(296, 65);
            this.lblRemainingDraws.Name = "lblRemainingDraws";
            this.lblRemainingDraws.Size = new System.Drawing.Size(46, 36);
            this.lblRemainingDraws.TabIndex = 9;
            // 
            // btnDrawCard
            // 
            this.btnDrawCard.Location = new System.Drawing.Point(40, 408);
            this.btnDrawCard.Name = "btnDrawCard";
            this.btnDrawCard.Size = new System.Drawing.Size(122, 35);
            this.btnDrawCard.TabIndex = 10;
            this.btnDrawCard.Text = "Draw Card";
            this.btnDrawCard.UseVisualStyleBackColor = true;
            this.btnDrawCard.Click += new System.EventHandler(this.btnDrawCard_Click);
            // 
            // btnSwapCard
            // 
            this.btnSwapCard.Location = new System.Drawing.Point(193, 408);
            this.btnSwapCard.Name = "btnSwapCard";
            this.btnSwapCard.Size = new System.Drawing.Size(154, 35);
            this.btnSwapCard.TabIndex = 11;
            this.btnSwapCard.Text = "Swap With Dealer";
            this.btnSwapCard.UseVisualStyleBackColor = true;
            this.btnSwapCard.Click += new System.EventHandler(this.btnSwapCard_Click);
            // 
            // btnDiscard
            // 
            this.btnDiscard.Location = new System.Drawing.Point(406, 408);
            this.btnDiscard.Name = "btnDiscard";
            this.btnDiscard.Size = new System.Drawing.Size(122, 35);
            this.btnDiscard.TabIndex = 12;
            this.btnDiscard.Text = "Discard";
            this.btnDiscard.UseVisualStyleBackColor = true;
            this.btnDiscard.Click += new System.EventHandler(this.btnDiscard_Click);
            // 
            // btnTurnOver
            // 
            this.btnTurnOver.Location = new System.Drawing.Point(419, 314);
            this.btnTurnOver.Name = "btnTurnOver";
            this.btnTurnOver.Size = new System.Drawing.Size(109, 44);
            this.btnTurnOver.TabIndex = 13;
            this.btnTurnOver.Text = "End Turn";
            this.btnTurnOver.UseVisualStyleBackColor = true;
            this.btnTurnOver.Click += new System.EventHandler(this.btnTurnOver_Click);
            // 
            // lblVictories
            // 
            this.lblVictories.BackColor = System.Drawing.Color.Cornsilk;
            this.lblVictories.Location = new System.Drawing.Point(482, 67);
            this.lblVictories.Name = "lblVictories";
            this.lblVictories.Size = new System.Drawing.Size(46, 34);
            this.lblVictories.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(394, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 22);
            this.label5.TabIndex = 14;
            this.label5.Text = "Victories";
            // 
            // PlayerHand
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OliveDrab;
            this.ClientSize = new System.Drawing.Size(571, 477);
            this.Controls.Add(this.lblVictories);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnTurnOver);
            this.Controls.Add(this.btnDiscard);
            this.Controls.Add(this.btnSwapCard);
            this.Controls.Add(this.btnDrawCard);
            this.Controls.Add(this.lblRemainingDraws);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.lblNumOfCard);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.playerCard);
            this.Controls.Add(this.lblPlayerName);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PlayerHand";
            this.Text = "PlayerHand";
            ((System.ComponentModel.ISupportInitialize)(this.playerCard)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label lblPlayerName;
        private System.Windows.Forms.PictureBox playerCard;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblNumOfCard;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblRemainingDraws;
        private System.Windows.Forms.Button btnDrawCard;
        private System.Windows.Forms.Button btnSwapCard;
        private System.Windows.Forms.Button btnDiscard;
        private System.Windows.Forms.Button btnTurnOver;
        private System.Windows.Forms.Label lblVictories;
        private System.Windows.Forms.Label label5;
    }
}