// Copyright (c) 2022 iyarashii @ https://github.com/iyarashii 
// Licensed under the GNU General Public License v3.0,
// go to https://github.com/iyarashii/Gw2Sharp/blob/master/LICENSE for license details.

using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using System.Globalization;
using System.Threading;

namespace PokemonTypeCalc
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        // Array of TextViews that are inside TableLayout
        protected TextView[] textViewArray;
        // private field used for storing id of selected radio button sorting method
        private int selectedSorting = 0;
        // private field used for comparing stored id to check which sorting mode is chosen
        private IMenu menu;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);        
            SetContentView(Resource.Layout.activity_main);

            // changing CultureInfo to en-GB to show decimal point as "." instead of ","
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-GB");

            // creating an array of 36 TextViews used for storing every cell from TableLayout
            int textViewCount = 36;
            textViewArray = new TextView[textViewCount];

            // assigning resources to local variables
            Spinner spinner = FindViewById<Spinner>(Resource.Id.spinnerPrimaryType);
            Spinner spinner2 = FindViewById<Spinner>(Resource.Id.spinnerSecondaryType);
            Button showDmgButton = FindViewById<Button>(Resource.Id.showDmgButton);
            TableLayout tableLayout1 = FindViewById<TableLayout>(Resource.Id.tableLayout1);
            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            // filling textViewArray with TextViews from TableLayout
            int y = 0;
            for (int i = 1; i < tableLayout1.ChildCount; i++)
            {
                View child = tableLayout1.GetChildAt(i);

                if (child is TableRow row)
                {
                    for (int x = 0; x < row.ChildCount; x++)
                    {
                        View view = row.GetChildAt(x);
                        textViewArray[y] = (TextView)view;
                        ++y;
                    }
                }
            }
            // restoring saved data when screen orientation is changed
            if (savedInstanceState != null)
            {
                string[] temp = savedInstanceState.GetStringArray("savedArray");
                int[] tempColors = savedInstanceState.GetIntArray("savedColors");
                selectedSorting = savedInstanceState.GetInt("savedSorting");
                
                for (int d = 0; d < 36; d++)
                {
                    textViewArray[d].Text = temp[d];
                    Android.Graphics.Color backgroundColor = new Android.Graphics.Color(tempColors[d]);
                    textViewArray[d].SetBackgroundColor(backgroundColor);                    
                }
                if (temp[0] != "")
                {
                    tableLayout1.SetColumnCollapsed(0, false);
                    tableLayout1.SetColumnCollapsed(1, false);
                }
            }
            // creating 2 custom spinner adapters and assigning them to the primary and secondary pokemon type spinners
            ColorfulSpinnerAdapter adapter = new ColorfulSpinnerAdapter(this, Resource.Array.pokemonType, Resource.Layout.spinner_item);
            ColorfulSpinnerAdapter adapter2 = new ColorfulSpinnerAdapter(this, Resource.Array.pokemonType, Resource.Layout.spinner_item);
            spinner.Adapter = adapter;
            spinner2.Adapter = adapter2;
            
            // creating local variables used for filling TextViews
            string type1 = string.Empty;
            string type2 = string.Empty;
            TypeCalculator dmgCalc = new TypeCalculator();       
            PkmnType[] typez;
            PkmnType[] typez2;

            showDmgButton.Click += (sender, e) =>
            {
                // checks spinner content
                type1 = spinner.SelectedItem.ToString();
                type2 = spinner2.SelectedItem.ToString();
                // check if one of chosen types is (none)
                if (string.Equals(type1, Resources.GetString(Resource.String.notype)))
                {
                    if (string.Equals(type2, Resources.GetString(Resource.String.notype)))
                    {
                        // fill TextViews of TableLayout with empty strings if both chosen types are (none)
                        for (int d = 0; d < textViewCount; d++)
                        {
                            textViewArray[d].Text = "";
                        }
                        // hide table
                        tableLayout1.SetColumnCollapsed(0, true);
                        tableLayout1.SetColumnCollapsed(1, true);
                    }
                    else
                    {
                        // if the secondary type is not (none) check type and start filling table with sorted values
                        typez = dmgCalc.CheckType(type2);
                        // check selected sorting option
                        if(selectedSorting == menu.GetItem(2).ItemId)
                        {
                            typez = dmgCalc.SortPkmnTypes(typez);
                        }
                        else if(selectedSorting == menu.GetItem(1).ItemId)
                        {
                            typez = dmgCalc.SortPkmnTypesByName(typez);
                        }
                        for(int d = 0, t = 0; d < textViewCount - 1; d += 2, t++)
                        {
                            textViewArray[d].Text = typez[t].TypeName;
                            textViewArray[d].SetBackgroundColor(typez[t].TypeColor);
                            textViewArray[d + 1].SetBackgroundColor(typez[t].TypeColor);
                            textViewArray[d + 1].Text = typez[t].DmgTaken.ToString() + "x";
                        }
                        // show table
                        tableLayout1.SetColumnCollapsed(0, false);
                        tableLayout1.SetColumnCollapsed(1, false);
                    }
                }
                else
                {
                    // if secondary type equals (none) or both types are the same check only primary type dmg multipliers
                    if (string.Equals(type2, Resources.GetString(Resource.String.notype)) || string.Equals(type2, type1))
                    {
                        typez = dmgCalc.CheckType(type1);
                        // check selected sorting option
                        if (selectedSorting == menu.GetItem(2).ItemId)
                        {
                            typez = dmgCalc.SortPkmnTypes(typez);
                        }
                        else if (selectedSorting == menu.GetItem(1).ItemId)
                        {
                            typez = dmgCalc.SortPkmnTypesByName(typez);
                        }
                        for (int d = 0, t = 0; d < textViewCount - 1; d += 2, t++)
                        {
                            textViewArray[d].Text = typez[t].TypeName;
                            textViewArray[d].SetBackgroundColor(typez[t].TypeColor);
                            textViewArray[d + 1].SetBackgroundColor(typez[t].TypeColor);
                            textViewArray[d + 1].Text = typez[t].DmgTaken.ToString() + "x";
                        }
                    }
                    else
                    {
                        // if both types are different and none of them equals (none) check both types and 
                        // multiply primary type multipliers by secondary type multipliers
                        typez = dmgCalc.CheckType(type1);
                        typez2 = dmgCalc.CheckType(type2);
                        for (int i = 0; i < 18; ++i)
                        {
                            typez[i].DmgTaken *= typez2[i].DmgTaken;
                        }
                        // check selected sorting option
                        if (selectedSorting == menu.GetItem(2).ItemId)
                        {
                            typez = dmgCalc.SortPkmnTypes(typez);
                        }
                        else if (selectedSorting == menu.GetItem(1).ItemId)
                        {
                            typez = dmgCalc.SortPkmnTypesByName(typez);
                        }
                        for (int d = 0, t = 0; d < textViewCount - 1; d += 2, t++)
                        {
                            textViewArray[d].Text = typez[t].TypeName;
                            textViewArray[d].SetBackgroundColor(typez[t].TypeColor);
                            textViewArray[d + 1].SetBackgroundColor(typez[t].TypeColor);
                            textViewArray[d + 1].Text = typez[t].DmgTaken.ToString() + "x";
                        }
                    }
                    tableLayout1.SetColumnCollapsed(0, false);
                    tableLayout1.SetColumnCollapsed(1, false);
                }
            };

		}
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            this.menu = menu;
            // check if some sorting method was chosen before rotating screen if not set sorting method to default(by Multiplier)
            switch (selectedSorting)
            {
                case 0:
                    menu.GetItem(2).SetChecked(true);
                    selectedSorting = menu.GetItem(2).ItemId;
                    break;
                default:
                    menu.FindItem(selectedSorting).SetChecked(true);
                    break;
            }
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            // check and store selected sorting method button id, if id matches header id do nothing
            switch (id)
            {
                case Resource.Id.sortBy:
                    return true;
                default:
                    item.SetChecked(true);
                    selectedSorting = item.ItemId;
                    break;               
            }
            return base.OnOptionsItemSelected(item);
        }

        protected override void OnSaveInstanceState(Bundle outState)
        {
            base.OnSaveInstanceState(outState);
            // save data from TableLayout
            string[] temp = new string[36];
            int[] tempColors = new int[36];
            for (int d = 35; d >= 0; d--)
            {
                temp[d] = textViewArray[d].Text;
                Android.Graphics.Drawables.ColorDrawable backgroundColor = textViewArray[d].Background as Android.Graphics.Drawables.ColorDrawable;                
                if (backgroundColor != null)
                {                 
                 int colorCode = backgroundColor.Color.ToArgb();
                 tempColors[d] = colorCode;
                 }
                
            }
            // save selected sorting method button id
            int radioId = selectedSorting; 
            outState.PutStringArray("savedArray", temp);
            outState.PutIntArray("savedColors", tempColors);     
            outState.PutInt("savedSorting", radioId);            
        }
    }
}

