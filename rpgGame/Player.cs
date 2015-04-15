using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace rpgGame
{
    class Player
    {
        private int contDelay = 5;
        private int id;
        private String name;
        private int gender;
        private double happiness;
        private int numberOfFriends;
        private int positionX=0;
        private int positionY=0;
        private int level;
        private int numerOfTrophies;
        private List<Image> sprite;
        private int pointingDirection;
        private Inventory inventory;
        private List<Friend> friends;
        private int width = 35;
        private int height = 35;
        private int xMove;
        private int yMove;
        private Game eng;
        private int dir = 2;//der=2 izq=1 arr=3 aba=0
        private int s = 0; //0->3
        private int delay = 10;
        private int speed = 40;
        public Sprite partySprite;
        private LocalMap worldMap;
        public Player(Point location, Image img, int id)
        {
            partySprite = new Sprite(location, img, id);
            sprite = new List<Image>();
            //for(int py =0; py <3; py++)
                for (int px = 0; px < 12; px++)
                {
                    sprite.Add(partySprite.crop(px * width, 0, width, height));
                }
        }

        public void Tick()
        {
            GetInput();
            Move();
         
        }

        private void GetInput()
        {
            xMove = 0;
            yMove = 0;
            //der=2 izq=1 arr=3 aba=0

            if (KeyManager.up)
            {
                //delay para actualizar sprite
                //s es un sprite movimiento de una direccion
                if (dir == 2) { if (delay == 0) { s++; delay = contDelay; } else delay--; } else s = 0;
                this.dir = 2;
                //collision
                //                    if (LC.getTiles()[yMove-speed][1]==1)
                yMove = -speed;
 
            }



            if (KeyManager.down)
            {
                if (dir == 0) { if (delay == 0) { s++; delay = contDelay; } else delay--; } else s = 0;
                this.dir = 0;
                yMove = speed;
           
            }


            if (KeyManager.left)
            {
                if (dir == 3) { if (delay == 0) { s++; delay = contDelay; } else delay--; } else s = 0;
                this.dir = 3;
                xMove = -speed;
                
            }


            if (KeyManager.right)
            {
                if (dir == 1) { if (delay == 0) { s++; delay = contDelay; } else delay--; } else s = 0;
                this.dir = 1;
                xMove = speed;
               
            }
            if (s == 3) s = 0;

        }

        public void increaseHappiness()
        {

        }

        public void increaseNumberOfFriends(Friend friend)
        {

        }

        public void increaseLevel()
        {

        }

        public void increaseNumberOfTrophies()
        {

        }

        public int getPositionX()
        {
            return positionX;
        }

        public void setPositionX(int positionX)
        {
            if(!(positionX < 0) && !(positionX > 650) && !worldMap.GetWalkableAt(new Point(positionX,positionY)) ) 
                this.positionX = positionX;
        }

        public int getPositionY()
        {
                return positionY;
        }

        public void setPositionY(int positionY)
        {
            if (!(positionY < 0) && !(positionY > 475) && !worldMap.GetWalkableAt(new Point(positionX, positionY))) 
                this.positionY = positionY;
        }

        public void Move()
        {
            int newX = positionX + xMove;
            int newY = positionY + yMove;
            this.setPositionX(newX);
            this.setPositionY(newY);
            //partySprite.Move(xMove, yMove);

        }

        public void Draw(Graphics device)
        {
            device.DrawImage(sprite[this.dir * 3 + s], positionX, positionY, width, height);
        }

        public void agregarWM(LocalMap worldMap){
            this.worldMap=worldMap;
        }
    }
}
