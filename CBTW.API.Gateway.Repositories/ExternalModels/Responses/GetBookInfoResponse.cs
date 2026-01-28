using CBTW.API.Gateway.Models.Dtos;

namespace CBTW.API.Gateway.Repositories.ExternalModels.Responses;

public class GetBookInfoResponse
{
    public IEnumerable<Book> BookInfos { get; set; }

    public string MatchReason { get; set; }
}