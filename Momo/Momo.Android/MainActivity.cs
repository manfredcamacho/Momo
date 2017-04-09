using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;


namespace Momo.Droid
{
    [Activity(Label = "Momo", Icon = "@drawable/icon", Theme = "@style/MainTheme", ScreenOrientation = ScreenOrientation.Portrait, MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected  override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            /* Statusbar transparente y agregar la imagen de fondo en toda la pantalla */
            Window.AddFlags(WindowManagerFlags.TranslucentNavigation);
            Window.SetBackgroundDrawableResource(Resource.Drawable.background);
            SetStatusBarColor(Android.Graphics.Color.Transparent);
            //Para que la statusbar tenga una opacidad se agrega esta linea a styles.xml
            //<item name="android:windowTranslucentStatus">true</item>

            /* END statusbar */

            LoadApplication(new App());
        }
    }
}

