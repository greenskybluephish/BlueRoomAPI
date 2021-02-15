using Contracts;
using Entities;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private RepositoryContext _repositoryContext;
        private ISongRepository _songRepository;
        private IArtistRepository _artistRepository;
        private ICommentRepository _commentRepository;
        private IExternalMediaObjectRepository _externalMediaObjectRepository;
        private ILocaleRepository _localeRepository;
        private INoteRepository _noteRepository;
        private ISetlistRepository _setlistRepository;
        private ISongPerformanceRepository _songPerformanceRepository;
        private IVenueRepository _venueRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public ISongRepository Song
        {
            get
            {
                if (_songRepository == null)
                    _songRepository = new SongRepository(_repositoryContext);

                return _songRepository;
            }
        }
        public IArtistRepository Artist
        {
            get
            {
                if (_artistRepository == null)
                    _artistRepository = new ArtistRepository(_repositoryContext);

                return _artistRepository;
            }
        }
        public ICommentRepository Comment
        {
            get
            {
                if (_commentRepository == null)
                    _commentRepository = new CommentRepository(_repositoryContext);

                return _commentRepository;
            }
        }
        public IExternalMediaObjectRepository ExternalMediaObject
        {
            get
            {
                if (_externalMediaObjectRepository == null)
                    _externalMediaObjectRepository = new ExternalMediaObjectRepository(_repositoryContext);

                return _externalMediaObjectRepository;
            }
        }

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

        public Task SaveAsync() => _repositoryContext.SaveChangesAsync();
    }
}