using DR_rest.Repositories;

namespace DR_unittest;

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
}
