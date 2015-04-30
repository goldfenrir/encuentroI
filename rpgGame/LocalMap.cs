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
    public class LocalMap : State, IXmlSerializable
    {
        private Map map;
        private List<Map> maps = new List<Map>();
        private Player player;

        internal Player Player
        {
            get { return player; }
            set { player = value; }
        }
        private List<Friend> friends;
        private int numMaps;
        private int mapAct;

        public int MapAct
        {
            get { return mapAct; }
            set { mapAct = value; }
        }
        
        public LocalMap() { }
        public XmlSchema GetSchema()
        {
            return null;
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteStartElement("Cantidad_de_mapas");
            writer.WriteValue(maps.Count);
            writer.WriteEndElement();
           
            //los mapas
            foreach(Map m in maps){
                XmlSerializer serializer = new XmlSerializer(typeof(Map));
                serializer.Serialize(writer,m);
            }
            XmlSerializer serializer2 = new XmlSerializer(typeof(Player));
            serializer2.Serialize(writer, player);
        }

        public void ReadXml(XmlReader reader)
        {
            reader.ReadStartElement();
            numMaps = reader.ReadElementContentAsInt();
            //reader.ReadEndElement();
            XmlSerializer serializer = new XmlSerializer(typeof(Map));
            for (int i = 0; i < numMaps;i++ )
                this.maps.Add((Map)serializer.Deserialize(reader));
            XmlSerializer serializer2 = new XmlSerializer(typeof(Player));
            this.player = (Player)serializer2.Deserialize(reader);
            mapAct = 0;
        }

        public LocalMap(SerializationInfo info, StreamingContext ctxt)
        {
            //map = (Map)info.GetValue("LMMap", typeof(Map));
            numMaps = (int)info.GetValue("LMNumMaps", typeof(int));
            maps = (List<Map>)info.GetValue("LMMaps", typeof(List<Map>));
            //player = (Player)info.GetValue("LMPlayer", typeof(Player));
            mapAct = (int)info.GetValue("LMMapAct", typeof(int));

        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            //info.AddValue("LMMap", map);
            info.AddValue("LMNumMaps", numMaps);
            info.AddValue("LMMaps", maps);
            //info.AddValue("LMPlayer", player);
            info.AddValue("LMMapAct", mapAct);

        }
        public LocalMap(Form form, Game game /*Player play*/)
        {

            player= new Player(game, new Point(80, 80), 1);
            mapAct = game.getCurrentMap();
        }

        public override void Draw(Graphics dv)
        {
            /*foreach (Tile t in mapTiles)
            {
                dv.DrawImage(t.img, t.esqSupIzq);
            }
            player.Draw(dv);*/
            maps[getMapAct()].render(dv);
            player.Draw(dv);
        }

        public override void saveToXml(Stream stream, BinaryFormatter bf)
        {
            bf.Serialize(stream, this);
            bf.Serialize(stream, player);
        }

        public override void loadFromXml(Stream stream, BinaryFormatter bf)
        {
            LocalMap lm = (LocalMap)bf.Deserialize(stream);
            this.mapAct = lm.mapAct;
            Player playerTemp = (Player)bf.Deserialize(stream);
            player.Name = playerTemp.Name;
            player.Gender = playerTemp.Gender;
            player.Id = playerTemp.Id;
            player.Level = playerTemp.Level;
            player.NumberOfClues = playerTemp.NumberOfClues;
            player.PositionX = playerTemp.PositionX;
            player.PositionY = playerTemp.PositionY;
            player.S = playerTemp.S;
            player.CloseNess = playerTemp.CloseNess;
            player.XMove = playerTemp.XMove;
            player.YMove = playerTemp.YMove;
            player.Dir = playerTemp.Dir;
            player.Clues = playerTemp.Clues;
            player.Inventory = playerTemp.Inventory;

        }

        public int getMapAct()
        {
            return mapAct;
        }

        public List<Map> getMaps(){
            return maps;
        }

        public Player getPlayer(){
            return player;
        }

    

        
        public override void Tick()
        {
            if (player != null)
            {
                player.Tick();
            }
            
        }

        public override bool ordenPop()
        {
            return false;
        }
    }
}
