using System.Net;
using CBTW.API.Abstractions.Dtos.Responses;
using CBTW.API.Abstractions.Services;
using CBTW.API.Models.Requests;
using Microsoft.AspNetCore.Mvc;

namespace CBTW.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookInfoController : ControllerBase
{
    private readonly IBookInfoService _bookInfoService;
    
    public BookInfoController(IBookInfoService bookInfoService) => _bookInfoService = bookInfoService;

    [HttpPost("SearchBookInfo")]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(SearchBookInfoResponse), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Post(SearchBookInfoRequest request)
    {
        var result = await _bookInfoService.InferFromPromptAsync(new Dictionary<string, string> { {"text", request.Text} });
        
        return result?.BookInfos is null ? NotFound() : Ok(result);
    }
}