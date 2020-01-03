using Inkript.Logging;
using Inkript.VR.API.Models;
using Inkript.VR.Business;
using Inkript.VR.Business.BusinessLayer;
using Inkript.VR.Models;
using System;
using System.Collections.Generic;

namespace Inkript.VR.API
{
    public class InvoiceNumberApiBLO
    {
        public ObjectResult<string> GenerateInvoiceNumber(int branchId, int feeCategoryId)
        {
            InvoiceNumberBLO invoiceNumberBiz = new InvoiceNumberBLO();
            BranchesBLO branchesBiz = new BranchesBLO();
            FeeCategoryBLO feeCategoryBiz = new FeeCategoryBLO();
            ObjectResult<string> output = new ObjectResult<string>();

            try
            {
                if (!feeCategoryBiz.FeeCategoryExist(feeCategoryId))
                {
                    output.Message = string.Format("Fee Category Id {0} Not Found", feeCategoryId);
                    return output;
                }

                if (!branchesBiz.BranchExist(branchId))
                {
                    output.Message = string.Format("Branch Id {0} Not Found", branchId);
                    return output;
                }

                output.Result = invoiceNumberBiz.GenerateInvoiceNumber(branchId, feeCategoryId);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = default(string);
                output.Success = false;
                output.Message = "Failed to Generate Invoice Number";
            }
            return output;
        }
    }
}