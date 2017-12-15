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
    [Activity(Label = "TimeDateSample")]
    public class TimeDateSample : Activity
    {
        Button btnGetTime, btnGetDate;
        TimePicker tp;
        TextView tvHour, tvMin,tvYear,tvMonth,tvDay;
        DatePicker dp;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.TimeDateSample);
            // Create your application here
            btnGetTime = FindViewById<Button>(Resource.Id.button_time);
            btnGetTime.Click += new EventHandler(btnGetTime_Click);
            tvHour = FindViewById<TextView>(Resource.Id.tvHour);
            tvMin = FindViewById<TextView>(Resource.Id.tvMin);
            tvHour.Text = DateTime.Now.Hour.ToString();
            tvMin.Text = DateTime.Now.Minute.ToString();
            tp = FindViewById<TimePicker>(Resource.Id.timePicker1);
            tp.TimeChanged += new EventHandler<TimePicker.TimeChangedEventArgs>(tp_TimeChanged);

            btnGetDate = FindViewById<Button>(Resource.Id.button_date);
            btnGetDate.Click += new EventHandler(btnGetDate_Click);
            tvYear = FindViewById<TextView>(Resource.Id.tvYear);
            tvMonth = FindViewById<TextView>(Resource.Id.tvMonth);
            tvDay = FindViewById<TextView>(Resource.Id.tvDay);
            tvYear.Text = DateTime.Now.Year.ToString();
            tvMonth.Text = DateTime.Now.Month.ToString();
            tvDay.Text = DateTime.Now.Day.ToString();
            dp = FindViewById<DatePicker>(Resource.Id.datePicker1);
            //dp.DateChanged += new EventHandler<DatePicker.DateChangedEventArgs>(dp_DateChanged);
            
        }

       

        private void dp_DateChanged(object sender, DatePicker.DateChangedEventArgs e)
        {
            tvYear.Text = e.Year.ToString();
            tvMonth.Text = e.MonthOfYear.ToString();
            tvDay.Text = e.DayOfMonth.ToString();
        }

        private void btnGetDate_Click(object sender, EventArgs e)
        {
            tvYear.Text = dp.Year.ToString();
            tvMonth.Text = (dp.Month +1).ToString();
            tvDay.Text = dp.DayOfMonth.ToString();
        }

        private void tp_TimeChanged(object sender, TimePicker.TimeChangedEventArgs e)
        {
            tvHour.Text = e.HourOfDay.ToString();
            tvMin.Text = e.Minute.ToString() + "time Changed"; 
            
        }

        private void btnGetTime_Click(object sender, EventArgs e)
        {
            tvHour.Text = tp.Hour.ToString();
            tvMin.Text = tp.Minute.ToString();
        }

    }
}