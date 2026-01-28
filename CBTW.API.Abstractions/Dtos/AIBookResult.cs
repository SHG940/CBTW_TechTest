namespace CBTW.API.Abstractions.Dtos;

public class AIBookResult
{
    public string? Title { get; set; }

    public string? Author { get; set; }

    public IEnumerable<string> Keywords { get; set; } = [];

    public string MatchReason { get; set; }
}