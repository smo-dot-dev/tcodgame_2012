using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using libtcod;
using System.Threading.Tasks;

namespace tcodgame
{
    class World
    {
        //CAMERA POSITION
        public static int cam_posx = 256;
        public static int cam_posy = 256;
        //CAMERA W/H ONSCREEN
        public static int cam_width = 60;
        public static int cam_height = 50;
        const ushort MAPSIZE = 1024;
        //MAPS
        public static Item[,] IMap = new Item[MAPSIZE, MAPSIZE];
        public static TerrainTile[,] TMap = new TerrainTile[MAPSIZE, MAPSIZE];

        static Random rand = new Random();
        
        //DRAWING
        public static void draw()
        {
            for (int i = 0; i < cam_width; i++)
            {
                for (int j = 0; j < cam_height; j++)
                {
                    TerrainTile tt = TMap[i + cam_posx, j + cam_posy];
                    TCODConsole.root.putCharEx(i, j, tt.icon, tt.fore, tt.back);
                }
            }

            for (int i = 0; i < cam_width; i++)
            {
                for (int j = 0; j < cam_height; j++)
                {
                    if (IMap[i + cam_posx, j + cam_posy] != null)
                    {
                        Item it = IMap[i + cam_posx, j + cam_posy];
                        TCODConsole.root.putCharEx(i, j, it.icon, it.fore, it.back);
                    }
                }
            }
        }

        //EXTRACTING PROPERTIES FROM THE MAPS
        //IMAP

        public static Item getItem(char d)
        {
            int x = Player.getX();
            int y = Player.getY();

            if (d == 'u' && IMap[x, y - 1] != null)
            {
                return IMap[x, y - 1];
            }
            else if (d == 'd' && IMap[x, y + 1] != null)
            {
                return IMap[x, y + 1];
            }
            else if (d == 'l' && IMap[x - 1, y] != null)
            {
                return IMap[x - 1, y];
            }
            else if (d == 'r' && IMap[x + 1, y] != null)
            {
                return IMap[x + 1, y];
            }
            else
            {
                return null;
            }
        }

        //INTERACTING WITH IMAP

        public static void eraseItem(char d) 
        {
            int x = Player.getX();
            int y = Player.getY();
            if (d == 'u')
            {
                IMap[x, y - 1] = null;
            }
            else if (d == 'd')
            {
                IMap[x, y + 1] = null;
            }
            else if (d == 'l')
            {
                IMap[x - 1, y] = null;
            }
            else if (d == 'r')
            {
                IMap[x + 1, y] = null;
            }
        }

        public static void newItem(char d, string id, MaterialType n) 
        {
            int x = Player.getX();
            int y = Player.getY();
            if (d == 'u')
            {
                IMap[x, y - 1] = new Item(id, n);
            }
            else if (d == 'd')
            {
                IMap[x, y + 1] = new Item(id, n);
            }
            else if (d == 'l')
            {
                IMap[x - 1, y] = new Item(id, n);
            }
            else if (d == 'r')
            {
                IMap[x + 1, y] = new Item(id, n);
            }
        }
    }
}
