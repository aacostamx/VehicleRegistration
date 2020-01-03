using System;
using System.ComponentModel.DataAnnotations;

namespace Inkript.VR.API.Models
{
    public class ImportCustomFilter
    {
        [Required]
        public DateTime YearFrom { get; set; }
        [Required]
        public DateTime YearTo { get; set; }
        public string Type { get; set; }
        public string Chassis { get; set; }
        public string Motor { get; set; }
        public string Mark { get; set; }
        public string Serie { get; set; }
        public int? Model { get; set; }
        public int? Color { get; set; }
        public int? Cylinders { get; set; }
        public int? Office { get; set; }
        public int? Year { get; set; }
        public string Certification_Id { get; set; }
        public string ImporterCode { get; set; }
        public string ImporterName { get; set; }
        public bool? Discounted { get; set; }

    }
}