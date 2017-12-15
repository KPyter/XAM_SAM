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
using Android.Util;

namespace App3
{
    [Activity(Label = "ckrb")]
    public class ckrb : Activity
    {
        Button btn;
        RadioButton rbf, rbm;
        CheckBox cb1, cb2, cb3;
        RadioGroup rg;
        TextView rbtv, cktv, rgtv;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ckrb);

            //RadioGroup 測試部分===========================================================================================================================
            rg = FindViewById<RadioGroup>(Resource.Id.radG1);
            //---------------------------------------------------
            //RadioGroup在Click的使用上無法觸發，
            //rg.Click += new EventHandler(rg_Click);
            //---------------------------------------------------

            rg.CheckedChange += new EventHandler<RadioGroup.CheckedChangeEventArgs>(rg_CheckedChange);
            rgtv = FindViewById<TextView>(Resource.Id.lay_rgTv);

            //動態產生3個RadioButton,一般來說宣告一個RadioGroup,動態產生其內部的選項較為彈性
            RadioButton rb1;
            for (int i = 0; i < 3; i++)
            {
                rb1 = new RadioButton(this);
                rb1.Text = "Item" + i.ToString();
                //rb1.Click += new EventHandler(rb1_Click);
                rg.AddView(rb1, i);
            }
            //RadioGroup 測試部分===========================================================================================================================

            //RadioButton 測試部分==========================================================================================================================

            rbf = FindViewById<RadioButton>(Resource.Id.radioButton1);
            rbf.Click += new EventHandler(rb_Click);
            rbm = FindViewById<RadioButton>(Resource.Id.radioButton2);
            rbm.Click += new EventHandler(rb_Click);
            rbtv = FindViewById<TextView>(Resource.Id.lay_rbtv);
            //RadioButton 測試部分==========================================================================================================================

            //CheckBox 測試部分=============================================================================================================================
            cb1 = FindViewById<CheckBox>(Resource.Id.checkBox1);
            cb2 = FindViewById<CheckBox>(Resource.Id.checkBox2);
            cb3 = FindViewById<CheckBox>(Resource.Id.checkBox3);
            cktv = FindViewById<TextView>(Resource.Id.lay_cktv);
            cktv.Text = "";
            btn = FindViewById<Button>(Resource.Id.cb_button);
            btn.Click += new EventHandler(cb_button_Click);
            //CheckBox 測試部分=============================================================================================================================
        }

        //CheckBox 測試部分=============================================================================================================================
        private void cb_button_Click(object sender, EventArgs e)
        {
            cktv.Text = "";
            if (cb1.Checked)
            {
                cktv.Text = cktv.Text + " " + cb1.Text;
            }
            if (cb2.Checked)
            {
                cktv.Text = cktv.Text + " " + cb2.Text;
            }
            if (cb3.Checked)
            {
                cktv.Text = cktv.Text + " " + cb3.Text;
            }
            if (!cb1.Checked && !cb2.Checked && !cb3.Checked)
            {
                cktv.Text = "";
            }

        }
        //CheckBox 測試部分=============================================================================================================================


        //RadioGroup 測試部分===========================================================================================================================
        //RadioGroup在Click的使用上無法觸發，此段程式碼經過測試後是無效用的
        //private void rg_Click(object sender, EventArgs e)
        //{
        //    Log.Info("TTTTTTTTTTTTTTTTTTTTTTTTTTT", sender.ToString());
        //}

        private void rg_CheckedChange(object sender, EventArgs e)
        {
            //RadioGroup 呼叫使用方法
            //RadioGroup radioGroup = FindViewById<RadioGroup>(Resource.Id.radioGroup1); 
            //RadioButton radioButton = FindViewById<RadioButton>(radioGroup.CheckedRadioButtonId);
            RadioButton rb1 = FindViewById<RadioButton>(((RadioGroup)sender).CheckedRadioButtonId);
            Log.Info("TTTTTTTTTTTTTTTTTTTTTTTTTTT", "hi checked" + rb1.Text);
            rgtv.Text = rb1.Text + " was clicked. --(CheckedChange)";
        }

        //本段程式碼為自訂RadioGroup內RadioButton的點擊(click)事件
        //會在CheckedChange事件後發生
        //private void rb1_Click(object sender, EventArgs e)
        //{
        //    RadioButton rb1 = (RadioButton)sender;
        //    rgtv.Text = rb1.Text + " was clicked.";
        //}
        //RadioGroup 測試部分===========================================================================================================================


        //RadioButton 測試部分==========================================================================================================================
        private void rb_Click(object sender, EventArgs e)
        {
            if (rbtv.Text != "")
            {
                rbtv.Text = ((RadioButton)sender).Text + rbtv.Text;
            }
            else
            {
                rbtv.Text = ((RadioButton)sender).Text;
            }

        }
        //RadioButton 測試部分==========================================================================================================================
    }

}