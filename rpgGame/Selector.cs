using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace rpgGame
{
    class Selector
    {
        protected Bitmap sprite;
        private int optY; //option default
        private String path;
        private int x, y, w, h;
        private int stepY;
        private int stepX;
        private int contDelay = 8;
        private int delay = 8;
        private int max_optsY;
        private int max_optsX;
        private int optX;
        public Selector(int x, int y, int w, int h, int stepY, int maxY, int indSel = 1, int stepX = 1, int maxX= 1)
        {
            this.max_optsY = maxY;
            this.max_optsX = maxX;
            this.optY = 1;
            this.optX = 1;
            this.x = x;
            this.y = y;
            this.w = w;
            this.h = h;
            this.stepY = stepY;
            this.stepX = stepX;
            path = "selector.png";
            if (indSel == 2)
                path = "handcursor.jpg";
            sprite = new Bitmap(path);

        }

        public void right(){
            if (getOptX() < max_optsX) if (delay == 0) { x += stepX; delay = contDelay; optX++; } else delay--;
        }

        public void left(){
            if (getOptX() > 1) if (delay == 0) { x -= stepX; delay = contDelay; optX--; } else delay--;
        }
        public void down()
        {

            if (getOpt() < max_optsY) if (delay == 0) { y += stepY; delay = contDelay; optY++; } else delay--;

        }
        public void up()
        {

            if (getOpt() > 1) if (delay == 0) { y -= stepY; delay = contDelay; optY--; } else delay--;

        }
        public void render(Graphics g)
        {
            g.DrawImage(sprite, x, y, w, h);

        }

        /**
         * @return the opt
         */
        public int getOpt()
        {
            return optY;
        }
        public int getOptX()
        {
            return optX;
        }
    }
}
