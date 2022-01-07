namespace DamienVDKHttpClient.Services;

public class NamedHttpClientService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public NamedHttpClientService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task PostTodoAsync(Todo todo)
    {
        var httpClient = _httpClientFactory.CreateClient(Constants.HttpClientName);
        var content = new StringContent(JsonConvert.SerializeObject(todo), Encoding.UTF8, "application/json");
        var response = await httpClient.PostAsync($"V1/Todo", content);
        Console.WriteLine($"Status code : {response.StatusCode}");
        response.EnsureSuccessStatusCode();
    }

    public async Task<string> GetTodoAsync()
    {
        var httpClient = _httpClientFactory.CreateClient(Constants.HttpClientName);
        var response = await httpClient.GetAsync("V1/Todo");
        Console.WriteLine(response.StatusCode);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }
}