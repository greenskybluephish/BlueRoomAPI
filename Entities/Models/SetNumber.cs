using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class SetNumber
    {
        public Guid SetNumberId { get; set; }
        public int SetIndex { get; set; }
        public string SetName { get; set; }
        public bool FullSet { get; set; }
    }
}
