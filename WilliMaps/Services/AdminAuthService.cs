namespace WilliMaps.Services;

public class AdminAuthService
{
    private const string AdminUsername = "admin";
    private const string AdminPassword = "root";

    public bool IsLoggedIn { get; private set; }
    public string? CurrentUser { get; private set; }

    public bool TryLogin(string? username, string? password)
    {
        var isValid = string.Equals(username, AdminUsername, StringComparison.Ordinal)
            && string.Equals(password, AdminPassword, StringComparison.Ordinal);

        if (!isValid)
        {
            IsLoggedIn = false;
            CurrentUser = null;
            return false;
        }

        IsLoggedIn = true;
        CurrentUser = username;
        return true;
    }

    public void Logout()
    {
        IsLoggedIn = false;
        CurrentUser = null;
    }
}
