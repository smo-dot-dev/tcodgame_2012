using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using libtcod;
using System.Threading.Tasks;

namespace tcodgame
{
    public struct ID 
    {
        public const string tree = "tree";
        public const string log = "log";
        public const string wall = "wall";
        public const string floor = "floor";
        public const string door = "door";
        public const string water = "water";
        public const string seed = "seed";
        public const string voidBucket =  "bucket(void)";
        public const string fullBucket = "bucket(full)";
    }

    public enum MaterialType 
    {
        larch, //wood
        pine,  //wood
        liquid,
        frozen
    }

    class CraftSystem
    {

        public static bool craft(Item it) 
        {
            if (it.canCraft)
            {
                TCODConsole.root.print(0, 0, craftString(it.id));
                TCODConsole.flush();
                char sel = TCODConsole.waitForKeypress(true).Character;
                Item final = new Item(it.id, it.m);
                int i = (int)Char.GetNumericValue(sel);
                string s;
                try
                {
                    s = getCraftableList(it.id)[i];
                }
                catch (IndexOutOfRangeException)
                {
                    return false;
                }

                final.init(s, it.m);

                if (Inventory.isFull() == false)
                {
                    if (final.id == ID.wall || final.id == ID.floor || final.id == ID.door)
                    {
                        Inventory.addItem(final);
                        Inventory.addItem(final);
                        return true;
                    }
                    else
                    {
                        Inventory.addItem(final);
                        return true;
                    }
                }
                else
                {
                    Utils.print("Inventory full!", 30, 0, TCODColor.white, TCODColor.darkRed);
                    TCODConsole.flush();
                    TCODConsole.waitForKeypress(true);
                    return false;
                }
                
            }
            else
            {
                return false;
            }
        }

        static string craftString(string id) {
            
            if (getCraftableList(id) == null)
            {
                return "";
            }
            string final = "With a " + id + ", you can make:";
            for (int i = 0; i < getCraftableList(id).Length; i++)
            {
                final += "\n(" + i + ") " + getCraftableList(id)[i];
            }

            return final + "\nPress a number please.";
        }

        static string[] getCraftableList(string id) {
            switch (id)
            {
                case ID.log:
                    return new string[] { ID.wall, ID.floor, ID.door };
                default:
                    return null;
            }
        }

        
    }
}
