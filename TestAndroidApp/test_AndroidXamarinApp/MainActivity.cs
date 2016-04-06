using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using Android.Speech.Tts;

namespace test_AndroidXamarinApp
{
    [Activity(Label = "test_AndroidXamarinApp", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            //Button button = FindViewById<Button>(Resource.Id.MyButton);
    
            //button.Click += delegate { button.Text = string.Format("{0} clicks!", count++); };

            //get available voices
            
            // Bussiness.PhoneTTS PhoneVoice = new Bussiness.PhoneTTS(this, x);
            ListView TtsList = FindViewById<ListView>(Resource.Id.listView_tts_available);
            
            
        }
    }
}

