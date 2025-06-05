namespace Register.MobileApp.Components.Storage;

#pragma warning disable CA1822
public sealed partial class StorageManager
{
    private partial string ResolvePublicFolder() => Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
}
#pragma warning restore CA1822
