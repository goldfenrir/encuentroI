using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace rpgGame
{
    class MiniGame : State
    {
        private int auxI = 0;
        private int aux = 0;
        private List<String> messages = new List<String>();
        protected List<String> options;
        protected List<GButton> buttons;
        private Selector sel;
        private static int spaceY = 100;
        private static int spaceX = 300;
        private String title = "Nido Nuevo, Amigos Nuevos!";
        private Font fntT;
        private static int fontSizeT = 40;
        private Bitmap background;
        private Game eng;
        private static int x = 120;
        private static int y = 500;
        private static int widthB = 250; //buttton width
        private static int heightB = 70; //button height
        private Font fnt0;
        private Font fnt1;
        private int selectY = y;
        private int turno = 0;
        private List<Player> persons;
        private List<int> total;
        private List<int> points;
        private List<String[]> answers;
        private List<int> correct;
        private int cont = 0;
        private bool force = false;
        private String resultado = null;

        public MiniGame(Game eng, List<Player> persons, List<String> messages, List<String[]> answers, List<int> correct, List<int> points)
        {
            this.answers = answers;
            this.messages = messages;
            this.points = points;
            this.persons = persons;
            total = new List<int>();

            for (int i = 0; i < persons.Count; i++)
            {
                total.Add(0);
            }
            this.correct = correct;
            fnt0 = new Font(FontFamily.Families[10],50);
            fnt0 = new Font(fnt0, FontStyle.Bold);
            fnt1 = new Font("Arial",  50);
            fnt1 = new Font(fnt1, FontStyle.Bold);
            buttons = new List<GButton>();
            options = new List<String>();
            fntT = new Font("Comic Sans MS", fontSizeT);
            fntT = new Font(fntT, FontStyle.Bold);
            options.Add("A");
            options.Add("B");
            options.Add("C");
            options.Add("SALIR");
            sel = new Selector(x - widthB, y, widthB, heightB, spaceY, spaceX, 2, 2);
            buttons.Add(new GButton(options[0], x, y, widthB, heightB));
            buttons.Add(new GButton(options[1], x, y + spaceY, widthB, heightB));
            buttons.Add(new GButton(options[2], x + spaceX, y, widthB, heightB));
            buttons.Add(new GButton(options[3], x + spaceX, y + spaceY, widthB, heightB));

            this.eng = eng;
            background = new Bitmap("bg_battle.png");

        }

        public override bool ordenPop(){
        //arreglar
        
        
        if (KeyManager.enter){
            
//            if (sel.getOpt()==2 && sel.getOptX()==2 ){
//                System.out.println("2");
//                return true; //eng.getSM().pop();
//            }
            if (sel.getOpt()==2 && sel.getOptX()==2 ){
                Console.WriteLine("2");
                return true; //eng.getSM().pop();
            }
            
        }
        if (KeyManager.q){
            
            //System.exit(1);
        }
       
        return (false || force);
    }

        public override void Draw(Graphics g){
        
        g.DrawImage(background,0,0,800,700);
        for (int i=0;i<buttons.Count;i++){
            buttons[i].render(g);
          
        }
        sel.render(g); 
//        g.drawRect(0, 0, 700, 100);
        //g.setColor(Color.WHITE);
        //g.fillRect(0, 0, 800, 100);
        //g.setColor(Color.BLACK);
        //g.fillRect(0, 101, 800, 5);
        
        //g.setColor(Color.BLUE);
        //g.setFont(fnt0);
        //lineas
        if (messages.Count>0 && cont<messages.Count){
            Console.WriteLine(messages[cont]);
            
            
            
            String[] auxS=new String[10];
            auxS=messages[cont].Split(',');
            for (int i=0;i<auxS.Length;i++){
                g.DrawString(auxS[i], fnt0, new SolidBrush(Color.Blue), 100, 50 + i * (35));  
            }
           // g.drawString(messages.get(cont),100,50);   
           // 
        }
       if (answers.Count>0 && cont<answers.Count){
           //g.DrawString()
           //g.setColor(Color.BLACK);
           int spa=50;
           String[] letters={"A","B","C"};
           for (int i =0; i<answers[cont].Length;i++){
               g.DrawString(letters[i]
                       + ". " + answers[cont][i], fnt0, new SolidBrush(Color.Black), new Point(150, 110 + spa * (i + 1)));
           }            
           
       }  
       if (resultado!=null){
           g.DrawString(resultado, fnt0, new SolidBrush(Color.Blue), new Point(500, 300));
       }
    }
        private void nextTurn()
        {
            if (turno < persons.Count - 1)
                turno++;
            else
                turno = 0;
        }
        public override void Tick()
        {

            if (KeyManager.enter)
            {
                if (aux == 0) aux++;
            }
            if (KeyManager.enterR)
            {
                if (aux == 1) aux++;
            }

            if (aux == 2 && cont < messages.Count && auxI == 0)
            {
                KeyManager.enterR = false;
                KeyManager.enter = false;
                if (sel.getOpt() == 1 && sel.getOptX() == 1)
                { //A

                    if (correct[cont] == 1)
                    {
                        int tot = getTotal()[turno];
                        tot += points[cont];
                        getTotal()[turno] = tot;

                        resultado = "Correcto:" + getTotal()[turno];
                    }
                    else
                    {
                        resultado = "Mal:" + getTotal()[turno];
                    }

                }
                else if (sel.getOpt() == 2 && sel.getOptX() == 1)
                { //B
                    if (correct[cont] == 2)
                    {
                        int tot = getTotal()[turno];
                        tot += points[cont];
                        getTotal()[turno] = tot;
                        resultado = "Correcto:" + getTotal()[turno];
                    }
                    else
                    {
                        resultado = "Mal:" + getTotal()[turno];
                    }

                } if (sel.getOpt() == 1 && sel.getOptX() == 2)
                {//C

                    if (correct[cont] == 3)
                    {
                        int tot = getTotal()[turno];
                        tot += points[cont];
                        getTotal()[turno] = tot;
                        resultado = "Correcto:" + getTotal()[turno];
                    }
                    else
                    {
                        resultado = "Mal:" + getTotal()[turno];
                    }

                }
                aux = 0;

                nextTurn();
                auxI = 1;

            }
            else if (cont == messages.Count)
            {
                force = true;
            }
            else if (aux == 2 && auxI == 1)
            {
                auxI = 0;
                aux = 0;
                resultado = null;
                cont++;
            }

            if (KeyManager.down)
            {
                sel.down();
                // sel.print();
            }
            if (KeyManager.up)
            {
                sel.up();
                // sel.print();
            }
            if (KeyManager.left)
            {
                sel.left();
                // sel.print();
            }
            if (KeyManager.right)
            {
                sel.right();
                // sel.print();
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
         * @return the total
         */
        public List<int> getTotal()
        {
            return total;
        }

        /**
         * @param total the total to set
         */
        public void setTotal(List<int> total)
        {
            this.total = total;
        }

        public override void loadFromXml(System.IO.Stream stream, System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf)
        {
            throw new NotImplementedException();
        }

        public override void saveToXml(System.IO.Stream stream, System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf)
        {
            throw new NotImplementedException();
        }
    }
}
