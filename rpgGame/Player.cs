using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace rpgGame
{
    [Serializable()]
    class Player : Person, ISerializable 
    {
        private int contDelay = 5;
        private int id;
        private String name;
        private int gender;
        private double closeNess;
        private int numberOfClues;
        private int positionX=0;
        private int positionY=0;
        private int level;
        private List<Image> sprite;
        
        private Inventory inventory;
        private List<Item> clues;
        private int width = 35;
        private int height = 35;
        private int xMove;
        private int yMove;
        private Game eng;
        private int dir = 2;//der=2 izq=1 arr=3 aba=0
        private int s = 0; //0->3
        private int delay = 10;
        private int speed = 3;
        public Sprite partySprite;
        private Layer LC;
        //private LocalMap worldMap;

        public Player(SerializationInfo info, StreamingContext ctxt)
        {
            contDelay = (int)info.GetValue("PlayerContDelay", typeof(int));
            id = (int)info.GetValue("PlayerId", typeof(int));
            name = (String)info.GetValue("PlayerName", typeof(String));
            gender = (int)info.GetValue("PlayerGender", typeof(int));
            closeNess = (double)info.GetValue("PlayerCloseness", typeof(double));
            numberOfClues = (int)info.GetValue("PlayerClues", typeof(int));
            positionX = (int)info.GetValue("PlayerPositionX", typeof(int));
            positionY = (int)info.GetValue("PlayerPositionY", typeof(int));
            level = (int)info.GetValue("PlayerLevel", typeof(int));
        //private List<Image> sprite;
        //private Inventory inventory; inventario sí
        //private List<Item> clues; clues también :c
            width = (int)info.GetValue("PlayerWidth", typeof(int));
            height = (int)info.GetValue("PlayerHeight", typeof(int));
            xMove = (int)info.GetValue("PlayerXMove", typeof(int));
            yMove = (int)info.GetValue("PlayerYMove", typeof(int));
        //private Game eng;
            dir = (int)info.GetValue("PlayerDir", typeof(int));
            s = (int)info.GetValue("PlayerS", typeof(int));
            delay = (int)info.GetValue("PlayerDelay", typeof(int));
            speed = (int)info.GetValue("PlayerSpeed", typeof(int));
            inventory = (Inventory)info.GetValue("PlayerInventory", typeof(Inventory));
        //public Sprite partySprite;
        //private Layer LC;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("PlayerContDelay", contDelay);
            info.AddValue("PlayerId", id);
            info.AddValue("PlayerName",name);
            info.AddValue("PlayerGender", gender);
            info.AddValue("PlayerCloseness", closeNess);
            info.AddValue("PlayerClues", clues);
            info.AddValue("PlayerPositionX", positionX);
            info.AddValue("PlayerPositionY", positionY);
            info.AddValue("PlayerLevel", level);
            info.AddValue("PlayerWidth", width);
            info.AddValue("PlayerHeight", height);
            info.AddValue("PlayerXMove", xMove);
            info.AddValue("PlayerYMove", yMove);
            info.AddValue("PlayerDir", dir);
            info.AddValue("PlayerS", s);
            info.AddValue("PlayerDelay", delay);
            info.AddValue("PlayerSpeed", speed);
            info.AddValue("PlayerInventory", inventory);
        }
        public Player(Game game, Point location, int id)
        {
            LC = game.getLc();
            this.eng = game;
            name = "GGwp"; //por cambiar, tiene que ser ingresao desde el meenu inicial
            positionX = location.X;
            positionY = location.Y;
            Bitmap bmp = new Bitmap("ash_sheet.png"); 
            partySprite = new Sprite(location, bmp, id);
            sprite = new List<Image>();
            //for(int py =0; py <3; py++)
                for (int px = 0; px < 12; px++)
                {
                    sprite.Add(partySprite.crop(px * width, 0, width, height));
                }
        }

        private int getT(int x)
        {
            int cW = (int)(LC.getTotalX() * 1.0 / LC.getWidth());
            return (x / cW) + 1;
        }
        private bool valid(int x, int y)
        {
            return (x >= 0 && y >= 0 && x < 750 && y < 650);
        }

        public void Tick()
        {
            GetInput();
            Move();
         
        }

        public int GetnumberOfClues()
        {
            return numberOfClues;
        }

        public void  SetnumberOfClues(int numberClues)
        {
            numberOfClues=numberClues;
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

                if (valid(getPositionX(), getPositionY() - speed))//valida si esta en marco
                    if (LC.getTiles()[getT(getPositionX())][getT(getPositionY() - speed)] == 1)//colision
                        yMove = -speed;
                //collision
                //                    if (LC.getTiles()[yMove-speed][1]==1)
                //yMove = -speed;
 
            }



            if (KeyManager.down)
            {
                if (dir == 0) { if (delay == 0) { s++; delay = contDelay; } else delay--; } else s = 0;
                this.dir = 0;

                if (valid(getPositionX(), getPositionY() + speed))
                    if (LC.getTiles()[getT(getPositionX())][getT(getPositionY() + speed)] == 1)
                        yMove = speed;
                //yMove = speed;
           
            }


            if (KeyManager.left)
            {
                if (dir == 3) { if (delay == 0) { s++; delay = contDelay; } else delay--; } else s = 0;
                this.dir = 3;
                if (valid(getPositionX() - speed, getPositionY()))
                    if (LC.getTiles()[getT(getPositionX() - speed)][getT(getPositionY())] == 1)
                        xMove = -speed;
                //xMove = -speed;
                
            }


            if (KeyManager.right)
            {
                if (dir == 1) { if (delay == 0) { s++; delay = contDelay; } else delay--; } else s = 0;
                this.dir = 1;
                if (valid(getPositionX() + speed, getPositionY()))
                    if (LC.getTiles()[getT(getPositionX() + speed)][getT(getPositionY())] == 1)
                        xMove = speed;
                //xMove = speed;
               
            }
            if (s == 3) s = 0;

        }

        public void increaseCloseness()
        {

        }

        public void increaseNumberOfClues(Friend friend)
        {

        }

        public void increaseLevel()
        {

        }


        public int getPositionX()
        {
            return positionX;
        }

        public void setPositionX(int positionX)
        {
            //if (!(positionX < 0) && !(positionX > 650) && (worldMap.GetWalkableAt(new Point(positionX, positionY)) == true)) //CAMBIAR WALKABLE A LOCAL MAP
                this.positionX = positionX;
        }

        public int getPositionY()
        {
                return positionY;
        }

        public void setPositionY(int positionY)
        {
            //if (!(positionY < 0) && !(positionY > 455) && worldMap.GetWalkableAt(new Point(positionX, positionY))) 
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

        /*public void agregarWM(LocalMap worldMap){
            this.worldMap=worldMap;
        }*/

        public int GetWidth()
        {
            return width;
        }

        public int GetHeight()
        {
            return height;
        }
    }
}
