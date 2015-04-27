using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using System.Windows.Forms;

namespace rpgGame
{
    class WorldMap : State
    {
        protected Image background;
        private int mapAct;

        public override void saveToXml(System.IO.Stream stream, System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf)
        {
            throw new NotImplementedException();
        }
        public override void Draw(Graphics dv)
        {

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
         * @return the mapAct
         */
        public int getMapAct()
        {
            return mapAct;
        }

        /**
         * @param mapAct the mapAct to set
         */
        public void setMapAct(int mapAct)
        {
            this.mapAct = mapAct;
        }
    }
}
