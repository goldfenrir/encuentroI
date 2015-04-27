using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace rpgGame
{
    [Serializable()]
    class Item: ISerializable
    {
        private int id;
        private String name;
        private int stock;
        private String description;

        public Item(SerializationInfo info, StreamingContext ctxt)
        {
            id = (int)info.GetValue("ItemId", typeof(int));
            name = (String)info.GetValue("ItemName", typeof(String));
            stock = (int)info.GetValue("ItemStock", typeof(int));
            description = (String)info.GetValue("ItemDescr", typeof(String));

        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("ItemId", id);
            info.AddValue("ItemName", name);
            info.AddValue("ItemStock", stock);
            info.AddValue("ItemDescr", description);

        }

        public int getId()
        {
            return id;
        }

        public void setId(int id)
        {
            this.id = id;
        }

        public String getName()
        {
            return name;
        }

        public void setName(String name)
        {
            this.name = name;
        }

        public int getStock()
        {
            return stock;
        }

        public void setStock(int stock)
        {
            this.stock = stock;
        }

        public String getDescription()
        {
            return description;
        }

        public void setDescription(String description)
        {
            this.description = description;
        }
    }
}
