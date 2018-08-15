using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace PokemonTypeCalc
{
    public class PkmnType
    {
        public PkmnType(string name, double multiplier)
        {
            TypeName = name;
            DmgTaken = multiplier;
        }
        public string TypeName { get; set; }
        public double DmgTaken { get; set; }
        public Android.Graphics.Color TypeColor
        {
            get
            {
                switch (TypeName)
                {
                    case "NORMAL":
                        return Android.Graphics.Color.ParseColor("#A8A878");
                    case "FIGHTING":
                        return (Android.Graphics.Color.ParseColor("#C03028"));
                    case "FLYING":
                        return (Android.Graphics.Color.ParseColor("#A890F0"));
                    case "POISON":
                        return (Android.Graphics.Color.ParseColor("#A040A0"));
                    case "GROUND":
                        return (Android.Graphics.Color.ParseColor("#E0C068"));
                    case "ROCK":
                        return (Android.Graphics.Color.ParseColor("#B8A038"));
                    case "BUG":
                        return (Android.Graphics.Color.ParseColor("#A8B820"));
                    case "GHOST":
                        return (Android.Graphics.Color.ParseColor("#705898"));
                    case "STEEL":
                        return (Android.Graphics.Color.ParseColor("#B8B8D0"));
                    case "FIRE":
                        return (Android.Graphics.Color.ParseColor("#F08030"));
                    case "WATER":
                        return (Android.Graphics.Color.ParseColor("#6890F0"));
                    case "GRASS":
                        return (Android.Graphics.Color.ParseColor("#78C850"));
                    case "ELECTRIC":
                        return (Android.Graphics.Color.ParseColor("#F8D030"));
                    case "PSYCHIC":
                        return (Android.Graphics.Color.ParseColor("#F85888"));
                    case "ICE":
                        return (Android.Graphics.Color.ParseColor("#98D8D8"));
                    case "DRAGON":
                        return (Android.Graphics.Color.ParseColor("#7038F8"));
                    case "DARK":
                        return (Android.Graphics.Color.ParseColor("#705848"));
                    case "FAIRY":
                        return (Android.Graphics.Color.ParseColor("#FF65D5"));
                    default:
                        return Android.Graphics.Color.White;
                }
            }
            set
            {
                TypeColor = value;
            }
        }
    }
}