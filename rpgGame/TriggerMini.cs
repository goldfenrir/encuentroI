using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpgGame
{
    public class TriggerMini: Trigger
    {
        private MainMenu menu;
    private int changeTo;
    
    public TriggerMini(int x,int y,int changeTo){
        this.x=x;
        this.y=y;
        this.changeTo=changeTo;
        this.active=true;
      
        
    }

  
 
    public override void execTrigger(LocalMap aThis) {
        
        if (this.active){
            //aThis.setChange(true);
            Console.WriteLine("Si");  
            aThis.getPlayer().correct=true;
            //aThis.getPlayer().positionX=800;
            //aThis.getPlayer().positionY=800;
          //  aThis.getEng().getSM().add(mini);
           
        }
        
    }

    /**
     * @return the pX


    /**
     * @return the changeTo
     */
    public int getChangeTo() {
        return changeTo;
    }

    /**
     * @param changeTo the changeTo to set
     */
    public void setChangeTo(int changeTo) {
        this.changeTo = changeTo;
    }
    }
}
