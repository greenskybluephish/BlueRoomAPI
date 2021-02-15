using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryManager
    {
        IArtistRepository Artist { get; }
        ICommentRepository Comment { get; }
        ILocaleRepository Locale { get; }
        IExternalMediaObjectRepository ExternalMediaObject { get; }
        INoteRepository Note { get; }
        ISongPerformanceRepository SongPerformance { get; }
        IVenueRepository Venue { get; }
        ISetlistRepository Setlist { get; }
        ISongRepository Song { get; }
        Task SaveAsync();
    }
}
