#pragma warning disable IDE0130
// ReSharper disable once CheckNamespace
namespace Register.MobileApp;

using Android.App;
using Android.Content.PM;
using Android.OS;

using AndroidX.Core.View;

using MauiComponents;

[Activity(
    Name = "Register.MobileApp.MainActivity",
    Theme = "@style/Maui.SplashTheme",
    MainLauncher = true,
    AlwaysRetainTaskState = true,
    LaunchMode = LaunchMode.SingleInstance,
    ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density,
    ScreenOrientation = ScreenOrientation.Landscape)]
public sealed class MainActivity : MauiAppCompatActivity
{
    protected override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);

        ActivityResolver.Init(this);

        if (Window is not null)
        {
            WindowCompat.SetDecorFitsSystemWindows(Window, false);
            using var windowInsetsController = new WindowInsetsControllerCompat(Window, Window.DecorView);
            windowInsetsController.Hide(WindowInsetsCompat.Type.SystemBars());
            windowInsetsController.SystemBarsBehavior = WindowInsetsControllerCompat.BehaviorShowTransientBarsBySwipe;
        }
    }
}
