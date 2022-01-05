//// Named
//// Setup DI
//var services = new ServiceCollection();
//services.AddHttpClient(Constants.HttpClientName, httpClient =>
//{
//    httpClient.BaseAddress = new Uri(Constants.BaseUrl);
//});
//services.AddTransient<NamedHttpClientService>();
//// Call http service
//var serviceProvider = services.BuildServiceProvider();
//var httpService = serviceProvider.GetRequiredService<NamedHttpClientService>();
//var result = await httpService.GetResultAsync();
//Console.WriteLine(result.BeautifyJson());

//// Basic
//// Setup DI
//var services = new ServiceCollection();
//services.AddHttpClient();
//services.AddTransient<BasicHttpClientService>();
//// Call http service
//var serviceProvider = services.BuildServiceProvider();
//var httpService = serviceProvider.GetRequiredService<BasicHttpClientService>();
//var result = await httpService.GetResultAsync();
//Console.WriteLine(result.BeautifyJson());

//// Singleton
//// Setup DI
//var services = new ServiceCollection();
//services.AddTransient<SingletonHttpClientService>();
//// Call http service
//var serviceProvider = services.BuildServiceProvider();
//var httpService = serviceProvider.GetRequiredService<SingletonHttpClientService>();
//var result = await httpService.GetResultAsync();
//Console.WriteLine(result.BeautifyJson());

//// Disposable
//// Setup DI
//var services = new ServiceCollection();
//services.AddTransient<DisposableHttpClientService>();
//// Call http service
//var serviceProvider = services.BuildServiceProvider();
//var httpService = serviceProvider.GetRequiredService<DisposableHttpClientService>();
//var result = await httpService.GetResultAsync();
//Console.WriteLine(result.BeautifyJson());