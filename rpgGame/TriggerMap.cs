using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpgGame
{
    public class TriggerMap : Trigger
    {
        private int pX;
    private int pY;
    private int changeTo;
    
    public TriggerMap(int x,int y,int changeTo,int pX,int pY){
        this.x=x;
        this.y=y;
        this.changeTo=changeTo;
        this.pX=pX;
        this.pY=pY;
        this.active=true;
    }
    
    public bool goalsAchieved(LocalMap aThis){
        /*
        List<Goal> metas = aThis.getMaps()[aThis.getMapAct()].getGoals();
        //metas = aThis.getMap().getGoals();
        for(int i = 0; i<metas.size(); i++){
            //if(metas.get(i).isActive())
               // return false;
        }*/
        return true;
    }
    
  
    public override void execTrigger(LocalMap aThis) {
        //if(aThis.getPlayer().positionX )
        if (this.active){
            if(((x==1 && aThis.getPlayer().PositionX <=2) || (x==19 && aThis.getPlayer().PositionX >=749) ||
                    (y==1 && aThis.getPlayer().PositionY <= 1) || (y==17 && aThis.getPlayer().PositionY >=645)) &&
                    goalsAchieved(aThis)){
                aThis.setChange(true);
            aThis.setMapAct(getChangeTo());
            aThis.getPlayer().PositionX=getpX();
            aThis.getPlayer().PositionY=getpY();
                
               
            }
            
        }
        
    }

    /**
     * @return the pX
     */
    public int getpX() {
        //return 0;
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
        //return 0;
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
        //return 0;
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
