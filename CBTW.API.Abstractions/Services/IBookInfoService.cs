using CBTW.API.Abstractions.Dtos.Responses;

namespace CBTW.API.Abstractions.Services;

public interface IBookInfoService
{
    Task<SearchBookInfoResponse> InferFromPromptAsync(Dictionary<string, string> promptValues);
}