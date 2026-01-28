using CBTW.API.Gateway.Models.Dtos;

namespace CBTW.API.Gateway.Abstractions.Repositories;

public interface IGeminiRepository
{
    Task<Book?> GetBookInfoAsync(string input);
}