namespace Register.MobileApp.Shell;

public static class ShellProperty
{
    // ------------------------------------------------------------
    // Shell
    // ------------------------------------------------------------

    public static readonly BindableProperty TitleProperty = BindableProperty.CreateAttached(
        "Title",
        typeof(string),
        typeof(ShellProperty),
        null,
        propertyChanged: PropertyChanged);

    public static string GetTitle(BindableObject bindable) => (string)bindable.GetValue(TitleProperty);

    public static void SetTitle(BindableObject bindable, string value) => bindable.SetValue(TitleProperty, value);

    private static void PropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var parent = ((ContentView)bindable).Parent;
        if (parent?.BindingContext is IShellControl shell)
        {
            UpdateShellControl(shell, bindable);
        }
    }

    public static void UpdateShellControl(IShellControl shell, BindableObject? bindable)
    {
        shell.Title = bindable is null ? string.Empty : GetTitle(bindable);
    }

    // ------------------------------------------------------------
    // Busy
    // ------------------------------------------------------------

    public static readonly BindableProperty BusyVisibleProperty = BindableProperty.CreateAttached(
        "BusyVisible",
        typeof(bool),
        typeof(ShellProperty),
        false,
        propertyChanged: HandleBusyVisibleChanged);

    public static readonly BindableProperty BusyViewProperty = BindableProperty.CreateAttached(
        "BusyView",
        typeof(IBusyView),
        typeof(ShellProperty),
        null,
        propertyChanged: HandleBusyViewChanged);

    public static bool GetBusyVisible(BindableObject obj) =>
        (bool)obj.GetValue(BusyVisibleProperty);

    public static void SetBusyVisible(BindableObject obj, bool value) =>
        obj.SetValue(BusyVisibleProperty, value);

    public static IBusyView? GetBusyView(BindableObject obj) =>
        (IBusyView?)obj.GetValue(BusyViewProperty);

    public static void SetBusyView(BindableObject obj, IBusyView? value) =>
        obj.SetValue(BusyViewProperty, value);

    private static void HandleBusyVisibleChanged(BindableObject bindable, object? oldValue, object? newValue)
    {
        if (oldValue == newValue)
        {
            return;
        }

        var view = GetBusyView(bindable);
        if (view is null)
        {
            return;
        }

        if (newValue is true)
        {
            view.Show();
        }
        else
        {
            view.Hide();
        }
    }

    private static void HandleBusyViewChanged(BindableObject bindable, object? oldValue, object? newValue)
    {
        if (oldValue == newValue)
        {
            return;
        }

        if (oldValue is IBusyView oldBusyView)
        {
            oldBusyView.Hide();
        }
        if (newValue is IBusyView newBusyView)
        {
            var visible = GetBusyVisible(bindable);
            if (visible)
            {
                newBusyView.Show();
            }
            else
            {
                newBusyView.Hide();
            }
        }
    }
}
