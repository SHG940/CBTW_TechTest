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
        var bookInfos = bookInfosFound.BookInfos.Take(5);

        return new SearchBookInfoResponse
        {
            BookInfos = bookInfos,
            MatchReason = bookKeyData.MatchReason,
        };
    }
}