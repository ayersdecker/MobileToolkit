using Shiny.Beacons;

namespace Toolkit.Delegates
{
    public partial class MyBeaconMonitorDelegate : IBeaconMonitorDelegate
    {
        public MyBeaconMonitorDelegate()
        {
        }


        public Task OnStatusChanged(BeaconRegionState newStatus, BeaconRegion region)
        {
            return Task.CompletedTask;
        }
    }
}

#if ANDROID
public partial class MyBeaconMonitorDelegate : IAndroidForegroundServiceDelegate
{
    public void Configure(AndroidX.Core.App.NotificationCompat.Builder builder)
    {
        
    }
}
#endif
