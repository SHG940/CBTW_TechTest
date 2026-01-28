using Newtonsoft.Json;

namespace CBTW.API.Gateway.Models.Dtos;

public class Book
{
    public string Title { get; set; }

    [JsonProperty("AuthorName")]
    public string Author { get; set; }

    public int FirstPublishYear { get; set; }

    public string Explanation { get; set; }
}