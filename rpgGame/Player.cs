using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Schema;

namespace rpgGame
{
    [Serializable()]
    public class Player : ISerializable, IXmlSerializable
    {
        private int contDelay = 5;
        private int id;
        private int auxR = 0;
        public bool correct;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private String name;

        public String Name
        {
            get { return name; }
            set { name = value; }
        }
        private int gender;

        public int Gender
        {
            get { return gender; }
            set { gender = value; }
        }
        private double closeNess;

        public double CloseNess
        {
            get { return closeNess; }
            set { closeNess = value; }
        }
        private int numberOfClues;

        public int NumberOfClues
        {
            get { return numberOfClues; }
            set { numberOfClues = value; }
        }
        private int positionX = 0;

        public int PositionX
        {
            get { return positionX; }
            set { positionX = value; }
        }
        private int positionY = 0;

        public int PositionY
        {
            get { return positionY; }
            set { positionY = value; }
        }
        private int level;

        public int Level
        {
            get { return level; }
            set { level = value; }
        }
        private List<Image> sprite;

        private Inventory inventory = new Inventory();

        internal Inventory Inventory
        {
            get { return inventory; }
            set { inventory = value; }
        }
        private List<Item> clues;

        internal List<Item> Clues
        {
            get { return clues; }
            set { clues = value; }
        }
        private int width = 35;
        private int height = 35;
        private int xMove;

        public int XMove
        {
            get { return xMove; }
            set { xMove = value; }
        }
        private int yMove;

        public int YMove
        {
            get { return yMove; }
            set { yMove = value; }
        }
        private Game eng;
        private int dir = 2;//der=2 izq=1 arr=3 aba=0

        public int Dir
        {
            get { return dir; }
            set { dir = value; }
        }
        private int s = 0; //0->3

        public int S
        {
            get { return s; }
            set { s = value; }
        }
        private int delay = 10;
        private int speed = 3;
        public Sprite partySprite;
        private Layer LC;
        //private LocalMap worldMap;

        public Player() { }
        public XmlSchema GetSchema()
        {
            return null;
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteStartElement("PosionX");
            writer.WriteValue(positionX);
            writer.WriteEndElement();
            writer.WriteStartElement("PositionY");
            writer.WriteValue(positionY);
            writer.WriteEndElement();
            writer.WriteStartElement("dir");
            writer.WriteValue(dir);
            writer.WriteEndElement();
            writer.WriteStartElement("path");
            writer.WriteValue("ash_sheet.png");
            writer.WriteEndElement(); 
            writer.WriteStartElement("contDelay");
            writer.WriteValue(contDelay);
            writer.WriteEndElement();
            writer.WriteStartElement("width");
            writer.WriteValue(width);
            writer.WriteEndElement();
            writer.WriteStartElement("height");
            writer.WriteValue(height);
            writer.WriteEndElement();
            writer.WriteStartElement("tW");
            writer.WriteValue("200");
            writer.WriteEndElement();
            writer.WriteStartElement("tH");
            writer.WriteValue("200");
            writer.WriteEndElement();
            writer.WriteStartElement("speed");
            writer.WriteValue(speed);
            writer.WriteEndElement();
            writer.WriteStartElement("closeness");
            writer.WriteValue(closeNess);
            writer.WriteEndElement();
            
            if (inventory.getQuantity()!=0)
            {
                writer.WriteStartElement("Inventory");
                foreach (Item i in inventory.getItems())
                {
                    writer.WriteStartElement("Nombre");
                    writer.WriteValue(i.getName());
                    writer.WriteEndElement();
                    writer.WriteStartElement("stock");
                    writer.WriteValue(i.getStock());
                    writer.WriteEndElement();
                    writer.WriteStartElement("Descripcion");
                    writer.WriteValue(i.getDescription());
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }
            
        }

        public void ReadXml(XmlReader reader)
        {
            reader.ReadStartElement();
            positionX = reader.ReadElementContentAsInt();
            positionY = reader.ReadElementContentAsInt();
            dir = reader.ReadElementContentAsInt();
            string path = reader.ReadElementContentAsString();
            Bitmap bmp = new Bitmap(path);
            partySprite = new Sprite(new Point(positionX, positionY), bmp, id);
            sprite = new List<Image>();
            for (int px = 0; px < 12; px++)
            {
                sprite.Add(partySprite.crop(px * width, 0, width, height));
            }
            contDelay = reader.ReadElementContentAsInt();
            width = reader.ReadElementContentAsInt();
            height = reader.ReadElementContentAsInt();
            reader.ReadElementContentAsInt();
            reader.ReadElementContentAsInt();
            speed = reader.ReadElementContentAsInt();
            closeNess = reader.ReadElementContentAsDouble();
            reader.Read();
            if (reader.Value.Equals("Inventory"))
            {
                inventory = new Inventory();
                reader.Read();
                while(reader.Value.Equals("Inventory")){
                    string name1 = reader.ReadElementContentAsString();
                    int stock = reader.ReadElementContentAsInt();
                    string descr = reader.ReadElementContentAsString();
                    Item it = new Item(name1, stock, descr);
                    inventory.addItem(it);
                }
            }
        }

        public Player(SerializationInfo info, StreamingContext ctxt)
        {
            //contDelay = (int)info.GetValue("PlayerContDelay", typeof(int));
            id = (int)info.GetValue("PlayerId", typeof(int));
            name = (String)info.GetValue("PlayerName", typeof(String));
            gender = (int)info.GetValue("PlayerGender", typeof(int));
            closeNess = (double)info.GetValue("PlayerCloseness", typeof(double));
            numberOfClues = (int)info.GetValue("PlayerNumberOfClues", typeof(int));
            clues = (List<Item>)info.GetValue("PlayerClues", typeof(List<Item>));
            positionX = (int)info.GetValue("PlayerPositionX", typeof(int));
            positionY = (int)info.GetValue("PlayerPositionY", typeof(int));
            level = (int)info.GetValue("PlayerLevel", typeof(int));
        //private List<Image> sprite;
        //private Inventory inventory; inventario sí
        //private List<Item> clues; clues también :c
            //width = (int)info.GetValue("PlayerWidth", typeof(int));
            //height = (int)info.GetValue("PlayerHeight", typeof(int));
            xMove = (int)info.GetValue("PlayerXMove", typeof(int));
            yMove = (int)info.GetValue("PlayerYMove", typeof(int));
        //private Game eng;
            dir = (int)info.GetValue("PlayerDir", typeof(int));
            s = (int)info.GetValue("PlayerS", typeof(int));
            //delay = (int)info.GetValue("PlayerDelay", typeof(int));
            //speed = (int)info.GetValue("PlayerSpeed", typeof(int));
            inventory = (Inventory)info.GetValue("PlayerInventory", typeof(Inventory));
        //public Sprite partySprite;
        //private Layer LC;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            //info.AddValue("PlayerContDelay", contDelay);
            info.AddValue("PlayerId", id);
            info.AddValue("PlayerName",name);
            info.AddValue("PlayerGender", gender);
            info.AddValue("PlayerCloseness", closeNess);
            info.AddValue("PlayerNumberOfClues", numberOfClues);
            info.AddValue("PlayerClues", clues);
            info.AddValue("PlayerPositionX", positionX);
            info.AddValue("PlayerPositionY", positionY);
            info.AddValue("PlayerLevel", level);
            //info.AddValue("PlayerWidth", width);
            //info.AddValue("PlayerHeight", height);
            info.AddValue("PlayerXMove", xMove);
            info.AddValue("PlayerYMove", yMove);
            info.AddValue("PlayerDir", dir);
            info.AddValue("PlayerS", s);
            //info.AddValue("PlayerDelay", delay);
            //info.AddValue("PlayerSpeed", speed);
            info.AddValue("PlayerInventory", inventory);
        }
        public Player(Game game, Point location, int id)
        {
            inventory = new Inventory();
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

        public int getT(int x)
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


        public Layer getLC()
        {
            return LC;
        }

        /**
         * @param LC the LC to set
         */
        public void setLC(Layer LC)
        {
            this.LC = LC;
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
                Console.WriteLine("El nombre del jugador es " + name);
                if (dir == 1) { if (delay == 0) { s++; delay = contDelay; } else delay--; } else s = 0;
                this.dir = 1;
                if (valid(getPositionX() + speed, getPositionY()))
                    if (LC.getTiles()[getT(getPositionX() + speed)][getT(getPositionY())] == 1)
                        xMove = speed;
                //xMove = speed;
               
            }

            if (KeyManager.menu)
            {
                InGameMenu inGameM = new InGameMenu(eng);
                eng.getSM().AddState(inGameM);
            }


            if (KeyManager.menu)
            {
                if (auxR == 0) auxR++;
            }
            if (KeyManager.mR)
            {
                if (auxR == 1) auxR++;
            }
            if (auxR == 2)
            {
                KeyManager.mR = false;
                KeyManager.m = false;
                auxR = 0;
                InGameMenu inGameM = new InGameMenu(eng);
                eng.getSM().add(inGameM);
            }
            if (KeyManager.s && correct)
            {
                //debe ser cargado del xml
                //Primero se crea los jugadores del minigame
                List<Person> persons = new List<Person>();
                persons.Add(this);
                //preguntas
                List<String> messages = new List<String>();
                messages.Add("Capital de Rumania?");
                messages.Add("Presidente de Ecuador?");
                messages.Add("Primer elemento de la, tabla periodica?");
                messages.Add("Descubridor del electrón?");
                //respuestas
                List<String[]> answers = new List<String[]>();
                String[] ans1 = { "Lima", "Kajaskitan", "Correcto" };
                answers.Add(ans1);
                String[] ans2 = { "Humala", "Niño Nieto", "Diego Bustamante xD" };
                answers.Add(ans2);
                String[] ans3 = { "H", "N", "Br" };
                answers.Add(ans3);
                String[] ans4 = { "Rutterford", "Einstein", "Fischer" };
                answers.Add(ans4);
                //repuestas correctas
                List<int> correct1 = new List<int>();
                correct1.Add(1);
                correct1.Add(2);
                correct1.Add(3);
                correct1.Add(1);
                //puntos
                List<int> points = new List<int>();
                points.Add(1);
                points.Add(5);
                points.Add(1);
                points.Add(5);

                MiniGame mini = new MiniGame(eng, persons, messages, answers, correct1, points);


                eng.getSM().add(mini);
            }
            if (KeyManager.enter)
            {
                //System.out.println("Solo se presiona enter");
                //Cuando tu mismo vuelves a presionar enter se para la secuencia
            }

            //esta linea que viene siempre ha estado
            if (s == 3) s = 0;

        }

        public void SetGame(Game gam)
        {
            this.eng = gam;
        }
        public void SetLC(Layer layer)
        {
            this.LC = layer;
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
            Console.WriteLine("Pixel X: "+getPositionX()+", Pixel Y:"+getPositionY());        
       Console.WriteLine("Title X: "+getT(getPositionX())+", Title Y: "+getT(getPositionY()));
       //Console.WriteLine("Aux: " + auxR);
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
