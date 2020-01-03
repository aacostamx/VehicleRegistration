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
    public class PlateRangesDAO : GenericDAO<PlateRanges>
    {
        public bool PlateRangeExist(string rangeName)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                try
                {
                    return session.Query<PlateRanges>().Any(c => (c.RangeName == rangeName));
                }
                catch (Exception ex)
                {
                    session.Clear();
                    Log.ErrorFormat("Cannot check if Plate Range Exist {0}", rangeName, ex);
                    throw new DALException("Cannot PlateRangeExist", ex);
                }
        }

        public int CheckPlateNumberPool(int startNumber, int endNumber)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                try
                {
                    return session.GetNamedQuery("CheckPlateNumberPool")
                        .SetParameter("StartNumber", startNumber)
                        .SetParameter("EndNumber", endNumber)
                        .UniqueResult<int>();
                }
                catch (Exception ex)
                {
                    session.Clear();
                    Log.ErrorFormat("Cannot Check Plate Number Pool start {0} and end {1}", startNumber, endNumber, ex);
                    throw new DALException("Cannot CheckPlateNumberPool", ex);
                }
        }

        public int CreatePlateRanges(PlateRanges plateRange)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                try
                {
                    return session.GetNamedQuery("CreatePlateRange")
                     .SetParameter("RangeName", plateRange.RangeName)
                     .SetParameter("StartNumber", plateRange.StartNumber)
                     .SetParameter("EndNumber", plateRange.EndNumber)
                     .SetParameter("SectorId", plateRange.SectorId)
                     .SetParameter("VehicleTypeId", plateRange.VehicleTypeId)
                     .SetParameter("PlateCodeId", plateRange.PlateCodeId)
                     .SetParameter("BranchId", plateRange.BranchId)
                     .SetParameter("SQLSequence", plateRange.SQLSequence)
                     .SetParameter("StatusId", plateRange.StatusId)
                     .SetParameter("PriorityLevel", plateRange.PriorityLevel)
                     .SetParameter("CreatedBy", plateRange.CreatedBy)
                     .SetParameter("UpdatedBy", plateRange.UpdatedBy)
                     .SetParameter("Prefix", plateRange.Prefix)
                     .SetParameter("DiplomaticLevel", plateRange.DiplomaticLevel)
                     .UniqueResult<int>();
                }
                catch (Exception ex)
                {
                    session.Clear();
                    Log.ErrorFormat("Cannot Create Plate Ranges", ex);
                    throw new DALException("Cannot CreatePlateRanges", ex);
                }
            }
        }       

        public List<PlateRanges> GetRangesByStatus(int statusId)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                try
                {
                    return session.Query<PlateRanges>()
                        .FetchMany(c => c.PlateNumberPool)
                        .ThenFetch(c => c.PlateCodes)
                        .Where(c => c.StatusId == statusId)
                        .ToList();
                }
                catch (Exception ex)
                {
                    session.Clear();
                    Log.ErrorFormat("Cannot Get Ranges By Status", statusId, ex);
                    throw new DALException("Cannot GetRangesByStatus", ex);
                }
        }

        public bool ValidStatus(int statusId)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                try
                {
                    return session.Query<PlateRanges>()
                        .Any(c => c.StatusId == statusId);
                }
                catch (Exception ex)
                {
                    session.Clear();
                    Log.ErrorFormat("Cannot check if status {0} Exist", statusId, ex);
                    throw new DALException("Cannot ValidStatus", ex);
                }
        }

        public bool PlateRangeIdExist(int plateRangeId)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                try
                {
                    return session.Query<PlateRanges>()
                        .Any(c => c.PlateRangeId == plateRangeId);
                }
                catch (Exception ex)
                {
                    session.Clear();
                    Log.ErrorFormat("Cannot check if Plate Range Id {0} Exist", plateRangeId, ex);
                    throw new DALException("Cannot PlateRangeIdExist", ex);
                }
        }

        public GenerateRandomNumber GenerateRandomNumber(int branchId, int sectorId, int vehicleTypeId)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                try
                {
                    return session.GetNamedQuery("GenerateRandomNumber")
                        .SetParameter("BranchId", branchId)
                        .SetParameter("SectorId", sectorId)
                        .SetParameter("VehicleTypeId", vehicleTypeId)
                        .SetResultTransformer(Transformers.AliasToBean(typeof(GenerateRandomNumber)))
                        .UniqueResult<GenerateRandomNumber>();
                }
                catch (Exception ex)
                {
                    session.Clear();
                    Log.ErrorFormat("Cannot Generate Random Number", ex);
                    throw new DALException("Cannot GenerateRandomNumber", ex);
                }
        }

        public IList<PlateRanges> PlateRangesFilter(int? sectorId, int? branchId, int? vehicleTypeId, int? plateCodeId)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                try
                {
                    return session.GetNamedQuery("PlateRangesFilter")
                        .SetParameter("SectorId", sectorId)
                        .SetParameter("BranchId", branchId)
                        .SetParameter("VehicleTypeId", vehicleTypeId)
                        .SetParameter("PlateCodeId", plateCodeId)
                        .SetResultTransformer(Transformers.AliasToBean(typeof(PlateRanges)))
                        .List<PlateRanges>();
                }
                catch (Exception ex)
                {
                    session.Clear();
                    Log.ErrorFormat("Cannot Get Plate Ranges by Filter", ex);
                    throw new DALException("Cannot PlateRangesFilter", ex);
                }
        }

        public PoolInfo PlateNumberPoolInfo(int? rangeId, string rangeName)
        {
            PoolInfo poolInfo = new PoolInfo();

            using (ISession session = NHibernateHelper.OpenSession())
                try
                {

                    PlateRanges plateRange = session.Query<PlateRanges>()
                        .Where(c => c.PlateRangeId == rangeId || c.RangeName == rangeName)
                        .FirstOrDefault();

                    if (plateRange.PlateNumberPool != null && plateRange.PlateNumberPool.Count() > 0)
                    {
                        poolInfo.TotalPlates = plateRange.PlateNumberPool.Count();
                        poolInfo.PlatesAvailable = plateRange.TotalAvailable ?? default(int);
                        poolInfo.PlatesUsed = poolInfo.TotalPlates - poolInfo.PlatesAvailable;
                        poolInfo.LimitsAllowed = session.Query<SectorWarningLimit>()
                            .Where(c => c.PlateCodeId == plateRange.PlateCodeId)
                            .ToList();
                    }

                    return poolInfo;

                }
                catch (Exception ex)
                {
                    session.Clear();
                    Log.Error("Cannot Get Pool Info", ex);
                    throw new DALException("Cannot GetPoolInfo", ex);
                }
        }
    }
}