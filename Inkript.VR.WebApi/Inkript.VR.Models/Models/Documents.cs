using System.Collections.Generic;

namespace Inkript.VR.Models
{
    public class Documents {
        public Documents()
        {
            DocumentInput = new List<DocumentInput>();
        }
        public virtual int DocumentId { get; set; }
        public virtual string DocumentNameEn { get; set; }
        public virtual string DocumentNameAr { get; set; }
        public string Mandatory { get; set; }
        public virtual int? GroupId { get; set; }
        public virtual IList<DocumentInput> DocumentInput { get; set; }
    }
}
