namespace rpgGame
{
    partial class FormSave
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
            this.label_save = new System.Windows.Forms.Label();
            this.text_save = new System.Windows.Forms.TextBox();
            this.but_save = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_save
            // 
            this.label_save.AutoSize = true;
            this.label_save.Location = new System.Drawing.Point(29, 26);
            this.label_save.Name = "label_save";
            this.label_save.Size = new System.Drawing.Size(139, 13);
            this.label_save.TabIndex = 0;
            this.label_save.Text = "Ingrese el nombre a guardar";
            // 
            // text_save
            // 
            this.text_save.Location = new System.Drawing.Point(196, 26);
            this.text_save.Name = "text_save";
            this.text_save.Size = new System.Drawing.Size(140, 20);
            this.text_save.TabIndex = 1;
            // 
            // but_save
            // 
            this.but_save.Location = new System.Drawing.Point(129, 68);
            this.but_save.Name = "but_save";
            this.but_save.Size = new System.Drawing.Size(75, 23);
            this.but_save.TabIndex = 2;
            this.but_save.Text = "Save";
            this.but_save.UseVisualStyleBackColor = true;
            this.but_save.Click += new System.EventHandler(this.but_save_Click);
            // 
            // FormSave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 112);
            this.Controls.Add(this.but_save);
            this.Controls.Add(this.text_save);
            this.Controls.Add(this.label_save);
            this.Name = "FormSave";
            this.Text = "FormSave";
            this.Load += new System.EventHandler(this.FormSave_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_save;
        private System.Windows.Forms.TextBox text_save;
        private System.Windows.Forms.Button but_save;
    }
}