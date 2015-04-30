using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Media.Imaging;

namespace rpgGame
{
    public class Sprite
    {
        public Point location;
        public Image image;
        public int id;

        public Sprite()
        {

        }
        public Sprite(Point loc, Image img, int id){
            this.location=loc;
            this.image=img;
            this.id=id;
        }
        public void Draw(Graphics device)
        {
            device.DrawImage(image, location);
        }

        //mover al sprite
        public void Move(int x, int y)
        {
            location.X += x * 5;
            location.Y += y * 5;
        }

        public  Image crop(int x, int y, int width, int height)
        {
            //Bitmap src = new Bitmap("ash_sheet.bmp");
            Bitmap src = new Bitmap(image);

            Bitmap cropped = src.Clone(new Rectangle(x, y, width, height) , src.PixelFormat);
            return (Image)cropped;
        }
    }
}
