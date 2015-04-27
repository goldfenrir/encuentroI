using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace rpgGame
{
    class SubMenu : State
    {
        private int type;
        private List<String> options = new List<String>();
        private int posY;

        public override void Draw(Graphics dv)
        {

        }

        public override void saveToXml(System.IO.Stream stream, System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf)
        {
            throw new NotImplementedException();
        }
        private void onExit()
        {

        }

        private void update()
        {

        }

        public int getType()
        {
            return type;
        }

        public void setType(int type)
        {
            this.type = type;
        }

        public List<String> getOptions()
        {
            return options;
        }

        public void setOptions(List<String> options)
        {
            this.options = options;
        }

        public int getPosY()
        {
            return posY;
        }

        public void setPosY(int posY)
        {
            this.posY = posY;
        }
    }
}
