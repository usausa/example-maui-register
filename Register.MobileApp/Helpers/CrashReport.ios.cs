namespace Register.MobileApp.Helpers;

public static partial class CrashReport
{
    private static partial void PlatformStart()
    {
        TaskScheduler.UnobservedTaskException += static (_, args) => LogException(args.Exception);
    }

    // TODO check
    private static partial string ResolveCrashLogPath() =>
        Path.Combine(FileSystem.Current.AppDataDirectory, "crash.log");

    // TODO check
    private static partial string ResolveOldCrashLogPath() =>
        Path.Combine(FileSystem.Current.AppDataDirectory, "crash.old.log");
}
