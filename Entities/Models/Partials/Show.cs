using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.DataTransferObjects;

namespace Entities.Models
{

    public partial class VwShow
    {
        public IEnumerable<SongPerformance> SongPerformances { get; set; }
        public IEnumerable<IdNameBase> Songs { get; set; }
    }
}