using CBTW.API.Services.Utils;

namespace CBTW.Services.Tests.Utils;

public class AiServiceUtilsTests
{
    [Fact]
    public void ReplaceValuesTest_Success()
    {
        // Arrange
        const string prompt = "There are {{values}} in the following text, you must {{action}} based on it: {{text}}";
        const string promptContext = "several words which not belong to Lorem Ipsum";
        const string promptAction = "remove them";
        const string promptContent = "Lorem ipsum dolor sit amet consectetur adipiscing silla elit. something else";
        var values = new Dictionary<string, string>
        {
            { "values", promptContext },
            { "action", promptAction },
            { "text",  promptContent},
        };

        var expectedResult = prompt.Replace("{{values}}", promptContext)
            .Replace("{{action}}", promptAction)
            .Replace("{{text}}", promptContent); 
        
        // Act
        var result = AiServiceUtils.ReplaceValues(prompt, values);
        
        // Assert
        Assert.Equal(expectedResult, result);
    }
    
    [Fact]
    public void ReplaceValuesTest_NonExistingKey_Success()
    {
        // Arrange
        var prompt = "{{NonKeyInDictionary}}{{postText}}";
        var values = new Dictionary<string, string> { { "values", "any value" } };

        // Act
        var result = AiServiceUtils.ReplaceValues(prompt, values);
        
        // Assert
        Assert.Equal(prompt, result);
    }
}