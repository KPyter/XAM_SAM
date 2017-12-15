using Android.App;
using Android.Widget;
using Android.OS;
using System;
using Android.Content;

namespace App3
{
    [Activity(Label = "App3", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            Button button = FindViewById<Button>(Resource.Id.button_spinner);
            button.Click += new EventHandler(buttonSpinner_Click);
            button = FindViewById<Button>(Resource.Id.button_ckrb);
            button.Click += new EventHandler(buttonCkRb_Click);
            button = FindViewById<Button>(Resource.Id.button_timeDate);
            button.Click += new EventHandler(buttonTimeDate_Click);
        }

        private void buttonTimeDate_Click(object sender, EventArgs e)
        {
            Intent i = new Intent();
            i.SetClass(this, typeof(TimeDateSample));
            i.AddFlags(ActivityFlags.NewTask);
            StartActivity(i);
            //throw new NotImplementedException();
        }

        private void buttonCkRb_Click(object sender, EventArgs e)
        {
            Intent i = new Intent();
            i.SetClass(this, typeof(ckrb));
            i.AddFlags(ActivityFlags.NewTask);
            StartActivity(i);
        }

        private void buttonSpinner_Click(object sender, EventArgs e)
        {
            Intent i = new Intent();
            i.SetClass(this, typeof(spinner));
            i.AddFlags(ActivityFlags.NewTask);
            StartActivity(i);

        }
    }
}

