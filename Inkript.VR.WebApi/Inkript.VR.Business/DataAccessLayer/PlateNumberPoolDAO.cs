using System;
using System.Linq;
using Inkript.Logging;
using Inkript.VR.Business.Helpers;
using Inkript.VR.Models;
using NHibernate;
using NHibernate.Linq;

namespace Inkript.VR.Business.DataAccessLayer
{
    public class PlateNumberPoolDAO : PlateNumberPool
    {
        public bool PlateNumberPoolExist(string plateNumber)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                try
                {
                    return session.Query<PlateNumberPool>().Any(c => (c.PlateNumber == plateNumber));
                }
                catch (Exception ex)
                {
                    session.Clear();
                    Log.ErrorFormat("Cannot check if Plate Number Pool Exist", ex);
                    throw new DALException("Cannot PlateNumberExist", ex);
                }
        }

        public bool ActivatePlateNumberPool(string plateNumber)
        {
            bool success = false;

            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                try
                {
                    PlateNumberPool plateNumberPool = session.Query<PlateNumberPool>()
                        .Where(c => c.PlateNumber == plateNumber)
                        .FirstOrDefault();

                    if (plateNumberPool != null
                        && plateNumberPool.StatusId !=
                        (int)FlagStatus.Active)
                    {
                        plateNumberPool.StatusId = (int)FlagStatus.Active;
                        session.Update(plateNumberPool);

                        PlateRanges plateRange = session.Query<PlateRanges>()
                            .Where(c => c.PlateRangeId == plateNumberPool.PlateRangeId)
                            .FirstOrDefault();

                        if (plateRange != null
                            && plateRange.StatusId != (int)FlagStatus.Active)
                        {
                            plateRange.StatusId = (int)FlagStatus.Active;
                        }
                        plateRange.TotalAvailable += 1;
                        session.Update(plateRange);

                        transaction.Commit();
                    }

                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    session.Clear();
                    Log.ErrorFormat("Cannot Update Plate Number Pool {0}", PlateNumber, ex);
                    throw new DALException("Cannot UpdateFee", ex);
                }
                return success;
            }
        }
    }
}
