using CBTW.API.Abstractions.Dtos.Requests;
using CBTW.API.Abstractions.Dtos.Responses;
using CBTW.API.Abstractions.Repositories;
using CBTW.API.Abstractions.Services;
using CBTW.API.Services.Utils;

namespace CBTW.API.Services;

public class GeminiService : IAiService
{
    private const string BasePrompt = """
Extract the key information of the following input related to a book;
the key information I want you to extract is the following: 'author', 'title', 'keywords', and 'matchReason' which contains a small description of why matched (max 2 sentences).
The way I want you to give me the information is in minimized JSON format as the following example (the json object only):
{'title':'Moby Dick','author':'Herman Melville','keywords':['Adventure Fiction','1851-10-18','Whale','Sea','Ahab Captain'],'matchReason':'Exact title match; Herman Melville is primary author; Action fiction is the gender of the novel; 1851-10-18 is the publish date; Whale, Sea, and Ahab Captain are characters and locations'}.
In case that you can't find the title or the author, you must assign the field as null, it is also posible that you can't find the author or the title,
in that scenario return just "not found"
Input: {{text}}
""";
    
    private readonly IOpenLibraryService _openLibraryService;
    private readonly IGeminiRepository _geminiRepository;

    public GeminiService(IGeminiRepository geminiRepository, IOpenLibraryService openLibraryService)
    {
        _geminiRepository = geminiRepository;
        _openLibraryService = openLibraryService;
    }
    
    public async Task<AIServiceResponse> CallAsync(AIServiceRequest request)
    {
        var prompt = AiServiceUtils.ReplaceValues(BasePrompt, request.PropmtValues);
        var bookKeyData = await _geminiRepository.ExtractInfoAsync(prompt);
        var bookInfosFound = await _openLibraryService.GetBookInfoAsync(bookKeyData);
        var bookInfo = bookInfosFound.BookInfo.FirstOrDefault();
        
        return new AIServiceResponse
        {
            InputPropmpt =  prompt,
            BookInfo = bookInfo,
        };
    }
}