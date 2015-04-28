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
    [Serializable()]
    class LocalMap : State, ISerializable
    {
        private Map map;
        private List<Map> maps = new List<Map>();
        private Player player;
        private List<Friend> friends;
        private int numMaps;
        private int mapAct;
        
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
            player = (Player)bf.Deserialize(stream);
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
    }
}
