using CBTW.API.Abstractions.Dtos;
using CBTW.API.Abstractions.Repositories;
using Google.GenAI;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace CBTW.API.Repositories;

public class GeminiRepository(IConfiguration configuration) : IGeminiRepository
{
    private readonly string _aiSecretKey = configuration["AI:Key"] ?? throw new ArgumentNullException("AI key is required to use AIService");
    private readonly string _aiModelName = configuration["AI:Model"] ?? throw new ArgumentNullException("AI model is required to use AIService");

    public async Task<AIBookResult> ExtractInfoAsync(string prompt)
    {
        await using var geminiClient = new Client(apiKey: _aiSecretKey);
        var response = await geminiClient.Models.GenerateContentAsync(model: _aiModelName, contents: prompt);
        var responseContent = response.Candidates.FirstOrDefault().Content.Parts.FirstOrDefault().Text;

        if (responseContent is null or "not found")
        {
            throw new ApplicationException("No content found");
        }

        return JsonConvert.DeserializeObject<AIBookResult>(responseContent);
    }
}