namespace Inkript.VR.Models
{
    public class Organization {
        public virtual int OrganizationId { get; set; }
        public virtual string OrganizationName { get; set; }
        public virtual string RegistrationNumber { get; set; }
        public virtual int RegisterRegionId { get; set; }
        public virtual string MOFNumber { get; set; }
        public virtual int SectorId { get; set; }
        public virtual int CompanyClassId { get; set; }
        public virtual int CompanyCategoryId { get; set; }
        public virtual int RegionId { get; set; }
        public virtual string Street { get; set; }
        public virtual string Building { get; set; }
        public virtual Status Status { get; set; }
    }
}
