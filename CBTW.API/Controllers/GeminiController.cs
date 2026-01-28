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

    [HttpPost("GetBookInfo")]
    public async Task<IActionResult> Post(GetAiAnalysisRequest request)
    {
        var result = await aiService.CallAsync(new AIServiceRequest
        {
            PropmtValues = new Dictionary<string, string> { {"text", request.Text} }
        });

        if (result is null || result.Result == "not found")
        {
            return BadRequest();
        }
        
        return Ok(result);
    }
}