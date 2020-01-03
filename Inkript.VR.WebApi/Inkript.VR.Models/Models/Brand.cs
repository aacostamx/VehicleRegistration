namespace Inkript.VR.Models
{

    public class Brand {
        public virtual int BrandId { get; set; }
        public virtual string BrandNameEN { get; set; }
        public virtual string BrandNameAR { get; set; }
        public virtual Status Status { get; set; }
    }
}
