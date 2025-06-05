namespace Register.MobileApp;

public static class Permissions
{
    public static async ValueTask<bool> RequestCameraAsync()
    {
        var status = await Microsoft.Maui.ApplicationModel.Permissions.RequestAsync<Microsoft.Maui.ApplicationModel.Permissions.Camera>();
        return status is PermissionStatus.Granted;
    }
}
