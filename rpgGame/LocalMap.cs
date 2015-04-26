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
    class LocalMap : State
    {
        private Map map;
        private List<Map> maps = new List<Map>();
        private Player player;
        private List<Friend> friends;
        private int mapAct;
        
        /*public struct Tile
        {
            public Image img;
            public Point esqSupIzq;
            public Point esqInfDer;
            public bool walkable;
        }*/
        //private List<PictureBox> tiles;
        //public List<Tile> mapTiles;
        public LocalMap(Form form, Game game /*Player play*/)
        {

            player= new Player(game, new Point(80, 80), 1);
            mapAct = game.getCurrentMap();
        }

        public override void Draw(Graphics dv)
        {
            /*foreach (Tile t in mapTiles)
            {
                dv.DrawImage(t.img, t.esqSupIzq);
            }
            player.Draw(dv);*/
            maps[getMapAct()].render(dv);
            player.Draw(dv);
        }

        public int getMapAct()
        {
            return mapAct;
        }

        public List<Map> getMaps(){
            return maps;
        }

        public Player getPlayer(){
            return player;
        }

        /*public void DrawMap(Graphics device)
        {
            /*for (int x = 0; x < 80; x++)
                for (int y = 0; y < 80; y++)
                {
                    //Pen pen = new Pen(Color.Transparent);
                    //Bitmap bmp = new Bitmap("background.jpg");
                    //device.DrawRectangle(pen, x * 10, y * 10, 10, 10);
                }
            //Image img = Image.FromFile("background.jpg");
            //device.DrawImage(img, 0, 0);  
            foreach (Tile t in mapTiles)
            {
                device.DrawImage(t.img, t.esqSupIzq);
            }
        }*/
        
        /*public void LoadMap(String mapName)
        {
            
        }*/

        /*public bool GetWalkableAt(Point loc)
        {
            foreach (Tile t in mapTiles)
            {
                int w = player.GetWidth();
                int h = player.GetHeight();
                //verificacion esquina sup izq del personaje
                if ((loc.X >= t.esqSupIzq.X) && (loc.X <= t.esqInfDer.X) && (loc.Y >= t.esqSupIzq.Y) && (loc.Y <= t.esqInfDer.Y))
                {
                            if (!t.walkable)
                                return false;
                                            
                }
                // esquina sup der del pers
                if ((loc.X+w >= t.esqSupIzq.X) && (loc.X+w <= t.esqInfDer.X) && (loc.Y >= t.esqSupIzq.Y) && (loc.Y <= t.esqInfDer.Y))
                {
                    if (!t.walkable)
                        return false;

                }
                // esquina inferior izq
                if ((loc.X >= t.esqSupIzq.X) && (loc.X <= t.esqInfDer.X) && (loc.Y+h >= t.esqSupIzq.Y) && (loc.Y+h <= t.esqInfDer.Y))
                {
                    if (!t.walkable)
                        return false;

                }
                //esquina inferio der
                if ((loc.X+w >= t.esqSupIzq.X) && (loc.X+w <= t.esqInfDer.X) && (loc.Y+h >= t.esqSupIzq.Y) && (loc.Y+h <= t.esqInfDer.Y))
                {
                    if (!t.walkable)
                        return false;

                }
            }
            return true;
        }*/

        
        public override void Tick()
        {
            if (player != null)
            {
                player.Tick();
            }
            
        }
    }
}
