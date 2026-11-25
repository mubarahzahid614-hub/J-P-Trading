namespace JPTrading.Client.Services;

public class AppUser
{
    public string FullName { get; set; } = "";
    public string Email { get; set; } = "";
    public string Country { get; set; } = "";
    public string Role { get; set; } = "Buyer";
}

public class AuthService
{
    private readonly List<(AppUser User, string Password)> _users = new()
    {
        (new AppUser { FullName = "Admin", Email = "admin@jptrading.com", Country = "Japan", Role = "Admin" }, "admin123"),
        (new AppUser { FullName = "Demo Buyer", Email = "buyer@jptrading.com", Country = "Pakistan", Role = "Buyer" }, "buyer123")
    };

    public AppUser? CurrentUser { get; private set; }
    public bool IsLoggedIn => CurrentUser != null;
    public event Action? OnChange;

    public bool Login(string email, string password)
    {
        var found = _users.FirstOrDefault(u =>
            u.User.Email.Equals(email, StringComparison.OrdinalIgnoreCase) && u.Password == password);
        if (found.User == null) return false;
        CurrentUser = found.User;
        OnChange?.Invoke();
        return true;
    }

    public bool Register(string fullName, string email, string country, string password)
    {
        if (_users.Any(u => u.User.Email.Equals(email, StringComparison.OrdinalIgnoreCase)))
            return false;
        _users.Add((new AppUser { FullName = fullName, Email = email, Country = country, Role = "Buyer" }, password));
        return true;
    }

    public void Logout()
    {
        CurrentUser = null;
        OnChange?.Invoke();
    }
}