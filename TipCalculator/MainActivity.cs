using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace TipCalculator
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : FormsAppCompatActivity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar_Layout;
            ToolbarResource = Resource.Layout.Toolbar_Layout;

            base.OnCreate(savedInstanceState);
            Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }
	}
}

