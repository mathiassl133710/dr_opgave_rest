using DR_rest.Models;

namespace DR_rest.Repositories;

public interface IMusicRecordRepository
{
    IEnumerable<MusicRecord> GetAll(string? title = null, string? artist = null);
}
