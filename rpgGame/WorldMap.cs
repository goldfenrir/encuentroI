﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace rpgGame
{
    class WorldMap : State
    {
        protected Image background;
        private int mapAct;

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
         * @return the mapAct
         */
        public int getMapAct()
        {
            return mapAct;
        }

        /**
         * @param mapAct the mapAct to set
         */
        public void setMapAct(int mapAct)
        {
            this.mapAct = mapAct;
        }
    }
}
