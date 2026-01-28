namespace CBTW.API.Gateway.Repositories.ExternalModels.Requests;

public class GetBookInfoRequest(string text)
{
    public string Text { get; set; } = text;
}