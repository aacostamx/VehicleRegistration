using System;
using System.Collections.Generic;
using Inkript.Logging;
using Inkript.VR.API.Models;
using Inkript.VR.Business.BusinessLayer;
using Inkript.VR.Models;

namespace Inkript.VR.API.BusinessLayerLogic
{
    public class AuditActivitiesApiBLO
    {
        public ObjectResult<int> CreateAuditActivities(AuditActivities auditActivity)
        {
            AuditActivitiesBLO biz = new AuditActivitiesBLO();
            ObjectResult<int> output = new ObjectResult<int>();

            try
            {
                output.Result = biz.CreateAuditActivities(auditActivity);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = 0;
                output.Success = false;
                output.Message = "Failed to Create Audit Activities";
            }
            return output;
        }

        public ObjectResult<List<AuditActivities>>  GetAllAuditActivities()
        {
            AuditActivitiesBLO biz = new AuditActivitiesBLO();
            ObjectResult<List<AuditActivities>> output = new ObjectResult<List<AuditActivities>>();

            try
            {
                output.Result = biz.GetAllAuditActivities();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to Get All Audit Activities";
            }
            return output;
        }
    }
}