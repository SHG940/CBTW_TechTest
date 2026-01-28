using System.Net.Http.Json;
using CBTW.API.Gateway.Abstractions.Repositories;
using CBTW.API.Gateway.Models.Dtos;
using CBTW.API.Gateway.Repositories.ExternalModels.Requests;
using CBTW.API.Gateway.Repositories.ExternalModels.Responses;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace CBTW.API.Gateway.Repositories;

public class BookInfoRepository(IConfiguration config) : IBookInfoRepository
{
    private readonly HttpClient _httpClient = new()
    {
        BaseAddress = new Uri(config["Repositories:GeminiRepository:Uri"])
    };

    public async Task<IEnumerable<Book?>> GetBookInfoAsync(string input)
    {
        var request = new GetBookInfoRequest(input);
        var uri = new Uri("bookinfo/searchbookinfo", UriKind.Relative);
        var response = await _httpClient.PostAsync(uri, JsonContent.Create(request));
        var responseContent = await response.EnsureSuccessStatusCode().Content.ReadAsStringAsync();

        var bookInfo = JsonConvert.DeserializeObject<GetBookInfoResponse>(responseContent);
        bookInfo?.BookInfos.ToList().ForEach(b => b.Explanation = bookInfo.MatchReason);

        return bookInfo?.BookInfos;
    }
}