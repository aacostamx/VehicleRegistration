using Inkript.VR.Business.DataAccessLayer;
using Inkript.VR.Models;
using System.Collections.Generic;
using System.Linq;

namespace Inkript.VR.Business.BusinessLayer
{
    public class DocumentGroupsBLO
    {
        private DocumentGroupsDAO _da { get; set; }

        public DocumentGroupsBLO()
        {
            _da = new DocumentGroupsDAO();
        }

        public List<DocumentGroups> GetDocumentGroups(List<DocumentCustom> documents)
        {
            return _da.GetDocumentGroups(documents).ToList();
        }
    }
}
