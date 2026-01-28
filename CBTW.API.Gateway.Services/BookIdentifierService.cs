using CBTW.API.Gateway.Abstractions.Repositories;
using CBTW.API.Gateway.Abstractions.Services;
using CBTW.API.Gateway.Models.Dtos;
using CBTW.API.Gateway.Models.Exceptions;

namespace CBTW.API.Gateway.Services;

public class BookIdentifierService : IBookIdentifierService
{
    private readonly IBookInfoRepository _bookInfoRepository;

    public BookIdentifierService(IBookInfoRepository bookInfoRepository)
        => _bookInfoRepository = bookInfoRepository;

    public async Task<IEnumerable<Book?>> IdentifyBookAsync(string input)
        => await _bookInfoRepository.GetBookInfoAsync(input) ?? throw new BookNotFoundException();
}