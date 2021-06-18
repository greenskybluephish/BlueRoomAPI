using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace Entities.DataTransferObjects
{
    public class SetlistDto
    {
        private Show _show;
        private List<SongPerformance> _songlist;
        public SetlistDto(IEnumerable<SongPerformance> songList)
        {
            _songlist = songList.ToList();

        }
        
        public int NumberOfSets => _songlist.Select(x=>x.SetNumber).Select(x=>x.SetIndex).Distinct().Count();
        public List<IdNameBase> Songs => _songlist.Select(x => new IdNameBase(x.SongId, x.Song.Name)).ToList();
        public List<Set> Setlist => _songlist.Select(x => x.SetNumber).Distinct()
                .Select(set => new Set(set, _songlist
                    .Where(x => x.SetNumber == set))).ToList();
        }

    public class Setlist
    {
        public Setlist(IEnumerable<Set> sets)
        {
            Sets = sets.ToList();
        }

        public List<Set> Sets { get; }

        public int SetCount => Sets.Count;
    }
    public class Set
    {

        public Set(SetNumber setNumber, IEnumerable<SongPerformance> songList)
        {
            SetNumber = setNumber;
            SongList = songList.ToList();
        }

        public SetNumber SetNumber { get; set; }
        public List<SongPerformance> SongList { get; set; }

        public SongPerformance Opener => SongList.First();
        public SongPerformance Closer => SongList.Last();
    }
}
