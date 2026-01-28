using CBTW.API.Gateway.Models.Dtos;

namespace CBTW.API.Gateway.Abstractions.Services;

public interface IBookIdentifierService
{
    Task<Book> IdentifyBookAsync(string input);
}