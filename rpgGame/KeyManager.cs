using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rpgGame
{
    class KeyManager
    {
        private static bool[] keys = new bool [256];
        public static bool up, down, left, right;

        public KeyManager()
        {
            keys = new bool[256];
        }

        public static void Tick()
        {
            up = keys[(int)Keys.Up];
            down = keys[(int)Keys.Down];
            left = keys[(int)Keys.Left];
            right = keys[(int)Keys.Right];
        }
        public static void HandleKeyPress(KeyEventArgs e)
        {
            keys[e.KeyValue] = true;
                    
        }

        public static void HandleKeyUp(KeyEventArgs e)
        {
            keys[e.KeyValue] = false;
        }
    }
}
