using DR_rest.Repositories;

namespace DR_unittest;

public class UserRepositoryTests
{
    private UserRepository CreateRepository() => new UserRepository();

    [Fact]
    public void Validate_CorrectCredentials_ReturnsSuccess()
    {
        var repo = CreateRepository();

        var (success, role) = repo.Validate("admin", "password123!");

        Assert.True(success);
        Assert.Equal("admin", role);
    }

    [Fact]
    public void Validate_WrongPassword_ReturnsFail()
    {
        var repo = CreateRepository();

        var (success, _) = repo.Validate("admin", "wrongpassword");

        Assert.False(success);
    }

    [Fact]
    public void Validate_UnknownUser_ReturnsFail()
    {
        var repo = CreateRepository();

        var (success, _) = repo.Validate("unknown", "password");

        Assert.False(success);
    }
}

public class MusicRecordRepositoryTests
{
    private MusicRecordRepository CreateRepository() => new MusicRecordRepository();

    [Fact]
    public void GetAll_ReturnsNonEmptyList()
    {
        var repo = CreateRepository();

        var result = repo.GetAll();

        Assert.NotEmpty(result);
    }

    [Fact]
    public void GetAll_ReturnsSeedData()
    {
        var repo = CreateRepository();

        var result = repo.GetAll().ToList();

        Assert.Equal(3, result.Count);
    }

    [Fact]
    public void GetAll_RecordsHaveExpectedTitles()
    {
        var repo = CreateRepository();

        var titles = repo.GetAll().Select(r => r.Title).ToList();

        Assert.Contains("Bohemian Rhapsody", titles);
        Assert.Contains("Hotel California", titles);
        Assert.Contains("Smells Like Teen Spirit", titles);
    }

    [Fact]
    public void GetAll_EachRecordHasPositiveDuration()
    {
        var repo = CreateRepository();

        var result = repo.GetAll();

        Assert.All(result, r => Assert.True(r.Duration > 0));
    }

    [Fact]
    public void GetAll_EachRecordHasUniqueId()
    {
        var repo = CreateRepository();

        var ids = repo.GetAll().Select(r => r.Id).ToList();

        Assert.Equal(ids.Count, ids.Distinct().Count());
    }

    [Fact]
    public void GetAll_FilterByTitle_ReturnsMatchingRecords()
    {
        var repo = CreateRepository();

        var result = repo.GetAll(title: "Bohemian").ToList();

        Assert.Single(result);
        Assert.Equal("Bohemian Rhapsody", result[0].Title);
    }

    [Fact]
    public void GetAll_FilterByTitle_IsCaseInsensitive()
    {
        var repo = CreateRepository();

        var result = repo.GetAll(title: "bohemian").ToList();

        Assert.Single(result);
    }

    [Fact]
    public void GetAll_FilterByArtist_ReturnsMatchingRecords()
    {
        var repo = CreateRepository();

        var result = repo.GetAll(artist: "Queen").ToList();

        Assert.Single(result);
        Assert.Equal("Queen", result[0].Artist);
    }

    [Fact]
    public void GetAll_FilterByArtist_IsCaseInsensitive()
    {
        var repo = CreateRepository();

        var result = repo.GetAll(artist: "queen").ToList();

        Assert.Single(result);
    }

    [Fact]
    public void GetAll_FilterByTitleAndArtist_ReturnsBothMatching()
    {
        var repo = CreateRepository();

        var result = repo.GetAll(title: "Bohemian", artist: "Queen").ToList();

        Assert.Single(result);
    }

    [Fact]
    public void GetAll_FilterByTitleAndArtist_NoMatch_ReturnsEmpty()
    {
        var repo = CreateRepository();

        var result = repo.GetAll(title: "Bohemian", artist: "Nirvana").ToList();

        Assert.Empty(result);
    }

    [Fact]
    public void GetAll_FilterWithNoMatch_ReturnsEmpty()
    {
        var repo = CreateRepository();

        var result = repo.GetAll(title: "nonexistent").ToList();

        Assert.Empty(result);
    }
}
