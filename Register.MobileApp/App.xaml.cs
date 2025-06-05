namespace Register.MobileApp;

using Microsoft.Extensions.DependencyInjection;

using Register.MobileApp.Helpers;
using Register.MobileApp.Modules;

public sealed partial class App
{
    private readonly IServiceProvider serviceProvider;

    public App(IServiceProvider serviceProvider, ILogger<App> log)
    {
        this.serviceProvider = serviceProvider;

        // Default theme light
        Current!.UserAppTheme = AppTheme.Light;

        InitializeComponent();

        // Start
        log.InfoApplicationStart(typeof(App).Assembly.GetName().Version, Environment.Version);
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        return new Window(serviceProvider.GetRequiredService<MainPage>());
    }

    // ReSharper disable once AsyncVoidMethod
    protected override async void OnStart()
    {
        // Report previous exception
        await CrashReport.ShowReport();

        // Permissions
        await Permissions.RequestCameraAsync();

        // Navigate
        var navigator = serviceProvider.GetRequiredService<INavigator>();
        await navigator.ForwardAsync(ViewId.Menu);
    }
}
