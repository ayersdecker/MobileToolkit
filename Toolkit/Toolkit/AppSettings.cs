namespace Toolkit
{
    //[Shiny.Stores.ObjectStoreBinder("secure")] // defaults to standard platform preferences
    // any public get/set values marked with [Reactive] will automatically be saved to the configured store
    public class AppSettings : ReactiveObject, IShinyStartupTask
    {
        [Reactive] public AppTheme CurrentTheme { get; set; } = AppTheme.Unspecified;


        public void Start()
        {
            Application.Current!.UserAppTheme = this.CurrentTheme;
            this.WhenAnyValue(x => x.CurrentTheme)
                .Skip(1)
                .Subscribe(x => this.CurrentTheme = x);
        }
    }
}