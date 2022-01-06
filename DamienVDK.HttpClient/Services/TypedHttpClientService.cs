namespace DamienVDKHttpClient.Services;

public class TypedHttpClientService
{
    private readonly HttpClient _httpClient;

    public TypedHttpClientService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri(Constants.BaseUrl);
    }

    public async Task PostTodoAsync(Todo todo)
    {
        var content = new StringContent(JsonConvert.SerializeObject(todo), Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync($"{Constants.BaseUrl}V1/Todo", content);
        Console.WriteLine($"Status code : {response.StatusCode}");
        response.EnsureSuccessStatusCode();
    }

    public async Task<string> GetTodoAsync()
    {
        var response = await _httpClient.GetAsync($"{Constants.BaseUrl}V1/Todo");
        Console.WriteLine($"Status code : {response.StatusCode}");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }
}

