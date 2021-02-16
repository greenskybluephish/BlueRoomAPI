using System.Threading.Tasks;
using Contracts;
using Entities;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private IArtistRepository _artistRepository;
        private ICommentRepository _commentRepository;
        private IExternalMediaObjectRepository _externalMediaObjectRepository;
        private ILocaleRepository _localeRepository;
        private INoteRepository _noteRepository;
        private ISetlistRepository _setlistRepository;
        private ISongPerformanceRepository _songPerformanceRepository;
        private ISongRepository _songRepository;
        private IVenueRepository _venueRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public ISongRepository Song => _songRepository ??= new SongRepository(_repositoryContext);

        public IArtistRepository Artist => _artistRepository ??= new ArtistRepository(_repositoryContext);

        public ICommentRepository Comment => _commentRepository ??= new CommentRepository(_repositoryContext);

        public IExternalMediaObjectRepository ExternalMediaObject =>
            _externalMediaObjectRepository ??= new ExternalMediaObjectRepository(_repositoryContext);

        public ILocaleRepository Locale
        {
            get
            {
                if (_localeRepository == null)
                    _localeRepository = new LocaleRepository(_repositoryContext);

                return _localeRepository;
            }
        }

        public INoteRepository Note
        {
            get
            {
                if (_noteRepository == null)
                    _noteRepository = new NoteRepository(_repositoryContext);

                return _noteRepository;
            }
        }

        public ISetlistRepository Setlist
        {
            get
            {
                if (_setlistRepository == null)
                    _setlistRepository = new SetlistRepository(_repositoryContext);

                return _setlistRepository;
            }
        }

        public ISongPerformanceRepository SongPerformance
        {
            get
            {
                if (_songPerformanceRepository == null)
                    _songPerformanceRepository = new SongPerformanceRepository(_repositoryContext);

                return _songPerformanceRepository;
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