using System;

namespace Entities.DataTranferObjects.LocaleDto
{
    public class LocaleDto
    {
        public Guid Id { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
}