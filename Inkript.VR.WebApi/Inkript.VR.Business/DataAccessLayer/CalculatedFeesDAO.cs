using Inkript.Logging;
using Inkript.VR.Business.Helpers;
using Inkript.VR.Models;
using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Inkript.VR.Business.DataAccessLayer
{
    public class CalculatedFeesDAO : GenericDAO<CalculatedFees>
    {
        public bool ExistCalculatedFee(int draftApplicationId, int feeId)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                try
                {
                   return session.Query<CalculatedFees>()
                        .Any(c => c.ApplicationId == draftApplicationId 
                        && c.FeeId == feeId);
                }
                catch (Exception ex)
                {
                    session.Clear();
                    Log.ErrorFormat("Cannot check if Exist Calculated Fee {0}, {1}", draftApplicationId, feeId, ex);
                    throw new DALException("Cannot ExistCalculatedFee.", ex);
                }
        }

        public void SaveCalculatedFees(List<CalculatedFees> calculatedFees)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                try
                {
                    if (calculatedFees != null && calculatedFees.Count > 0)
                    {
                        foreach (var item in calculatedFees)
                        {
                            if (ExistCalculatedFee(item.ApplicationId, item.FeeId))
                            {
                                CalculatedFees calculatedFee = session.Query<CalculatedFees>()
                                    .Where(c => c.ApplicationId == item.ApplicationId
                                    && c.FeeId == item.FeeId)
                                    .FirstOrDefault();

                                calculatedFee.FeeNameEn = item.FeeNameEn;
                                calculatedFee.FeeNameAr = item.FeeNameAr;
                                calculatedFee.FeeType = item.FeeType;
                                calculatedFee.FeeValue = item.FeeValue;
                                calculatedFee.FeeSP = item.FeeSP;
                                calculatedFee.FeeTotal = item.FeeTotal;
                                calculatedFee.FeeCategoryId = item.FeeCategoryId;
                                calculatedFee.UpdatedDate = DateTime.Now;
                                calculatedFee.StatusId = item.StatusId;

                                session.Update(calculatedFee);
                            }
                            else
                            {
                                item.CreatedDate = DateTime.Now;
                                session.Save(item);
                            }
                        }
                    }
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    session.Clear();
                    Log.ErrorFormat("Cannot Create Calculated Fees", ex);
                    throw new DALException("Cannot SaveCalculatedFees", ex);
                }
            }
        }
    }
}
