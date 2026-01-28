namespace CBTW.API.Abstractions.Dtos.Responses;

public class SearchBookInfoResponse
{
    public string InputPropmpt { get; set; }

    public BookInfo? BookInfo { get; set; }
}