using CBTW.API.Gateway.Abstractions.Services;
using CBTW.API.Gateway.Models.Dtos.Requests;
using Microsoft.AspNetCore.Mvc;

namespace CBTW.API.Gateway.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class BookController : ControllerBase
{
    private readonly IBookIdentifierService _bookIdentifierService;
    
    public BookController(IBookIdentifierService bookIdentifierService)
    {
        _bookIdentifierService = bookIdentifierService;
    }
    
    [HttpPost("GetBookInfo")]
    public async Task<IActionResult> GetBookInfoAsync(BookIdentifierRequest request)
    {
        return Ok(await _bookIdentifierService.IdentifyBookAsync(request.Input));
    }
}