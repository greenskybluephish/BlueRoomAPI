using System.Collections.Generic;
using Entities.DataTransferObjects;

namespace Entities.Models
{

    public partial class VwShow
    {
        public IEnumerable<SongPerformance> SongPerformances { get; set; }
        public IEnumerable<IdNameBase> Songs { get; set; }
    }
}