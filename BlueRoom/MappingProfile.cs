using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.DataTransferObjects;
using Entities.Models;
using AutoMapper;

namespace BlueRoom
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Song, SongDto>();
            CreateMap<SongDto, Song>();

            CreateMap<Setlist, SetlistDto>();

            CreateMap<SetlistDto, Setlist>();

            CreateMap<Artist, ArtistDto>();

            CreateMap<ArtistDto, Artist>();

        }
    }
}
