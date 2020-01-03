using Inkript.VR.Business.DataAccessLayer;
using Inkript.VR.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Inkript.VR.Business.BusinessLayer
{
    public class ApplicationBLO
    {
        private ApplicationDAO _da { get; set; }

        public ApplicationBLO()
        {
            _da = new ApplicationDAO();
        }

        public int CreateApplication(Application application)
        {
            application.CreatedDate = DateTime.Now;
            return _da.CreateApplication(application);
        }

        public List<Application> GetAllApplication()
        {
            return _da.GetAll().ToList();
        }

        public bool ApplicationExist(int applicationId)
        {
            return _da.Exist(applicationId);
        }

        public Application GetApplication(int applicationId)
        {
            return _da.GetById(applicationId);
        }

        public bool UpdateApplication(Application application)
        {
            return _da.UpdateApplication(application);
        }

        public List<Application> ApplicationFilter(int statusId, string userId = null)
        {
            return _da.ApplicationFilter(statusId, userId).ToList();
        }

        public bool DeleteApplication(int applicationId)
        {
            return _da.Delete(GetApplication(applicationId));
        }

        public List<Application> GetApplications(int? statusId, DateTime? lastUpdated, int? userId, int? branchId, int? sectionId)
        {
            return _da.GetApplications(statusId, lastUpdated, userId, branchId, sectionId).ToList();
        }

        public int CommitApplication(int applicationId, string businessProcesses)
        {
            return _da.CommitApplication(applicationId, businessProcesses);
        }

        public PrivateLogRUFPayment GetPrivateLogRUFPayment(int applicationId)
        {
            //TODO waiting for the business requirement of this part
            return new PrivateLogRUFPayment() { };
        }
    }
}
