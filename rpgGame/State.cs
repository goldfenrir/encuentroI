using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace rpgGame
{
    abstract class State
    {
        public abstract void Draw(Graphics dev);
        public void update()
        {

        }
        public void onEnter()
        {

        }
        public void onExit()
        {

        }
        public virtual void Tick()
        {
            //def
        }
    }
}
