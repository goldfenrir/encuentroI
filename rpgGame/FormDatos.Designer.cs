namespace rpgGame
{
    partial class FormDatos
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
            this.label_name = new System.Windows.Forms.Label();
            this.text_name = new System.Windows.Forms.TextBox();
            this.gBox_gender = new System.Windows.Forms.GroupBox();
            this.radio_female = new System.Windows.Forms.RadioButton();
            this.radio_male = new System.Windows.Forms.RadioButton();
            this.combo_animals = new System.Windows.Forms.ComboBox();
            this.label_Animal = new System.Windows.Forms.Label();
            this.button_save = new System.Windows.Forms.Button();
            this.gBox_gender.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_name
            // 
            this.label_name.AutoSize = true;
            this.label_name.BackColor = System.Drawing.Color.Khaki;
            this.label_name.Location = new System.Drawing.Point(13, 28);
            this.label_name.Name = "label_name";
            this.label_name.Size = new System.Drawing.Size(35, 13);
            this.label_name.TabIndex = 0;
            this.label_name.Text = "Name";
            this.label_name.Click += new System.EventHandler(this.label1_Click);
            // 
            // text_name
            // 
            this.text_name.Location = new System.Drawing.Point(68, 25);
            this.text_name.Name = "text_name";
            this.text_name.Size = new System.Drawing.Size(168, 20);
            this.text_name.TabIndex = 1;
            // 
            // gBox_gender
            // 
            this.gBox_gender.Controls.Add(this.radio_female);
            this.gBox_gender.Controls.Add(this.radio_male);
            this.gBox_gender.Location = new System.Drawing.Point(16, 75);
            this.gBox_gender.Name = "gBox_gender";
            this.gBox_gender.Size = new System.Drawing.Size(220, 71);
            this.gBox_gender.TabIndex = 2;
            this.gBox_gender.TabStop = false;
            this.gBox_gender.Text = "Gender";
            // 
            // radio_female
            // 
            this.radio_female.AutoSize = true;
            this.radio_female.Location = new System.Drawing.Point(135, 32);
            this.radio_female.Name = "radio_female";
            this.radio_female.Size = new System.Drawing.Size(59, 17);
            this.radio_female.TabIndex = 1;
            this.radio_female.TabStop = true;
            this.radio_female.Text = "Female";
            this.radio_female.UseVisualStyleBackColor = true;
            // 
            // radio_male
            // 
            this.radio_male.AutoSize = true;
            this.radio_male.Location = new System.Drawing.Point(37, 32);
            this.radio_male.Name = "radio_male";
            this.radio_male.Size = new System.Drawing.Size(48, 17);
            this.radio_male.TabIndex = 0;
            this.radio_male.TabStop = true;
            this.radio_male.Text = "Male";
            this.radio_male.UseVisualStyleBackColor = true;
            // 
            // combo_animals
            // 
            this.combo_animals.FormattingEnabled = true;
            this.combo_animals.Items.AddRange(new object[] {
            "Dog",
            "Cat",
            "Lion",
            "Bear",
            "Parrot",
            "Hanster",
            "Rabbit"});
            this.combo_animals.Location = new System.Drawing.Point(22, 196);
            this.combo_animals.Name = "combo_animals";
            this.combo_animals.Size = new System.Drawing.Size(214, 21);
            this.combo_animals.TabIndex = 3;
            // 
            // label_Animal
            // 
            this.label_Animal.AutoSize = true;
            this.label_Animal.Location = new System.Drawing.Point(22, 180);
            this.label_Animal.Name = "label_Animal";
            this.label_Animal.Size = new System.Drawing.Size(79, 13);
            this.label_Animal.TabIndex = 4;
            this.label_Animal.Text = "Favorite Animal";
            this.label_Animal.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // button_save
            // 
            this.button_save.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Aqua;
            this.button_save.Location = new System.Drawing.Point(84, 239);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(96, 38);
            this.button_save.TabIndex = 5;
            this.button_save.Text = "Save Player";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // FormDatos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Khaki;
            this.ClientSize = new System.Drawing.Size(274, 303);
            this.Controls.Add(this.button_save);
            this.Controls.Add(this.label_Animal);
            this.Controls.Add(this.combo_animals);
            this.Controls.Add(this.gBox_gender);
            this.Controls.Add(this.text_name);
            this.Controls.Add(this.label_name);
            this.Name = "FormDatos";
            this.Text = "New Player";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.gBox_gender.ResumeLayout(false);
            this.gBox_gender.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_name;
        private System.Windows.Forms.TextBox text_name;
        private System.Windows.Forms.GroupBox gBox_gender;
        private System.Windows.Forms.RadioButton radio_female;
        private System.Windows.Forms.RadioButton radio_male;
        private System.Windows.Forms.ComboBox combo_animals;
        private System.Windows.Forms.Label label_Animal;
        private System.Windows.Forms.Button button_save;
    }
}