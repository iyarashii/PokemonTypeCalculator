using System;
using Android.App;
namespace PokemonTypeCalc
{
    public class TypeCalculator
    {
        readonly String[] types = Application.Context.Resources.GetStringArray(Resource.Array.pokemonType);
        PkmnType[] typez;
        
        public PkmnType[] SortPkmnTypes(PkmnType[] pkmnArray)
        {
            Array.Sort(pkmnArray, delegate (PkmnType x, PkmnType y)
            {
                return y.DmgTaken.CompareTo(x.DmgTaken);
            });
            return pkmnArray;
        }
        public PkmnType[] CheckType(string raw)
        {
            typez = new PkmnType[18];
            // NORMAL
            if (string.Equals(raw, types[1]))
            {
                for (int i = 0; i < 18; ++i)
                {
                    typez[i] = new PkmnType(null,0);

                    if (i == 1)
                    {
                        typez[i].DmgTaken = 2;
                    }
                    else if (i == 7)
                    {
                        typez[i].DmgTaken = 0;
                    }
                    else
                    {
                        typez[i].DmgTaken = 1;
                    }
                    typez[i].TypeName = types[i + 1];
                }

            }
            // FIGHTING
            if (string.Equals(raw, types[2]))
            {
                for (int i = 0; i < 18; ++i)
                {
                    typez[i] = new PkmnType(null, 0);

                    if (i == 2 || i == 13 || i == 17)
                    {
                        typez[i].DmgTaken = 2;
                    }
                    else if (i == 5 || i == 6 || i == 16)
                    {
                        typez[i].DmgTaken = 0.5;
                    }
                    else
                    {
                        typez[i].DmgTaken = 1;
                    }
                    typez[i].TypeName = types[i + 1];
                }
            }
            // FLYING
            if (string.Equals(raw, types[3]))
            {
                for (int i = 0; i < 18; ++i)
                {
                    typez[i] = new PkmnType(null, 0);

                    if (i == 5 || i == 12 || i == 14)
                    {
                        typez[i].DmgTaken = 2;
                    }
                    else if (i == 1 || i == 6 || i == 11)
                    {
                        typez[i].DmgTaken = 0.5;
                    }
                    else if (i == 4)
                    {
                        typez[i].DmgTaken = 0;
                    }
                    else
                    {
                        typez[i].DmgTaken = 1;
                    }
                    typez[i].TypeName = types[i + 1];
                }
            }
            // POISON
            if (string.Equals(raw, types[4]))
            {
                for (int i = 0; i < 18; ++i)
                {
                    typez[i] = new PkmnType(null, 0);

                    if (i == 4 || i == 13)
                    {
                        typez[i].DmgTaken = 2;
                    }
                    else if (i == 1 || i == 3 || i == 6 || i == 11 || i == 17)
                    {
                        typez[i].DmgTaken = 0.5;
                    }
                    else
                    {
                        typez[i].DmgTaken = 1;
                    }
                    typez[i].TypeName = types[i + 1];
                }
            }
            // GROUND
            if (string.Equals(raw, types[5]))
            {
                for (int i = 0; i < 18; ++i)
                {
                    typez[i] = new PkmnType(null, 0);

                    if (i == 10 || i == 11 || i == 14)
                    {
                        typez[i].DmgTaken = 2;
                    }
                    else if (i == 3 || i == 5)
                    {
                        typez[i].DmgTaken = 0.5;
                    }
                    else if (i == 12)
                    {
                        typez[i].DmgTaken = 0;
                    }
                    else
                    {
                        typez[i].DmgTaken = 1;
                    }
                    typez[i].TypeName = types[i + 1];
                }
            }
            // ROCK
            if (string.Equals(raw, types[6]))
            {
                for (int i = 0; i < 18; ++i)
                {
                    typez[i] = new PkmnType(null, 0);

                    if (i == 1 || i == 4 || i == 8 || i == 10 || i == 11)
                    {
                        typez[i].DmgTaken = 2;
                    }
                    else if (i == 0 || i == 2 || i == 3 || i == 9)
                    {
                        typez[i].DmgTaken = 0.5;
                    }
                    else
                    {
                        typez[i].DmgTaken = 1;
                    }
                    typez[i].TypeName = types[i + 1];
                }
            }
            // BUG
            if (string.Equals(raw, types[7]))
            {
                for (int i = 0; i < 18; ++i)
                {
                    typez[i] = new PkmnType(null, 0);

                    if (i == 2 || i == 5 || i == 9)
                    {
                        typez[i].DmgTaken = 2;
                    }
                    else if (i == 1 || i == 4 || i == 11)
                    {
                        typez[i].DmgTaken = 0.5;
                    }
                    else
                    {
                        typez[i].DmgTaken = 1;
                    }
                    typez[i].TypeName = types[i + 1];
                }
            }
            // GHOST
            if (string.Equals(raw, types[8]))
            {
                for (int i = 0; i < 18; ++i)
                {
                    typez[i] = new PkmnType(null, 0);

                    if (i == 7 || i == 16)
                    {
                        typez[i].DmgTaken = 2;
                    }
                    else if (i == 3 || i == 6)
                    {
                        typez[i].DmgTaken = 0.5;
                    }
                    else if (i == 0 || i == 1)
                    {
                        typez[i].DmgTaken = 0;
                    }
                    else
                    {
                        typez[i].DmgTaken = 1;
                    }
                    typez[i].TypeName = types[i + 1];
                }
            }
            // STEEL
            if (string.Equals(raw, types[9]))
            {
                for (int i = 0; i < 18; ++i)
                {
                    typez[i] = new PkmnType(null, 0);

                    if (i == 1 || i == 4 || i == 9)
                    {
                        typez[i].DmgTaken = 2;
                    }
                    else if (i == 7 || i == 10 || i == 12 || i == 16)
                    {
                        typez[i].DmgTaken = 1;
                    }
                    else if (i == 3)
                    {
                        typez[i].DmgTaken = 0;
                    }
                    else
                    {
                        typez[i].DmgTaken = 0.5;
                    }
                    typez[i].TypeName = types[i + 1];
                }
            }
            // FIRE
            if (string.Equals(raw, types[10]))
            {
                for (int i = 0; i < 18; ++i)
                {
                    typez[i] = new PkmnType(null, 0);

                    if (i == 4 || i == 5 || i == 10)
                    {
                        typez[i].DmgTaken = 2;
                    }
                    else if (i == 6 || i == 8 || i == 9 || i == 11 || i == 14 || i == 17)
                    {
                        typez[i].DmgTaken = 0.5;
                    }
                    else
                    {
                        typez[i].DmgTaken = 1;
                    }
                    typez[i].TypeName = types[i + 1];
                }
            }
            // WATER
            if (string.Equals(raw, types[11]))
            {
                for (int i = 0; i < 18; ++i)
                {
                    typez[i] = new PkmnType(null, 0);

                    if (i == 11 || i == 12)
                    {
                        typez[i].DmgTaken = 2;
                    }
                    else if (i == 8 || i == 9 || i == 10 || i == 14)
                    {
                        typez[i].DmgTaken = 0.5;
                    }
                    else
                    {
                        typez[i].DmgTaken = 1;
                    }
                    typez[i].TypeName = types[i + 1];
                }
            }
            // GRASS
            if (string.Equals(raw, types[12]))
            {
                for (int i = 0; i < 18; ++i)
                {
                    typez[i] = new PkmnType(null, 0);

                    if (i == 2 || i == 3 || i == 6 || i == 9 || i == 14)
                    {
                        typez[i].DmgTaken = 2;
                    }
                    else if (i == 4 || i == 10 || i == 11 || i == 12)
                    {
                        typez[i].DmgTaken = 0.5;
                    }
                    else
                    {
                        typez[i].DmgTaken = 1;
                    }
                    typez[i].TypeName = types[i + 1];
                }
            }
            // ELECTRIC
            if (string.Equals(raw, types[13]))
            {
                for (int i = 0; i < 18; ++i)
                {
                    typez[i] = new PkmnType(null, 0);

                    if (i == 4)
                    {
                        typez[i].DmgTaken = 2;
                    }
                    else if (i == 2 || i == 8 || i == 12)
                    {
                        typez[i].DmgTaken = 0.5;
                    }
                    else
                    {
                        typez[i].DmgTaken = 1;
                    }
                    typez[i].TypeName = types[i + 1];
                }
            }
            // PSYCHIC
            if (string.Equals(raw, types[14]))
            {
                for (int i = 0; i < 18; ++i)
                {
                    typez[i] = new PkmnType(null, 0);

                    if (i == 6 || i == 7 || i == 16)
                    {
                        typez[i].DmgTaken = 2;
                    }
                    else if (i == 1 || i == 13)
                    {
                        typez[i].DmgTaken = 0.5;
                    }
                    else
                    {
                        typez[i].DmgTaken = 1;
                    }
                    typez[i].TypeName = types[i + 1];
                }
            }
            // ICE
            if (string.Equals(raw, types[15]))
            {
                for (int i = 0; i < 18; ++i)
                {
                    typez[i] = new PkmnType(null, 0);

                    if (i == 1 || i == 5 || i == 8 || i == 9)
                    {
                        typez[i].DmgTaken = 2;
                    }
                    else if (i == 14)
                    {
                        typez[i].DmgTaken = 0.5;
                    }
                    else
                    {
                        typez[i].DmgTaken = 1;
                    }
                    typez[i].TypeName = types[i + 1];
                }
            }
            // DRAGON
            if (string.Equals(raw, types[16]))
            {
                for (int i = 0; i < 18; ++i)
                {
                    typez[i] = new PkmnType(null, 0);

                    if (i == 14 || i == 15 || i == 17)
                    {
                        typez[i].DmgTaken = 2;
                    }
                    else if (i == 9 || i == 10 || i == 11 || i == 12)
                    {
                        typez[i].DmgTaken = 0.5;
                    }
                    else
                    {
                        typez[i].DmgTaken = 1;
                    }
                    typez[i].TypeName = types[i + 1];
                }
            }
            // DARK
            if (string.Equals(raw, types[17]))
            {
                for (int i = 0; i < 18; ++i)
                {
                    typez[i] = new PkmnType(null, 0);

                    if (i == 1 || i == 6 || i == 17)
                    {
                        typez[i].DmgTaken = 2;
                    }
                    else if (i == 7 || i == 16)
                    {
                        typez[i].DmgTaken = 0.5;
                    }
                    else if (i == 13)
                    {
                        typez[i].DmgTaken = 0;
                    }
                    else
                    {
                        typez[i].DmgTaken = 1;
                    }
                    typez[i].TypeName = types[i + 1];
                }
            }
            // FAIRY
            if (string.Equals(raw, types[18]))
            {
                for (int i = 0; i < 18; ++i)
                {
                    typez[i] = new PkmnType(null, 0);

                    if (i == 3 || i == 8)
                    {
                        typez[i].DmgTaken = 2;
                    }
                    else if (i == 1 || i == 6 || i == 16)
                    {
                        typez[i].DmgTaken = 0.5;
                    }
                    else if (i == 15)
                    {
                        typez[i].DmgTaken = 0;
                    }
                    else
                    {
                        typez[i].DmgTaken = 1;
                    }
                    typez[i].TypeName = types[i + 1];
                }
            }

            return typez;
        }
      /*      public double[] CheckType(string raw)
        {
            double[] multipliers = new double[18];
            // NORMAL
            if (string.Equals(raw, types[1]))
            {
                for (int i = 0; i < 18; ++i)
                {
                    if (i == 1)
                    {
                        multipliers[i] = 2;
                    }
                    else if (i == 7)
                    {
                        multipliers[i] = 0;
                    }
                    else
                    {
                        multipliers[i] = 1;
                    }
                }
                
            }
            // FIGHTING
            if (string.Equals(raw, types[2]))
            {
                for (int i = 0; i < 18; ++i)
                {
                    if (i == 2 || i == 13 || i == 17)
                    {
                        multipliers[i] = 2;
                    }
                    else if (i == 5 || i == 6 || i == 16)
                    {
                        multipliers[i] = 0.5;
                    }
                    else
                    {
                        multipliers[i] = 1;
                    }
                }
            }
            // FLYING
            if (string.Equals(raw, types[3]))
            {
                for (int i = 0; i < 18; ++i)
                {
                    if (i == 5 || i == 12 || i == 14)
                    {
                        multipliers[i] = 2;
                    }
                    else if (i == 1 || i == 6 || i == 11)
                    {
                        multipliers[i] = 0.5;
                    }
                    else if (i == 4)
                    {
                        multipliers[i] = 0;
                    }
                    else
                    {
                        multipliers[i] = 1;
                    }
                }
            }
            // POISON
            if (string.Equals(raw, types[4]))
            {
                for (int i = 0; i < 18; ++i)
                {
                    if (i == 4 || i == 13)
                    {
                        multipliers[i] = 2;
                    }
                    else if (i == 1 || i == 3 || i == 6 || i == 11 || i == 17)
                    {
                        multipliers[i] = 0.5;
                    }
                    else
                    {
                        multipliers[i] = 1;
                    }
                }
            }
            // GROUND
            if (string.Equals(raw, types[5]))
            {
                for (int i = 0; i < 18; ++i)
                {
                    if (i == 10 || i == 11 || i == 14)
                    {
                        multipliers[i] = 2;
                    }
                    else if (i == 3 || i == 5)
                    {
                        multipliers[i] = 0.5;
                    }
                    else if (i == 12)
                    {
                        multipliers[i] = 0;
                    }
                    else
                    {
                        multipliers[i] = 1;
                    }
                }
            }
            // ROCK
            if (string.Equals(raw, types[6]))
            {
                for (int i = 0; i < 18; ++i)
                {
                    if (i == 1 || i == 4 || i == 8 || i == 10 || i == 11)
                    {
                        multipliers[i] = 2;
                    }
                    else if (i == 0 || i == 2 || i == 3 || i == 9)
                    {
                        multipliers[i] = 0.5;
                    }
                    else
                    {
                        multipliers[i] = 1;
                    }
                }
            }
            // BUG
            if (string.Equals(raw, types[7]))
            {
                for (int i = 0; i < 18; ++i)
                {
                    if (i == 2 || i == 5 || i == 9)
                    {
                        multipliers[i] = 2;
                    }
                    else if (i == 1 || i == 4 || i == 11)
                    {
                        multipliers[i] = 0.5;
                    }
                    else
                    {
                        multipliers[i] = 1;
                    }
                }
            }
            // GHOST
            if (string.Equals(raw, types[8]))
            {
                for (int i = 0; i < 18; ++i)
                {
                    if (i == 7 || i == 16)
                    {
                        multipliers[i] = 2;
                    }
                    else if (i == 3 || i == 6)
                    {
                        multipliers[i] = 0.5;
                    }
                    else if (i == 0 || i == 1)
                    {
                        multipliers[i] = 0;
                    }
                    else
                    {
                        multipliers[i] = 1;
                    }
                }
            }
            // STEEL
            if (string.Equals(raw, types[9]))
            {
                for (int i = 0; i < 18; ++i)
                {
                    if (i == 1 || i == 4 || i == 9)
                    {
                        multipliers[i] = 2;
                    }
                    else if (i == 7 || i == 10 || i == 12 || i == 16)
                    {
                        multipliers[i] = 1;
                    }
                    else if (i == 3)
                    {
                        multipliers[i] = 0;
                    }
                    else
                    {
                        multipliers[i] = 0.5;
                    }
                }
            }
            // FIRE
            if (string.Equals(raw, types[10]))
            {
                for (int i = 0; i < 18; ++i)
                {
                    if (i == 4 || i == 5 || i == 10)
                    {
                        multipliers[i] = 2;
                    }
                    else if (i == 6 || i == 8 || i == 9 || i == 11 || i == 14 || i == 17)
                    {
                        multipliers[i] = 0.5;
                    }
                    else
                    {
                        multipliers[i] = 1;
                    }
                }
            }
            // WATER
            if (string.Equals(raw, types[11]))
            {
                for (int i = 0; i < 18; ++i)
                {
                    if (i == 11 || i == 12)
                    {
                        multipliers[i] = 2;
                    }
                    else if (i == 8 || i == 9 || i == 10 || i == 14)
                    {
                        multipliers[i] = 0.5;
                    }
                    else
                    {
                        multipliers[i] = 1;
                    }
                }
            }
            // GRASS
            if (string.Equals(raw, types[12]))
            {
                for (int i = 0; i < 18; ++i)
                {
                    if (i == 2 || i == 3 || i == 6 || i == 9 || i == 14)
                    {
                        multipliers[i] = 2;
                    }
                    else if (i == 4 || i == 10 || i == 11 || i == 12)
                    {
                        multipliers[i] = 0.5;
                    }
                    else
                    {
                        multipliers[i] = 1;
                    }
                }
            }
            // ELECTRIC
            if (string.Equals(raw, types[13]))
            {
                for (int i = 0; i < 18; ++i)
                {
                    if (i == 4)
                    {
                        multipliers[i] = 2;
                    }
                    else if (i == 2 || i == 8 || i == 12)
                    {
                        multipliers[i] = 0.5;
                    }
                    else
                    {
                        multipliers[i] = 1;
                    }
                }
            }
            // PSYCHIC
            if (string.Equals(raw, types[14]))
            {
                for (int i = 0; i < 18; ++i)
                {
                    if (i == 6 || i == 7 || i == 16)
                    {
                        multipliers[i] = 2;
                    }
                    else if (i == 1 || i == 13)
                    {
                        multipliers[i] = 0.5;
                    }
                    else
                    {
                        multipliers[i] = 1;
                    }
                }
            }
            // ICE
            if (string.Equals(raw, types[15]))
            {
                for (int i = 0; i < 18; ++i)
                {
                    if (i == 1 || i == 5 || i == 8 || i == 9)
                    {
                        multipliers[i] = 2;
                    }
                    else if (i == 14)
                    {
                        multipliers[i] = 0.5;
                    }
                    else
                    {
                        multipliers[i] = 1;
                    }
                }
            }
            // DRAGON
            if (string.Equals(raw, types[16]))
            {
                for (int i = 0; i < 18; ++i)
                {
                    if (i == 14 || i == 15 || i == 17)
                    {
                        multipliers[i] = 2;
                    }
                    else if (i == 9 || i == 10 || i == 11 || i == 12)
                    {
                        multipliers[i] = 0.5;
                    }
                    else
                    {
                        multipliers[i] = 1;
                    }
                }
            }
            // DARK
            if (string.Equals(raw, types[17]))
            {
                for (int i = 0; i < 18; ++i)
                {
                    if (i == 1 || i == 6 || i == 17)
                    {
                        multipliers[i] = 2;
                    }
                    else if (i == 7 || i == 16)
                    {
                        multipliers[i] = 0.5;
                    }
                    else if (i == 13)
                    {
                        multipliers[i] = 0;
                    }
                    else
                    {
                        multipliers[i] = 1;
                    }
                }
            }
            // FAIRY
            if (string.Equals(raw, types[18]))
            {
                for (int i = 0; i < 18; ++i)
                {
                    if (i == 3 || i == 8)
                    {
                        multipliers[i] = 2;
                    }
                    else if (i == 1 || i == 6 || i == 16)
                    {
                        multipliers[i] = 0.5;
                    }
                    else if (i == 15)
                    {
                        multipliers[i] = 0;
                    }
                    else
                    {
                        multipliers[i] = 1;
                    }
                }
            }
            return multipliers;
        }*/
    }
}
