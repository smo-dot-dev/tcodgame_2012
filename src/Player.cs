using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using libtcod;
using System.Threading.Tasks;

namespace tcodgame
{
    class Player
    {
        //posición relativa a la consola (centro)
        public static int playerx_console = 30;
        public static int playery_console = 25;

        //posición relativa al mapa
        public static int getX() {
            return World.cam_posx + playerx_console;
        }

        public static int getY() {
            return World.cam_posy + playery_console;
        }

        public static void keyPress()
        {
            var keyPress = TCODConsole.waitForKeypress(true);
            switch (keyPress.KeyCode)
            {
                case TCODKeyCode.Up:
                    if (World.getItem('u') == null || !World.getItem('u').solid) { World.cam_posy -= 1; }
                    break;
                case TCODKeyCode.Down:
                    if (World.getItem('d') == null || !World.getItem('d').solid) { World.cam_posy += 1; }
                    break;
                case TCODKeyCode.Left:
                    if (World.getItem('l') == null || !World.getItem('l').solid) { World.cam_posx -= 1; }
                    break;
                case TCODKeyCode.Right:
                    if (World.getItem('r') == null || !World.getItem('r').solid) { World.cam_posx += 1; }
                    break;
                case TCODKeyCode.F11:
                    if (!TCODConsole.isFullscreen()) { TCODConsole.setFullscreen(true); } else { TCODConsole.setFullscreen(false); }
                    break;

                case TCODKeyCode.One://punch                    
                    TCODConsole.flush();
                    int x = Player.getX();
                    int y = Player.getY();
                    
                    TCODConsole.root.putCharEx(62, 7, ' ', TCODColor.desaturatedGreen, TCODColor.desaturatedGreen);
                    Utils.print("-direction?", 68, 7, TCODColor.desaturatedGreen, TCODColor.black);
                    TCODConsole.flush();
                    TCODConsole.root.putCharEx(62, 7, ' ', TCODColor.black, TCODColor.black);
                    
                    var key = TCODConsole.waitForKeypress(true);
                    if (key.KeyCode == TCODKeyCode.Up && World.getItem('u') != null)
                    {
                        World.getItem('u').punch();
                    }
                    else if (key.KeyCode == TCODKeyCode.Down && World.getItem('d') != null)
                    {
                        World.getItem('d').punch();
                    }
                    else if (key.KeyCode == TCODKeyCode.Left && World.getItem('l') != null)
                    {
                        World.getItem('l').punch();
                    }
                    else if (key.KeyCode == TCODKeyCode.Right && World.getItem('r') != null)
                    {
                        World.getItem('r').punch();
                    }
                    break;

                case TCODKeyCode.Two://get
                    TCODConsole.root.putCharEx(62, 8, ' ', TCODColor.desaturatedGreen, TCODColor.desaturatedGreen);
                    Utils.print("-direction?", 67, 8, TCODColor.desaturatedGreen, TCODColor.black);
                    TCODConsole.flush();
                    TCODConsole.root.putCharEx(62, 8, ' ', TCODColor.black, TCODColor.black);
                    var keyGet = TCODConsole.waitForKeypress(true);

                    if (keyGet.KeyCode == TCODKeyCode.Up)
                    {
                        Inventory.addItem(World.getItem('u'), 'u');
                    }
                    else if (keyGet.KeyCode == TCODKeyCode.Down)
                    {
                        Inventory.addItem(World.getItem('d'), 'd');
                    }
                    else if (keyGet.KeyCode == TCODKeyCode.Left)
                    {
                        Inventory.addItem(World.getItem('l'), 'l');
                    }
                    else if (keyGet.KeyCode == TCODKeyCode.Right)
                    {
                        Inventory.addItem(World.getItem('r'), 'r');
                    }
                    break;

                case TCODKeyCode.Three://drop
                    TCODConsole.root.putCharEx(62, 9, ' ', TCODColor.desaturatedGreen, TCODColor.desaturatedGreen);
                    Utils.print("-inv.slot?", 67, 9, TCODColor.desaturatedGreen, TCODColor.black);
                    TCODConsole.flush();
                    var keyOrd = TCODConsole.waitForKeypress(true);
                    Utils.print("-direction?", 67, 9, TCODColor.desaturatedGreen, TCODColor.black);
                    TCODConsole.flush();
                    var keyDrop = TCODConsole.waitForKeypress(true);
                    TCODConsole.root.putCharEx(62, 9, ' ', TCODColor.black, TCODColor.black);

                    if (keyDrop.KeyCode == TCODKeyCode.Up)
                    {
                        Inventory.dropItem('u', keyOrd.Character);
                    }
                    else if (keyDrop.KeyCode == TCODKeyCode.Down)
                    {
                        Inventory.dropItem('d', keyOrd.Character);
                    }
                    else if (keyDrop.KeyCode == TCODKeyCode.Left)
                    {
                        Inventory.dropItem('l', keyOrd.Character);
                    }
                    else if (keyDrop.KeyCode == TCODKeyCode.Right)
                    {
                        Inventory.dropItem('r', keyOrd.Character);
                    }
                    break;

                case TCODKeyCode.Four:
                    TCODConsole.root.putCharEx(62, 10, ' ', TCODColor.desaturatedGreen, TCODColor.desaturatedGreen);
                    Utils.print("-inv.slot?", 68, 10, TCODColor.desaturatedGreen, TCODColor.black);
                    TCODConsole.flush();
                    TCODConsole.root.putCharEx(62, 10, ' ', TCODColor.black, TCODColor.black);
                    char keyCraft = TCODConsole.waitForKeypress(true).Character;
                    Inventory.craftItem(keyCraft);

                    break;
                case TCODKeyCode.Five:
                    TCODConsole.root.putCharEx(62, 11, ' ', TCODColor.desaturatedGreen, TCODColor.desaturatedGreen);
                    Utils.print("-dir?", 74, 11, TCODColor.desaturatedGreen, TCODColor.black);
                    TCODConsole.flush();
                    TCODConsole.root.putCharEx(62, 11, ' ', TCODColor.black, TCODColor.black);
                    var keyGather = TCODConsole.waitForKeypress(true);

                    if (keyGather.KeyCode == TCODKeyCode.Up)
                    {
                        if (World.getItem('u').gather())
                        {
                            World.getItem('u').punch();
                        }
                    }
                    else if (keyGather.KeyCode == TCODKeyCode.Down)
                    {
                        if (World.getItem('d').gather())
                        {
                            World.getItem('d').punch();
                        }
                    }
                    else if (keyGather.KeyCode == TCODKeyCode.Left)
                    {
                        if (World.getItem('l').gather())
                        {
                            World.getItem('l').punch();
                        }
                    }
                    else if (keyGather.KeyCode == TCODKeyCode.Right)
                    {
                        if (World.getItem('r').gather())
                        {
                            World.getItem('r').punch();
                        }
                    }

                    break;
            }
        }
    }
}
