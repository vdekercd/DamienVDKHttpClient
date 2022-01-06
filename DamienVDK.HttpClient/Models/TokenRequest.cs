namespace DamienVDKHttpClient.Models;

internal class TokenRequest
{
    [JsonProperty("username")]
    public string Username;
    [JsonProperty("password")]
    public string Password;
}

