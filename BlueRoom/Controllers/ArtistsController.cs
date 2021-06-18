using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlueRoom.Controllers
{
    [Route("api/Artists")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public ArtistController(IRepositoryManager repository,
            ILoggerManager logger,
            IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

/*        // GET api/Artist
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var shows = _repository.Show.FindAll(false)
                .Include(s => s.Venue)
                .Include(x=>x.PerformingArtist)
                .Include(s=>s.SongPerformances)
                .ThenInclude(a=>a.Song)
                .Include(s => s.SongPerformances)
                .ThenInclude(y => y.SetNumber)
                .Where(x=>x.PerformingArtistId == id)
                .ToList();


            var artistsDto = new ArtistDto
            {
                ArtistId = s.PerformingArtist.ArtistId,
                ArtistName = s.PerformingArtist.Name,
                Shows = shows
            }).ToListAsync();

            return Ok(artistsDto);
        }*/


        //[Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int? id)
        {
            var shows = _repository.Show.FindAll(false)
                .Include(s => s.Venue)
                .Include(x => x.PerformingArtist)
                .Include(s => s.SongPerformances)
                .ThenInclude(a => a.Song)
                .Include(s => s.SongPerformances)
                .ThenInclude(y => y.SetNumber)
                .Where(x => x.PerformingArtistId == id)
                .OrderBy(x=>x.Date)
                .AsQueryable();

            var artistsDto = new ArtistDto
            {
                ArtistId = shows.First().PerformingArtistId,
                ArtistName = shows.First().PerformingArtist.Name,
                Shows = shows.Select(d => new ShowDto(d))
            };


            return Ok(artistsDto);
        }

        [HttpGet("{name}/{date}")]
        public async Task<IActionResult> Get(string name, DateTime date)
        {
            var upper = name.ToUpper();
            var shows = _repository.Show.FindByCondition(x => x.PerformingArtist.Name == upper && x.Date.Equals(date), false)
                .Include(v => v.Venue).Include(a => a.PerformingArtist)
                .Include(s => s.SongPerformances).AsQueryable();

            var showsDto = await shows.Select(s => new ShowDto()
            {
                ShowId = s.ShowId,
                ShowDate = s.Date,
                ShowDateString = s.Date.ToShortDateString(),
                ArtistName = s.PerformingArtist.Name,
                VenueName = s.Venue.Name,
                VenueCity = s.Venue.City,
                VenueCountry = s.Venue.Country,
                VenueState = s.Venue.State,
                Setlist = new SetlistDto(s.SongPerformances)
            }).FirstOrDefaultAsync();

            return Ok(showsDto);
        }

        [HttpGet("GetArtistDropdown")]
        public async Task<IActionResult> GetArtistDropdown()
        {
            var artists = _repository.Artist.FindAll(false).AsQueryable();

            var artistsDto = await artists.Select(s => new ArtistDto
            {
                ArtistId = s.ArtistId,
                ArtistName = s.Name
            }).ToListAsync();

            return Ok(artistsDto);
        }

        // POST api/Artist
        [HttpPost]
        public async Task Post(ArtistDto model)
        {
            var mapped = _mapper.Map<Artist>(model);
            _repository.Artist.Create(mapped);
            await _repository.SaveAsync();
        }

        // [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] ArtistDto artist)
        {
            var artistToUpdate = await _repository.Artist.GetArtistAsync(id, false);

            if (artistToUpdate == null)
            {
                return NotFound();
            }
            var mappedArtist = _mapper.Map<Artist>(artist);

            _repository.Artist.Update(mappedArtist);

            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var artist = await _repository.Artist.GetArtistAsync(id, false);

            _repository.Artist.DeleteArtist(artist);
            await _repository.SaveAsync();
            return NoContent();
        }
    }
}
