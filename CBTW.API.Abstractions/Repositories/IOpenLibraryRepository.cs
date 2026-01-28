using CBTW.API.Abstractions.Dtos;
using CBTW.API.Abstractions.Dtos.Responses;

namespace CBTW.API.Abstractions.Repositories;

public interface IOpenLibraryRepository
{
    Task<BookInfoRespose> GetBookInfoAsync(string searchString, IEnumerable<string> fields);
}