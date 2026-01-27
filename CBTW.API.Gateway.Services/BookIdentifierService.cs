using CBTW.API.Gateway.Abstractions.Services;
using CBTW.API.Gateway.Models.Dtos.Requests;
using CBTW.API.Gateway.Models.Dtos.Responses;

namespace CBTW.API.Gateway.Services;

public class BookIdentifierService : IBookIdentifierService
{
    public Task<BookIdentifierResponse> IdentifyBookAsync(BookIdentifierRequest request)
    {
        throw new NotImplementedException();
    }
}