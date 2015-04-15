using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace rpgGame
{
    class LocalMap
    {

        private Player player;
        private int mapAct;
        public Image mapImage;
        public struct Tile
        {
            public Image img;
            public Point loc;
            public bool walkable;
        }
        //private List<PictureBox> tiles;
        public List<Tile> mapTiles;
        public LocalMap(Form form, Player play)
        {
            player = play;
            mapTiles = new List<Tile>();
            LoadMap("Map");
        }

        public void DrawMap(Graphics device)
        {
            /*for (int x = 0; x < 80; x++)
                for (int y = 0; y < 80; y++)
                {
                    //Pen pen = new Pen(Color.Transparent);
                    //Bitmap bmp = new Bitmap("background.jpg");
                    //device.DrawRectangle(pen, x * 10, y * 10, 10, 10);
                }*/
            //Image img = Image.FromFile("background.jpg");
            //device.DrawImage(img, 0, 0);  
            foreach (Tile t in mapTiles)
            {
                device.DrawImage(t.img, t.loc);
            }
        }

        
        public void LoadMap(String mapName)
        {
            StreamReader reader = new StreamReader(mapName +".txt");
            int y=0;
            while(!reader.EndOfStream)
            {
                string line= reader.ReadLine();
                for(int x=0;x<line.Length;x++)
                {
                    Tile t=new Tile();
                    t.loc= new Point(x*40,y*40);
                    if(line[x].ToString() == "0")
                    {
                        t.img= new Bitmap("pared.png");
                        t.walkable=false;
                    }
                    if(line[x].ToString() == "1")
                    {
                        t.img= new Bitmap("piso.png");
                        t.walkable=true;
                    }
                    mapTiles.Add(t);
                }
                y++;
            }
        }

        public bool GetWalkableAt(Point loc)
        {
            foreach (Tile t in mapTiles)
            {
                if (t.loc == loc)
                {
                    if (t.walkable)
                        return true;
                }
            }
            return false;
        }

        public void Tick()
        {
            if (player != null)
            {
                player.Tick();
            }
            
        }
    }
}
