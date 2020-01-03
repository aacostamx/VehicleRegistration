using Inkript.Logging;
using Inkript.VR.Business.DataAccessLayer;
using Inkript.VR.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Inkript.VR.Business.BusinessLayer
{
    public class BPFeeBLO
    {
        private BPFeeDAO _da { get; set; }

        public BPFeeBLO()
        {
            _da = new BPFeeDAO();
        }

        public bool DuplicateBPFeeFront(IList<BPFee> bpFee)
        {
            bool duplicate = false;
            try
            {
                if (bpFee != null && bpFee.Count > 0)
                {
                    duplicate = bpFee.GroupBy(g => new { g.BPId, g.SectorId, g.VTId }).Where(g => g.Count() > 1).Count() > 0;
                }
            }
            catch (Exception ex)
            {
                Log.ErrorFormat(" Cannot check for BP Fees duplicates", ex);
            }
            return duplicate;
        }

        public bool BPFeeExist(int bpId, int sectorId, int vtId)
        {
            return _da.BPFeeExist(bpId, sectorId, vtId);
        }

        public BPFee GetBPFee(int bpId, int sectorId, int vtId)
        {
            return _da.GetBPFee(bpId, sectorId, vtId);
        }

        public bool BPFeeExist(int bpFeeId)
        {
            return _da.Exist(bpFeeId);
        }

        public List<BPFee> GetBPFees(JsonBP bp, int sectorId, int vehicleTypeId)
        {
            List<BPFee> bpFees = new List<BPFee>();

            try
            {
                if (bp.PrimaryBusinessProcess != null
                    && bp.PrimaryBusinessProcess.BPId > 0)
                {
                    bp.BusinessProcesses.Add(bp.PrimaryBusinessProcess);
                }

                if (bp.SecondaryBusinessProcess != null
                    && bp.SecondaryBusinessProcess.Count > 0)
                {
                    foreach (var item in bp.SecondaryBusinessProcess)
                    {
                        bp.BusinessProcesses.Add(new BusinessProcessJSON { BPId = item });
                    }
                }

                if (bp.BusinessProcesses != null
                    && bp.BusinessProcesses.Count > 0)
                {
                    foreach (var item in bp.BusinessProcesses)
                    {
                        bpFees.AddRange(_da.GetBPFees(item.BPId, sectorId, vehicleTypeId));
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }

            return bpFees;
        }
    }
}
