using CBTW.API.Abstractions.Dtos.Requests;
using CBTW.API.Abstractions.Services;
using CBTW.API.Models.Requests;
using Microsoft.AspNetCore.Mvc;

namespace CBTW.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GeminiController : ControllerBase
{
    private readonly IAiService aiService;
    
    public GeminiController(IAiService aiService)
        => this.aiService = aiService;

    [HttpPost]
    public async Task<IActionResult> Post(GetAiAnalysisRequest request)
    {
        const string basePrompt = "Extract the key information of the following input related to a book; " +
                                  "the key information I want you to extract is the following: author, title, and keywords." +
                                  "The way I want you to give me the information is in minimized JSON format as the following example (the json object only):" +
                                  "{'title':'Moby Dick','author':'Herman Melville','keywords':['Adventure Fiction','1851-10-18','Whale','Sea','Ahab Captain']}." +
                                  "In case that you can't find the title or the author, you must assign the field as null" +
                                  "Input: {{text}}";
        var result = await aiService.CallAsync(new AIServiceRequest
        {
            Propmt = basePrompt,
            PropmtValues = new Dictionary<string, string> { {"text", request.Text} }
        });
        
        return Ok(result);
    }
}