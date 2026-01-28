using CBTW.API.Gateway.Models.Dtos;

namespace CBTW.API.Gateway.Abstractions.Repositories;

public interface IBookInfoRepository
{
    Task<IEnumerable<Book?>> GetBookInfoAsync(string input);
}