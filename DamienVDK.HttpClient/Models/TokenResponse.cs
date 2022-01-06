namespace DamienVDKHttpClient.Models;

public class TokenResponse
{
    public UserInfo UserInfo { get; set; }
}

public class UserInfo
{
    public string Token { get; set; }
}


