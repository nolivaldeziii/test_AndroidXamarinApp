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
            var button_tts_force = FindViewById<Button>(Resource.Id.button_tts_force);
            var button_ttsf_english = FindViewById<Button>(Resource.Id.button_ttsf_english);
            //initialize tts
            SimpleTTS = new Bussiness.SimpleAndroidTTS(this);
            spinner_tts_lang_list.Adapter = SimpleTTS.GetLanguagesAdapter();

            SimpleTTS.Settings.BypasslanguageCheck = true;

            //add set language
            spinner_tts_lang_list.ItemSelected += (object sender, AdapterView.ItemSelectedEventArgs e) =>
            {
                SimpleTTS.SetLanguage(sender, e);
            };

            button_tts_force.Click += delegate
            {
                SimpleTTS.SetLanguage(Java.Util.Locale.Japanese);
                SimpleTTS.Speak("日本語を話します");
            };

            button_ttsf_english.Click += delegate
            {
                SimpleTTS.SetLanguage(Java.Util.Locale.English);
                SimpleTTS.Speak("I will now speak in english!");

                SetContentView(Resource.Layout.layout1);
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

