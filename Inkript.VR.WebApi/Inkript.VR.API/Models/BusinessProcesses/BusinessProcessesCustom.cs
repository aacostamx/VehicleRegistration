using Inkript.VR.Models;
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

        [Required]
        public string BPNameEn { get; set; }
        [Required]
        public string BPNameAr { get; set; }
        public string BPType { get; set; }
        public string Icon { get; set; }
        [StringLength(1)]
        public string HotKey { get; set; }
        public string BPUrl { get; set; }
        public bool? Active { get; set; }
        public List<BPRelationshipsCustom> BPRelationships { get; set; }
    }
}