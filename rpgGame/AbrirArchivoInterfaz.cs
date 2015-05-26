using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.IO;

namespace rpgGame
{
    class AbrirArchivoInterfaz : State
    {
        private int delayEnter = 7;
        private int genero;
        protected string[] archivos;
        protected List<GButton> buttons;
        private Selector sel;
        private  int space=100;
        private String dialogo1 = "Selecciona la partida a cargar";
        private String nombre = " ";
        private Font fntT;
        private Bitmap background;
        private Bitmap back2;
        private Game eng;
        private int x=275;    
        private int y=350;
        private int  widthB=250; //buttton width
        private int  heightB=30; //button height
        public AbrirArchivoInterfaz(Game eng){
        //aca se debe cargar el menu inicial
        //carga de botones
            archivos = new string[100];
            archivos = Directory.GetFiles("estados guardados\\", "*.bin");
            buttons=new List<GButton>();        
        //fntT =new Font("Comic Sans MS",Font.BOLD,fontSizeT);
            fntT = new Font(FontFamily.Families[5], 40);
            sel=new Selector(x - widthB +100,y,widthB-100,heightB,space,3);
            for (int i = 0; i < archivos.Length;i++ )
                buttons.Add(new GButton(archivos[i], x, y+60*i, widthB, heightB + 50));
            //buttons.Add(new GButton(archivos[1], x, y+100, widthB, heightB+50));
            //buttons.Add(new GButton(archivos[2], x, y + 200, widthB, heightB + 50));
            this.eng=eng;
            background=new Bitmap("zoofinal.jpg");
            back2 = new Bitmap("fondoestrelladoamarillo.jpg");
        }

        public override void Draw(Graphics dev)
        {
            //dev.Clear(Color.White);
            dev.DrawImage(background, 0, 0, 800, 700);
            dev.DrawImage(back2, 200, 50, 400, 500);
            //eng.GameForm.Opacity = 0.1;
            Font fnt0 = new Font(FontFamily.Families[52], 30);
            dev.DrawString(dialogo1, fnt0, new SolidBrush(Color.Brown), new Point(220,100));
            dev.DrawString(nombre, fnt0, new SolidBrush(Color.Green), new Point(250, 150));
            fnt0 = new Font(FontFamily.Families[52], 20);
            for (int i = 0; i < buttons.Count; i++)
            {
                buttons[i].render(dev);
            }
            sel.render(dev);
        }

        public override void Tick()
        {
            if (KeyManager.down)
                sel.down();
            if (KeyManager.up)
                sel.up();
            if (KeyManager.left)
                sel.left();
            if (KeyManager.right)
                sel.right();
            
        }

        public override void saveToXml(System.IO.Stream stream, System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf)
        {
            throw new NotImplementedException();
        }

        public override void loadFromXml(System.IO.Stream stream, System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf)
        {
            throw new NotImplementedException();
        }

        public override bool ordenPop()
        {
            string name = "";
            if (KeyManager.enter)
            {
                if (delayEnter == 0)
                {
                    name = archivos[sel.getOpt() - 1];
                    eng.loadStateToBin(name);
                    /*if (sel.getOpt() == 1) genero = 0;
                    if (sel.getOpt() == 2) genero = 1;
                    if(sel.getOpt()==3){
                        DialogoDatos dd = (DialogoDatos)eng.getSM().PopState();
                        LocalMap lm = (LocalMap)eng.getSM().PopState();
                        lm.Player.Name = nombre;
                        lm.Player.Gender = genero;
                        eng.getSM().AddState(lm);
                        eng.getSM().AddState(dd);
                        return true;
                 
                    }*/
                    delayEnter = 7;
                    return true;
                }
                else delayEnter--;
                
                
            }
            return false;
        }
    }
}
