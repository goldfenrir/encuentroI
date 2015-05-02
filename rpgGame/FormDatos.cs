using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rpgGame
{
    public partial class FormDatos : Form
    {
        private bool gender = true;
        private String name = "Player";
        public FormDatos()
        {
            InitializeComponent();
            this.Show();

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button_save_Click(object sender, EventArgs e)
        {
            // Get name from textbox
            //name="";
            name = text_name.Text;

            MessageBox.Show("Your name is: " + name);

            //Get Gender
            gender = this.radio_male.Checked;
            if (gender) MessageBox.Show("Your gender is: male");
            else MessageBox.Show("Your gender is: female");
            this.Close();


        }
        public void getData(String nameG, int genderG)
        {
            nameG = name;
            if (gender) genderG = 1;
            else genderG = 0;
        }
    }
}
