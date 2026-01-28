using System.Text;
using CBTW.API.Abstractions.Dtos;
using CBTW.API.Abstractions.Dtos.Responses;
using CBTW.API.Abstractions.Repositories;
using CBTW.API.Abstractions.Services;

namespace CBTW.API.Services;

public class OpenLibraryService : IOpenLibraryService
{
    private static readonly IEnumerable<string> Fields = ["key", "title", "author_name", "author_key", "first_publish_year"];
    private readonly IOpenLibraryRepository _openLibraryRepository;
    
    public OpenLibraryService(IOpenLibraryRepository openLibraryRepository) => _openLibraryRepository = openLibraryRepository;
    
    public async Task<BookInfoRespose> GetBookInfoAsync(AIBookResult bookData)
    {
        bool hasTitle;
        var queryText = new StringBuilder();

        if (hasTitle = !string.IsNullOrWhiteSpace(bookData.Title))
        {
            queryText.Append($"title={bookData.Title}");
        }

        if (!string.IsNullOrWhiteSpace(bookData.Author))
        {
            queryText.Append($"{(hasTitle ? "&" : string.Empty)}author={bookData.Author}");
        }
        
        return await _openLibraryRepository.GetBookInfoAsync(queryText.ToString(), Fields);
    }
}