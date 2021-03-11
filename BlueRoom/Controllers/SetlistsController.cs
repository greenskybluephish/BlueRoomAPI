using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlueRoom.Controllers
{
    [Route("api/Setlists")]
    [ApiController]
    public class SetlistsController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public SetlistsController(IRepositoryManager repository,
            ILoggerManager logger,
            IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        // GET api/Setlist
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var setlists = await _repository.Setlist.GetAllSetlistsAsync(trackChanges: false);

            var setlistsDto = _mapper.Map<IQueryable<SetlistDto>>(setlists);

            return Ok(setlistsDto);
        }


        //[Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var setlist = await _repository.Setlist.GetSetlistAsync(id, trackChanges: false);
            return Ok(setlist);
        }

        // POST api/Setlist
        [HttpPost]
        public async Task Post(SetlistDto model)
        {
            var mapped = _mapper.Map<Setlist>(model);
            _repository.Setlist.Create(mapped);
            await _repository.SaveAsync();
        }

        // [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] SetlistDto setlist)
        {
            var setlistToUpdate = await _repository.Setlist.GetSetlistAsync(id, false);

            if (setlistToUpdate == null)
            {
                return NotFound();
            }
            var mappedSetlist = _mapper.Map<Setlist>(setlist);

            _repository.Setlist.Update(mappedSetlist);

            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var setlist = await _repository.Setlist.GetSetlistAsync(id, false);

            _repository.Setlist.DeleteSetlist(setlist);
            await _repository.SaveAsync();
            return NoContent();
        }
    }
}
