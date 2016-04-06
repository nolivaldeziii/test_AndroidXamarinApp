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
        Bussiness.SimpleAndroidTTS SimpleTTS;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            //init assets
            var button_speak = FindViewById<Button>(Resource.Id.button_tts_speak);
            var edittext_tts_source = FindViewById<EditText>(Resource.Id.editText_tts_source_talk);
            var spinner_tts_lang_list = FindViewById<Spinner>(Resource.Id.spinner_tts_lang_list);

            //initialize tts
            SimpleTTS = new Bussiness.SimpleAndroidTTS(this);
            spinner_tts_lang_list.Adapter = SimpleTTS.GetLanguagesAdapter();

            //add set language
            spinner_tts_lang_list.ItemSelected += (object sender, AdapterView.ItemSelectedEventArgs e) =>
            {
                SimpleTTS.SetLanguage(sender, e);
            };

            //add functionality to speak button
            button_speak.Click += delegate { SimpleTTS.Speak(edittext_tts_source.Text); };

        }

        

        private readonly int MyCheckCode = 101, NeedLang = 103;
        protected override void OnActivityResult(int req, Result res, Intent data)
        {
            if (req == NeedLang)
            {
                // we need a new language installed
                var installTTS = new Intent();
                installTTS.SetAction(TextToSpeech.Engine.ActionInstallTtsData);
                StartActivity(installTTS);
            }
        }
    }
}

