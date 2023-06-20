using Plugin.Fingerprint;
using Plugin.Maui.Audio;
using Plugin.StoreReview;
using Prism.DryIoc;
using ZXing.Net.Maui.Controls;

namespace Toolkit
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp() => MauiApp
            .CreateBuilder()
            .UseMauiApp<App>()
            .UseBarcodeReader()
            .UseMauiCommunityToolkit()
            .UseShinyFramework(
                new DryIocContainerExtension(),
                prism => prism.OnAppStart("NavigationPage/MainPage")
            )
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            })
            .RegisterInfrastructure()
            .RegisterAppServices()
            .RegisterViews()
            .Build();


        static MauiAppBuilder RegisterAppServices(this MauiAppBuilder builder)
        {
            // register your own services here!
            return builder;
        }


        static MauiAppBuilder RegisterInfrastructure(this MauiAppBuilder builder)
        {
#if IOS && DEBUG
        global::Flipper.FlipperProxy.Shared.InitializeProxy();
#endif

            builder.Configuration.AddJsonPlatformBundle();
#if DEBUG
        builder.Logging.SetMinimumLevel(LogLevel.Trace);
        builder.Logging.AddDebug();
#endif
            var s = builder.Services;
            s.AddSingleton(AudioManager.Current);
            s.AddSingleton(CrossStoreReview.Current);
            s.AddSingleton(sp =>
            {
#if ANDROID
            CrossFingerprint.SetCurrentActivityResolver(() => sp.GetRequiredService<AndroidPlatform>().CurrentActivity);
#endif
                return CrossFingerprint.Current;
            });
            s.AddShinyService<AppStartup>();
            s.AddShinyService<AppSettings>();
            s.AddJob(typeof(Toolkit.Delegates.MyJob));
            s.AddBluetoothLE();
            s.AddBluetoothLeHosting();
            s.AddBeaconRanging();
            s.AddBeaconMonitoring<Toolkit.Delegates.MyBeaconMonitorDelegate>();
            s.AddGps<Toolkit.Delegates.MyGpsDelegate>();
            s.AddGeofencing<Toolkit.Delegates.MyGeofenceDelegate>();
            s.AddHttpTransfers<Toolkit.Delegates.MyHttpTransferDelegate>();
            s.AddNotifications();
            s.AddSpeechRecognition();
            s.AddDataAnnotationValidation();
            s.AddGlobalCommandExceptionHandler(new(
#if DEBUG
            ErrorAlertType.FullError
#else
                ErrorAlertType.NoLocalize
#endif
            ));
            return builder;
        }


        static MauiAppBuilder RegisterViews(this MauiAppBuilder builder)
        {
            var s = builder.Services;


            s.RegisterForNavigation<MainPage, MainViewModel>();
            return builder;
        }
    }
}