namespace DamienVDKHttpClient.Services;

public class DisposableHttpClientService
{
    public async Task PostTodoAsync(Todo todo)
    {
        using (var client = new HttpClient())
        {
            var content = new StringContent(JsonConvert.SerializeObject(todo), Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"{Constants.BaseUrl}V1/Todo", content);
            Console.WriteLine($"Status code : {response.StatusCode}");
            response.EnsureSuccessStatusCode();
        }
    }

    public async Task<string> GetTodoAsync()
    {
        using (var client = new HttpClient())
        {
            var response = await client.GetAsync($"{Constants.BaseUrl}V1/Todo");
            Console.WriteLine($"Status code : {response.StatusCode}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync(); 
        }
    }
}

