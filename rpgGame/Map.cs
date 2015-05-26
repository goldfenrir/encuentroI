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
    public class Map : ISerializable, IXmlSerializable
    {
        private int id;
        private List<Layer> layers = new List<Layer>();
        private int width, height;
        private int spawnX, spawnY;
        private String[] paths;
        private int numLayers;
        private List<Trigger> triggers = new List<Trigger>();
        //private String[] dirImg;

        public int NumLayers
        {
            get { return numLayers; }
            set { numLayers = value; }
        }

        public List<Trigger> GetTriggers()
        {
            return triggers;
        }

        /**
         * @param triggers the triggers to set
         */
        public void SetTriggers(List<Trigger> triggers)
        {
            this.triggers = triggers;
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
            writer.WriteStartElement("Number_of_layers");
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
            
            writer.WriteStartElement("Triggers");
            for (int i = 0; i < triggers.Count; i++)
            {
                writer.WriteStartElement("Trigger");
                if(triggers[i] is TriggerChangeMap){
                    TriggerChangeMap trig = (TriggerChangeMap)triggers[i];
                    writer.WriteStartElement("type");
                    writer.WriteValue("TriggerChangeMap");
                    writer.WriteEndElement();
                writer.WriteStartElement("par");
                writer.WriteValue(triggers[i].getX());
                writer.WriteEndElement();
                writer.WriteStartElement("par");
                writer.WriteValue(triggers[i].getY());
                writer.WriteEndElement();
                writer.WriteStartElement("par");
                writer.WriteValue(trig.getChangeTo());
                writer.WriteEndElement();
                writer.WriteStartElement("par");
                writer.WriteValue(trig.getpX());
                writer.WriteEndElement();
                writer.WriteStartElement("par");
                writer.WriteValue(trig.getpY());
                writer.WriteEndElement();
                }

                if (triggers[i] is TriggerMap)
                {
                    TriggerMap trig = (TriggerMap)triggers[i];
                    writer.WriteStartElement("type");
                    writer.WriteValue("TriggerMap");
                    writer.WriteEndElement();
                    writer.WriteStartElement("par");
                    writer.WriteValue(triggers[i].getX());
                    writer.WriteEndElement();
                    writer.WriteStartElement("par");
                    writer.WriteValue(triggers[i].getY());
                    writer.WriteEndElement();
                    writer.WriteStartElement("par");
                    writer.WriteValue(trig.getChangeTo());
                    writer.WriteEndElement();
                    writer.WriteStartElement("par");
                    writer.WriteValue(trig.getpX());
                    writer.WriteEndElement();
                    writer.WriteStartElement("par");
                    writer.WriteValue(trig.getpY());
                    writer.WriteEndElement();
                }
                if (triggers[i] is TriggerMini)
                {
                    TriggerMini trig = (TriggerMini)triggers[i];
                    writer.WriteStartElement("type");
                    writer.WriteValue("TriggerMini");
                    writer.WriteEndElement();
                    writer.WriteStartElement("par");
                    writer.WriteValue(triggers[i].getX());
                    writer.WriteEndElement();
                    writer.WriteStartElement("par");
                    writer.WriteValue(triggers[i].getY());
                    writer.WriteEndElement();
                    writer.WriteStartElement("par");
                    writer.WriteValue(trig.getChangeTo());
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }
                writer.WriteEndElement();
        }

        public void ReadXml(XmlReader reader)
        {
            reader.ReadStartElement();
            id = reader.ReadElementContentAsInt();
            numLayers = reader.ReadElementContentAsInt();
            reader.Read();
            paths = new string[numLayers];
            dirImg = new string[numLayers];
            for (int i = 0; i < numLayers; i++)
            {
                paths[i] = (string)reader.ReadElementContentAsString();
                dirImg[i] = (string)reader.ReadElementContentAsString();
                layers.Add(new Layer(paths[i], dirImg[i]));
            }
            reader.Read(); // fin source
            
            //reader.Read();
            
            string val = reader.Name;
            if (val.Equals("Triggers"))
            {
                reader.Read();
                //reader.Read();
                do
                {
                    reader.Read();
                    string type = (string)reader.ReadElementContentAsString();
                    if (type.Equals("TriggerChangeMap"))
                    {
                        int x = reader.ReadElementContentAsInt();
                        int y = reader.ReadElementContentAsInt();
                        int change = reader.ReadElementContentAsInt();
                        int px = reader.ReadElementContentAsInt();
                        int py = reader.ReadElementContentAsInt();
                        TriggerChangeMap trig = new TriggerChangeMap(x, y, change, px, py);
                        triggers.Add(trig);
                    }

                    else if (type.Equals("TriggerMap"))
                    {
                        int x = reader.ReadElementContentAsInt();
                        int y = reader.ReadElementContentAsInt();
                        int change = reader.ReadElementContentAsInt();
                        int px = reader.ReadElementContentAsInt();
                        int py = reader.ReadElementContentAsInt();
                        TriggerMap trig = new TriggerMap(x, y, change, px, py);
                        triggers.Add(trig);
                    }
                    else if (type.Equals("TriggerMini"))
                    {
                        int x = reader.ReadElementContentAsInt();
                        int y = reader.ReadElementContentAsInt();
                        int change = reader.ReadElementContentAsInt();
                        TriggerMini trig = new TriggerMini(x, y, change);
                        triggers.Add(trig);
                    }
                    //reader.Read(); //fin de trigger
                    reader.Read(); //fin de triggers;
                } while (reader.Name.Equals("Trigger"));
                reader.Read();// fin map
                reader.Read();
            }
            else reader.Read();//fin de map;
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
            //triggers.Add(new TriggerChangeMap(16, 5, 1, 410, 618));
            //triggers.Add(new TriggerMap(1, 7, 2, 400, 618));

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
