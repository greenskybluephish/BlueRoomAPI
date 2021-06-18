using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Entities.Context;
using Entities.DataTransferObjects;
using Entities.Models;

namespace BlueRoom.Controllers
{
    [Route("api/Venues")]
    [ApiController]
    public class VenuesController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public VenuesController(IRepositoryManager repository,
            ILoggerManager logger,
            IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }
        // GET: api/Venues
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var venues = await _repository.Venue.GetAllVenuesAsync(false);
            return Ok(venues);
        }

        // GET: api/Venues
        [HttpGet]
        [RouteAttribute("list")]
        public async Task<IActionResult> GetDropDownList()
        {
            var venues = await _repository.Venue.GetAllVenuesAsync(false);
            var list = venues.Select(y => new IdNameBase(y.VenueId, y.Name));
            return Ok(list);
        }

        // GET: api/Venues/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var venue = await _repository.Venue.GetVenueAsync(id, false);

            if (venue == null)
            {
                return NotFound();
            }

            return Ok(venue);
        }

        // PUT: api/Venues/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] VenueDto venue)
        {
            var venueToUpdate = await _repository.Venue.GetVenueAsync(id, false);

            if (venueToUpdate == null)
            {
                return NotFound();
            }
            var mappedVenue = _mapper.Map<Venue>(venue);

            _repository.Venue.Update(mappedVenue);

            await _repository.SaveAsync();

            return NoContent();
        }

        // POST: api/Venues
        [HttpPost]
        public async Task<IActionResult> Post(Venue venue)
        {
            _repository.Venue.CreateVenue(venue);
            await _repository.SaveAsync();

            return CreatedAtAction("Get", new { id = venue.VenueId }, venue);
        }

        // DELETE: api/Venues/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var venue = await _repository.Venue.GetVenueAsync(id, false);
            if (venue == null)
            {
                return NotFound();
            }

            _repository.Venue.DeleteVenue(venue);
            await _repository.SaveAsync();

            return NoContent();
        }

        private bool VenueExists(int id)
        {
            return _repository.Venue.GetVenueAsync(id, false) != null;
        }
    }
}
