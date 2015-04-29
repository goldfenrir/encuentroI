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

namespace rpgGame
{
    [Serializable()]
    class Game : ISerializable
    {
        private String title;
        private int width, height;
        private bool running;
        private Thread newThread;
        private Form gameForm;
        //public LocalMap worldMap;
        //private Player playerParty;
        private PictureBox worldMapSpritePb;
        //private Friend monster;
        private Graphics device;
        private Image imageDevice;
        private StateMachine stateMachine;
        //layer de collision
        private Layer lc;
        //Actual map
        private int currentMap = 0;

        public Game(SerializationInfo info, StreamingContext ctxt)
        {
            title = (String)info.GetValue("GameTitle", typeof(String));
            width = (int)info.GetValue("GameWidth", typeof(int));
            height = (int)info.GetValue("GameHeight", typeof(int));
            //lc = (int)info.GetValue("PlayerHeight", typeof(int));
            currentMap = (int)info.GetValue("GameCurrMap", typeof(int));
            stateMachine = (StateMachine)info.GetValue("GameStateMachine", typeof(StateMachine));

        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("GameTitle", title);
            info.AddValue("GameWidth", width);
            info.AddValue("GameHeight", height);
            info.AddValue("GameCurrMap", currentMap);
            info.AddValue("GameStateMachine", stateMachine);
        }
        public Game(Form form, int w, int h, String title)
        {
            /*this.title = title;
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
            LocalMap LMS = new LocalMap(gameForm, this);
            LMS.getMaps().Add(map);
            stateMachine = new StateMachine();
            stateMachine.AddState(LMS);
            saveToXml();*/
            loadFromXml(form);
            //Draw();
            
        }

        public void saveToXml()
        {
            Stream stream = File.Open("initialState.xml", FileMode.Create);
            BinaryFormatter bformatter = new BinaryFormatter();
            bformatter.Serialize(stream, this);
            stream.Close();
        }

        public void loadFromXml(Form form)
        {
            Stream stream = File.Open("initialState.xml", FileMode.OpenOrCreate);
            BinaryFormatter bformatter = new BinaryFormatter();
            Game gameTemp = (Game)bformatter.Deserialize(stream);
            title = gameTemp.title;
            width = gameTemp.width;
            height = gameTemp.height;
            currentMap = gameTemp.currentMap;

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
            LocalMap lmtemp = (LocalMap)gameTemp.stateMachine.PeekState();
            //LocalMap LMS = new LocalMap(gameForm, this);
            List<Map> mapList = new List<Map>();
            Console.WriteLine("cantidad de mapas : " + lmtemp.getMaps().Count);
            for (int i = 0; i < lmtemp.getMaps().Count; i++ )
            {
                Map m = lmtemp.getMaps()[i];
                Console.WriteLine("cantidad de layers : " + m.NumLayers);
                string[] paths = m.Paths;
                string[] dirImg = m.DirImg;
                Map map = new Map(this, m.NumLayers, paths, dirImg);//eng, cant layer, paths2, iamgeleyer
                //this.lc = map.getLC();
                mapList.Add(map);
            }
            this.lc = mapList[currentMap].getLC();
            LocalMap LMS = new LocalMap(gameForm, this);
            foreach (Map m in mapList)
                LMS.getMaps().Add(m);
            stateMachine = new StateMachine();
            stateMachine.AddState(LMS);
            stream.Close();
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
            stateMachine.PeekState().Tick();
        }

        void Draw()
        {
                // arreglar, poner como miembro las variables reutilizables
            stateMachine.PeekState().Draw(this.device); //statemch.top.render


            //playerParty.Draw(this.device); AGREGAR ESTO EN PLAYER CUANDO LO JALA DE LOCALMAP

            //monster.Draw(device);
            worldMapSpritePb.Image = imageDevice;
            Thread.Sleep(20);

        }

        public int getCurrentMap()
        {
            return currentMap;
        }

        public Layer getLc()
        {
            return this.lc;
        }

        public void saveStateToBin()
        {
            Stream stream = File.Open("savedState.xml", FileMode.Create);
            BinaryFormatter bformatter = new BinaryFormatter();

            stateMachine.PeekState().saveToXml(stream, bformatter);
                //bformatter.Serialize(stream, p);
            stream.Close();
        }

        public void loadStateToBin()
        {
            Stream stream = File.Open("savedState.xml", FileMode.Create);
            BinaryFormatter bformatter = new BinaryFormatter();

            //stateMachine.PeekState().saveToXml(stream, bformatter);
            stateMachine.PeekState().loadFromXml(stream, bformatter);
            //bformatter.Serialize(stream, p);
            stream.Close();
          
        }
      

    }

}
