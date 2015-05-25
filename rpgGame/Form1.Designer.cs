namespace rpgGame
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
            this.SuspendLayout();
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(291, 261);
            this.Name = "Form1";
            this.Text = "RPG GAME";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.cerrado);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion
        /*
        private System.Windows.Forms.Label label_game;
        private System.Windows.Forms.Button but_start;
        private System.Windows.Forms.Button but_options;
        private System.Windows.Forms.Button but_car;
        private System.Windows.Forms.Button but_scores;
        private System.Windows.Forms.Button but_credits;*/
    }
}

