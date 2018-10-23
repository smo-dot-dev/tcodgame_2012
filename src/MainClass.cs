using System;
using System.Linq;
using libtcod;
using System.Collections.Generic;

namespace tcodgame
{
    class MainClass
    {
        const byte window_x = 85;
        const byte window_y = 50;
        

        static void Main()
        {
            TCODConsole.setCustomFont("tileset.png", (int)TCODFontFlags.LayoutAsciiInRow | (int)TCODFontFlags.Greyscale, 16, 16);
            TCODConsole.initRoot(window_x, window_y, "tcodgame", false, TCODRendererType.SDL);
            TCODSystem.setFps(60);

            //generating world...
            Terragen.generateForest(1024, World.IMap, World.TMap);
            Inventory.init();


            
            while (!TCODConsole.isWindowClosed())
            {
                World.draw();
                TCODConsole.root.putCharEx(30, 25, '@', TCODColor.white, TCODColor.black);
                GUI.draw();
                
                TCODConsole.flush();
                Player.keyPress();
                
            }
            
        }
    }
}
