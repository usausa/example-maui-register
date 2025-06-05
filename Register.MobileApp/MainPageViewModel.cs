namespace Register.MobileApp;

using Register.MobileApp.Shell;

[ObservableGeneratorOption(Reactive = true, ViewModel = true)]
public sealed partial class MainPageViewModel : ExtendViewModelBase, IShellControl, IAppLifecycle
{
    private readonly IScreen screen;

    public INavigator Navigator { get; }

    public IBusyView BusyView { get; }

    [ObservableProperty]
    public partial string Title { get; set; } = default!;

    //--------------------------------------------------------------------------------
    // Constructor
    //--------------------------------------------------------------------------------

    public MainPageViewModel(
        INavigator navigator,
        IBusyView progressView,
        IScreen screen)
    {
        Navigator = navigator;
        BusyView = progressView;
        this.screen = screen;
    }

    //--------------------------------------------------------------------------------
    // Lifecycle
    //--------------------------------------------------------------------------------

    public void OnCreated()
    {
        screen.EnableDetectScreenState(true);
    }

    public void OnActivated()
    {
        // TODO Device activate
    }

    public void OnDeactivated()
    {
        // TODO Device deactivate
    }

    public void OnStopped()
    {
    }

    public void OnResumed()
    {
    }

    public void OnDestroying()
    {
    }
}
