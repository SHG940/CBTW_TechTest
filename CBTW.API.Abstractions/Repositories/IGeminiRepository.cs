using CBTW.API.Abstractions.Dtos;

namespace CBTW.API.Abstractions.Repositories;

public interface IGeminiRepository
{
    Task<AIBookResult> ExtractInfoAsync(string prompt);
}