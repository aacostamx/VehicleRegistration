using System;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Inkript.VR.API.Models {
    
    public class OrganizationCustom {
        [JsonIgnore]
        public int OrganizationId { get; set; }
        [Required]
        public string OrganizationName { get; set; }
        [Required]
        public string RegistrationNumber { get; set; }
        [Required]
        public int RegisterRegionId { get; set; }
        [Required]
        public string MOFNumber { get; set; }
        [Required]
        public int SectorId { get; set; }
        [Required]
        public int CompanyClassId { get; set; }
        [Required]
        public int CompanyCategoryId { get; set; }
        [Required]
        public int RegionId { get; set; }
        public string Street { get; set; }
        [Required]
        public string Building { get; set; }
        [Required]
        public int StatusId { get; set; }
    }
}
