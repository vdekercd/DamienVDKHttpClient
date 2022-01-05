namespace DamienVDKHttpClient.Services;

public class DisposableHttpClientService
{
    public async Task<string> GetResultAsync()
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

