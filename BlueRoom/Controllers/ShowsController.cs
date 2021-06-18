﻿using Microsoft.AspNetCore.Mvc;
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
    [Route("api/Shows")]
    [ApiController]
    public class ShowsController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public ShowsController(IRepositoryManager repository,
            ILoggerManager logger,
            IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        // GET api/Shows
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var shows = _repository.Show.FindAll(false)
                .Include(v =>v.Venue)
                .Include(a=>a.PerformingArtist)
                .Include(s=>s.SongPerformances)
                .ThenInclude(y=>y.Song)
                .AsQueryable();

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
            }).OrderBy(y=>y.ShowDate).Take(2).ToListAsync();

            return Ok(showsDto);
        }


        //[Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var s = await _repository.Show.FindByCondition(x=> x.ShowId.Equals(id), false)
                .Include(v => v.Venue)
                .Include(a => a.PerformingArtist)
                .Include(s => s.SongPerformances)
                .ThenInclude(y=>y.SetNumber)
                .Include(s => s.SongPerformances)
                .ThenInclude(y => y.Song)
                .FirstOrDefaultAsync();

            var showsDto = new ShowDto()
            {
                ShowId = s.ShowId,
                ShowDate = s.Date,
                ShowDateString = s.Date.ToShortDateString(),
                VenueName = s.Venue.Name,
                VenueCity = s.Venue.City,
                VenueCountry = s.Venue.Country,
                VenueState = s.Venue.State,
                Setlist = new SetlistDto(s.SongPerformances)
            };
            return Ok(showsDto);
        }

        // POST api/Show
        [HttpPost]
        public async Task Post(ShowDto model)
        {
            var mapped = _mapper.Map<Show>(model);
            _repository.Show.Create(mapped);
            await _repository.SaveAsync();
        }

        // [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] ShowDto show)
        {
            var showToUpdate = await _repository.Show.GetShowAsync(id, false);

            if (showToUpdate == null)
            {
                return NotFound();
            }
            var mappedShow = _mapper.Map<Show>(show);

            _repository.Show.Update(mappedShow);

            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var show = await _repository.Show.GetShowAsync(id, false);

            if (show == null)
            {
                return NotFound();
            }

            _repository.Show.DeleteShow(show);
            await _repository.SaveAsync();
            return NoContent();
        }
    }
}
