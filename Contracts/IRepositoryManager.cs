using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryManager
    {
        IArtistRepository Artist { get; }
        IVenueRepository Venue { get; }
        IShowRepository Show { get; }
        ISongRepository Song { get; }
        Task SaveAsync();
    }
}
