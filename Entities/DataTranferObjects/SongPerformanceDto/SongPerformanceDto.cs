using System;
using Entities.Enumerations;

namespace Entities.DataTranferObjects.SongPerformanceDto
{
    public class SongPerformanceDto
    {
        public Guid Id { get; set; }
        public SetNumber SetIndex { get; set; }
        public int SetlistSongIndex { get; set; }
        public int? Duration { get; set; }

    }
}