using System;
using Inkript.Logging;
using Inkript.VR.Business.Helpers;
using Inkript.VR.Models;
using NHibernate;

namespace Inkript.VR.Business.DataAccessLayer
{
    public class AuditLogDAO : GenericDAO<AuditLog>
    {
        public int CreateAuditLog(AuditLog auditLog)
        {
            int activityLog = 0;
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                try
                {
                    activityLog = (Int32)session.Save(auditLog);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    session.Clear();
                    Log.ErrorFormat("Cannot Create Audit Log", ex);
                    throw new DALException("Cannot CreateAuditLog", ex);
                }
                return activityLog;
            }
        }
    }
}
