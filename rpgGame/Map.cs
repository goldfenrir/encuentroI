using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace rpgGame
{
    class Map
    {
        private List<Layer> layers = new List<Layer>();
        private int width, height;
        private int spawnX, spawnY;

        public Map(Game eng, int cantLayer, String[] paths, String[] dirImg)
        {
            for (int i = 0; i < cantLayer; i++)
            {
                layers.Add(new Layer(paths[i], dirImg[i]));
            }

        }
        public void tick()
        {


        }

        public Layer getLC()
        {
            return layers[layers.Count - 1];
            //layers.
            //return layers.Get(layers.size() - 1);
        }
        public void render(Graphics g)
        {
            for (int i = 0; i < layers.Count; i++)
            {
                layers[i].render(g);
            }
        }
    }
}
