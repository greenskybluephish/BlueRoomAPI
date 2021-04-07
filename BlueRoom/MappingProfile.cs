using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.DataTransferObjects;
using Entities.Models;
using AutoMapper;
using Entities.Models.Partials;

namespace BlueRoom
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Song, SongDto>();

            CreateMap<SongDto, Song>();

            CreateMap<Show, ShowDto>();

            CreateMap<ShowDto, Show>();

            CreateMap<Artist, ArtistDto>();

            CreateMap<ArtistDto, Artist>();

            CreateMap<SongPerformance, SongPerformanceDto>();

            CreateMap<SongPerformanceDto, SongPerformance>();

            CreateMap<Venue, VenueDto>();

            CreateMap<VenueDto, Venue>();

        }
    }
}
