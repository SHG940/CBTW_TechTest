using AutoFixture;
using CBTW.API.Abstractions.Dtos;
using CBTW.API.Abstractions.Repositories;
using Moq;

namespace CBTW.API.Services.Tests.Services;

public class GeminiServiceTests
{
    private readonly GeminiService _geminiService;
    private readonly Mock<IGeminiRepository> _repositoryMock;
    private readonly Fixture _fixture;

    public GeminiServiceTests()
    {
        _fixture = new Fixture();
        _repositoryMock = new Mock<IGeminiRepository>();
        _geminiService = new GeminiService(_repositoryMock.Object);
    }

    [Fact]
    public async Task ExtractBookInfoAsync_Succeeds()
    {
        // Arrange
        var keys = new Dictionary<string, string> { { "text", "some random text" } };
        var expectedResult = _fixture.Create<AIBookResult>();
        _repositoryMock.Setup(x => x.ExtractInfoAsync(It.IsAny<string>()))
            .ReturnsAsync(expectedResult);

        // Act
        var result = await _geminiService.ExtractBookInfoAsync(keys);

        // Assert
        Assert.Equal(expectedResult, result);
    }
    
    [Fact]
    public async Task ExtractBookInfoAsync_Fails()
    {
        // Arrange
        var keys = new Dictionary<string, string> { { "text", "some random text" } };
        _repositoryMock.Setup(x => x.ExtractInfoAsync(It.IsAny<string>()))
            .ThrowsAsync(new Exception());

        // Act & Assert
        await Assert.ThrowsAsync<Exception>(() => _geminiService.ExtractBookInfoAsync(keys));
    }
}