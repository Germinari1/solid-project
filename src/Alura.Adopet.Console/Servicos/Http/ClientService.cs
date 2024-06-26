using Project.Adopet.Console.Modelos;
using Project.Adopet.Console.Servicos.Abstracoes;
using System.Net.Http.Json;

namespace Project.Adopet.Console.Servicos.Http;
public class ClientService : IApiService<Client>
{
    private HttpClient client;

    public ClientService(HttpClient client)
    {
        this.client = client;
    }
    public Task CreateAsync(Client cliente)
    {
        return client.PostAsJsonAsync("cliente/add", cliente);
    }

    public async Task<IEnumerable<Client>?> ListAsync()
    {
        HttpResponseMessage response = await client.GetAsync("cliente/list");
        return await response.Content.ReadFromJsonAsync<IEnumerable<Client>>();
    }
}
