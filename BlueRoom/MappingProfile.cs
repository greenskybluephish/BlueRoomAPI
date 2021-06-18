using System.Linq;
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

            CreateMap<Show, ShowDto>()
                .ForMember(dto=> dto.ArtistName, cfg => cfg.MapFrom(a=>a.PerformingArtist.Name))
                .ForMember(dto=>dto.Setlist, cfg=> cfg.MapFrom(s=> s.SongPerformances.Select(y=>y.Song.Name)));

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
