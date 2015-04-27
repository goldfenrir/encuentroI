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
    public partial class MainMenuG : Form
    {
        public MainMenuG()
        {
            InitializeComponent();
        }

        private void MainMenuG_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void but_start_Click(object sender, EventArgs e)
        {
            Form1 startGame= new Form1();
            startGame.Show();
        }
    }
}
