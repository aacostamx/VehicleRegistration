using System;
using System.Collections.Generic;
using System.Linq;
using Inkript.Logging;
using Inkript.VR.Business.Helpers;
using Inkript.VR.Models;
using NHibernate;
using NHibernate.Linq;
using NHibernate.Transform;

namespace Inkript.VR.Business.DataAccessLayer
{
    public class SectorsDAO : GenericDAO<Sectors>
    {
        public bool SectorNameEnExist(string sectorNameEn)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                try
                {
                    return session.Query<Sectors>().Any(c => (c.SectorNameEn == sectorNameEn));
                }
                catch (Exception ex)
                {
                    session.Clear();
                    Log.ErrorFormat("Cannot find sector name En {0}", sectorNameEn, ex);
                    throw new DALException("Cannot SectorNameEnExist", ex);
                }
        }

        public IList<Sectors> GetSectorsByVehicleType(int vehicleTypeId)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                try
                {
                    return session.GetNamedQuery("GetSectorsByVehicleType")
                         .SetParameter("VehicleTypeId", vehicleTypeId)
                         .SetResultTransformer(Transformers.AliasToBean(typeof(Sectors)))
                         .List<Sectors>();
                }
                catch (Exception ex)
                {
                    session.Clear();
                    Log.ErrorFormat("Cannot Return Sectors By Vehicle Type ", ex);
                    throw new DALException("Cannot GetSectorsByVehicleType", ex);
                }
        }

        public bool SectorNameArExist(string sectorNameAr)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                try
                {
                    return session.Query<Sectors>().Any(c => (c.SectorNameAr == sectorNameAr));
                }
                catch (Exception ex)
                {
                    session.Clear();
                    Log.ErrorFormat("Cannot find sector name AR {0}", sectorNameAr, ex);
                    throw new DALException("Cannot SectorNameArExist", ex);
                }
        }

        public bool ValidateSectorNameEn(int sectorId, string sectorNameEn)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                try
                {
                    return session.Query<Sectors>().Any(c => (c.SectorId == sectorId && c.SectorNameEn == sectorNameEn));
                }
                catch (Exception ex)
                {
                    session.Clear();
                    Log.ErrorFormat("Cannot validate sector name En {0} for Sector Id {1}", sectorNameEn, sectorId, ex);
                    throw new DALException("Cannot ValidateSectorNameEn", ex);
                }
        }

        public bool ValidateSectorNameAr(int sectorId, string sectorNameAr)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                try
                {
                    return session.Query<Sectors>().Any(c => (c.SectorId == sectorId && c.SectorNameAr == sectorNameAr));
                }
                catch (Exception ex)
                {
                    session.Clear();
                    Log.ErrorFormat("Cannot validate sector name AR {0} for Sector Id {1}", sectorNameAr, sectorId, ex);
                    throw new DALException("Cannot ValidateSectorNameAr", ex);
                }
        }

        public IList<Sectors> SectorFilter(string search)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                try
                {
                    return session.GetNamedQuery("SectorsFilter")
                         .SetString("search", search)
                         .SetResultTransformer(Transformers.AliasToBean(typeof(Sectors))).List<Sectors>();
                }
                catch (Exception ex)
                {
                    session.Clear();
                    Log.ErrorFormat("Cannot Get Sector by Filter search {0}", search, ex);
                    throw new DALException("Cannot SectorFilter", ex);
                }
        }

        public IList<SectorsLimit> GetSectorsAtRisk(int sectorId, int? vehicleTypeId, int? plateCodeId, int? branchId)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                try
                {
                    IQueryable<SectorsLimit> sectorsAtRisk = session.Query<SectorsLimit>()
                        .Where(c => c.SectorId == sectorId && c.TotalAvailable <= Convert.ToInt32(c.WarningLimit));

                    if (vehicleTypeId.HasValue)
                    {
                        sectorsAtRisk = sectorsAtRisk.Where(c => c.VehicleTypeId == vehicleTypeId);
                    }

                    if (plateCodeId.HasValue)
                    {
                        sectorsAtRisk = sectorsAtRisk.Where(c => c.PlateCodeId == plateCodeId);
                    }

                    if (branchId.HasValue)
                    {
                        sectorsAtRisk = sectorsAtRisk.Where(c => c.BranchId == branchId);
                    }

                    return sectorsAtRisk.ToList();

                }
                catch (Exception ex)
                {
                    session.Clear();
                    Log.ErrorFormat("Cannot Get Sector At Risk by Sector: {0}, Vehicle Type: {1}, Plate Code Id: {2}, and Branch Id: {3}",
                        sectorId, vehicleTypeId, plateCodeId, branchId, ex);
                    throw new DALException("Cannot SectorAtRisk", ex);
                }
        }
    }
}
