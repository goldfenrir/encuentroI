using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace rpgGame
{
    class GButton
    {
        private int quanSp=3;
    protected Bitmap[] sprite;
    private String[] paths;
    private int x,y,w,h;
    private Font fnt0;
    private String title;
    private int fontSize=40; //leer xml
     //cantidad de sprites
    public GButton(String title,int x,int y,int w,int h){
        this.title=title;
        this.x=x;
        this.y=y;
        this.w=w;
        this.h=h;
        sprite=new Bitmap[quanSp];
        paths=new String[quanSp];
        paths[0]="buttonF.png"; //leer desde xml
        paths[1]="button2.png";
        paths[2]="button1.png";
        for(int i=0;i<quanSp;i++){
            sprite[i] = new Bitmap(paths[i]);
            
        }
        
        fnt0 =new Font(FontFamily.Families[10],fontSize);
        
    }
    public void render(Graphics g){
        
        //g.setFont(fnt0);
        //g.setColor(Color.black);
        g.DrawImage(sprite[0],x,y,w,h);

        int cen=(int)(sprite[0].Width-title.Length*((int)(fontSize*0.65)))/(2);
        //g.drawString(title,x+cen,y+fontSize);
        g.DrawString(title, fnt0, new SolidBrush(Color.Black), new Point(x + cen, y+fontSize));
    }
    }
}
