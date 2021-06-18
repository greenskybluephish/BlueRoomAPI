using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;

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

        public SongsController(IRepositoryManager repository, 
            ILoggerManager logger,
            IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        // GET api/SONG
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var songs = await _repository.Song.GetAllSongsAsync(trackChanges: false);

            var songsDto = _mapper.Map<IEnumerable<SongDto>>(songs);

            return Ok(songsDto);
        }

        // GET api/Song/{email}
        //[Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var song = await _repository.Song.GetSongAsync(id, trackChanges: false);
            return Ok(song);
        }

        // POST api/Song
        [HttpPost]
        public async Task Post(SongDto model)
        {
            var mapped = _mapper.Map<Song>(model);
            _repository.Song.Create(mapped);
            await _repository.SaveAsync();
        }

        // PUT api/Song/{email}
       // [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] SongDto song)
        {
            var songToUpdate = await _repository.Song.GetSongAsync(id, false);
            
            if (songToUpdate == null)
            {
                return NotFound();
            }
            var mappedSong = _mapper.Map<Song>(song);
            
            _repository.Song.Update(mappedSong);
            

            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var song = await _repository.Song.GetSongAsync(id, false);

            _repository.Song.DeleteSong(song);
            await _repository.SaveAsync();
            return NoContent();
        }
    }
}
