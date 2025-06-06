// ReSharper disable once CheckNamespace
namespace Register.MobileApp.Platforms.Android.Helpers;

public static class JavaObjectExtensions
{
    public static bool IsDisposed(this Java.Lang.Object obj)
    {
        return obj.Handle == IntPtr.Zero;
    }
}
