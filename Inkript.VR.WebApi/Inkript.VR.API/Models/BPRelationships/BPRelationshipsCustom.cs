using Newtonsoft.Json;

namespace Inkript.VR.API.Models
{
    public class BPRelationshipsCustom
    {
        [JsonIgnore]
        public int Id { get; set; }
        public int BPId { get; set; }
        [JsonIgnore]
        public int AssociatedBP { get; set; }
        public bool Mandatory { get; set; }
    }
}