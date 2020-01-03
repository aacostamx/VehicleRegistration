using System;
using System.Collections.Generic;
using System.Linq;
using Inkript.VR.Business.DataAccessLayer;
using Inkript.VR.Models;

namespace Inkript.VR.Business.BusinessLayer
{
    public class ExemptedFeesBLO
    {
        public ExemptedFeesDAO _da { get; set; }

        public ExemptedFeesBLO()
        {
            _da = new ExemptedFeesDAO();
        }

        public bool ExemptedFeeExist(int exemptedFeeId)
        {
            return _da.ExemptedFeeExist(exemptedFeeId);
        }

        public List<ExemptedFees> GetExemptedFees()
        {
            return _da.GetAll().ToList();
        }

        public List<ExemptedFeesActive> ReturnExemptedFees(List<int> exemptionCategoriesIds)
        {
            return _da.ReturnExemptedFees(exemptionCategoriesIds).ToList();
        }
    }
}
