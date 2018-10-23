using System;
using libtcod;
namespace tcodgame 
{
    public class InventorySlot
    {
        public Item item;
        public int qt = 0;
        
        public void addItem(Item it) {
            this.item = it;
        }
    }

    public class Inventory
    {
        public static InventorySlot[] inv = new InventorySlot[10];
        public static char[] qwerty = new char[] {'q','w','e','r','t','y','u','i','o','p'};
        public const int maxQt = 16;

        public static void init() {
            for (int i = 0; i < 10; i++)
            {
                inv[i] = new InventorySlot();
            }
        }

        public static InventorySlot getSlot(char ord) 
        {
            for (int i = 0; i < inv.Length; i++)
            {
                if (qwerty[i] == ord)
                {
                    return inv[i];
                }
            }
            return null;
        }

        public static void dropItem(char d, char ord)
        {
            if (World.getItem(d) != null && World.getItem(d).m == MaterialType.liquid)
            {
                getSlot(ord).item.init(ID.fullBucket, MaterialType.liquid);
            }

            if (World.getItem(d) == null)
            {
                if (getSlot(ord).item != null && getSlot(ord).qt == 1)
                {
                    World.newItem(d, getSlot(ord).item.id, getSlot(ord).item.m);
                    getSlot(ord).item = null;
                    getSlot(ord).qt = 0;
                }
                else if (getSlot(ord).item != null && getSlot(ord).qt > 1)
                {
                    World.newItem(d, getSlot(ord).item.id, getSlot(ord).item.m);
                    getSlot(ord).qt--;
                }
            }
        }

        public static void addItem(Item item, char dir)
        {
            if (item == null || !item.pocket) { return; }
            for (int i = 0; i < inv.Length; i++)
			{
                if (inv[i].item == null)//if item not inside, assign it
                {
                    inv[i].item = item;
                    inv[i].qt = 1;
                    World.eraseItem(dir);
                    return;
                }
                else if (inv[i].item.getInfo() == item.getInfo() && inv[i].qt < maxQt)//if said item is already inside, just qt++
                {
                    inv[i].qt++;
                    World.eraseItem(dir);
                    return;
                }
			}
        }

        public static void addItem(Item item)
        {
            if (item == null || !item.pocket) { return; }
            
            for (int i = 0; i < inv.Length; i++)
            {
                if (inv[i].item == null)//if item not inside, assign it
                {
                    inv[i].item = item;
                    inv[i].qt = 1;
                    return;
                }
                else if (inv[i].item.getInfo() == item.getInfo() && inv[i].qt < maxQt)//if said item is already inside, just qt++
                {
                    inv[i].qt++;
                    return;
                }
            }
        }

        public static bool isFull() {
            for (int i = 0; i < inv.Length; i++)
            {
                if (inv[i].item == null)
                {
                    return false;
                }
            }
            return true;
        }

        public static void craftItem(char ord)
        {
            if (getSlot(ord).item != null)
            {
                if (CraftSystem.craft(getSlot(ord).item))
                {
                    getSlot(ord).qt--;
                    if (getSlot(ord).qt == 0)
                    {
                        getSlot(ord).item = null;
                    }
                }
            }
        }
    }
}


