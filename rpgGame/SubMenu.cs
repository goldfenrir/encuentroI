﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpgGame
{
    class SubMenu : State
    {
        private int type;
        private List<String> options = new List<String>();
        private int posY;

        private void render()
        {

        }

        private void onExit()
        {

        }

        private void update()
        {

        }

        public int getType()
        {
            return type;
        }

        public void setType(int type)
        {
            this.type = type;
        }

        public List<String> getOptions()
        {
            return options;
        }

        public void setOptions(List<String> options)
        {
            this.options = options;
        }

        public int getPosY()
        {
            return posY;
        }

        public void setPosY(int posY)
        {
            this.posY = posY;
        }
    }
}