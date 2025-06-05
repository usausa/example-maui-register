#pragma warning disable IDE0130
// ReSharper disable once CheckNamespace
namespace Register.MobileApp;

using Foundation;

#pragma warning disable CA1711
[Register("AppDelegate")]
public class AppDelegate : MauiUIApplicationDelegate
{
    protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
}
#pragma warning restore CA1711
