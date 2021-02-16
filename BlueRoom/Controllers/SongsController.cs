using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.DataTranferObjects.ArtistDto;
using Entities.DataTranferObjects.ExternalMediaObjectDto;
using Entities.DataTranferObjects.SongDto;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlueRoom.Controllers
{
    [Route("api/songs")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public SongsController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }


        // GET api/SONG
        //[HttpGet]
        //[HttpGet]
        public async Task<IActionResult> Get()
        {
            var companies = await _repository.Song.GetAllSongsAsync(trackChanges: false);

            var companiesDto = _mapper.Map<IQueryable<SongDto>>(companies);

            return Ok(companiesDto);
        }

        // POST api/Song
        [HttpPost]
        public async Task Post(SongModel model)
        {
            var mapped = _mapper.Map<Song>(model);
            _repository.Song.Create(mapped);
            await _repository.SaveAsync();
        }

        // GET api/Song
        //[HttpGet]
        //public async Task<IActionResult> Get()
        //{
        //    var companies = await _repository.Song.GetAllSongsAsync(trackChanges: false);

        //    var companiesDto = _mapper.Map<IQueryable<SongDto>>(companies);

        //    return Ok(companiesDto);
        //}

        //// GET api/Song/{email}
        //[Authorize]
        //[HttpGet("{id}")]
        //public async Task<IActionResult> Get(Guid id)
        //{
        //    var song = await _repository.Song.GetSongAsync(id, trackChanges: false);
        //    return Ok(song);
        //}

        //// POST api/Song
        //[Authorize]
        //[HttpPost]
        //public async Task Post(SongForCreationDto model)
        //{
        //    await _repository.Song.
        //    await _repository.SaveAsync();
        //}

        //// PUT api/Song/{email}
        //[Authorize]
        //[HttpPut("{id}")]
        //public async Task<ActionResult> Put(string id, Song model)
        //{
        //    var exists = await _repository.Song.AnyAsync(f => f.Id == id);
        //    if (!exists)
        //    {
        //        return NotFound();
        //    }

        //    _repository.Song.Update(model);

        //    await _repository.SaveAsync();

        //    return Ok();
        //}
    }
}
