using System;
using System.Collections.Generic;
using Inkript.Logging;
using Inkript.VR.API.Models;
using Inkript.VR.Business.BusinessLayer;
using Inkript.VR.Models;

namespace Inkript.VR.API.BusinessLayerLogic
{
    public class AuditLogApiBLO
    {
        public ObjectResult<int> CreateAuditLog(AuditLog auditLog)
        {
            AuditLogBLO biz = new AuditLogBLO();
            ObjectResult<int> output = new ObjectResult<int>();

            try
            {
                output.Result = biz.CreateAuditLog(auditLog);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = 0;
                output.Success = false;
                output.Message = "Failed to Create Audit Log";
            }
            return output;
        }

        internal object GetAllAuditLogs()
        {
            throw new NotImplementedException();
        }

        public ObjectResult<List<AuditLog>> GetAllAuditLog()
        {
            AuditLogBLO biz = new AuditLogBLO();
            ObjectResult<List<AuditLog>> output = new ObjectResult<List<AuditLog>>();

            try
            {
                output.Result = biz.GetAllAuditLog();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to Get All Audit Logs";
            }
            return output;
        }
    }
}