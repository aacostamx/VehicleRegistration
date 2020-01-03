using Inkript.Logging;
using Inkript.VR.Business.DataAccessLayer;
using Inkript.VR.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Inkript.VR.Business.BusinessLayer
{
    public class FeesBLO
    {
        private FeesDAO _da { get; set; }

        public FeesBLO()
        {
            _da = new FeesDAO();
        }

        public GenericPagedList<Fees> GetAllFeesPaged(int pageNumber, int pageSize)
        {
            return _da.GetAllPaged(pageNumber, pageSize);
        }

        public void CreateFee(Fees fee)
        {
            _da.CreateFee(fee);
        }

        public bool FeeNameEnExist(string name)
        {
            return _da.FeeNameEnExist(name);
        }

        public bool FeeNameArExist(string name)
        {
            return _da.FeeNameArExist(name);
        }

        public bool FeeExist(int feeId)
        {
            return _da.FeeExist(feeId);
        }

        public void UpdateFee(Fees fee)
        {
            _da.SaveOrUpdate(fee, string.Empty);
        }

        public Fees GetByFeeId(int feeId)
        {
            return _da.GetByFeeId(feeId);
        }

        public bool DeleteFee(int feeId)
        {
            return _da.DeleteFee(GetByFeeId(feeId));
        }

        public bool ValidateFeeNameEn(int feeId, string feeNameEn)
        {
            return _da.ValidateFeeNameEn(feeId, feeNameEn);
        }

        public bool ValidateFeeNameAr(int feeId, string feeNameAr)
        {
            return _da.ValidateFeeNameAr(feeId, feeNameAr);
        }

        public List<Fees> FeesFilter(string search)
        {
            return _da.FeesFilter(search).ToList();
        }

        public List<Fees> GetAllFees()
        {
            return _da.GetAll().ToList();
        }

        public List<Fees> GetFees(List<BPFee> bpFees)
        {
            List<Fees> fees = new List<Fees>();

            try
            {
                if (bpFees != null && bpFees.Count > 0)
                {
                    foreach (var item in bpFees)
                    {
                        Fees fee = _da.GetFeeBy(item);
                        fee.TaxPercentageApplicable = item.TaxPercentageApplicable;
                        if (fee.FeeCategory != null
                            && fee.FeeCategory != null
                            && fee.FeeCategory.Fees.Count > 0)
                        {
                            fee.FeeCategory.Fees = null;
                        }
                        fees.Add(fee);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }

            return fees;
        }

        public List<Fees> CalculateFees(List<Fees> fees, int draftApplicationId)
        {
            try
            {
                if (fees != null && fees.Count > 0)
                {
                    foreach (var item in fees)
                    {
                        if (item.FeeType == (int)FlagFeeTypes.StoredProcedure)
                            item.FeeValue = _da.GetFeeValue(item.FeeSP, draftApplicationId);

                        if (item.FeeValue.HasValue)
                        {
                            if (item.TaxPercentageApplicable.HasValue
                                && item.TaxPercentageApplicable.Value > 0)
                            {
                                float? feeTotal = item.FeeValue * (float)item.TaxPercentageApplicable;
                                item.FeeTotal = item.FeeValue + feeTotal;
                            }
                            else
                                item.FeeTotal = item.FeeValue;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }

            return fees;
        }

        public List<string> StoredProceduresFees()
        {
            return _da.StoredProceduresFees().ToList();
        }

        public StampFee StampFee(double value, int calledFromUI)
        {
            return _da.StampFee(value, calledFromUI);
        }
    }
}
