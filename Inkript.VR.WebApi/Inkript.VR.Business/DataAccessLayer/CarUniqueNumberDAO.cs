using System;
using System.Linq;
using Inkript.Logging;
using Inkript.VR.Business.Helpers;
using Inkript.VR.Models;
using NHibernate;
using NHibernate.Linq;

namespace Inkript.VR.Business.DataAccessLayer
{
    public class CarUniqueNumberDAO : GenericDAO<CarUniqueNumber>
    {
        public int GetCarUniqueNumber(string chassisNumber)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                try
                {
                    return session.Query<CarUniqueNumber>()
                        .Where(c => c.Chassis == chassisNumber)
                        .Select(c => c.CarUniqueNumberVal)
                        .FirstOrDefault();
                }
                catch (Exception ex)
                {
                    session.Clear();
                    Log.ErrorFormat("Cannot Get Car Unique Number", ex);
                    throw new DALException("Cannot GetCarUniqueNumber", ex);
                }
        }

        public int GenerateCarUniqueNumber(CarUniqueNumber carUniqueNumber)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                try
                {
                    session.Save(carUniqueNumber);
                    transaction.Commit();

                    return carUniqueNumber.CarUniqueNumberVal;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    session.Clear();
                    Log.ErrorFormat("Cannot Generate Car Unique Number", ex);
                    throw new DALException("Cannot GenerateCarUniqueNumber", ex);
                }
            }
        }
    }
}
