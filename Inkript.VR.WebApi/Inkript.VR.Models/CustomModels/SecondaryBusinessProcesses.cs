namespace Inkript.VR.Models
{
    public class SecondaryBusinessProcesses
    {
        public int BPRelationshipsId { get; set; }
        public int BPId { get; set; }
        public int AssociatedBP { get; set; }
        public string BPNameEn { get; set; }
        public string BPNameAr { get; set; }
        public string BPType { get; set; }
        public string Icon { get; set; }
        public string HotKey { get; set; }
        public string BPUrl { get; set; }
        public int CarStatusId { get; set; }
        public int StatusId { get; set; }
    }
}
