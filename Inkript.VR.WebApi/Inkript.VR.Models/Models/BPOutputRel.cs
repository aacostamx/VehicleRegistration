namespace Inkript.VR.Models
{

    public class BPOutputRel {
        public virtual int BPOuputId { get; set; }
        public virtual int BPId { get; set; }
        public virtual BPOutput BPOutput { get; set; }
    }
}
