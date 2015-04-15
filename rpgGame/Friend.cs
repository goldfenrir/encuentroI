﻿using System;
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
        private int id;
        private String name;
        private int gender;
        private String province;
        private int positionX;
        private int positiony;
        private int homePositionX;
        private int homePositionY;
        private int unlockLevel;
        private Sprite sprite;
        private int dir;
        /**
         * @return the id/*/
        public Friend(Point location, Image img, int id)
            : base(location, img, id) 
        {
            isStatic = true;
        } 
        public int getId()
        {
            return id;
        }

        /**
         * @param id the id to set
         */
        public void setId(int id)
        {
            this.id = id;
        }

        /**
         * @return the name
         */
        public String getName()
        {
            return name;
        }

        /**
         * @param name the name to set
         */
        public void setName(String name)
        {
            this.name = name;
        }

        /**
         * @return the gender
         */
        public int getGender()
        {
            return gender;
        }

        /**
         * @param gender the gender to set
         */
        public void setGender(int gender)
        {
            this.gender = gender;
        }

        /**
         * @return the province
         */
        public String getProvince()
        {
            return province;
        }

        /**
         * @param province the province to set
         */
        public void setProvince(String province)
        {
            this.province = province;
        }

        /**
         * @return the positionX
         */
        public int getPositionX()
        {
            return positionX;
        }

        /**
         * @param positionX the positionX to set
         */
        public void setPositionX(int positionX)
        {
            this.positionX = positionX;
        }

        /**
         * @return the positiony
         */
        public int getPositiony()
        {
            return positiony;
        }

        /**
         * @param positiony the positiony to set
         */
        public void setPositiony(int positiony)
        {
            this.positiony = positiony;
        }

        /**
         * @return the homePositionX
         */
        public int getHomePositionX()
        {
            return homePositionX;
        }

        /**
         * @param homePositionX the homePositionX to set
         */
        public void setHomePositionX(int homePositionX)
        {
            this.homePositionX = homePositionX;
        }

        /**
         * @return the homePositionY
         */
        public int getHomePositionY()
        {
            return homePositionY;
        }

        /**
         * @param homePositionY the homePositionY to set
         */
        public void setHomePositionY(int homePositionY)
        {
            this.homePositionY = homePositionY;
        }

        /**
         * @return the unlockLevel
         */
        public int getUnlockLevel()
        {
            return unlockLevel;
        }

        /**
         * @param unlockLevel the unlockLevel to set
         */
        public void setUnlockLevel(int unlockLevel)
        {
            this.unlockLevel = unlockLevel;
        }
        public void move()
        {

        }
        public void talk()
        {
        }
        public void giveItem()
        {

        }
        public void addItem()
        {

        }
        public void consumeItem()
        {

        }
        
    }
}
