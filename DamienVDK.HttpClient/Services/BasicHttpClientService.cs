namespace DamienVDKHttpClient.Services;

public class BasicHttpClientService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public BasicHttpClientService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<string> GetResultAsync()
    {
        var httpClient = _httpClientFactory.CreateClient();
        var response = await httpClient.GetAsync($"{Constants.BaseUrl}V1/Todo");
        Console.WriteLine(response.StatusCode);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }
}

