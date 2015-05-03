using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace rpgGame
{
    class DialogoDatos : State
    {
        private int delayEnter = 7;
        private int genero;
        protected List<String> options;
        protected List<GButton> buttons;
        private Selector selAbc;
        private Selector sel;
        private Selector actSelector;
        private  int space=100;
        private String dialogo1 = "cual es tu nombre?";
        private String abc1 = "a   b   c   d   e   f   g   h   i   j";
        private String abc2 = "k   l   m   n   o   p   q   r   s   t";
        private String abc3 = "u   v   w   x   y   z   <- enter";
        private String nombre = " ";
        private char letra = 'a';
        private Font fntT;
        private Bitmap background;
        private Bitmap back2;
        private Game eng;
        private int x=275;    
        private int y=350;
        private int  widthB=250; //buttton width
        private int  heightB=30; //button height
        public DialogoDatos(Game eng){
        //aca se debe cargar el menu inicial
        //carga de botones
            buttons=new List<GButton>();        
            options=new List<String>();
        //fntT =new Font("Comic Sans MS",Font.BOLD,fontSizeT);
            fntT = new Font(FontFamily.Families[5], 40);
            options.Add("Hombre");
            options.Add("Mujer");
            options.Add("Guardar");  
            sel=new Selector(x - widthB +100,y,widthB-100,heightB,space,3);
            selAbc = new Selector(210+30, 200, 50, 30, 30, 3, 2, 40, 10);
            actSelector = selAbc;
            buttons.Add(new GButton(options[0],x,y,widthB,heightB+50));
            buttons.Add(new GButton(options[1], x, y+100, widthB, heightB+50));
            buttons.Add(new GButton(options[2], x, y + 200, widthB, heightB + 50));
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
            dev.DrawString(abc1, fnt0, new SolidBrush(Color.Brown), new Point(210, 200));
            dev.DrawString(abc2, fnt0, new SolidBrush(Color.Brown), new Point(210, 230));
            dev.DrawString(abc3, fnt0, new SolidBrush(Color.Brown), new Point(210, 260));
            
            for (int i = 0; i < buttons.Count; i++)
            {
                buttons[i].render(dev);
            }
            getActiveSelector().render(dev);
        }

        public Selector getActiveSelector()
        {
            return actSelector;
        }

        public override void Tick()
        {
            if (KeyManager.down)
                getActiveSelector().down();
            if (KeyManager.up)
                getActiveSelector().up();
            if (KeyManager.left)
                getActiveSelector().left();
            if (KeyManager.right)
                getActiveSelector().right();
            
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
            if (KeyManager.enter && getActiveSelector() == selAbc)
            {
                if (delayEnter == 0)
                {
                    int num = (int)Char.GetNumericValue(letra);
                    num = 98 + num + 10 * (getActiveSelector().getOpt() - 1) + getActiveSelector().getOptX() - 1;
                    if (num < 123)
                    {
                        letra = (char)num;
                        String ele = Char.ToString(letra);
                        nombre += ele;
                        letra = 'a';
                    }
                    if (num == 123)
                        nombre = nombre.Remove(nombre.Length - 1);
                    if (num == 124)
                        actSelector = sel;
                    delayEnter = 7;
                }
                else delayEnter--;
            }

            if (KeyManager.enter && actSelector == sel)
            {
                if (sel.getOpt() == 1) genero = 0;
                if (sel.getOpt() == 2) genero = 1;
                if(sel.getOpt()==3){
                    DialogoDatos dd = (DialogoDatos)eng.getSM().PopState();
                    LocalMap lm = (LocalMap)eng.getSM().PopState();
                    lm.Player.Name = nombre;
                    lm.Player.Gender = genero;
                    eng.getSM().AddState(lm);
                    eng.getSM().AddState(dd);
                    return true;
                }

            }
            return false;
        }
    }
}
