// Copyright (c) 2022 iyarashii @ https://github.com/iyarashii 
// Licensed under the GNU General Public License v3.0,
// go to https://github.com/iyarashii/PokemonTypeCalculator/blob/master/LICENSE for license details.

using Android.Content;
using Android.Views;
using Android.Widget;

namespace PokemonTypeCalc
{
    class ColorfulSpinnerAdapter : BaseAdapter
    {
        // field used for storing context
        private readonly Context mContext;
        // property used for storing resource layout id
        public int LayoutStyle { get; set; }
        // property used for storing array id
        public string[] PkmnTypeArray { get; set; }

        // constructor
        public ColorfulSpinnerAdapter(Context context, int textArrayResId, int textViewResId)
        {
            mContext = context;
            PkmnTypeArray = mContext.Resources.GetStringArray(textArrayResId);
            LayoutStyle = textViewResId;
        }
        public override int Count
        {
            get { return 19; }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return PkmnTypeArray[position];
        }
        public override long GetItemId(int position)
        {
            return position;
        }
        
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View v = convertView;

            if (v == null)
            {
                LayoutInflater vi = (LayoutInflater)mContext.GetSystemService(Context.LayoutInflaterService);
                v = vi.Inflate(LayoutStyle, null);
            }
            TextView tv = (TextView)v.FindViewById(Resource.Id.Kolor);
            tv.Text = PkmnTypeArray[position];
            // setting different color for each item in the spinner
            switch (tv.Text)
            {
                case "(none)":
                    tv.SetTextColor(Android.Graphics.Color.White);                    
                    break;
                case "NORMAL":
                    tv.SetTextColor(Android.Graphics.Color.ParseColor("#A8A878"));
                    break;
                case "FIGHTING":
                    tv.SetTextColor(Android.Graphics.Color.ParseColor("#C03028"));
                    break;
                case "FLYING":
                    tv.SetTextColor(Android.Graphics.Color.ParseColor("#A890F0"));
                    break;
                case "POISON":
                    tv.SetTextColor(Android.Graphics.Color.ParseColor("#A040A0"));
                    break;
                case "GROUND":
                    tv.SetTextColor(Android.Graphics.Color.ParseColor("#E0C068"));
                    break;
                case "ROCK":
                    tv.SetTextColor(Android.Graphics.Color.ParseColor("#B8A038"));
                    break;
                case "BUG":
                    tv.SetTextColor(Android.Graphics.Color.ParseColor("#A8B820"));
                    break;
                case "GHOST":
                    tv.SetTextColor(Android.Graphics.Color.ParseColor("#705898"));
                    break;
                case "STEEL":
                    tv.SetTextColor(Android.Graphics.Color.ParseColor("#B8B8D0"));
                    break;
                case "FIRE":
                    tv.SetTextColor(Android.Graphics.Color.ParseColor("#F08030"));
                    break;
                case "WATER":
                    tv.SetTextColor(Android.Graphics.Color.ParseColor("#6890F0"));
                    break;
                case "GRASS":
                    tv.SetTextColor(Android.Graphics.Color.ParseColor("#78C850"));
                    break;
                case "ELECTRIC":
                    tv.SetTextColor(Android.Graphics.Color.ParseColor("#F8D030"));
                    break;
                case "PSYCHIC":
                    tv.SetTextColor(Android.Graphics.Color.ParseColor("#F85888"));
                    break;
                case "ICE":
                    tv.SetTextColor(Android.Graphics.Color.ParseColor("#98D8D8"));
                    break;
                case "DRAGON":
                    tv.SetTextColor(Android.Graphics.Color.ParseColor("#7038F8"));
                    break;
                case "DARK":
                    tv.SetTextColor(Android.Graphics.Color.ParseColor("#705848"));
                    break;
                case "FAIRY":
                    tv.SetTextColor(Android.Graphics.Color.ParseColor("#FF65D5"));
                    break;
            }
            return v;
        }         
    }
}