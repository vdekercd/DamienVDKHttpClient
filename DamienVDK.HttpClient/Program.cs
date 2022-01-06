// Refit
// Setup DI
var services = new ServiceCollection();
services.AddRefitClient<IGeneratedHttpClient>()
    .ConfigureHttpClient(httpClient =>
    {
        httpClient.BaseAddress = new Uri(Constants.BaseUrl);
    })
    .AddPolicyHandler(GetRetryPolicy());

// Get Service
var serviceProvider = services.BuildServiceProvider();
var httpService = serviceProvider.GetRequiredService<IGeneratedHttpClient>();

// Post
await httpService.PostTodoAsync(Todo.GetNewInstance("IGenerated Factory Todo"));

// Get
var result = await httpService.GetTodoAsync();
var resultAsJson = JsonConvert.SerializeObject(result);
Console.WriteLine(resultAsJson.BeautifyJson());

static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
{
    return HttpPolicyExtensions
        .HandleTransientHttpError()
        .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)
        .WaitAndRetryAsync(5, retryAttempt => TimeSpan.FromSeconds(3));
}