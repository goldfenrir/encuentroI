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
        public LocalMap worldMap;
        private Player playerParty;
        private PictureBox worldMapSpritePb;
        private Friend monster;
        public Game(Form form, int w, int h, String title)
        {
            this.title = title;
            this.width = w;
            this.height = h;
            gameForm = form;
            gameForm.Width = width;
            gameForm.Height = height;
            gameForm.Text = title;
            gameForm.BackColor = Color.White;
            
            Bitmap bmp = new Bitmap("ash_sheet.png");
            playerParty = new Player(new Point(80, 80), bmp, 1);
            worldMap = new LocalMap(gameForm, playerParty);
            playerParty.agregarWM(worldMap);
            worldMapSpritePb = new PictureBox();
            worldMapSpritePb.Width = gameForm.Width;
            worldMapSpritePb.Height = gameForm.Height;
            worldMapSpritePb.BackColor = Color.Green;
            worldMapSpritePb.Parent = gameForm;

            bmp = new Bitmap("monster.png");
            monster = new Friend(new Point (0,280),bmp,0);

            //Draw();
            
        }

        public void Start()
        {
            //if (running)
              //  return;
            running = true;
            Thread newThread = new Thread(new ThreadStart(Run));
            newThread.IsBackground = false;
            newThread.Start();
        }

        public void Run()
        {
            DateTimeOffset date = new DateTimeOffset();
            int fps = 60;
		    double timePerTick = 1000000000 / fps;
		    double delta = 0;
		    long now;
		    long lastTime = date.Ticks;
		    long timer = 0;
		    int ticks = 0;
		
		while(running){
			now = date.Ticks;
			delta += (now - lastTime) / timePerTick;
			timer += now - lastTime;
			lastTime = now;
			if(delta <= 1){
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
            worldMap.Tick();
        }

        void Draw()
        {
            Graphics device;
            Image img = new Bitmap(gameForm.Width, gameForm.Height);
            device = Graphics.FromImage(img);
            worldMap.DrawMap(device);
            playerParty.Draw(device);

            monster.Draw(device);
            worldMapSpritePb.Image = img;
        }

    }

}
