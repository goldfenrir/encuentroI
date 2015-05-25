using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpgGame
{
    public class Goals
    {
        private int id;
   private bool active;
   private String description;
   private int tipo; //1 para minigame
   public Goals(){
       
   }
   public Goals(int id, bool active,String desc,int tipo){
       this.id=id;
       this.active=active;
       description=desc;
       this.tipo=tipo;
   }

   
    public bool isActive() {
        return active;
    }

    public void setActive(bool active) {
        this.active = active;
    }

    
    public String getDescription() {
        return description;
    }

    
    public void setDescription(String description) {
        this.description = description;
    }

    /**
     * @return the id
     */
    public int getId() {
        return id;
    }

    /**
     * @param id the id to set
     */
    public void setId(int id) {
        this.id = id;
    }

    /**
     * @return the tipo
     */
    public int getTipo() {
        return tipo;
    }

    /**
     * @param tipo the tipo to set
     */
    public void setTipo(int tipo) {
        this.tipo = tipo;
    }
    }
}
