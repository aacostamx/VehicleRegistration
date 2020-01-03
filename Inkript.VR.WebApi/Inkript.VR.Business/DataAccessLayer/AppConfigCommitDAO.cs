using System;
using System.Collections.Generic;
using System.Reflection;
using Inkript.Json;
using Inkript.Logging;
using Inkript.VR.Business.Helpers;
using Inkript.VR.Models;
using NHibernate;

namespace Inkript.VR.Business.DataAccessLayer
{
    public class AppConfigCommitDAO : GenericDAO<AppConfigCommit>
    {
        public IList<AppConfigCommit> GetAppConfigCommit(List<int> bpList)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                try
                {
                    AuditLog(MethodBase.GetCurrentMethod().Name, typeof(AppConfigCommit).Name, 0, JsonConvert.SerializeObject(bpList));

                    IQuery query = null;
                    string hql = string.Empty;

                    hql = @"SELECT acp FROM AppConfigCommit acp WHERE acp.BPId IN (:bpIds) ORDER BY acp.SectionId;";
                    query = session.CreateQuery(hql);
                    query.SetParameterList("bpIds", bpList);

                    return query.List<AppConfigCommit>();
                }
                catch (Exception ex)
                {
                    session.Clear();
                    AuditLog(MethodBase.GetCurrentMethod().Name, typeof(AppConfigCommit).Name, 0, JsonConvert.SerializeObject(bpList), 1);
                    Log.ErrorFormat("Cannot Get Appliacation Config for Commit", ex);
                    throw new DALException("Cannot GetAppConfigCommit", ex);
                }
        }
    }
}
