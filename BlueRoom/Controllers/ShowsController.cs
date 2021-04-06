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
    [Route("api/Shows")]
    [ApiController]
    public class ShowController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public ShowController(IRepositoryManager repository,
            ILoggerManager logger,
            IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        // GET api/Show
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var shows = await _repository.Show.GetAllShowsAsync(trackChanges: false);

            var showsDto = _mapper.Map<IQueryable<ShowDto>>(shows);

            return Ok(showsDto);
        }


        //[Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var show = await _repository.Show.GetShowAsync(id, trackChanges: false);
            return Ok(show);
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
        public async Task<ActionResult> Put(Guid id, [FromBody] ShowDto show)
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
        public async Task<IActionResult> Delete(Guid id)
        {
            var show = await _repository.Show.GetShowAsync(id, false);

            _repository.Show.DeleteShow(show);
            await _repository.SaveAsync();
            return NoContent();
        }
    }
}
