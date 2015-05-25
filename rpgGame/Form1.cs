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
            game = new Game(this, 800, 740, "encuentro inesperado");
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

        private void cerrado(object sender, EventArgs e)
        {
            Dispose();
            //Application.Exit();
        }

        /*
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        /*
        private void but_start_Click(object sender, EventArgs e)
        {

            game = new Game(this, 800, 740, "encuentro inesperado");
            game.Start();
            hideLayer();

        }
        private void hideLayer()
        {
            this.but_car.Enabled = false;
            this.but_credits.Enabled = false;
            this.but_options.Enabled = false;
            this.but_scores.Enabled = false;
            this.but_start.Enabled = false;
            this.but_car.Visible = false;
            this.but_start.Visible = false;
            this.but_credits.Visible = false;
            this.but_options.Visible = false;
            this.label_game.Visible = false;
            this.but_scores.Visible = false;
            //this.pictureBox1.Visible = false;
        }
        /*private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        *//*
        private void but_car_Click(object sender, EventArgs e)
        {
            dataPlayer = new FormDatos();
            dataPlayer.Show();
        }

        private void but_credits_Click(object sender, EventArgs e)
        {
            FormCredits creditos = new FormCredits();
            creditos.Show();
        }

        private void pic_save_Click(object sender, EventArgs e)
        {
            game.saveStateToBin();
        }

        private void pic_load_Click(object sender, EventArgs e)
        {
            game.loadStateToBin();
        }*/
    }
}
