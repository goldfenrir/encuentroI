using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace rpgGame
{
    abstract class State
    {
        public abstract void Draw(Graphics dev);
        public abstract void saveToXml(Stream stream, BinaryFormatter bf );
        public void update()
        {

        }
        public void onEnter()
        {

        }
        public void onExit()
        {

        }
        public virtual void Tick()
        {
            //def
        }
    }
}
