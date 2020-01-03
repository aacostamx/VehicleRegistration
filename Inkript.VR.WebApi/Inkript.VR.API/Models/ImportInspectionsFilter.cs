using System;
using System.ComponentModel.DataAnnotations;

namespace Inkript.VR.API.Models
{
    public class ImportInspectionsFilter
    {
        [Required]
        [DataType(DataType.Date)]
        public DateTime YearFrom { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime YearTo { get; set; }
        public string PlateNumber { get; set; }
        public int? PlateCodeId { get; set; }
    }
}