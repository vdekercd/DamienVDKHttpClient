// Disposable
// Setup DI
var services = new ServiceCollection();
services.AddRefitClient<IGeneratedHttpClientService>()
    .ConfigureHttpClient(httpClient =>
    {
        httpClient.BaseAddress = new Uri(Constants.BaseUrl);
    })
    .AddPolicyHandler(GetRetryPolicy())
    .AddHttpMessageHandler<TokenHandler>();

// Get Service
var serviceProvider = services.BuildServiceProvider();
var httpService = serviceProvider.GetRequiredService<IGeneratedHttpClientService>();

// Post
await httpService.PostTodoAsync(Todo.GetNewInstance("Generated"));

// Get
var result = await httpService.GetTodoAsync();
var resultAsString = JsonConvert.SerializeObject(result);
Console.WriteLine(resultAsString);

static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
{
    return HttpPolicyExtensions
        .HandleTransientHttpError()
        .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)
        .WaitAndRetryAsync(5, retryAttempt => TimeSpan.FromSeconds(3));
}