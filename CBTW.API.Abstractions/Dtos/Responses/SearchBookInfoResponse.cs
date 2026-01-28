namespace CBTW.API.Abstractions.Dtos.Responses;

public class SearchBookInfoResponse
{
    public IEnumerable<BookInfo> BookInfos { get; set; }

    public string MatchReason { get; set; }
}