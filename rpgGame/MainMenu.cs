using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace rpgGame
{
    class MainMenu : State
    {
        protected List<String> options;
        protected List<GButton> buttons;
        private Selector sel;
        private  int space=100;
        private String title="Un Encuentro Inesperado";
        private Font fntT;
        private  int fontSizeT=40;
        private Bitmap background;
        private Game eng;
        private int x=275;    
        private int y=250;
        private int  widthB=250; //buttton width
        private int  heightB=70; //button height

        private int selectY=250;


        public MainMenu(Game eng){
        //aca se debe cargar el menu inicial
        //carga de botones
        buttons=new List<GButton>();        
        options=new List<String>();
        //fntT =new Font("Comic Sans MS",Font.BOLD,fontSizeT);
        fntT = new Font(FontFamily.Families[5], fontSizeT);
            options.Add("Nuevo Juego");        
        options.Add("Cargar Juego");
        options.Add("HELP");
        options.Add("SALIR");
        sel=new Selector(x-widthB,y,widthB,heightB,space,4);
        buttons.Add(new GButton(options[0],x,y,widthB,heightB));
        buttons.Add(new GButton(options[1],x,y+space,widthB,heightB));
        buttons.Add(new GButton(options[2],x,y+2*space,widthB,heightB));
        buttons.Add(new GButton(options[3],x,y+3*space,widthB,heightB));
       this.eng=eng;
       background=new Bitmap("zoofinal.jpg");
    }
    public override void Draw(Graphics g){
        //background
        
        g.DrawImage(background,0,0,800,700);
        //titulo
//        g.setFont(fntT);
//        g.setColor(Color.black);
//        int cen=(int)(800-title.length()*((int)(fontSizeT)))/(2);
//        g.drawString(title,x+cen,y-100);
        //buttons
        for (int i=0;i<buttons.Count;i++){
            buttons[i].render(g);
        }
        sel.render(g);
        //Console.WriteLine("termina el draw de main menu .___.");
    }
    public override bool ordenPop(){
        //arreglar
        if (KeyManager.enter)
        {
            if (sel.getOpt() == 1)
            {
                FormDatos dataPlayer = new FormDatos();
                dataPlayer.Show();
            }

            if (sel.getOpt() == 2)
            {


                //                loadGame lgDialog = new loadGame(new java.awt.Frame());
                //                lgDialog.addWindowListener(new java.awt.event.WindowAdapter() {
                //                    public void windowClosing(java.awt.event.WindowEvent e) {
                //                        System.exit(0); //quitar elboton de cerrar
                //                    }
                //                });
                //                lgDialog.setVisible(true);
                eng.getSM().PopState();
                eng.loadStateToBin();

                

            }
        }
       /*
        if (eng.getKeyManager().q){
            System.exit(1);
        }*/
        return false;
    }
    public override void Tick(){
        //Console.WriteLine("llega al tick de main menu? :c");
        if (KeyManager.down){
            sel.down();
            Console.WriteLine("se presionó abajo");
        }
        if(KeyManager.up){
            sel.up();
        }
    }
        public override void loadFromXml(System.IO.Stream stream, System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf)
        {
            throw new NotImplementedException();
        }
        /*public override void Draw(Graphics dv)
        {

        }*/
        public void update()
        {

        }

        public override void saveToXml(System.IO.Stream stream, System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf)
        {
            throw new NotImplementedException();
        }
        public void onEnter()
        {

        }
        public void onExit()
        {

        }


    }
}
