using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace rpgGame
{
    class Game 
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

        public Game(Form form, int w, int h, String title)
        {
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
            
            
            //playerParty = new Player(new Point(80, 80), 1);
            LocalMap localMap = new LocalMap(gameForm/*, playerParty*/);
            //playerParty.agregarWM(localMap);//esto va dentrode worldmap
            // crear el state machine
            stateMachine = new StateMachine();
            stateMachine.AddState(localMap);
            
             //arreglar el nombre
            //Draw();
            
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
			
			if(timer >= 1000000000){
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
            playerParty.Draw(this.device);
            //monster.Draw(device);
            worldMapSpritePb.Image = imageDevice;

        }

    }

}
