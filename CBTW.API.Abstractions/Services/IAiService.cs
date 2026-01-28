using CBTW.API.Abstractions.Dtos.Responses;

namespace CBTW.API.Abstractions.Services;

public interface IAiService
{
    Task<SearchBookInfoResponse> CallAsync(Dictionary<string, string> promptValues);
}