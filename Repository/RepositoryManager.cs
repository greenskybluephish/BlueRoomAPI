using System.Threading.Tasks;
using Contracts;
using Entities;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private IArtistRepository _artistRepository;
        private IShowRepository _ShowRepository;

        private ISongRepository _songRepository;
        private IVenueRepository _venueRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public ISongRepository Song => _songRepository ??= new SongRepository(_repositoryContext);

        public IArtistRepository Artist => _artistRepository ??= new ArtistRepository(_repositoryContext);


        public IShowRepository Show
        {
            get
            {
                if (_ShowRepository == null)
                    _ShowRepository = new ShowRepository(_repositoryContext);

                return _ShowRepository;
            }
        }

        public IVenueRepository Venue
        {
            get
            {
                if (_venueRepository == null)
                    _venueRepository = new VenueRepository(_repositoryContext);

                return _venueRepository;
            }
        }

        public Task SaveAsync()
        {
            return _repositoryContext.SaveChangesAsync();
        }
    }
}