using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using libtcod;
using System.Threading.Tasks;

namespace tcodgame
{
    public class Item
    {
        public string id;
        public char icon;
        public bool solid = false;
        public bool pocket = false;
        public bool canCraft = false;
        public int seed = 0;
        public TCODColor fore;
        public TCODColor back = TCODColor.black;
        public MaterialType m;

        public void punch()
        {
            switch (this.id)
            {
                case ID.tree:
                    init(ID.log, this.m);
                    break;
                case ID.door:
                    open();
                    break;
            }
        }

        public bool gather() {
            if (seed > 0)
            {
                for (int i = 0; i < seed; i++)
                {
                    Inventory.addItem(new Item(ID.seed, this.m));
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        //init VERY USEFUL
        public void init(string id, MaterialType n)
        {
            switch (id)
            {
                case ID.tree:
                    setProperties(id, (char)23, true, false, false, n);
                    this.seed = 2;
                    break;
                case ID.log:
                    setProperties(id, (char)22, false, true, true, n);
                    break;
                case ID.wall:
                    setProperties(id, (char)241, true, true, false, n);
                    break;
                case ID.floor:
                    setProperties(id, (char)240, false, true, false, n);
                    break;
                case ID.door:
                    setProperties(id, 'X', true, true, false, n);
                    break;
                case ID.water:
                    setProperties(id, (char)TCODSpecialCharacter.Block1, true, false, false, n);
                    break;
                case ID.seed:
                    setProperties(id, '.', false, true, false, n);
                    break;
                case ID.voidBucket:
                    setProperties(id, (char)233, false, true, false, n);
                    break;
                case ID.fullBucket:
                    setProperties(id, (char)233, false, true, false, n);
                    break;
                default://error
                    System.Windows.Forms.MessageBox.Show("ID creation error, now printing Stacktrace. Send this to samuel3801@gmail.com.\n" + Environment.StackTrace);
                    break;
            }
        }

        void setProperties(string i, char c, bool solid, bool pocket, bool canCraft, MaterialType n)
        {
            this.id = i;
            this.icon = c;
            this.solid = solid;
            this.pocket = pocket;
            this.canCraft = canCraft;
            setForeColor(n);
            this.m = n;
            
        }

        public void setForeColor(MaterialType n)
        {
            if (id == ID.tree)
            {
                switch (n)
                {
                    case MaterialType.larch:
                        this.fore = TCODColor.darkerChartreuse;
                        break;
                    case MaterialType.pine:
                        this.fore = TCODColor.green;
                        break;
                }
            }
            if (id == ID.wall || id == ID.floor || id == ID.log || id == ID.door || id == ID.seed || id == ID.voidBucket || id == ID.fullBucket)
            {
                switch (n)
                {
                    case MaterialType.larch:
                        this.fore = TCODColor.darkerSepia;
                        break;
                    case MaterialType.pine:
                        this.fore = TCODColor.sepia;
                        break;
                }
            }
            if (id == ID.water)
            {
                switch (n){
                    case MaterialType.liquid:
                        this.fore = TCODColor.sky;
                        break;
                    case MaterialType.frozen:
                        this.fore = TCODColor.lighterSky;
                        break;
                }
            }
        }
        
        public string getInfo() {
            if (this.id != ID.door)
            {
                return this.m + " " + this.id;
            }
            else
            {
                if (this.solid)
                {
                    return this.m + " " + this.id + " C";
                }
                else
                {
                    return this.m + " " + this.id + " O";
                }
            }
        }
        //FOR DOORS
        void open() {
            if (this.id == ID.door && this.solid)
            {
                this.solid = false;
            }
            else
            {
                this.solid = true;
            }
        }
        //CONSTRUCTOR
        public Item(string id, MaterialType n)
        {
            init(id, n);
        }
    }

    class TerrainTile
    {
        public string id;
        public char icon;
        public TCODColor fore;
        public TCODColor back = TCODColor.black;

        public TerrainTile(string id)
        {
            switch (id)
            {
                case "grass0":
                    this.id = id;
                    this.icon = '.';
                    this.fore = TCODColor.green;
                    break;

                case "grass1":
                    this.id = id;
                    this.icon = '\"';
                    this.fore = TCODColor.darkGreen;
                    break;

                case "snow0":
                    this.id = id;
                    this.icon = '.';
                    this.fore = TCODColor.white;
                    break;

                case "snow1":
                    this.id = id;
                    this.icon = '\"';
                    this.fore = TCODColor.lightestGrey;
                    break;
            }
        }
    }
}
