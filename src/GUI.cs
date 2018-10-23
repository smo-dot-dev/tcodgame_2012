using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using libtcod;
using System.Threading.Tasks;

namespace tcodgame
{
    class GUI
    {

        public static void draw()
        {
            TCODConsole.root.printFrame(60, 0, 25, 25);
            //COMPASS
            Utils.print("COMPASS                ", 61, 1, TCODColor.darkestSepia, TCODColor.lighterSepia);
            drawSurroundingItemInfo();
            //ACTIONS
            Utils.print("ACTIONS                ", 61, 6, TCODColor.darkestSepia, TCODColor.lighterSepia);
            TCODConsole.root.print(61, 7, "1 Punch\n2 Grab\n3 Drop\n4 Craft\n5 Gather Seeds");
            //
            //INVENTORY
            Utils.print("INVENTORY              ", 61, 12, TCODColor.darkestSepia, TCODColor.lighterSepia);
            for (int i = 0; i < 10; i++)
            {
                if (Inventory.inv[i].item != null)
                {
                    TCODConsole.root.print(61, i + 13, Inventory.qwerty[i] + ": " + Inventory.inv[i].item.getInfo() + "  " + Inventory.inv[i].qt);
                    TCODConsole.root.putCharEx(63, i + 13, Inventory.inv[i].item.icon, Inventory.inv[i].item.fore, TCODColor.black);
                }

            }
        }


        static void drawSurroundingItemInfo()
        {
            Item u = World.getItem('u');
            Item d = World.getItem('d');
            Item l = World.getItem('l');
            Item r = World.getItem('r');
            try
            {
                TCODConsole.root.print(61, 2, "North:");
                TCODConsole.root.putCharEx(67, 2, u.icon, u.fore, u.back);
                Utils.print(u.getInfo(), 68, 2, TCODColor.white, TCODColor.black);
                
            }catch {
                TCODConsole.root.print(61, 2, "North:                 "); undoPutChar(67, 2);
            }

            try{
                TCODConsole.root.print(61, 3, "South:");
                TCODConsole.root.putCharEx(67, 3, d.icon, d.fore, d.back);
                Utils.print(d.getInfo(), 68, 3, TCODColor.white, TCODColor.black);
            }catch {
                TCODConsole.root.print(61, 3, "South:                 "); undoPutChar(67, 3);
            }

            try
            {
                TCODConsole.root.print(61, 4, "West:");
                TCODConsole.root.putCharEx(66, 4, l.icon, l.fore, l.back);
                Utils.print(l.getInfo(), 67, 4, TCODColor.white, TCODColor.black);
                
            }
            catch {
                TCODConsole.root.print(61, 4, "West:                 "); undoPutChar(66, 4);
            }
                
            try{
                TCODConsole.root.print(61, 5, "East:");
                TCODConsole.root.putCharEx(66, 5, r.icon, r.fore, r.back);
                Utils.print(r.getInfo(), 67, 5, TCODColor.white, TCODColor.black);
                
            }
            catch
            {
                TCODConsole.root.print(61, 5, "East:                  "); undoPutChar(66, 5);
            }


        }

        static void undoPutChar(int x, int y) {
            TCODConsole.root.putCharEx(x, y, ' ', TCODColor.black, TCODColor.black);
        }
    }
}