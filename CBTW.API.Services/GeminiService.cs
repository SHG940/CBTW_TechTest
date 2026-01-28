using CBTW.API.Abstractions.Dtos;
using CBTW.API.Abstractions.Repositories;
using CBTW.API.Abstractions.Services;
using CBTW.API.Services.Utils;

namespace CBTW.API.Services;

public class GeminiService : IAiService
{
    private readonly IGeminiRepository _geminiRepository;

    public GeminiService(IGeminiRepository geminiRepository) => _geminiRepository = geminiRepository;
    
    public async Task<AIBookResult> ExtractBookInfoAsync(Dictionary<string, string> promptValues)
    => await _geminiRepository.ExtractInfoAsync(
            AiServiceUtils.ReplaceValues(Constants.BookExtractionInfoBasePrompt, promptValues)
        );
}