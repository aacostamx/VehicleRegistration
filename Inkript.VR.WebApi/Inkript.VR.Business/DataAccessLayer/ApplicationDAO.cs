using Inkript.Json;
using Inkript.Logging;
using Inkript.VR.Business.Helpers;
using Inkript.VR.Models;
using NHibernate;
using NHibernate.Linq;
using NHibernate.Transform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Inkript.VR.Business.DataAccessLayer
{
    public class ApplicationDAO : GenericDAO<Application>
    {

        public IList<Application> ApplicationFilter(int statusId, string userId = null)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                try
                {
                    AuditLog(MethodBase.GetCurrentMethod().Name, typeof(Application).Name, 0);

                    IList<Application> applications = session.GetNamedQuery("DraftApplicationFilter")
                        .SetParameter("StatusId", statusId)
                        .SetParameter("UserId", userId)
                        .SetResultTransformer(Transformers.AliasToBean(typeof(Application)))
                        .List<Application>();

                    if (applications != null && applications.Count > 0)
                    {
                        foreach (var item in applications)
                        {
                            item.Status = session.Query<Status>()
                                .Where(c => c.StatusId == item.StatusId)
                                .FirstOrDefault();
                        }
                    }

                    return applications;
                }
                catch (Exception ex)
                {
                    session.Clear();
                    AuditLog(MethodBase.GetCurrentMethod().Name, typeof(Application).Name, 0, string.Empty, 1);
                    Log.ErrorFormat("Cannot Filter Application", ex);
                    throw new DALException("Cannot ApplicationFilter", ex);
                }
        }

        public int CommitApplication(int applicationId, string businessProcesses)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                try
                {
                    AuditLog(MethodBase.GetCurrentMethod().Name, typeof(Application).Name, 0, JsonConvert.SerializeObject(applicationId));

                    return session.CreateSQLQuery(@"EXEC CommitApplication " + applicationId.ToString() + ", '" + businessProcesses + "'")
                        .UniqueResult<int>();
                }
                catch (Exception ex)
                {
                    session.Clear();
                    AuditLog(MethodBase.GetCurrentMethod().Name, typeof(Application).Name, 0, string.Empty, 1);
                    Log.ErrorFormat("Cannot Commit Application", ex);
                    throw new DALException("Cannot CommitApplication", ex);
                }
        }

        public IList<Application> GetApplications(int? statusId, DateTime? lastUpdated, int? userId, int? branchId, int? sectionId)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                try
                {
                    AuditLog(MethodBase.GetCurrentMethod().Name, typeof(Application).Name, 0);

                    return session.GetNamedQuery("GetApplications")
                        .SetParameter("StatusId", statusId)
                        .SetParameter("LastUpdated", lastUpdated)
                        .SetParameter("UserId", userId)
                        .SetParameter("BranchId", branchId)
                        .SetParameter("SectionId", sectionId)
                        .SetResultTransformer(Transformers.AliasToBean(typeof(Application)))
                        .List<Application>();
                }
                catch (Exception ex)
                {
                    session.Clear();
                    AuditLog(MethodBase.GetCurrentMethod().Name, typeof(Application).Name, 0, string.Empty, 1);
                    Log.ErrorFormat("Cannot Get Applications by Params", ex);
                    throw new DALException("Cannot GetApplications", ex);
                }
        }

        public int CreateApplication(Application application)
        {
            int draftApplicationId = 0;
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                try
                {
                    AuditLog(MethodBase.GetCurrentMethod().Name, typeof(Application).Name, 0, JsonConvert.SerializeObject(application));

                    draftApplicationId = (Int32)session.Save(application);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    session.Clear();
                    AuditLog(MethodBase.GetCurrentMethod().Name, typeof(Application).Name, 0, JsonConvert.SerializeObject(application), 1);
                    Log.ErrorFormat("Cannot Create Application", ex);
                    throw new DALException("Cannot CreateApplication", ex);
                }
                return draftApplicationId;
            }
        }

        public bool UpdateApplication(Application application)
        {
            bool success = false;

            using (ISession session = NHibernateHelper.OpenSession())
                try
                {
                    AuditLog(MethodBase.GetCurrentMethod().Name, typeof(Application).Name, 0, JsonConvert.SerializeObject(application));

                    session.GetNamedQuery("UpdateDraftApplication")
                         .SetParameter("DraftApplicationId", application.ApplicationId)
                         .SetParameter("BranchId", application.BranchId)
                         .SetParameter("SectionId", application.SectionId)
                         .SetParameter("BusinessProcess", application.BusinessProcess)
                         .SetParameter("CarPlateInfo", application.CarPlateInfo)
                         .SetParameter("CarUniqueNumber", application.CarUniqueNumber)
                         .SetParameter("CarDetails", application.CarDetails)
                         .SetParameter("OwnerType", application.OwnerType)
                         .SetParameter("OwnersInfo", application.OwnersInfo)
                         .SetParameter("Fees", application.Fees)
                         .SetParameter("Documents", application.Documents)
                         .SetParameter("AutomaticallyCalculatedFees", application.AutomaticallyCalculatedFees)
                         .SetParameter("OutputDocuments", application.OutputDocuments)
                         .SetParameter("CreatedBy", application.CreatedBy)
                         .SetParameter("ProcessedBy", application.ProcessedBy)
                         .SetParameter("InvoicesNumbers", application.InvoicesNumbers)
                         .SetParameter("StatusId", application.Status.StatusId)
                         .SetParameter("UpdatedBy", application.UpdatedBy)
                         .UniqueResult();
                    success = true;
                }
                catch (Exception ex)
                {
                    session.Clear();
                    AuditLog(MethodBase.GetCurrentMethod().Name, typeof(Application).Name, 0, JsonConvert.SerializeObject(application), 1);
                    Log.ErrorFormat("Cannot Update Application", ex);
                    throw new DALException("Cannot UpdateApplication", ex);
                }
            return success;
        }
    }
}
