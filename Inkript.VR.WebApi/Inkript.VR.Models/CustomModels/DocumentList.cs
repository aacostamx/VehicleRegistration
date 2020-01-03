using System.Collections.Generic;

namespace Inkript.VR.Models
{
    public class DocumentList
    {
        public DocumentList()
        {
            DocumentInputs = new List<DocumentInput>();
        }
        public int DocumentId { get; set; }
        public string DocumentNameEn { get; set; }
        public string DocumentNameAr { get; set; }
        public List<DocumentInput> DocumentInputs { get; set; }
    }
}
