using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Inkript.VR.API.Models
{

    public class BusinessProcessesCustom
    {
        public BusinessProcessesCustom()
        {
            BPRelationships = new List<BPRelationshipsCustom>();
        }
        [JsonIgnore]
        public int BPId { get; set; }
        [Required]
        public string BPNameEn { get; set; }
        [Required]
        public string BPNameAr { get; set; }
        public string BPType { get; set; }
        public string Icon { get; set; }
        [StringLength(1)]
        public string HotKey { get; set; }
        public string BPUrl { get; set; }
        public int CarStatusId { get; set; }
        public int StatusId { get; set; }

        [JsonIgnore]
        public IList<BPFeeCustom> BPFee { get; set; }
        [JsonIgnore]
        public IList<BPOutputRelCustom> BPOutputRel { get; set; }
        public IList<BPSectorVehicleCustom> BPSectorVehicle { get; set; }
        public IList<BPRelationshipsCustom> BPRelationships { get; set; }
        [JsonIgnore]
        public IList<DocumentProcessRelationshipCustom> DocumentProcessRelationship { get; set; }
        [JsonIgnore]
        public IList<OutputGroupCustom> OutputGroup { get; set; }

        [JsonIgnore]
        public IList<BPRelationshipsCustom> SecondaryBusinessProcesses { get; set; }
    }
}
