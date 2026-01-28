using AutoFixture;
using CBTW.API.Abstractions.Dtos;
using CBTW.API.Abstractions.Dtos.Responses;
using CBTW.API.Abstractions.Repositories;
using Moq;

namespace CBTW.API.Services.Tests.Services;

public class OpenLibraryServiceTests
{
    private readonly OpenLibraryService _openLibraryService;
    private readonly Mock<IOpenLibraryRepository> _repositoryMock;
    private readonly Fixture _fixture;

    public OpenLibraryServiceTests()
    {
        _fixture = new Fixture();
        _repositoryMock = new Mock<IOpenLibraryRepository>();
        _openLibraryService = new OpenLibraryService(_repositoryMock.Object);
    }

    [Fact]
    public async Task GetBookInfoAsync_WithAllFields_Success()
    {
        // Arrange
        var aiDataResult = new AIBookResult
        {
            Title =  _fixture.Create<string>(),
            Author = _fixture.Create<string>(),
            Keywords = _fixture.CreateMany<string>(),
            MatchReason =  _fixture.Create<string>(),
        };
        var expectedQueryParam = $"title={aiDataResult.Title}&author={aiDataResult.Author}";
        var expectedResult = _fixture.Create<BookInfoRespose>();

        _repositoryMock.Setup(x => x.GetBookInfoAsync(expectedQueryParam, It.IsAny<IEnumerable<string>>()))
            .ReturnsAsync(expectedResult);
        
        // Act
        var result = await _openLibraryService.GetBookInfoAsync(aiDataResult);

        // Assert
        _repositoryMock.Verify(x => x.GetBookInfoAsync(expectedQueryParam, It.IsAny<IEnumerable<string>>()), Times.Once);
        Assert.Equal(expectedResult, result);
    }
    
    [Theory]
    [InlineData(null, "Some Author")]
    [InlineData("Lord of the rings", null)]
    public async Task GetBookInfoAsync_WithTitleOrAuthorOnly_Success(string? title,  string? author)
    {
        // Arrange
        var aiDataResult = _fixture.Build<AIBookResult>()
            .With(x => x.Title, title)
            .With(x => x.Author, author)
            .Create();
        var titleString = title is null ? string.Empty : $"title={aiDataResult.Title}";
        var authorParam = author is null ? string.Empty : $"author={aiDataResult.Author}";
        var expectedQueryParam = string.Concat(titleString, authorParam);
        var expectedResult = _fixture.Create<BookInfoRespose>();

        _repositoryMock.Setup(x => x.GetBookInfoAsync(expectedQueryParam, It.IsAny<IEnumerable<string>>()))
            .ReturnsAsync(expectedResult);
        
        // Act
        var result = await _openLibraryService.GetBookInfoAsync(aiDataResult);

        // Assert
        _repositoryMock.Verify(x => x.GetBookInfoAsync(expectedQueryParam, It.IsAny<IEnumerable<string>>()), Times.Once);
        Assert.Equal(expectedResult, result);
    }
    
    [Fact]
    public async Task GetBookInfoAsync_Fails()
    {
        // Arrange
        var aiDataResult = _fixture.Create<AIBookResult>();

        _repositoryMock.Setup(x => x.GetBookInfoAsync(It.IsAny<string>(), It.IsAny<IEnumerable<string>>()))
            .ThrowsAsync(new Exception());
        
        // Act & Assert
        await Assert.ThrowsAsync<Exception>(() => _openLibraryService.GetBookInfoAsync(aiDataResult));
    }
}