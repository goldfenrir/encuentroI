using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.Xml;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.Xml.Schema;

namespace rpgGame
{
    
    public class Game :  IXmlSerializable
    {
        private String title;
        private int width, height;
        private bool running;
        public Thread newThread;
        private Form1 gameForm;

        public Form1 GameForm
        {
            get { return gameForm; }
            set { gameForm = value; }
        }
        private PictureBox worldMapSpritePb;
        private Graphics device;

        public Graphics Device
        {
            get { return device; }
            set { device = value; }
        }
        private Image imageDevice;
        private StateMachine stateMachine;
        private LocalMap LMS;
        //layer de collision
        private Layer lc;
        //Actual map
        private int currentMap = 0;

        public Game() { }
        public XmlSchema GetSchema()
        {
            return null;
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteStartElement("title");
            writer.WriteValue(title);
            writer.WriteEndElement();
            writer.WriteStartElement("width");
            writer.WriteValue(width);
            writer.WriteEndElement();
            writer.WriteStartElement("height");
            writer.WriteValue(height);
            writer.WriteEndElement();
            //los mapas
            XmlSerializer serializer = new XmlSerializer(typeof(LocalMap));
            LocalMap lm = LMS;
            serializer.Serialize(writer, lm);

        }

        public void ReadXml(XmlReader reader)
        {
            reader.ReadStartElement();
            title = reader.ReadElementContentAsString();
            width = reader.ReadElementContentAsInt();
            height = reader.ReadElementContentAsInt();
            XmlSerializer serializer = new XmlSerializer(typeof(LocalMap));
            LocalMap lm = (LocalMap)serializer.Deserialize(reader);
            lm.Player.SetGame(this);
            lm.Player.SetLC(lm.getMaps()[0].getLC());
            stateMachine = new StateMachine();
            stateMachine.AddState(lm);
            LMS = lm;
        }
        
        public Game(Form1 form, int w, int h, String title)
        {
            /*
            this.title = title;
            this.width = w;
            this.height = h;
            gameForm = form;
            // se inicializa el form
            gameForm.Width = width;
            gameForm.Height = height;
            gameForm.Text = title;
            gameForm.BackColor = Color.White;

            imageDevice = new Bitmap(gameForm.Width, gameForm.Height);
            device = Graphics.FromImage(imageDevice);

            //se inicializa el bg
            worldMapSpritePb = new PictureBox();
            worldMapSpritePb.Width = gameForm.Width;
            worldMapSpritePb.Height = gameForm.Height;
            worldMapSpritePb.BackColor = Color.Green;
            worldMapSpritePb.Parent = gameForm;
            String[] paths = new String[2];
            paths[0] = "l1.txt";

            paths[1] = "lc1.txt";
            String[] dirImg = new String[2];
            dirImg[0] = "l1.png";
            dirImg[1] = "lc1.png";
            Map map = new Map(this, 2, paths, dirImg);//eng, cant layer, paths2, iamgeleyer
            lc = map.getLC();
            LMS = new LocalMap(gameForm, this);
            LMS.getMaps().Add(map);
            stateMachine = new StateMachine();
            stateMachine.AddState(LMS);
            saveToXml();*/
            loadFromXml(form);
            //LMS.getMaps()[LMS.getMapAct()].GetTriggers().Add(new TriggerMini(5, 5, 1));
            saveToXml();
            
            //Draw();
            //saveStateToBin();
            
        }

        public void saveToXml()
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            XmlWriter writer = XmlWriter.Create("GameInit.xml", settings);
            XmlSerializer serializer = new XmlSerializer(typeof(Game));
            serializer.Serialize(writer, this);
            writer.Close();
        }

        public void loadFromXml(Form1 form)
        {
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreWhitespace = true;
            XmlReader writer = XmlReader.Create("GameInit.xml", settings);
            XmlSerializer serializer = new XmlSerializer(typeof(Game));
            Game gtemp = (Game)serializer.Deserialize(writer);
            title = gtemp.title;
            width = gtemp.width;
            height = gtemp.height;
            //currentMap = gameTemp.currentMap;

            gameForm = form;
            // se inicializa el form
            gameForm.Width = width;
            gameForm.Height = height;
            gameForm.Text = title;
            gameForm.BackColor = Color.White;
            this.LMS = gtemp.LMS;
            imageDevice = new Bitmap(gameForm.Width, gameForm.Height);
            device = Graphics.FromImage(imageDevice);

            //se inicializa el bg
            worldMapSpritePb = new PictureBox();
            worldMapSpritePb.Width = gameForm.Width;
            worldMapSpritePb.Height = gameForm.Height;
            worldMapSpritePb.BackColor = Color.Green;
            worldMapSpritePb.Parent = gameForm;
            this.stateMachine = gtemp.stateMachine;
            writer.Close();
            MainMenu menu = new MainMenu(this);
            stateMachine.AddState(menu);
        }

        

        public void Start()
        {
            //if (running)
              //  return;
            running = true;
            newThread = new Thread(new ThreadStart(Run));
            newThread.IsBackground = false;
            newThread.Start();// llama al run()
        }

        public void Run()
        {
            //DateTimeOffset date = new DateTimeOffset();
            int fps = 60;
		    double timePerTick = 1000000000 / fps;
		    double delta = 0;
		    long now;
		    long lastTime = DateTime.Now.ToFileTime()*100;
		    long timer = 0;
		    int ticks = 0;
		
		while(running){
            now = DateTime.Now.ToFileTime()*100;
			delta += (now - lastTime) / timePerTick;
			timer += now - lastTime;
			lastTime = now;
			if(delta >= 1){
				Tick();
				//render();
                Draw();
				ticks++;
				delta--;
			}
			
			if(timer >= 1300000000){
				Console.WriteLine("Ticks and Frames: " + ticks);
				ticks = 0;
				timer = 0;
			}
		}
		
		//stop();
        }

        public void Tick()
        {
            KeyManager.Tick();
            if (stateMachine.PeekState().ordenPop())
                stateMachine.PopState();
            if (stateMachine.getState().Count!=0)
            {
                stateMachine.PeekState().Tick();
            }
            //stateMachine.PeekState().Tick();
        }

        void Draw()
        {
            try
            {
                if (gameForm.InvokeRequired)
                {
                    MethodInvoker method = new MethodInvoker(Draw);
                    gameForm.Invoke(method);
                    return;

                }
                // arreglar, poner como miembro las variables reutilizables
                stateMachine.PeekState().Draw(this.device); //statemch.top.render
                worldMapSpritePb.Image = imageDevice;
                //Thread.Sleep(15);
            }
            catch (System.ObjectDisposedException e)
            {
                Console.WriteLine("gg");
                newThread.Abort();
            }

        }

        public int getCurrentMap()
        {
            return currentMap;
        }

        public Layer getLc()
        {
            return this.lc;
        }

        public void saveStateToBin(string arch)
        {
            string namefile = "estados guardados\\" + arch  + ".bin";
            Stream stream = File.Open(namefile, FileMode.Create);
            BinaryFormatter bformatter = new BinaryFormatter();
            //stateMachine.PopState();
            //InGameMenu ing = (InGameMenu)stateMachine.PopState();
            
            //LocalMap lm = (LocalMap)stateMachine.PopState();
            bformatter.Serialize(stream, LMS);
            bformatter.Serialize(stream, LMS.Player);
            //stateMachine.AddState(lm);
            //stateMachine.AddState(ing);
            stream.Close();
            
        }

        public bool loadStateToBin()
        {
            //string namefile = "savedState" + num.ToString() + ".bin";
            Stream stream = File.Open("savedState.bin", FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();

            //LocalMap lm = (LocalMap)stateMachine.PopState();
            try
            {
                LocalMap lmtemp = (LocalMap)bf.Deserialize(stream);
                LMS.MapAct = lmtemp.MapAct;
            }
            catch (System.Reflection.TargetInvocationException e)
            {
                Console.WriteLine("gg no pudo deserializar localmpa");
            }
             
            Player playerTemp = (Player)bf.Deserialize(stream);
            if (playerTemp != null) {
                LMS.Player.Name = "hola";
                Console.WriteLine(playerTemp.Name);
                LMS.Player.Name = playerTemp.Name;
            LMS.Player.Gender = playerTemp.Gender;
            LMS.Player.Id = playerTemp.Id;
            LMS.Player.Level = playerTemp.Level;
            LMS.Player.NumberOfClues = playerTemp.NumberOfClues;
            LMS.Player.PositionX = playerTemp.PositionX;
            LMS.Player.PositionY = playerTemp.PositionY;
            LMS.Player.S = playerTemp.S;
            LMS.Player.CloseNess = playerTemp.CloseNess;
            LMS.Player.XMove = playerTemp.XMove;
            LMS.Player.YMove = playerTemp.YMove;
            LMS.Player.Dir = playerTemp.Dir;
            LMS.Player.Clues = playerTemp.Clues;
            LMS.Player.Inventory = playerTemp.Inventory;
                }
            else
            {
                Console.WriteLine("gg el player es nulo");
            }
            //LMS.Player = playerTemp;
            //LMS = lm;
            //stateMachine.PopState();//popea el mainmenu
            //stateMachine.PopState();//popea el ex lms
            //stateMachine.AddState(LMS);
            stream.Close();
            return true;
        }

        public StateMachine getSM()
        {
            return stateMachine;
        }
      

    }

}
