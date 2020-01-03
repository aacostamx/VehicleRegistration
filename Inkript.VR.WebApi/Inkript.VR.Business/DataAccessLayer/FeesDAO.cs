using Inkript.Logging;
using Inkript.VR.Business.Helpers;
using Inkript.VR.Models;
using NHibernate;
using NHibernate.Linq;
using NHibernate.Transform;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Inkript.VR.Business.DataAccessLayer
{
    public class FeesDAO : GenericDAO<Fees>
    {
        #region Methods
        public bool FeeNameEnExist(string name)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                try
                {
                    return session.Query<Fees>().Any(c => (c.FeeNameEn == name));
                }
                catch (Exception ex)
                {
                    session.Clear();
                    Log.ErrorFormat("Cannot check FeeNameEn exist {0}", name, ex);
                    throw new DALException("Cannot FeeNameEnExist", ex);
                }
        }

        public void CreateFee(Fees fee)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                try
                {
                    List<BPFee> bpFee = fee.BPFee.ToList();
                    fee.BPFee = null;
                    session.Save(fee);

                    if (bpFee != null && bpFee.Count > 0)
                    {
                        foreach (var item in bpFee)
                        {
                            item.FeeId = fee.FeeId;
                            session.Save(item);
                        }
                    }

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    session.Clear();
                    Log.ErrorFormat("Cannot Create Fee", ex);
                    throw new DALException("Cannot CreateFee", ex);
                }
            }
        }

        public Fees GetByFeeId(int feeId)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                try
                {
                    return session.Query<Fees>().Where(c => c.FeeId == feeId).FirstOrDefault();
                }
                catch (Exception ex)
                {
                    session.Clear();
                    Log.ErrorFormat("Cannot Get Fee By {0}", feeId, ex);
                    throw new DALException("Cannot GetByFeeId.", ex);
                }
        }

        public void UpdateFee(Fees fee)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                try
                {
                    IList<BPFee> bpFee = fee.BPFee;
                    fee.BPFee = null;
                    session.Update(fee);

                    if (bpFee != null && bpFee.Count > 0)
                    {
                        foreach (var item in bpFee)
                        {
                            BPFee bp = session.Query<BPFee>().Where(c => c.FeeId == fee.FeeId).FirstOrDefault();
                            bp.TaxPercentageApplicable = item.TaxPercentageApplicable;
                            bp.BPId = item.BPId;
                            bp.SectorId = item.SectorId;
                            bp.VTId = item.VTId;

                            session.Update(bp);
                        }
                    }

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    session.Clear();
                    Log.ErrorFormat("Cannot Update Fee Id {0}", fee.FeeId, ex);
                    throw new DALException("Cannot UpdateFee", ex);
                }
            }
        }

        public Fees GetFeeBy(BPFee bpFee)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                try
                {
                    Fees fee = session.Query<Fees>()
                        .Where(c => c.FeeId == bpFee.FeeId)
                        .FirstOrDefault();

                    fee.BPFee = session.Query<BPFee>()
                        .Where(c => c.BPFeeId == bpFee.BPFeeId)
                        .ToList();

                    return fee;
                }
                catch (Exception ex)
                {
                    session.Clear();
                    Log.ErrorFormat("Cannot Get Fee By {0}", bpFee, ex);
                    throw new DALException("Cannot GetFeeBy.", ex);
                }
        }

        public StampFee StampFee(double value, int calledFromUI)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                try
                {
                    StampFee stampFee = session.GetNamedQuery("F19FeeStamp")
                        .SetParameter("Value", value)
                        .SetParameter("CalledFromUI", calledFromUI)
                        .SetResultTransformer(Transformers.AliasToBean(typeof(StampFee)))
                        .UniqueResult<StampFee>();

                    if (stampFee.FeeId == 0)
                    {
                        stampFee = null;
                        return stampFee;
                    }

                    if (stampFee.FeeCategoryId != 0)
                    {
                        stampFee.FeeCategory = session.Query<FeeCategory>()
                            .Where(c => c.FeeCategoryId == stampFee.FeeCategoryId)
                            .FirstOrDefault();

                        if (stampFee.FeeCategory.Fees != null
                            && stampFee.FeeCategory.Fees.Count > 0)
                        {
                            stampFee.FeeCategory.Fees = null;
                        }
                    }

                    if (stampFee.StatusId != 0)
                    {
                        stampFee.Status = session.Query<Status>()
                            .Where(c => c.StatusId == stampFee.StatusId)
                            .FirstOrDefault();
                    }

                    return stampFee;
                }
                catch (Exception ex)
                {
                    session.Clear();
                    Log.ErrorFormat("Cannot Get Stamp Fee for Value {0}", value, ex);
                    throw new DALException("Cannot StampFee", ex);
                }
        }

        public IList<string> StoredProceduresFees()
        {
            using (ISession session = NHibernateHelper.OpenSession())
                try
                {
                    string sqlQuery = @"SELECT SPECIFIC_NAME FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_NAME LIKE 'F[0-9]%' AND ROUTINE_TYPE = 'PROCEDURE';";
                    return session.CreateSQLQuery(sqlQuery).List<string>();
                }
                catch (Exception ex)
                {
                    session.Clear();
                    Log.ErrorFormat("Cannot Get Stored Procedures for Fees", ex);
                    throw new DALException("Cannot StoredProceduresFees", ex);
                }
        }

        public float GetFeeValue(string feeSP, int draftApplicationId)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                try
                {
                    var sql = @"EXEC " + feeSP + " " + draftApplicationId.ToString();
                    var result = session.CreateSQLQuery(sql).UniqueResult();
                    return Convert.ToSingle(result);
                }
                catch (Exception ex)
                {
                    session.Clear();
                    Log.ErrorFormat("Cannot Get Fee Value from Stored Procedure {0}", feeSP, ex);
                    throw new DALException("Cannot GetFeeValue", ex);
                }
        }

        public bool DeleteFee(Fees fee)
        {
            bool deleted = false;
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                try
                {
                    fee.BPFee = null;
                    session.Delete(fee);

                    IList<BPFee> bpFee = session.Query<BPFee>()
                        .Where(c => c.FeeId == fee.FeeId)
                        .ToList();

                    if (bpFee != null && bpFee.Count > 0)
                    {
                        foreach (var item in bpFee)
                        {
                            session.Delete(item);
                        }
                    }
                    transaction.Commit();
                    deleted = true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    session.Clear();
                    Log.ErrorFormat("Cannot Delete Fee Id {0}", fee.FeeId, ex);
                    throw new DALException("Cannot DeleteFee", ex);
                }
            }
            return deleted;
        }

        public bool FeeNameArExist(string name)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                try
                {
                    return session.Query<Fees>().Any(c => (c.FeeNameAr == name));
                }
                catch (Exception ex)
                {
                    session.Clear();
                    Log.ErrorFormat("Cannot check FeeNameAr exist {0}", name, ex);
                    throw new DALException("Cannot FeeNameArExist", ex);
                }
        }

        public bool FeeExist(int feeId)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                try
                {
                    return session.Query<Fees>().Any(c => (c.FeeId == feeId));
                }
                catch (Exception ex)
                {
                    session.Clear();
                    Log.ErrorFormat("Cannot check Fee exist {0}", feeId, ex);
                    throw new DALException("Cannot FeeExist", ex);
                }
        }

        public bool ValidateFeeNameEn(int feeId, string feeNameEn)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                try
                {
                    return session.Query<Fees>().Any(c => (c.FeeId == feeId && c.FeeNameEn == feeNameEn));
                }
                catch (Exception ex)
                {
                    session.Clear();
                    Log.ErrorFormat("Cannot Validate if FeeNameEn {0} for Fee Id {1}", feeId, feeNameEn, ex);
                    throw new DALException("Cannot ValidateFeeNameEn", ex);
                }
        }

        public IList<Fees> FeesFilter(string search)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                try
                {
                    return session.GetNamedQuery("FeesFilter")
                        .SetString("search", search)
                        .List<Fees>();
                }
                catch (Exception ex)
                {
                    session.Clear();
                    Log.ErrorFormat("Cannot Get Fee Filter Search {0}", search, ex);
                    throw new DALException("Cannot FeesFilter", ex);
                }
        }

        public bool ValidateFeeNameAr(int feeId, string feeNameAr)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                try
                {
                    return session.Query<Fees>().Any(c => (c.FeeId == feeId && c.FeeNameAr == feeNameAr));
                }
                catch (Exception ex)
                {
                    session.Clear();
                    Log.ErrorFormat("Cannot Validate if FeeNameAr {0} for Fee Id {1}", feeId, feeNameAr, ex);
                    throw new DALException("Cannot ValidateFeeNameAr", ex);
                }
        }
        #endregion
    }
}
