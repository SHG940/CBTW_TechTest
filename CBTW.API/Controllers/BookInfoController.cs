using CBTW.API.Abstractions.Services;
using CBTW.API.Models.Requests;
using Microsoft.AspNetCore.Mvc;

namespace CBTW.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookInfoController : ControllerBase
{
    private readonly IAiService aiService;
    
    public BookInfoController(IAiService aiService)
        => this.aiService = aiService;

    [HttpPost("SearchBookInfo")]
    public async Task<IActionResult> Post(SearchBookInfoRequest request)
    {
        var result = await aiService.CallAsync(new Dictionary<string, string> { {"text", request.Text} });
        
        return result?.BookInfo is null ? NotFound() : Ok(result);
    }
}