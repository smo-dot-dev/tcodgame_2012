using System;
using libtcod;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tcodgame
{
    class Utils
    {
        public static void writeSlowly(string message, int x, int y, int delay, TCODColor foreColor, TCODColor backColor)
        {
            char[] inpToChar = message.ToCharArray();

            for (int i = 0; i < message.Length; i++)
            {
                TCODConsole.root.putCharEx(x, y, inpToChar[i], foreColor, backColor);
                TCODConsole.flush();
                x++;
                System.Threading.Thread.Sleep(delay);
            }
        }

        public static void print(string inp, int x, int y, TCODColor foreColor, TCODColor backColor)
        {
            char[] inpToChar = inp.ToCharArray();

            for (int i = 0; i < inp.Length; i++)
            {
                TCODConsole.root.putCharEx(x, y, inpToChar[i], foreColor, backColor);
                x++;
            }
        }

        public static void printTileset() {
            int x = 0;
            int y = 1;
            while (!TCODConsole.isWindowClosed())
            {
                for (int i = 0; i < 255; i++)
                {
                    TCODConsole.root.putChar(x, y, (char)i);
                    x++;
                    if (x % 16 == 0)
                    {
                        x = 1;
                        y++;
                    }
                }
                TCODConsole.flush();
                TCODConsole.waitForKeypress(true);
            }
        }
    }
}
