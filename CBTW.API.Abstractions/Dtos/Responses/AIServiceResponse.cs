namespace CBTW.API.Abstractions.Dtos.Responses;

public class AIServiceResponse
{
    public string InputPropmpt { get; set; }

    public BookInfo? BookInfo { get; set; }
}