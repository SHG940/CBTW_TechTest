using CBTW.API.Abstractions.Dtos.Requests;
using CBTW.API.Abstractions.Dtos.Responses;
using CBTW.API.Abstractions.Services;
using CBTW.API.Services.Utils;
using Google.GenAI;
using Microsoft.Extensions.Configuration;

namespace CBTW.API.Services;

public class GeminiService : IAiService
{
    private readonly string _aiSecretKey;
    private readonly string _aiModelName;

    public GeminiService(IConfiguration configuration)
    {
        _aiSecretKey = configuration["AI:Key"] ?? throw new ArgumentNullException("AI key is required to use AIService");
        _aiModelName = configuration["AI:Model"] ?? throw new ArgumentNullException("AI model is required to use AIService");
    }
    
    public async Task<AIServiceResponse> CallAsync(AIServiceRequest request)
    {
        await using var geminiClient = new Client(apiKey: _aiSecretKey);
        var prompt = AiServiceUtils.ReplaceValues(request.Propmt, request.PropmtValues);
        var response = await geminiClient.Models.GenerateContentAsync(model: _aiModelName, contents: prompt);

        return new AIServiceResponse
        {
            InputPropmpt = prompt,
            Result = response.Candidates.First().Content.Parts.First().Text,
        };
    }
}