namespace Register.MobileApp.Services;

public sealed class ApiContext
{
    public Uri? BaseAddress { get; set; }

    public string Token { get; set; } = default!;
}
