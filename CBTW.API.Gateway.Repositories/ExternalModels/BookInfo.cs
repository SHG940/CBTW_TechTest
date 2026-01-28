using System.Text.Json.Serialization;

namespace CBTW.API.Gateway.Repositories.ExternalModels;

public class BookInfo
{
    public string Key { get; set; }

    public string Title { get; set; }

    public string AuthorName { get; set; }

    public int FirstPublishYear { get; set; }
}