using Inkript.VR.API.Helpers;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace Inkript.VR.API.Models
{
    public class ImportCustomsCustom
    {
        [Required]
        public string Certification_Id { get; set; }
        [JsonConverter(typeof(JsonFormatValidate), "dd/MM/yyyy")]
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public string Chassis { get; set; }
        public string Motor { get; set; }
        public string Mark { get; set; }
        public string Mark_Desc { get; set; }
        public string Serie { get; set; }
        public string Serie_Desc { get; set; }
        public int? Model { get; set; }
        public int? Color { get; set; }
        public string Color_Desc { get; set; }
        public int? Cylinders { get; set; }
        public int? Office { get; set; }
        public int? Year { get; set; }
        public string ImporterCode { get; set; }
        public string ImporterName { get; set; }
        public float Value { get; set; }
        public float Taxes { get; set; }
        public bool? Discounted { get; set; }
    }
}