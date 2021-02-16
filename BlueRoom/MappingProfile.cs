using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.DataTranferObjects.SongDto;
using Entities.Models;
using AutoMapper;
using Entities.DataTranferObjects.SetlistDto;

namespace BlueRoom
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Song, SongDto>();
            CreateMap<SongDto, Song>();

            CreateMap<Setlist, SetlistDto>();

            CreateMap<SongForCreationDto, Song>();

            CreateMap<SetlistForCreationDto, Setlist>().ReverseMap();

            CreateMap<SetlistForUpdateDto, Setlist>().ReverseMap();

            CreateMap<SongForUpdateDto, Song>();


        }
    }
}
