using System;
using Inkript.Logging;
using Inkript.VR.Business.Helpers;
using Inkript.VR.Models;
using NHibernate;

namespace Inkript.VR.Business.DataAccessLayer
{
    public class AuditActivitiesDAO : GenericDAO<AuditActivities>
    {
        public int CreateAuditActivities(AuditActivities auditActivity)
        {
            int activityLog = 0;
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                try
                {
                    activityLog = (Int32)session.Save(auditActivity);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    session.Clear();
                    Log.ErrorFormat("Cannot Create Audit Activities", ex);
                    throw new DALException("Cannot CreateAuditActivities", ex);
                }
                return activityLog;
            }
        }
    }
}
