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
        private static bool[] keysR = new bool[256];
        public static bool up, down, left, right, menu, enter;
        public static bool enterR, i, iR, z, zR,s,q,m;

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
            menu = keys[(int)Keys.M];
            enter = keys[(int)Keys.Space];
            enterR = keysR[(int)Keys.Enter];
            q = keys[(int)Keys.Q];
            m = keys[(int)Keys.M];
            i = keys[(int)Keys.I];
            iR = keysR[(int)Keys.I];
            z = keys[(int)Keys.Z];
            zR = keysR[(int)Keys.Z];
            s = keys[(int)Keys.S];
        }
        public static void HandleKeyPress(KeyEventArgs e)
        {
            keys[e.KeyValue] = true;
            keysR[e.KeyValue] = false;
                    
        }

        public static void HandleKeyUp(KeyEventArgs e)
        {
            keys[e.KeyValue] = false;
            keysR[e.KeyValue] = true;
        }
    }
}
