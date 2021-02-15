using System;
using Entities.Enumerations;

namespace Entities.DataTranferObjects.ExternalMediaObjectDto
{
    public class ExternalMediaObjectDto
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public MediaType Type { get; set; }
    }
}