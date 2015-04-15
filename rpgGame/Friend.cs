using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace rpgGame
{
    class Friend : Sprite
    {
        public bool isStatic;
        public Friend(Point location, Image img, int id)
            : base(location, img, id) 
        {
            isStatic = true;
        }
    }
}
