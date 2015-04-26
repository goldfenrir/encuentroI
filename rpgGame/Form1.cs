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
    public partial class Form1 : Form
    {
        Game game;
        public Form1()
        {
            InitializeComponent();
            game = new Game(this,800,740,"encuentro inesperado");
            game.Start();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            KeyManager.HandleKeyPress(e);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            KeyManager.HandleKeyUp(e);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
