using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.DataTranferObjects.SetlistDto
{
    public abstract class SetlistForManipulationDto
    {
        [Required(ErrorMessage = "Date is required")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime Date { get; set; }

    }
}