using System.Collections.Generic;

namespace Inkript.VR.Models
{
    public class DocumentGroups
    {
        public DocumentGroups()
        {
            Documents = new List<Documents>();
        }
        public virtual int GroupId { get; set; }
        public virtual string GroupName { get; set; }
        public virtual IList<Documents> Documents { get; set; }
    }
}
