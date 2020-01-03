using System;
using System.Collections.Generic;
using System.Linq;
using Inkript.VR.Business.DataAccessLayer;
using Inkript.VR.Models;

namespace Inkript.VR.Business.BusinessLayer
{
    public class AuditActivitiesBLO
    {
        public AuditActivitiesDAO _da { get; set; }

        public AuditActivitiesBLO()
        {
            _da = new AuditActivitiesDAO();
        }

        public int CreateAuditActivities(AuditActivities auditActivity)
        {
            return _da.CreateAuditActivities(auditActivity);
        }

        public List<AuditActivities> GetAllAuditActivities()
        {
            return _da.GetAll().ToList();
        }
    }
}
