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
    class Inventory: ISerializable
    {
        List<Item> items;
        private int quantity;
        private int capacity;

        public Inventory(SerializationInfo info, StreamingContext ctxt)
        {
            quantity = (int)info.GetValue("InventoryQuantity", typeof(int));
            capacity = (int)info.GetValue("InventoryCapacity", typeof(int));
            items = (List<Item>)info.GetValue("InventoryItems", typeof(List<Item>));

        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("InventoryQuantity", quantity);
            info.AddValue("InventoryCapacity", capacity);
            info.AddValue("InventoryItems", items);

        }

        public void addItem(int itemId)
        {

        }

        public void consumeItem(int itemId)
        {

        }

        public void increaseQuantity()
        {

        }

        public void decreaseQuantity()
        {

        }

        public int getQuantity()
        {
            return quantity;
        }

        public void setQuantity(int quantity)
        {
            this.quantity = quantity;
        }

        public int getCapacity()
        {
            return capacity;
        }

        public void setCapacity(int capacity)
        {
            this.capacity = capacity;
        }

        public List<Item> getItems()
        {
            return items;
        }

        public void setItems(List<Item> items)
        {
            this.items = items;
        }
    }
}
