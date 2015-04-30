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
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Schema;

namespace rpgGame
{
    [Serializable()]
    class Map : ISerializable, IXmlSerializable
    {
        private int id;
        private List<Layer> layers = new List<Layer>();
        private int width, height;
        private int spawnX, spawnY;
        private String[] paths;
        private int numLayers;
        //private String[] dirImg;

        public int NumLayers
        {
            get { return numLayers; }
            set { numLayers = value; }
        }
        public String[] Paths
        {
            get { return paths; }
            set { paths = value; }
        }
        private String[] dirImg;

        public String[] DirImg
        {
            get { return dirImg; }
            set { dirImg = value; }
        }

        public Map() { }
        public XmlSchema GetSchema()
        {
            return null;
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteStartElement("MapId");
            writer.WriteValue(id);
            writer.WriteEndElement();
            writer.WriteStartElement("Number of Layers");
            writer.WriteValue(layers.Count);
            writer.WriteEndElement();
            writer.WriteStartElement("Source");
            for (int i = 0; i < layers.Count; i++)
            {
                writer.WriteStartElement("Path");
                writer.WriteValue(paths[i]);
                writer.WriteEndElement();
                writer.WriteStartElement("Img");
                writer.WriteValue(dirImg[i]);
                writer.WriteEndElement();
                
            }
            writer.WriteEndElement();
        }

        public void ReadXml(XmlReader reader)
        {
        }

        public Map(SerializationInfo info, StreamingContext ctxt)
        {
            //layers = (List<Layer>)info.GetValue("MapLayer", typeof(List<Layer>));
            width = (int)info.GetValue("MapWidth", typeof(int));
            height = (int)info.GetValue("MapHeight", typeof(int));
            spawnX = (int)info.GetValue("MapSpawnX", typeof(int));
            spawnY = (int)info.GetValue("MapSpawnY", typeof(int));
            numLayers = (int)info.GetValue("MapNumLayers", typeof(int));
            paths = (String[])info.GetValue("MapPaths", typeof(String[]));
            dirImg = (String[])info.GetValue("MapDirImg", typeof(String[]));

        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            //info.AddValue("MapLayer", layers);
            info.AddValue("MapWidth", width);
            info.AddValue("MapHeight", height);
            info.AddValue("MapSpawnX", spawnX);
            info.AddValue("MapSpawnY", spawnY);
            info.AddValue("MapNumLayers", numLayers);
            info.AddValue("MapPaths", paths);
            info.AddValue("MapDirImg", dirImg);
        }

        public Map(Game eng, int cantLayer, String[] paths, String[] dirImg)
        {
            this.paths = paths;
            this.dirImg = dirImg;
            this.numLayers = cantLayer;
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
