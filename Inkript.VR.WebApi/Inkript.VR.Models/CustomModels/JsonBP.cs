using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Inkript.VR.Models
{
    public class JsonBP
    {
        public JsonBP()
        {
            BPList = new List<int>();
            SecondaryBusinessProcess = new List<int>();
            BusinessProcesses = new List<BusinessProcessJSON>();
        }

        public BusinessProcessJSON PrimaryBusinessProcess { get; set; }
        public List<int> SecondaryBusinessProcess { get; set; }
        [IgnoreDataMember]
        public List<BusinessProcessJSON> BusinessProcesses { get; set; }
        [IgnoreDataMember]
        public List<int> BPList { get; set; }
    }

    public class BusinessProcessJSON
    {
        public int BPId { get; set; }
    }
}
