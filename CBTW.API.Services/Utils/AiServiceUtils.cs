using System.Text.RegularExpressions;

namespace CBTW.API.Services.Utils;

public static class AiServiceUtils
{
    private static readonly Regex ContentRegex = new Regex(@"\{\{(?<key>\w+)\}\}");
    
    public static string ReplaceValues(string prompt, Dictionary<string, string> values)
    {
        var output = ContentRegex.Replace(prompt, match =>
        {
            var key = match.Groups["key"].Value;
            
            return values.TryGetValue(key, out var value) ? value : match.Value;
        });
        return output;
    }
}