using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpgGame
{
    public class TriggerChangeMap : Trigger
    {
    private int pX;
    private int pY;
    private int changeTo;
    public TriggerChangeMap(int x,int y,int changeTo,int pX,int pY){
        this.x=x;
        this.y=y;
        this.changeTo=changeTo;
        this.pX=pX;
        this.pY=pY;
        this.active=true;
    }

  
    public override void execTrigger(LocalMap aThis) {
        
        if (this.active){
            aThis.setChange(true);
            aThis.setMapAct(getChangeTo());
            aThis.getPlayer().PositionX=getpX();
            aThis.getPlayer().PositionY=getpY();    
        }
        
    }

    /**
     * @return the pX
     */
    public int getpX() {
        return pX;
    }

    /**
     * @param pX the pX to set
     */
    public void setpX(int pX) {
        this.pX = pX;
    }

    /**
     * @return the pY
     */
    public int getpY() {
        return pY;
    }

    /**
     * @param pY the pY to set
     */
    public void setpY(int pY) {
        this.pY = pY;
    }

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
