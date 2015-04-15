using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpgGame
{
    class Inventory
    {
        List<Item> items;
        private int quantity;
        private int capacity;

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
