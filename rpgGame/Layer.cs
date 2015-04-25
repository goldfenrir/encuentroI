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
    class Layer
    {
        private int id;
        private int width, height;
        private int totalX, totalY;
        private int[][] tiles;
        private Bitmap[] gTilePalette;
        public struct Tile
        {
            public Image img;
            public Point esqSupIzq;
            public Point esqInfDer;
            public bool walkable;
        }

        public List<Tile> mapTiles;

        public Layer(String path, String dirImg)
        {
            loadWorld(path);
            gTilePalette = SliceImg(dirImg, width, height, totalX, totalY);
        }

        private Bitmap[] SliceImg(String dirImg, int width, int height, int totalX, int totalY)
        {
            int cW = (int)(totalX * 1.0 / width);
            int cH = (int)(totalY * 1.0 / height);
            Bitmap[] a = new Bitmap[width * height];
            Image img = new Bitmap(dirImg);
            Sprite sheet = new Sprite(new Point(0,0), img, 8);

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    a[x + width * y] = (Bitmap)sheet.crop(x * cW, y * cH, cW, cH);
                }
            }
            return a;
        }

        private void loadWorld(String mapName){
            StreamReader reader = new StreamReader(mapName + ".txt");
            int y = 0;
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                for (int x = 0; x < line.Length; x++)
                {
                    Tile t = new Tile();
                    t.esqSupIzq = new Point(x * 40, y * 40);
                    t.esqInfDer = new Point((x * 40) + 39, (y * 40) + 39);
                    if (line[x].ToString() == "1")
                    {
                        t.img = new Bitmap("pared.png");
                        t.walkable = false;
                    }
                    if (line[x].ToString() == "0")
                    {
                        t.img = new Bitmap("piso.png");
                        t.walkable = true;
                    }
                    mapTiles.Add(t);

                }
                y++;
            }
	    }

        public void render(Graphics g)
        {
            int cW = (int)(getTotalX() * 1.0 / getWidth());
            int cH = (int)(totalY * 1.0 / getHeight());
            for (int y = 0; y < getHeight(); y++)
            {
                for (int x = 0; x < getWidth(); x++)
                {
                    g.DrawImage((Image)gTilePalette[getTiles()[x][y]], (int)(x * cW),
                            (int)(y * cH), cW, cH);
                }
            }

        }

        /**
         * @return the tiles
         */
        public int[][] getTiles()
        {
            return tiles;
        }

        /**
         * @return the width
         */
        public int getWidth()
        {
            return width;
        }

        /**
         * @return the height
         */
        public int getHeight()
        {
            return height;
        }

        /**
         * @return the totalX
         */
        public int getTotalX()
        {
            return totalX;
        }

        /**
         * @param totalX the totalX to set
         */
        public void setTotalX(int totalX)
        {
            this.totalX = totalX;
        }
  
    }
}
