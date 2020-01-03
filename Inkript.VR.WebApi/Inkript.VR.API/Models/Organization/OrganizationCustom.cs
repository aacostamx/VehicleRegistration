using System.ComponentModel.DataAnnotations;

namespace Inkript.VR.API.Models
{

    public class OrganizationCustom
    {
        [Required]
        public string OrganizationName { get; set; }
        [Required]
        public string RegistrationNumber { get; set; }
        public int RegionId { get; set; }
        [Required]
        public string MOFNumber { get; set; }
        public int SectorId { get; set; }
        public int CompanyClassId { get; set; }
        public int CompanyCategoryId { get; set; }
        public int RegisterRegionId { get; set; }
        public string Street { get; set; }
        public int StatusId { get; set; }
        public string Building { get; set; }
    }
}