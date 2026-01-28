using CBTW.API.Abstractions.Dtos.Responses;
using CBTW.API.Abstractions.Services;

namespace CBTW.API.Services;

public class BookInfoService : IBookInfoService
{
    private readonly IAiService _aiService;
    private readonly IOpenLibraryService _openLibraryService;

    public BookInfoService(IAiService aiService, IOpenLibraryService openLibraryService)
    {
        _aiService = aiService;
        _openLibraryService = openLibraryService;
    }
    
    public async Task<SearchBookInfoResponse> InferFromPromptAsync(Dictionary<string, string> promptValues)
    {
        var bookKeyData = await _aiService.ExtractBookInfoAsync(promptValues);
        var bookInfosFound = await _openLibraryService.GetBookInfoAsync(bookKeyData);
        var bookInfo = bookInfosFound.BookInfo.FirstOrDefault();
        
        return new SearchBookInfoResponse
        {
            BookInfo = bookInfo,
        };
    }
}