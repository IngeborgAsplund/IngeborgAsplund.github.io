namespace BlackJackSimple
{
    partial class GameBoard
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
            this.DealerCard = new System.Windows.Forms.PictureBox();
            this.Deck = new System.Windows.Forms.PictureBox();
            this.Discarded = new System.Windows.Forms.PictureBox();
            this.BtnStartGame = new System.Windows.Forms.Button();
            this.btnReshuffle = new System.Windows.Forms.Button();
            this.btnReplay = new System.Windows.Forms.Button();
            this.Sidebar1 = new System.Windows.Forms.PictureBox();
            this.sidebar2 = new System.Windows.Forms.PictureBox();
            this.btnQuit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lbldealerScore = new System.Windows.Forms.Label();
            this.btnSaveGame = new System.Windows.Forms.Button();
            this.btnOpenOldSave = new System.Windows.Forms.Button();
            this.btnHowToPlay = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DealerCard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Deck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Discarded)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sidebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sidebar2)).BeginInit();
            this.SuspendLayout();
            // 
            // DealerCard
            // 
            this.DealerCard.Image = global::BlackJackSimple.Properties.Resources.jb;
            this.DealerCard.Location = new System.Drawing.Point(377, 28);
            this.DealerCard.Name = "DealerCard";
            this.DealerCard.Size = new System.Drawing.Size(143, 219);
            this.DealerCard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.DealerCard.TabIndex = 0;
            this.DealerCard.TabStop = false;
            // 
            // Deck
            // 
            this.Deck.Image = global::BlackJackSimple.Properties.Resources.b1fv;
            this.Deck.Location = new System.Drawing.Point(170, 28);
            this.Deck.Name = "Deck";
            this.Deck.Size = new System.Drawing.Size(143, 219);
            this.Deck.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Deck.TabIndex = 1;
            this.Deck.TabStop = false;
            // 
            // Discarded
            // 
            this.Discarded.Image = global::BlackJackSimple.Properties.Resources.b2fh;
            this.Discarded.Location = new System.Drawing.Point(597, 56);
            this.Discarded.Name = "Discarded";
            this.Discarded.Size = new System.Drawing.Size(219, 143);
            this.Discarded.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Discarded.TabIndex = 2;
            this.Discarded.TabStop = false;
            // 
            // BtnStartGame
            // 
            this.BtnStartGame.Location = new System.Drawing.Point(12, 384);
            this.BtnStartGame.Name = "BtnStartGame";
            this.BtnStartGame.Size = new System.Drawing.Size(140, 38);
            this.BtnStartGame.TabIndex = 3;
            this.BtnStartGame.Text = "New Game";
            this.BtnStartGame.UseVisualStyleBackColor = true;
            this.BtnStartGame.Click += new System.EventHandler(this.BtnStartGame_Click);
            // 
            // btnReshuffle
            // 
            this.btnReshuffle.Location = new System.Drawing.Point(400, 441);
            this.btnReshuffle.Name = "btnReshuffle";
            this.btnReshuffle.Size = new System.Drawing.Size(140, 38);
            this.btnReshuffle.TabIndex = 4;
            this.btnReshuffle.Text = "Reshuffle";
            this.btnReshuffle.UseVisualStyleBackColor = true;
            this.btnReshuffle.Click += new System.EventHandler(this.btnReshuffle_Click);
            // 
            // btnReplay
            // 
            this.btnReplay.Location = new System.Drawing.Point(561, 441);
            this.btnReplay.Name = "btnReplay";
            this.btnReplay.Size = new System.Drawing.Size(140, 38);
            this.btnReplay.TabIndex = 5;
            this.btnReplay.Text = "Replay";
            this.btnReplay.UseVisualStyleBackColor = true;
            this.btnReplay.Click += new System.EventHandler(this.btnReplay_Click);
            // 
            // Sidebar1
            // 
            this.Sidebar1.Image = global::BlackJackSimple.Properties.Resources.b1pr;
            this.Sidebar1.Location = new System.Drawing.Point(516, 56);
            this.Sidebar1.Name = "Sidebar1";
            this.Sidebar1.Size = new System.Drawing.Size(50, 143);
            this.Sidebar1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Sidebar1.TabIndex = 6;
            this.Sidebar1.TabStop = false;
            // 
            // sidebar2
            // 
            this.sidebar2.Image = global::BlackJackSimple.Properties.Resources.b1pl;
            this.sidebar2.Location = new System.Drawing.Point(330, 56);
            this.sidebar2.Name = "sidebar2";
            this.sidebar2.Size = new System.Drawing.Size(50, 143);
            this.sidebar2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.sidebar2.TabIndex = 7;
            this.sidebar2.TabStop = false;
            // 
            // btnQuit
            // 
            this.btnQuit.Location = new System.Drawing.Point(817, 471);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(97, 55);
            this.btnQuit.TabIndex = 8;
            this.btnQuit.Text = "Quit";
            this.btnQuit.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 22);
            this.label1.TabIndex = 9;
            this.label1.Text = "Dealers score";
            // 
            // lbldealerScore
            // 
            this.lbldealerScore.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbldealerScore.Location = new System.Drawing.Point(46, 56);
            this.lbldealerScore.Name = "lbldealerScore";
            this.lbldealerScore.Size = new System.Drawing.Size(66, 35);
            this.lbldealerScore.TabIndex = 10;
            // 
            // btnSaveGame
            // 
            this.btnSaveGame.Location = new System.Drawing.Point(12, 496);
            this.btnSaveGame.Name = "btnSaveGame";
            this.btnSaveGame.Size = new System.Drawing.Size(140, 38);
            this.btnSaveGame.TabIndex = 11;
            this.btnSaveGame.Text = "Save Game";
            this.btnSaveGame.UseVisualStyleBackColor = true;
            this.btnSaveGame.Click += new System.EventHandler(this.btnSaveGame_Click);
            // 
            // btnOpenOldSave
            // 
            this.btnOpenOldSave.Location = new System.Drawing.Point(12, 441);
            this.btnOpenOldSave.Name = "btnOpenOldSave";
            this.btnOpenOldSave.Size = new System.Drawing.Size(140, 38);
            this.btnOpenOldSave.TabIndex = 12;
            this.btnOpenOldSave.Text = "Load Saved";
            this.btnOpenOldSave.UseVisualStyleBackColor = true;
            this.btnOpenOldSave.Click += new System.EventHandler(this.btnOpenOldSave_Click);
            // 
            // btnHowToPlay
            // 
            this.btnHowToPlay.Location = new System.Drawing.Point(817, 401);
            this.btnHowToPlay.Name = "btnHowToPlay";
            this.btnHowToPlay.Size = new System.Drawing.Size(97, 55);
            this.btnHowToPlay.TabIndex = 13;
            this.btnHowToPlay.Text = "How to play";
            this.btnHowToPlay.UseVisualStyleBackColor = true;
            this.btnHowToPlay.Click += new System.EventHandler(this.btnHowToPlay_Click);
            // 
            // GameBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OliveDrab;
            this.ClientSize = new System.Drawing.Size(936, 551);
            this.Controls.Add(this.btnHowToPlay);
            this.Controls.Add(this.btnOpenOldSave);
            this.Controls.Add(this.btnSaveGame);
            this.Controls.Add(this.lbldealerScore);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.sidebar2);
            this.Controls.Add(this.Sidebar1);
            this.Controls.Add(this.btnReplay);
            this.Controls.Add(this.btnReshuffle);
            this.Controls.Add(this.BtnStartGame);
            this.Controls.Add(this.Discarded);
            this.Controls.Add(this.Deck);
            this.Controls.Add(this.DealerCard);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GameBoard";
            this.Text = "Game";
            ((System.ComponentModel.ISupportInitialize)(this.DealerCard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Deck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Discarded)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sidebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sidebar2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox DealerCard;
        private System.Windows.Forms.PictureBox Deck;
        private System.Windows.Forms.PictureBox Discarded;
        private System.Windows.Forms.Button BtnStartGame;
        private System.Windows.Forms.Button btnReshuffle;
        private System.Windows.Forms.Button btnReplay;
        private System.Windows.Forms.PictureBox Sidebar1;
        private System.Windows.Forms.PictureBox sidebar2;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbldealerScore;
        private System.Windows.Forms.Button btnSaveGame;
        private System.Windows.Forms.Button btnOpenOldSave;
        private System.Windows.Forms.Button btnHowToPlay;
    }
}

