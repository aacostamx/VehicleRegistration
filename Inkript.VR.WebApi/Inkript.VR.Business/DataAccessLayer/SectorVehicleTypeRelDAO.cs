using Inkript.Logging;
using Inkript.VR.Business.Helpers;
using Inkript.VR.Models;
using NHibernate;
using NHibernate.Linq;
using System;
using System.Linq;

namespace Inkript.VR.Business.DataAccessLayer
{
    public class SectorVehicleTypeRelDAO : GenericDAO<SectorVehicleTypeRel>
    {
        public int GetSectorVehicleTypeRef(int? sectorId, int? vehicleTypeId)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                try
                {
                    return session.Query<SectorVehicleTypeRel>()
                        .Where(c => c.Sectors.SectorId == sectorId && c.VehicleTypes.VehicleTypeId == vehicleTypeId)
                        .FirstOrDefault()
                        .RelId;
                }
                catch (Exception ex)
                {
                    session.Clear();
                    Log.ErrorFormat("Cannot Get Sector Vehicle Type Ref", ex);
                    throw new DALException("Cannot GetSectorVehicleTypeRef", ex);
                }
        }
    }
}
