namespace Register.MobileApp.Modules;

using System.ComponentModel.DataAnnotations;

using Smart.Mvvm.Resolver;

using Register.MobileApp.Shell;

[ObservableGeneratorOption(Reactive = true, ViewModel = true)]
public abstract class AppViewModelBase : ExtendViewModelBase, IValidatable, INavigatorAware, INavigationEventSupport, INotifySupportAsync<ShellEvent>
{
    private List<ValidationResult>? validationResults;

    private IAccessor? propertyAccessor;

    public INavigator Navigator { get; set; } = default!;

    protected override void Dispose(bool disposing)
    {
        base.Dispose(disposing);

        System.Diagnostics.Debug.WriteLine($"{GetType()} is Disposed");
    }

    public void Validate(string name)
    {
        propertyAccessor ??= AccessorRegistry.FindAccessor(GetType());
        if (propertyAccessor is null)
        {
            throw new InvalidOperationException($"Accessor is not supported. type=[{GetType()}]");
        }

        var value = propertyAccessor.GetValue(this, name);
        var context = new ValidationContext(this, DefaultResolveProvider.Default, null)
        {
            MemberName = name
        };
        validationResults ??= new List<ValidationResult>();

        if (!Validator.TryValidateProperty(value, context, validationResults))
        {
            Errors.AddError(name, validationResults[0].ErrorMessage!);
        }

        validationResults.Clear();
    }

    public virtual void OnNavigatingFrom(INavigationContext context)
    {
    }

    public virtual void OnNavigatingTo(INavigationContext context)
    {
    }

    public virtual void OnNavigatedTo(INavigationContext context)
    {
    }

    public async Task NavigatorNotifyAsync(ShellEvent parameter)
    {
        using (BusyState.Begin())
        {
            var task = parameter switch
            {
                ShellEvent.Back => OnNotifyBackAsync(),
                _ => Task.CompletedTask
            };

            await task.ConfigureAwait(true);
        }
    }

    protected virtual Task OnNotifyBackAsync() => Task.CompletedTask;
}
