namespace Register.MobileApp.Markup;

using System;

using Register.MobileApp.Modules;

[AcceptEmptyServiceProvider]
[ContentProperty("Value")]
public sealed class ViewIdExtension : IMarkupExtension<ViewId>
{
    public ViewId Value { get; set; }

    public ViewId ProvideValue(IServiceProvider serviceProvider) => Value;

    object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider) => ProvideValue(serviceProvider);
}
