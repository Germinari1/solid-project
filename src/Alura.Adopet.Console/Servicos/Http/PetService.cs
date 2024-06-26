using System.Net.Http.Json;
using Project.Adopet.Console.Modelos;
using Project.Adopet.Console.Servicos.Abstracoes;

namespace Project.Adopet.Console.Servicos.Http;

public class PetService: IApiService<Pet>
{
    private HttpClient client;

    public PetService(HttpClient client)
    {
        this.client = client;
    }

    public virtual Task CreateAsync(Pet pet)
    {
        return client.PostAsJsonAsync("pet/add", pet);
    }

    public virtual async Task<IEnumerable<Pet>?> ListAsync()
    {
        HttpResponseMessage response = await client.GetAsync("pet/list");
        return await response.Content.ReadFromJsonAsync<IEnumerable<Pet>>();
    }
}
