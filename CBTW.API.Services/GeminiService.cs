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

    private const string BasePrompt = """
                                      Extract the key information of the following input related to a book;
the key information I want you to extract is the following: author, title, and keywords.
The way I want you to give me the information is in minimized JSON format as the following example (the json object only):
{'title':'Moby Dick','author':'Herman Melville','keywords':['Adventure Fiction','1851-10-18','Whale','Sea','Ahab Captain']}.
In case that you can't find the title or the author, you must assign the field as null, it is also posible that you can't find the author or the title,
in that scenario return just "not found"
Input: {{text}}
""";

    public GeminiService(IConfiguration configuration)
    {
        _aiSecretKey = configuration["AI:Key"] ?? throw new ArgumentNullException("AI key is required to use AIService");
        _aiModelName = configuration["AI:Model"] ?? throw new ArgumentNullException("AI model is required to use AIService");
    }
    
    public async Task<AIServiceResponse> CallAsync(AIServiceRequest request)
    {
        await using var geminiClient = new Client(apiKey: _aiSecretKey);
        var prompt = AiServiceUtils.ReplaceValues(BasePrompt, request.PropmtValues);
        var response = await geminiClient.Models.GenerateContentAsync(model: _aiModelName, contents: prompt);
        var responseContent = response.Candidates.First().Content.Parts.First().Text;

        return new AIServiceResponse
        {
            InputPropmpt = prompt,
            Result = responseContent,
        };
    }
}