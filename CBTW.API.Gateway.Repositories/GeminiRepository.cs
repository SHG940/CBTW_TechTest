using System.Net.Http.Json;
using CBTW.API.Gateway.Abstractions.Repositories;
using CBTW.API.Gateway.Models.Dtos;
using CBTW.API.Gateway.Repositories.ExternalModels.Requests;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace CBTW.API.Gateway.Repositories;

public class GeminiRepository(IConfiguration config) : IGeminiRepository
{
    private readonly HttpClient _httpClient = new()
    {
        BaseAddress = new Uri(config["Repositories:GeminiRepository:Uri"])
    };

    public async Task<Book?> GetBookInfoAsync(string input)
    {
        var request = new GetBookInfoRequest(input);
        var uri = new Uri("gemini/getbookinfo", UriKind.Relative);
        var response = await _httpClient.PostAsync(uri, JsonContent.Create(request));

        var responseContent = await response.EnsureSuccessStatusCode().Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<Book>(responseContent);
    }
}