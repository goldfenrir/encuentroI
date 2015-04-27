﻿namespace rpgGame
{
    partial class MainMenuG
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenuG));
            this.label_game = new System.Windows.Forms.Label();
            this.but_start = new System.Windows.Forms.Button();
            this.but_options = new System.Windows.Forms.Button();
            this.but_car = new System.Windows.Forms.Button();
            this.but_scores = new System.Windows.Forms.Button();
            this.but_credits = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label_game
            // 
            this.label_game.AccessibleName = "label_menu";
            this.label_game.AutoSize = true;
            this.label_game.Font = new System.Drawing.Font("Algerian", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_game.Location = new System.Drawing.Point(24, 25);
            this.label_game.Name = "label_game";
            this.label_game.Size = new System.Drawing.Size(285, 24);
            this.label_game.TabIndex = 0;
            this.label_game.Text = "Un encuentro inesperado";
            // 
            // but_start
            // 
            this.but_start.AccessibleName = "but_start";
            this.but_start.Location = new System.Drawing.Point(28, 223);
            this.but_start.Name = "but_start";
            this.but_start.Size = new System.Drawing.Size(88, 40);
            this.but_start.TabIndex = 1;
            this.but_start.Text = "Start Game";
            this.but_start.UseVisualStyleBackColor = true;
            this.but_start.Click += new System.EventHandler(this.but_start_Click);
            // 
            // but_options
            // 
            this.but_options.AccessibleName = "but_options";
            this.but_options.Location = new System.Drawing.Point(28, 290);
            this.but_options.Name = "but_options";
            this.but_options.Size = new System.Drawing.Size(88, 40);
            this.but_options.TabIndex = 2;
            this.but_options.Text = "Options";
            this.but_options.UseVisualStyleBackColor = true;
            // 
            // but_car
            // 
            this.but_car.AccessibleName = "but_car";
            this.but_car.BackColor = System.Drawing.SystemColors.Control;
            this.but_car.Location = new System.Drawing.Point(150, 223);
            this.but_car.Name = "but_car";
            this.but_car.Size = new System.Drawing.Size(88, 40);
            this.but_car.TabIndex = 3;
            this.but_car.Text = "Select Character";
            this.but_car.UseVisualStyleBackColor = false;
            // 
            // but_scores
            // 
            this.but_scores.AccessibleName = "but_scores";
            this.but_scores.Location = new System.Drawing.Point(150, 290);
            this.but_scores.Name = "but_scores";
            this.but_scores.Size = new System.Drawing.Size(88, 40);
            this.but_scores.TabIndex = 4;
            this.but_scores.Text = "High scores";
            this.but_scores.UseVisualStyleBackColor = true;
            // 
            // but_credits
            // 
            this.but_credits.AccessibleName = "but_credits";
            this.but_credits.Location = new System.Drawing.Point(297, 260);
            this.but_credits.Name = "but_credits";
            this.but_credits.Size = new System.Drawing.Size(88, 40);
            this.but_credits.TabIndex = 5;
            this.but_credits.Text = "Credits";
            this.but_credits.UseVisualStyleBackColor = true;
            this.but_credits.Click += new System.EventHandler(this.button5_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::rpgGame.Properties.Resources.zoo2;
            this.pictureBox1.Location = new System.Drawing.Point(1, -24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(402, 391);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // MainMenuG
            // 
            this.AccessibleName = "Form_Menu";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 369);
            this.Controls.Add(this.but_credits);
            this.Controls.Add(this.but_scores);
            this.Controls.Add(this.but_car);
            this.Controls.Add(this.but_options);
            this.Controls.Add(this.but_start);
            this.Controls.Add(this.label_game);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainMenuG";
            this.Text = "RPG Main Menu";
            this.Load += new System.EventHandler(this.MainMenuG_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_game;
        private System.Windows.Forms.Button but_start;
        private System.Windows.Forms.Button but_options;
        private System.Windows.Forms.Button but_car;
        private System.Windows.Forms.Button but_scores;
        private System.Windows.Forms.Button but_credits;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}