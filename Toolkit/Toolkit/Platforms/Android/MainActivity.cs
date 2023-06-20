using Android.App;
using Android.Content.PM;
using Android.OS;

namespace Toolkit
{
    [Activity(
        Theme = "@style/Maui.SplashTheme",
        MainLauncher = true,
        ConfigurationChanges =
            ConfigChanges.ScreenSize |
            ConfigChanges.Orientation |
            ConfigChanges.UiMode |
            ConfigChanges.ScreenLayout |
            ConfigChanges.SmallestScreenSize |
            ConfigChanges.Density
    )]
    [IntentFilter(
        new[] { ShinyNotificationIntents.NotificationClickAction }
    )]
    public class MainActivity : MauiAppCompatActivity
    {
#if DEBUG
    protected override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        Com.Facebook.Soloader.SoLoader.Init(this.ApplicationContext, false);
        var androidClient = Com.Facebook.Flipper.Android.AndroidFlipperClient.GetInstance(this.ApplicationContext);
        var flipperPlugin = new Com.Facebook.Flipper.Plugins.Inspector.InspectorFlipperPlugin(this.ApplicationContext, Com.Facebook.Flipper.Plugins.Inspector.DescriptorMapping.WithDefaults());
        androidClient.AddPlugin(flipperPlugin);
        androidClient.Start();
    }
    
#endif
    }
}