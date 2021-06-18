using System.Threading.Tasks;
using Contracts;
using Entities.Context;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly BlueRoomContext _repositoryContext;
        private IArtistRepository _artistRepository;
        private IShowRepository _showRepository;
        private ISongRepository _songRepository;
        private IVenueRepository _venueRepository;

        public RepositoryManager(BlueRoomContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public ISongRepository Song => _songRepository ??= new SongRepository(_repositoryContext);
        public IArtistRepository Artist => _artistRepository ??= new ArtistRepository(_repositoryContext);
        public IShowRepository Show => _showRepository ??= new ShowRepository(_repositoryContext);
        public IVenueRepository Venue => _venueRepository ??= new VenueRepository(_repositoryContext);

        public Task SaveAsync()
        {
            return _repositoryContext.SaveChangesAsync();
        }
    }
}