using CBTW.API.Gateway.Abstractions.Repositories;
using CBTW.API.Gateway.Abstractions.Services;
using CBTW.API.Gateway.Models.Dtos;
using CBTW.API.Gateway.Models.Exceptions;

namespace CBTW.API.Gateway.Services;

public class BookIdentifierService : IBookIdentifierService
{
    private readonly IGeminiRepository _geminiRepository;
    
    public BookIdentifierService(IGeminiRepository geminiRepository)
        => _geminiRepository = geminiRepository;

    public async Task<Book> IdentifyBookAsync(string input)
        => await _geminiRepository.GetBookInfoAsync(input) ?? throw new BookNotFoundException();
}