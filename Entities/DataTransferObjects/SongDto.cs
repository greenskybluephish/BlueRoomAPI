using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Entities.Models;

namespace Entities.DataTransferObjects
{
    public class SongDto
    {
        public int SongId { get; set; }

        [Required] public string Name { get; set; }

        public string Description { get; set; }

        [Required] public int OriginalArtistId { get; set; }

        public ArtistDto OriginalArtist { get; set; }

        public ICollection<SongPerformanceDto> SongPerformances { get; set; }


    }


    public class Setlist
    {
        public Setlist(List<Set> sets)
        {
            Sets = sets;
        }

        public List<Set> Sets { get; }

        public int SetCount => Sets.Count;
    }

    public class Set
    {

        public Set(SetNumber setNumber, List<SongPerformance> songList)
        {
            SetNumber = setNumber;
            SongList = songList;
        }

        public SetNumber SetNumber { get; set; }
        public List<SongPerformance> SongList { get; set; }

        public SongPerformance Opener => SongList.First(y=>y.SetOpener);
        public SongPerformance Closer => SongList.Last(y=>y.SetCloser);
    }

    public class IdNameBase
    {
        public IdNameBase(int id, string name)
        {
            Name = name;
            Id = id;
        }
        public string Name { get; set; }
        public int Id { get; set; }
    }
}
