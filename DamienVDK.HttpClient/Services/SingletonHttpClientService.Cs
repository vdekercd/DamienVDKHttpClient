namespace DamienVDKHttpClient.Services;

public class SingletonHttpClientService
{
    private static readonly HttpClient _httpClient = new HttpClient();

    public async Task<string> GetResultAsync()
    {
        var response = await _httpClient.GetAsync($"{Constants.BaseUrl}V1/Todo");
        Console.WriteLine(response.StatusCode);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }
}

