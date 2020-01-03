using Inkript.Logging;
using Inkript.VR.Business.Helpers;
using Inkript.VR.Models;
using NHibernate;
using System;
using System.Collections.Generic;

namespace Inkript.VR.Business.DataAccessLayer
{
    public class ExemptionCategoriesDAO : GenericDAO<ExemptionCategories>
    {
        public IList<ExemptionCategories> ReturnExemptionCategories(List<int> feeIds)
        {
            IQuery query = null;
            string hql = string.Empty;
            using (ISession session = NHibernateHelper.OpenSession())
                try
                {
                    if (feeIds == null)
                    {
                        hql = @"SELECT ec FROM ExemptionCategories AS ec";
                        query = session.CreateQuery(hql);
                    }
                    else
                    {
                        hql = @"SELECT ec FROM ExemptionCategories AS ec
                                   INNER JOIN ec.ExemptedFees AS ef
                                   WHERE ef.ExemptedFeeId IN (:FeeIds)
                                   GROUP BY ec.ExemptionCategoryId, ec.ExemptionCategoryDescEn, ec.ExemptionCategoryDescAr";

                        query = session.CreateQuery(hql);
                        query.SetParameterList("FeeIds", feeIds);
                    }

                    return query.List<ExemptionCategories>();
                }
                catch (Exception ex)
                {
                    session.Clear();
                    Log.ErrorFormat("Cannot Return Exemption Categories ", ex);
                    throw new DALException("Cannot Exemption Categories", ex);
                }
        }
    }
}
