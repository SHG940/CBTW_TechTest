using Newtonsoft.Json;

namespace CBTW.API.Repositories.ExternalTypes;

public class Doc
{
    public string Key { get; set; }

    [JsonProperty("author_name")]
    public IEnumerable<string> AuthorName { get; set; }

    [JsonProperty("first_publish_year")]
    public int FirstPublishYear { get; set; }

    public string Title { get; set; }
}