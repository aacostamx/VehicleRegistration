using Inkript.VR.API.Helpers;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace Inkript.VR.API.Models
{

    public class ImportCustomsCustom {
        [JsonIgnore]
        public int ImportCustomId { get; set; }
        public int FileInfoCustomId { get; set; }
        [JsonConverter(typeof(JsonFormatValidate), "dd/MM/yyyy")]
        [JsonProperty(PropertyName = "Date")]
        public DateTime CertificateDate { get; set; }
        [JsonProperty(PropertyName = "Type")]
        public string OperationType { get; set; }
        [Required]
        [JsonProperty(PropertyName = "Certification_Id")]
        public string CertificateId { get; set; }
        [JsonProperty(PropertyName = "Year")]
        public int FiscalYear { get; set; }    
        public ImporterCustom Importer { get; set; }
        [JsonProperty(PropertyName = "Mark")]
        public int BrandId { get; set; }
        [JsonProperty(PropertyName = "Mark_Desc")]
        public string BrandDesc { get; set; }
        [JsonProperty(PropertyName = "Serie")]
        public int ModelId { get; set; }
        [JsonProperty(PropertyName = "Serie_Desc")]
        public string ModelDesc { get; set; }
        [JsonProperty(PropertyName = "Model")]
        public int ProductionYear { get; set; }
        [JsonProperty(PropertyName = "Color")]
        public int ColorId { get; set; }
        [JsonProperty(PropertyName = "Color_Desc")]
        public string ColorDesc { get; set; }
        [JsonProperty(PropertyName = "Chassis")]
        public string Chassis { get; set; }
        [JsonProperty(PropertyName = "Motor")]
        public string MotorNumber { get; set; }
        public string Comments { get; set; }
        [JsonIgnore]
        public DateTime CreatedDate { get; set; }
        [JsonIgnore]
        public DateTime? DateModified { get; set; }
        [JsonProperty(PropertyName = "Value")]
        public float Value { get; set; }
        [JsonProperty(PropertyName = "Taxes")]
        public float Taxes { get; set; }
        [JsonProperty(PropertyName = "Cylinders")]
        public int Cylinders { get; set; }
        [JsonProperty(PropertyName = "Office")]
        public int OfficeId { get; set; }
        public int Discounted { get; set; }
    }
}
