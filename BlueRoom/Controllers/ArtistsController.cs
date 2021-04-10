using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
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

        // GET api/Artist
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var artists = _repository.Artist.FindAll(false)
                .Include(a => a.Shows).Include(a=>a.Songs)
                .AsQueryable();

            var artistsDto = await artists.Select(s => new ArtistDto
            {
                ArtistId = s.ArtistId,
                ArtistName = s.Name,
                OriginalSongs = s.Songs.Select(y=> new IdNameBase(y.SongId, y.Name)),
                Shows = s.Shows
            }).ToListAsync();

            return Ok(artistsDto);
        }


        //[Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int? id)
        {
            var artists = _repository.Artist.FindByCondition(x => x.ArtistId.Equals(id), false)
                .Include(s => s.Songs)
                .Include(a => a.Shows).AsQueryable();

            var artistsDto = await artists.Select(s => new ArtistDto
            {
                ArtistId = s.ArtistId,
                ArtistName = s.Name,
                OriginalSongs = s.Songs.Select(y => new IdNameBase(y.SongId, y.Name)),
                Shows = s.Shows
            }).FirstOrDefaultAsync();
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
                Setlist = s.SongPerformances.Select(y => new IdNameBase(y.SongId, y.Song.Name))
            }).FirstOrDefaultAsync();

            return Ok(showsDto);
        }

        [HttpGet("GetArtistDropdown")]
        public async Task<IActionResult> GetArtistDropdown()
        {
            var artists = _repository.Artist.FindAll(false)
                .Select(y=> new {y.ArtistId, y.Name}).AsQueryable();

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
