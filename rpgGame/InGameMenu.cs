﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpgGame
{
    class InGameMenu : State
    {
        protected Stack<SubMenu> subMenus;
        private int posY;
        protected List<String> options;
        public void render()
        {

        }
        public void update()
        {

        }
        public void onEnter()
        {

        }
        public void onExit()
        {

        }

        /**
         * @return the posY
         */
        public int getPosY()
        {
            return posY;
        }

        /**
         * @param posY the posY to set
         */
        public void setPosY(int posY)
        {
            this.posY = posY;
        }
    }
}
