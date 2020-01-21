using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TranslateExtension
{
    [ContentProperty("Text")]
    class Translate : IMarkupExtension
    {
        const string ResourceId = "TipCalculator.Resources.translations.AppTranslations";

        private static ResourceManager _resourceManager;

        private static CultureInfo _resourceCulture;

        public string Text { get; set; }

        public static ResourceManager ResourceManager
        {
            get
            {
                if (_resourceManager is null)
                {
                    var temp = new ResourceManager(ResourceId, typeof(Translate).Assembly);
                    _resourceManager = temp;
                }
                return _resourceManager;
            }
        }

        public static CultureInfo Culture
        {
            get
            {
                var androidLocale = Java.Util.Locale.Default;
                _resourceCulture = new CultureInfo(androidLocale.ToString().Replace("_", "-"));
                return _resourceCulture;
            }
            set
            {
                _resourceCulture = value;
            }
        }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Text is null)
                return null;

            _resourceManager = new ResourceManager(ResourceId, typeof(Translate).Assembly);
            return _resourceManager.GetString(Text, Culture);
        }
    }
}