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
        private int opt; //option default
        private String path;
        private int x, y, w, h;
        private int stepY;
        private int contDelay = 10;
        private int delay = 10;
        private int max_opts;
        public Selector(int x, int y, int w, int h, int stepY, int max)
        {
            this.max_opts = max;
            this.opt = 1;
            this.x = x;
            this.y = y;
            this.w = w;
            this.h = h;
            this.stepY = stepY;
            path = "selector.png";
            sprite = new Bitmap(path);

        }
        public void down()
        {

            if (getOpt() < max_opts) if (delay == 0) { y += stepY; delay = contDelay; opt++; } else delay--;

        }
        public void up()
        {

            if (getOpt() > 1) if (delay == 0) { y -= stepY; delay = contDelay; opt--; } else delay--;

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
            return opt;
        }
    }
}
