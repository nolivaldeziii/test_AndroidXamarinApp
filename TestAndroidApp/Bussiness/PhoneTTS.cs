using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Runtime;
using Android.Speech.Tts;

namespace Bussiness
{
    public class PhoneTTS : TextToSpeech.IOnInitListener
    {
        TextToSpeech speaker;
        string linescript;
        Java.Util.Locale language;

        public IntPtr Handle
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public PhoneTTS(Android.Content.Context a)
        {
            speaker = new TextToSpeech(a, this);
        }

        public void Speak(string text)
        {
            //speaker.Speak()
        }

        /// <summary>
        /// Set the language for the TTS engine
        /// </summary>
        /// <param name="lang">the language to be used (get it from GetVoices method</param>
        public void SetVoice(string lang)
        {
            //get the language by passing the string language
            //tip: use get voices method to get available strings
            Java.Util.Locale _lang = new Java.Util.Locale(lang);
            language = _lang;
        }

        public List<string> GetVoices()
        {
            var langAvailable = new List<string> { "Default" };
            var localesAvailable = Java.Util.Locale.GetAvailableLocales().ToList();
            foreach (var locale in localesAvailable)
            {
                var res = speaker.IsLanguageAvailable(locale);
                switch (res)
                {
                    case LanguageAvailableResult.Available:
                        langAvailable.Add(locale.DisplayLanguage);
                        break;
                    case LanguageAvailableResult.CountryAvailable:
                        langAvailable.Add(locale.DisplayLanguage);
                        break;
                    case LanguageAvailableResult.CountryVarAvailable:
                        langAvailable.Add(locale.DisplayLanguage);
                        break;
                }
            }
            langAvailable = langAvailable.OrderBy(t => t).Distinct().ToList();

            return langAvailable;
        }


        public void OnInit([GeneratedEnum] OperationResult status)
        {
            // if we get an error, default to the default language
            if (status == OperationResult.Error)
                speaker.SetLanguage(Java.Util.Locale.Default);
            // if the listener is ok, set the lang
            if (status == OperationResult.Success)
                speaker.SetLanguage(language);
        }

        public void Dispose()
        {
            speaker.Dispose();
        }
    }


}
