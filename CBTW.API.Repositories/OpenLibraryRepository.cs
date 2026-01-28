using System.Runtime.InteropServices.JavaScript;
using CBTW.API.Abstractions.Dtos;
using CBTW.API.Abstractions.Dtos.Responses;
using CBTW.API.Abstractions.Repositories;
using CBTW.API.Repositories.ExternalTypes;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace CBTW.API.Repositories;

public class OpenLibraryRepository(IConfiguration config) : IOpenLibraryRepository
{
    private readonly HttpClient _httpClient = new HttpClient
    {
        BaseAddress = new Uri(config["Repositories:OpenLibraryRepository:Uri"])
    };

    public async Task<BookInfoRespose> GetBookInfoAsync(string searchString, IEnumerable<string> fields)
    {
        var uri = new Uri(string.Concat("search.json?", searchString, "&fields=", string.Join(',', fields)), UriKind.Relative);
        var response = await _httpClient.GetAsync(uri);
        var responseContent = await response.EnsureSuccessStatusCode().Content.ReadAsStringAsync();
        var searchResult = JsonConvert.DeserializeObject<OpenLibrarySearchResult>(responseContent);
        return new BookInfoRespose
        {
            BookInfos = searchResult.Docs.Select(d => new BookInfo
            {
                AuthorName = d.AuthorName.FirstOrDefault() ?? string.Empty,
                FirstPublishYear =  d.FirstPublishYear,
                Key = d.Key,
                Title =  d.Title,
            }),
        };
    }
}