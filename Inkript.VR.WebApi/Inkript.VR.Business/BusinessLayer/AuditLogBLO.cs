using System;
using System.Collections.Generic;
using System.Linq;
using Inkript.VR.Business.DataAccessLayer;
using Inkript.VR.Models;

namespace Inkript.VR.Business.BusinessLayer
{
    public class AuditLogBLO
    {
        public AuditLogDAO _da { get; set; }

        public AuditLogBLO()
        {
            _da = new AuditLogDAO();
        }

        public int CreateAuditLog(AuditLog auditLog)
        {
            return _da.CreateAuditLog(auditLog);
        }

        public List<AuditLog> GetAllAuditLog()
        {
            return _da.GetAll().ToList();
        }
    }
}
