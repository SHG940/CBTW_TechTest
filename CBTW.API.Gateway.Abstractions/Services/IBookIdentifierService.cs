namespace CBTW.API.Gateway.Abstractions.Services;

public interface IBookIdentifierService
{
    Task<BookIdentifierResponse> IdentifyBookAsync(string input);
}