using DR_rest.Models;

namespace DR_rest.Repositories;

public class MusicRecordRepository : IMusicRecordRepository
{
    private readonly List<MusicRecord> _records = new()
    {
        new MusicRecord { Id = 1, Title = "Bohemian Rhapsody", Artist = "Queen", Duration = 354, PublicationYear = 1975 },
        new MusicRecord { Id = 2, Title = "Hotel California", Artist = "Eagles", Duration = 391, PublicationYear = 1976 },
        new MusicRecord { Id = 3, Title = "Smells Like Teen Spirit", Artist = "Nirvana", Duration = 301, PublicationYear = 1991 },
    };

    public IEnumerable<MusicRecord> GetAll() => _records.ToList();
}
