namespace Inkript.VR.Models
{

    public class Cities {
        public virtual int CityId { get; set; }
        public virtual string CityNameEn { get; set; }
        public virtual string CityNameAr { get; set; }
        public virtual Districts Districts { get; set; }
    }
}
