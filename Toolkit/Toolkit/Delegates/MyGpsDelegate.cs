using Shiny.Locations;

namespace Toolkit.Delegates
{
    public partial class MyGpsDelegate : IGpsDelegate
    {
        public MyGpsDelegate()
        {

        }


        public Task OnReading(GpsReading reading)
        {
            throw new NotImplementedException();
        }
    }
}

#if ANDROID
public partial class MyGpsDelegate : IAndroidForegroundServiceDelegate
{
    public void Configure(AndroidX.Core.App.NotificationCompat.Builder builder)
    {
        
    }
}
#endif
