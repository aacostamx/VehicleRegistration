using System;
using System.Collections.Generic;
using System.Linq;
using Inkript.VR.Business.DataAccessLayer;
using Inkript.VR.Models;

namespace Inkript.VR.Business.BusinessLayer
{
    public class DocumentsBLO
    {
        private DocumentsDAO _da { get; set; }

        public DocumentsBLO()
        {
            _da = new DocumentsDAO();
        }

        public List<Documents> GetDocuments(int BPId, int SectorId, int VehicleTypeId)
        {
            return _da.GetDocuments(BPId, SectorId, VehicleTypeId).ToList();
        }

        public List<Documents> GetDocuments(List<DocumentCustom> documents)
        {
            return _da.GetDocuments(documents).ToList();
        }

        public List<Documents> GetAllDocuments()
        {
            return _da.GetAll().ToList();
        }

        public List<Documents> GetBusinessProcessDocuments(int businessProcessId)
        {
            return _da.GetBusinessProcessDocuments(businessProcessId).ToList();
        }
    }
}
