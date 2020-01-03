using System;
using System.Collections.Generic;
using System.Linq;
using Inkript.Logging;
using Inkript.VR.Business.Helpers;
using Inkript.VR.Models;
using NHibernate;
using NHibernate.Linq;

namespace Inkript.VR.Business.DataAccessLayer
{
    public class ExemptedFeesDAO : GenericDAO<ExemptedFees>
    {
        public bool ExemptedFeeExist(int exemptedFeeId)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                try
                {
                    return session.Query<ExemptedFees>()
                        .Any(c => (c.ExemptedFeeId == exemptedFeeId));
                }
                catch (Exception ex)
                {
                    session.Clear();
                    Log.ErrorFormat("Cannot check if Exempted Fee Exist", ex);
                    throw new DALException("Cannot ExemptedFeeExist", ex);
                }
        }

        public IList<ExemptedFeesActive> ReturnExemptedFees(List<int> exemptionCategoriesIds)
        {
            IQuery query = null;
            string hql = string.Empty;
            using (ISession session = NHibernateHelper.OpenSession())
                try
                {
                    if (exemptionCategoriesIds == null)
                    {
                        hql = @"SELECT efa FROM ExemptedFeesActive AS efa";
                        query = session.CreateQuery(hql);
                    }
                    else
                    {
                        hql = @"SELECT efa FROM ExemptedFeesActive AS efa 
                                WHERE efa.ExemptedCategoryId IN (:ExemptionCategoriesIds)";
                        query = session.CreateQuery(hql);
                        query.SetParameterList("ExemptionCategoriesIds", exemptionCategoriesIds);
                    }

                    return query.List<ExemptedFeesActive>();
                }
                catch (Exception ex)
                {
                    session.Clear();
                    Log.ErrorFormat("Cannot Return Exempted Fees", ex);
                    throw new DALException("Cannot ReturnExemptedFees", ex);
                }
        }
    }
}
