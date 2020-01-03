using System;
using System.Collections.Generic;
using System.Linq;
using Inkript.VR.Business.DataAccessLayer;
using Inkript.VR.Models;

namespace Inkript.VR.Business.BusinessLayer
{
    public class ExemptionCategoriesBLO
    {
        public ExemptionCategoriesDAO _da { get; set; }

        public ExemptionCategoriesBLO()
        {
            _da = new ExemptionCategoriesDAO();
        }

        public List<ExemptionCategories> ReturnExemptionCategories(List<int> feeIds)
        {
            return _da.ReturnExemptionCategories(feeIds).ToList();
        }
    }
}
