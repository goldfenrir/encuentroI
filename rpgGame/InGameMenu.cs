using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace rpgGame
{
    class InGameMenu : State
    {
        //protected Stack<SubMenu> subMenus;
        
        protected List<String> options;
        private Selector sel;
        private List<GButton> buttons;
        private int space=100;
        private String title="Nido Nuevo, Amigos Nuevos!";
        private Font fntT;
        private int fontSizeT=40;
        private Bitmap background;
        private Game eng;
        private int x=275;    
        private int y=250;
        private int  widthB=250; //buttton width
        private int  heightB=70;

        public InGameMenu(Game eng)
        {
            buttons = new List<GButton>();
            options = new List<String>();
            fntT = new Font(FontFamily.Families[5], fontSizeT);
            //fntT = new Font("Comic Sans MS", Font.BOLD, fontSizeT);
            options.Add("SAVE");
            options.Add("SALIR");
            sel = new Selector(x - widthB, y, widthB, heightB, space, 2);
            buttons.Add(new GButton(options[0], x, y, widthB, heightB));
            buttons.Add(new GButton(options[1], x, y + space, widthB, heightB));
            this.eng = eng;
            background = new Bitmap("zoo2.jpg");
           // background = ImageLoader.loadImage("/img/bgF.jpg");
        }

        public override void loadFromXml(System.IO.Stream stream, System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf)
        {
            throw new NotImplementedException();
        }
        public override void saveToXml(System.IO.Stream stream, System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf)
        {
            throw new NotImplementedException();
        }

        public override bool ordenPop(){
        //arreglar
        if (KeyManager.enter){
            if (sel.getOpt()==1){
                eng.saveStateToBin();
                Console.WriteLine("1");
                eng.getSM().PopState();

            }
            if (sel.getOpt()==2){
                Console.WriteLine("2");
                eng.getSM().PopState();
            }
            
        }/*
        if (KeyManager.q){
            System.exit(1);
        }*/
        return false;
    }
        public override void Draw(Graphics dv)
        {
            dv.DrawImage(background, 0, 0, 800, 700);
            
            //g.drawImage(background, 0, 0, 800, 700, null);
            for (int i = 0; i < buttons.Count; i++)
            {
                buttons[i].render(dv);
                //buttons[i].BringToFront();
            }
            sel.render(dv);   

        }

        public override void Tick()
        {
            if (KeyManager.down)
            {
                sel.down();
            }
            if (KeyManager.up)
            {
                sel.up();
            }
        }
        public void update()
        {

        }
        public void onEnter()
        {

        }
        public void onExit()
        {

        }

        /**
         * @return the posY
         */


        /**
         * @param posY the posY to set
         */

    }
}
