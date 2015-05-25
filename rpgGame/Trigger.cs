using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpgGame
{
    public abstract class Trigger
    {
        protected int x;
        protected int y;
        protected bool active;
        public int getX()
        {
            return x;
        }

        public int getY()
        {
            return y;
        }

        public abstract void execTrigger(LocalMap aThis);

        /**
         * @return the active
         */
        public bool isActive()
        {
            return active;
        }

        /**
         * @param active the active to set
         */
        public void setActive(bool active)
        {
            this.active = active;
        }
    }
}
