using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tcodgame
{
    public enum Biome
    {
        forest,
        snow,
        desert,
    };

    class Terragen
    {
        static Random rand;
        
        public static void generateForest(int size, Item[,] imap, TerrainTile[,] tmap)
        {
            rand = new Random(System.DateTime.Now.Millisecond);
            size = size - 1;
            int reproductivity = 8; //generations of trees
            //*****GENERATE TMAP*****
            for (int i = 1; i < size; i++)
            {
                for (int j = 1; j < size; j++)
                {
                    if (rand.Next(100) > 50) { tmap[i, j] = new TerrainTile("grass0"); } else { tmap[i, j] = new TerrainTile("grass1"); }
                }
            }

            //*****GENERATE IMAP*****
            //AUTOMATA INIT TREES
            for (int i = 1; i < size; i++)
			{
                for (int j = 1; j < size; j++)
                {
                    if (rand.Next(1000) > 997)
                    {
                        imap[i, j] = new Item(ID.tree, randomTreeMaterial());
                    }
                }
			}
            //AUTOMATA INIT WATER
            for (int i = 1; i < size; i++)
            {
                for (int j = 1; j < size; j++)
                {
                    if (rand.Next(1000) > 995)
                    {
                        imap[i, j] = new Item(ID.water, MaterialType.liquid);
                    }
                }
            }

            //CELLULLAR AUTOMATA FOR WATER
            for (int i = 1; i < size; i++)
            {
                for (int j = 1; j < size; j++)
                {
                    if (imap[i, j] != null && imap[i, j].id != ID.tree)
                    {
                        for (int k = 0; k < reproductivity; k++)
                        {
                            if (rand.Next(100) > 70)
                            {
                                switch (rand.Next(4))
                                {
                                    case 0:
                                        imap[i, j - 1] = new Item(ID.water, MaterialType.liquid);
                                        break;
                                    case 1:
                                        imap[i, j + 1] = new Item(ID.water, MaterialType.liquid);
                                        break;
                                    case 2:
                                        imap[i + 1, j] = new Item(ID.water, MaterialType.liquid);
                                        break;
                                    case 3:
                                        imap[i - 1, j] = new Item(ID.water, MaterialType.liquid);
                                        break;
                                }
                            }
                        }
                    }

                }
            }
            rand = new Random(System.DateTime.Now.Millisecond);
            //CELLULLAR AUTOMATA FOR TREES
            for (int i = 1; i < size; i++)
            {
                for (int j = 1; j < size; j++)
                {
                    if (imap[i, j] != null && (imap[i, j].id == ID.tree))
                    {
                        for (int k = 0; k < reproductivity; k++)
                        {
                            if (rand.Next(100) > 57)
                            {
                                switch (rand.Next(4))
                                {
                                    case 0:
                                        imap[i, j - 1] = new Item(ID.tree, randomTreeMaterial());
                                        break;
                                    case 1:
                                        imap[i, j + 1] = new Item(ID.tree, randomTreeMaterial());
                                        break;
                                    case 2:
                                        imap[i + 1, j] = new Item(ID.tree, randomTreeMaterial());
                                        break;
                                    case 3:
                                        imap[i - 1, j] = new Item(ID.tree, randomTreeMaterial());
                                        break;
                                }
                            }
                        }
                    }

                }
            }

        }

        public static void generateSnow(int size, Item[,] imap, TerrainTile[,] tmap)
        {
            rand = new Random(System.DateTime.Now.Millisecond);
            size = size - 1;
            int reproductivity = 8; //generations of trees
            //*****GENERATE TMAP*****
            for (int i = 1; i < size; i++)
            {
                for (int j = 1; j < size; j++)
                {
                    if (rand.Next(100) > 50) { tmap[i, j] = new TerrainTile("snow0"); } else { tmap[i, j] = new TerrainTile("snow1"); }
                }
            }

            //*****GENERATE IMAP*****
            //SEEDS
            for (int i = 1; i < size; i++)
            {
                for (int j = 1; j < size; j++)
                {
                    if (rand.Next(1000) > 997)
                    {
                        imap[i, j] = new Item(ID.tree, randomTreeMaterial());
                    }
                }
            }
            //CELLULLAR AUTOMATA
            for (int i = 1; i < size; i++)
            {
                for (int j = 1; j < size; j++)
                {
                    if (imap[i, j] != null && (imap[i, j].id == ID.tree))
                    {
                        for (int k = 0; k < reproductivity; k++)
                        {
                            if (rand.Next(100) > 60)
                            {
                                switch (rand.Next(4))
                                {
                                    case 0:
                                        imap[i, j - 1] = new Item(ID.tree, randomTreeMaterial());
                                        break;
                                    case 1:
                                        imap[i, j + 1] = new Item(ID.tree, randomTreeMaterial());
                                        break;
                                    case 2:
                                        imap[i + 1, j] = new Item(ID.tree, randomTreeMaterial());
                                        break;
                                    case 3:
                                        imap[i - 1, j] = new Item(ID.tree, randomTreeMaterial());
                                        break;
                                }
                            }
                        }
                    }

                }
            }

        }

        static MaterialType randomTreeMaterial() {
            if (rand.Next(100) > 65)
            {
                return MaterialType.larch;
            }
            else
            {
                return MaterialType.pine;
            }
        }
    }
}
