using System;
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using System.Globalization;
using System.Threading;

namespace PokemonTypeCalc
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        // Array of textviews that are inside tablelayout
        protected TextView[] textViewArray;        
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-GB");

            SetContentView(Resource.Layout.activity_main);
        
            int textViewCount = 36;
            textViewArray = new TextView[textViewCount];

            Spinner spinner = FindViewById<Spinner>(Resource.Id.spinnerPrimaryType);
            Spinner spinner2 = FindViewById<Spinner>(Resource.Id.spinnerSecondaryType);

            Button showDmgButton = FindViewById<Button>(Resource.Id.showDmgButton);
            TableLayout tableLayout1 = FindViewById<TableLayout>(Resource.Id.tableLayout1);
            
            // filling textViewArray with textviews from table layout
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
            // restoring saved strings when screen orientation is changed
            if (savedInstanceState != null)
            {
                string[] temp = savedInstanceState.GetStringArray("savedArray");
                int[] tempColors = savedInstanceState.GetIntArray("savedColors");
                
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

            
            ColorfulSpinnerAdapter adapter = new ColorfulSpinnerAdapter(this, Resource.Array.pokemonType, Resource.Layout.spinner_item);
            ColorfulSpinnerAdapter adapter2 = new ColorfulSpinnerAdapter(this, Resource.Array.pokemonType, Resource.Layout.spinner_item);
            spinner.Adapter = adapter;
            spinner2.Adapter = adapter2;

            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            string type1 = string.Empty;
            string type2 = string.Empty;
            TypeCalculator dmgCalc = new TypeCalculator();

            //
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
                        // fill textviews of tablelayout with empty strings if both chosen types are (none)
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
                        typez = dmgCalc.SortPkmnTypes(typez);
                        for(int d = 0, t = 0; d < textViewCount - 1; d += 2, t++)
                        {
                            textViewArray[d].Text = typez[t].TypeName;
                            textViewArray[d].SetBackgroundColor(typez[t].TypeColor);
                            textViewArray[d + 1].SetBackgroundColor(typez[t].TypeColor);
                            textViewArray[d + 1].Text = typez[t].DmgTaken.ToString() + "x";
                        }
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
                        typez = dmgCalc.SortPkmnTypes(typez);
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
                        typez = dmgCalc.SortPkmnTypes(typez);
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
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }
        protected override void OnSaveInstanceState(Bundle savedInstanceState)
        {
            base.OnSaveInstanceState(savedInstanceState);
            // save strings from tablelayout
            string[] temp = new string[36];
            int[] tempColors = new int[36];
            for (int d = 35; d >= 0; d--)
            {
                temp[d] = textViewArray[d].Text;
                if (textViewArray[d].Background is Android.Graphics.Drawables.ColorDrawable)
                 {
                 Android.Graphics.Drawables.ColorDrawable cd = (Android.Graphics.Drawables.ColorDrawable)textViewArray[d].Background;
                 int colorCode = cd.Color.ToArgb();
                 tempColors[d] = colorCode;
                 }
                
            }
            savedInstanceState.PutStringArray("savedArray", temp);
            savedInstanceState.PutIntArray("savedColors", tempColors);              
        }
    }
}

