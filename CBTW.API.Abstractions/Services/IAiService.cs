using CBTW.API.Abstractions.Dtos;

namespace CBTW.API.Abstractions.Services;

public interface IAiService
{
    Task<AIBookResult> ExtractBookInfoAsync(Dictionary<string, string> promptValues);
}