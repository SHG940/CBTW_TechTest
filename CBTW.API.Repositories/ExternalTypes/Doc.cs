using System.Text.Json.Serialization;

namespace CBTW.API.Repositories.ExternalTypes;

public class Doc
{
    public string Key { get; set; }
    
    public IEnumerable<string> AuthorName { get; set; }

    [JsonPropertyName("first_publish_year")]
    public int FirstPublishYear { get; set; }

    public string Title { get; set; }
}