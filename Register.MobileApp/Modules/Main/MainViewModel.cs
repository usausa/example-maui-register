namespace Register.MobileApp.Modules.Main;

public sealed partial class MainViewModel : AppViewModelBase
{
    [ObservableProperty]
    public partial string Flavor { get; set; }

    [ObservableProperty]
    public partial Version Version { get; set; }

    public IObserveCommand ForwardCommand { get; }

    public MainViewModel(IAppInfo appInfo)
    {
        Flavor = !String.IsNullOrEmpty(Variants.Flavor) ? Variants.Flavor : "Unknown";
        Version = appInfo.Version;

        ForwardCommand = MakeAsyncCommand<ViewId>(x => Navigator.ForwardAsync(x));
    }
}
