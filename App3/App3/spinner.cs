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

namespace App3
{
    [Activity(Label = "spinner")]
    public class spinner : Activity
    {
        Spinner state;
        TextView tvSp;
        ArrayAdapter<String> aas;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.spinner);

            state = FindViewById<Spinner>(Resource.Id.sp);
            tvSp = FindViewById<TextView>(Resource.Id.tvSp);
            aas = new ArrayAdapter<String>(this,
                Android.Resource.Layout.SimpleSpinnerDropDownItem);
            aas.Add(String.Empty);
            aas.Add("Alabama");
            aas.Add("Arizona");
            aas.Add("California");
            aas.Add("Tennessee");
            aas.Add("Texas");
            aas.Add("Washington");
            state.Adapter = aas;
            state.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(sp_ItemSelected);
            // Create your application here
        }

        private void sp_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            tvSp.Text = Convert.ToString(aas.GetItem(e.Position));
        }
    }
}