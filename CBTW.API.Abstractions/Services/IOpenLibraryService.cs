using CBTW.API.Abstractions.Dtos;
using CBTW.API.Abstractions.Dtos.Responses;

namespace CBTW.API.Abstractions.Services;

public interface IOpenLibraryService
{
    Task<BookInfoRespose> GetBookInfoAsync(AIBookResult bookData);
}