using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace rpgGame
{
    public class Lobby : State
    {
        TcpClient clientSocket = new TcpClient();
        NetworkStream serverStream = default(NetworkStream);
        string readData = null;
        Game eng;
        private Bitmap background;
        public Lobby(Game g)
        {
            eng = g;
            background = new Bitmap("zoofinal.jpg");
        }

        public override void Draw(Graphics dev)
        {

        }

        public override bool ordenPop()
        {
            return false;
        }

        public bool mostrarDialogoDatos()
        {
            DialogoDatos dat = new DialogoDatos(eng);

            return true;
        }
        
    }
}
