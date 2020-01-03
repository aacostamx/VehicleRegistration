using System;
using System.Linq;
using Inkript.Logging;
using Inkript.VR.Business.Helpers;
using Inkript.VR.Models;
using NHibernate;
using NHibernate.Linq;

namespace Inkript.VR.Business.DataAccessLayer
{
    public class UtilizationDAO : GenericDAO<Utilization>
    {
        public int GetUtilizationby(int sectorId, int vehicleTypeId)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                try
                {
                    return session.Query<SectorVehicleTypeRel>()
                        .Where(c => c.Sectors.SectorId == sectorId 
                        && c.VehicleTypes.VehicleTypeId == vehicleTypeId)
                        .Select(c => c.Utilization.UtilizationId)
                        .FirstOrDefault();
                }
                catch (Exception ex)
                {
                    session.Clear();
                    Log.ErrorFormat("Cannot Get Utilization by {0} and {1}", sectorId, vehicleTypeId, ex);
                    throw new DALException("Cannot GetUtilizationby", ex);
                }
        }
    }
}