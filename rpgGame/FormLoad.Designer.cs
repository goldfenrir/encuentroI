namespace rpgGame
{
    partial class FormLoad
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
            this.label_load = new System.Windows.Forms.Label();
            this.combo_load = new System.Windows.Forms.ComboBox();
            this.but_ok = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_load
            // 
            this.label_load.AutoSize = true;
            this.label_load.Location = new System.Drawing.Point(13, 46);
            this.label_load.Name = "label_load";
            this.label_load.Size = new System.Drawing.Size(98, 26);
            this.label_load.TabIndex = 0;
            this.label_load.Text = "Choose your game \r\nsaved";
            // 
            // combo_load
            // 
            this.combo_load.FormattingEnabled = true;
            this.combo_load.Location = new System.Drawing.Point(181, 43);
            this.combo_load.Name = "combo_load";
            this.combo_load.Size = new System.Drawing.Size(121, 21);
            this.combo_load.TabIndex = 1;
            // 
            // but_ok
            // 
            this.but_ok.Location = new System.Drawing.Point(204, 85);
            this.but_ok.Name = "but_ok";
            this.but_ok.Size = new System.Drawing.Size(75, 23);
            this.but_ok.TabIndex = 2;
            this.but_ok.Text = "ok";
            this.but_ok.UseVisualStyleBackColor = true;
            // 
            // FormLoad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 120);
            this.Controls.Add(this.but_ok);
            this.Controls.Add(this.combo_load);
            this.Controls.Add(this.label_load);
            this.Name = "FormLoad";
            this.Text = "FormLoad";
            this.Load += new System.EventHandler(this.FormLoad_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_load;
        private System.Windows.Forms.ComboBox combo_load;
        private System.Windows.Forms.Button but_ok;
    }
}