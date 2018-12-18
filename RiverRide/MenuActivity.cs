

using System;
using Android.Runtime;
using Android.App;
using Android.OS;

namespace RiverRide
{
    [Activity(Label = "Menu"),
        Android.Runtime.Register("android/widget/Button", DoNotGenerateAcw = true)]
    public class MenuActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            //WRRRRR próbowałem tu na różne sposoby zrobić menu ;_;
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.layout1);
            
           //Button playBTN = FindViewById<Button>(Resource.Layout.layout1.plaxyBTN);
            //playBTN.Click += delegate {
               // playBTN.Text = string.Format("{0} clicks!", count++);
            //};

        }
        void OnButtonClicked(object sender, EventArgs args)
        {

        }
    }
}