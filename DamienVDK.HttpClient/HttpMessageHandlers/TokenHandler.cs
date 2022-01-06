namespace DamienVDKHttpClient.HttpMessageHandlers;

public class TokenHandler : DelegatingHandler
{
    private static string Token = string.Empty;

    // Must be in settings
    private const string ENDPOINT = "Token_Endpoint";
    private const string USERNAME = "USERNAME";
    private const string PASSWORD = "*****";

    private readonly IServiceProvider _serviceProvider;

    public TokenHandler(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {     
        await AddOrUpdateTokenInContent(request, cancellationToken);
        var response = await base.SendAsync(request, cancellationToken);

        if (response.StatusCode != HttpStatusCode.Forbidden) return response;

        await ResetToken(request, cancellationToken);
        await AddOrUpdateTokenInContent(request, cancellationToken);

        response = await base.SendAsync(request, cancellationToken);
        return response;
    }

    private async Task AddOrUpdateTokenInContent(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var json = request?.Content != null ? await request.Content.ReadAsStringAsync(cancellationToken) : "{}";
        dynamic content = JsonConvert.DeserializeObject(json) ?? new();
        if (!string.IsNullOrEmpty(Token)) content.token = Token;
        request!.Content = new StringContent(JsonConvert.SerializeObject(content), System.Text.Encoding.UTF8, "application/json");
    }

    private async Task ResetToken(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var getTokenRequest = new HttpRequestMessage(HttpMethod.Post, new Uri(ENDPOINT));
        var requestLoginBody = new TokenRequest() { Username = USERNAME, Password = PASSWORD };
        getTokenRequest.Content = new StringContent(JsonConvert.SerializeObject(requestLoginBody), System.Text.Encoding.UTF8, "application/json");

        var loginResponse = await base.SendAsync(getTokenRequest, cancellationToken);
        loginResponse.EnsureSuccessStatusCode();

        Token = JsonConvert.DeserializeObject<TokenResponse>(await loginResponse.Content.ReadAsStringAsync(cancellationToken))?.UserInfo?.Token!;
    }       
}

