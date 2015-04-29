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
    public partial class FormSave : Form
    {
        Game games;
        bool clicked = false;

        public bool Clicked
        {
            get { return clicked; }
            set { clicked = value; }
        }
        public FormSave ()
        {
            InitializeComponent();
            //games = eng;
        }

        private void FormSave_Load(object sender, EventArgs e)
        {

        }

        private void but_save_Click(object sender, EventArgs e)
        {
            /*String text = "";
            text = text_save.Text;
            game.saveStateToBin(text);
            Console.WriteLine("1");
            KeyManager.menu = false;
            game.getSM().PopState();
            this.Close();*/
            clicked = true;
        }
        public String getText()
        {
            String text = "";
            text+=text_save.Text;
            return text;
        }
    }
}
