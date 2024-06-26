using System.Net.Http.Headers;

namespace Project.Adopet.Console.Servicos.Http;

public class APIClientFactory : IHttpClientFactory
{
    private string url;

    public APIClientFactory(string url)
    {
        this.url = url;
    }

    public HttpClient CreateClient(string name)
    {
        HttpClient _client = new HttpClient();
        _client.DefaultRequestHeaders.Accept.Clear();
        _client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
        _client.BaseAddress = new Uri(url);
        return _client;
    }
}
