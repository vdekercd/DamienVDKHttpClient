namespace DamienVDKHttpClient.Extensions;

public static class StringExtensions
{
    public static string BeautifyJson(this string @this)
    {
        JToken parsedJson = JToken.Parse(@this);
        return parsedJson.ToString(Formatting.Indented);
    }
}

