using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace rpgGame
{
   
    public class Layer 
    {
        private int id;
        private int width, height;
        private int totalX, totalY;
        private int[][] tiles;
        private Bitmap[] gTilePalette;
        //public List<Tile> mapTiles;



        public Layer(String path, String dirImg)
        {
            loadWorld(path);
            gTilePalette = SliceImg(dirImg);
        }

        private Bitmap[] SliceImg(String dirImg)
        {
            int cW = (totalX / width);
            int cH = (totalY / height);
            Bitmap[] a = new Bitmap[width * height];
            Image img = new Bitmap(dirImg);
            //Sprite sheet = new Sprite(new Point(0,0), img, 8);
            //Bitmap src = new Bitmap(img);

            /*Image croppedImage = new Image();
            croppedImage.Width = 200;
            croppedImage.Margin = new Thickness(5);*/

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    //Bitmap src = new Bitmap(img);

                    //Bitmap cropped = src.Clone(new Rectangle(x*cW, y*cH, width, height), src.PixelFormat);
                    
                    a[x + width * y] = CropImage(img, new Rectangle(x*cW, y*cH,cW,cH));
                }
            }
            return a;
        }

        static Bitmap CropImage(Image originalImage, Rectangle sourceRectangle,
    Rectangle? destinationRectangle = null)
        {
            if (destinationRectangle == null)
            {
                destinationRectangle = new Rectangle(Point.Empty, sourceRectangle.Size);
            }

            var croppedImage = new Bitmap(destinationRectangle.Value.Width,
                destinationRectangle.Value.Height);
            using (var graphics = Graphics.FromImage(croppedImage))
            {
                graphics.DrawImage(originalImage, destinationRectangle.Value,
                    sourceRectangle, GraphicsUnit.Pixel);
            }
            return croppedImage;
        }

        private void loadWorld(String mapName){
            StreamReader reader = new StreamReader(mapName);
            //int y = 0;
            //reader.
                //reader.ReadLine();
                string line = "safasdfasasdfasf";
                line = reader.ReadLine();
                string[] arr;
                arr = new string [2];
                arr = line.Split(' ');
                width = int.Parse(arr[1]);
                height = int.Parse(arr[1]);
                line = reader.ReadLine();
                arr = line.Split(' ');
                totalX = int.Parse(arr[0]);
                totalY = int.Parse(arr[1]);

                tiles = new int[getWidth()][];
                for (int x = 0; x < tiles.Length; x++)
                {
                    tiles[x] = new int[getHeight()];
                }
                char[] delim;
                delim = new char[2];
                delim[0] = ' ';
                delim[1] = '\t';
                string[] arr2;
                int mul = width * height;
                arr2= new string[width];
                //line = reader.ReadLine();
                //arr2 = line.Split(delim);
		        for(int y = 0;y < getHeight();y++){
                    line = reader.ReadLine();
                    arr2 = line.Split(delim);
			        for(int x = 0;x < getWidth();x++){
                        tiles[x][y] = int.Parse(arr2[x]);
				        //tiles[x][y] = Utils.parseInt(tokens[(x + y * getWidth()) + 4]);//pensar
			        }
		        }
                /*
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
                y++;*/
            
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
