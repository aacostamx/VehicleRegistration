using Inkript.Logging;
using Inkript.VR.Business.Helpers;
using Inkript.VR.Models;
using NHibernate;
using NHibernate.Transform;
using System;

namespace Inkript.VR.Business.DataAccessLayer
{
    public class VehicleDAO : GenericDAO<VehicleDetails>
    {
        public VehicleSearch VehicleSearch(int carUniqueNumber, string certificateId)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                try
                {
                    return session.CreateSQLQuery(@"EXEC VehicleSearch " + carUniqueNumber + ", '" + certificateId + "'")
                        .SetResultTransformer(Transformers.AliasToBean(typeof(VehicleSearch)))
                        .UniqueResult<VehicleSearch>();
                }
                catch (Exception ex)
                {
                    session.Clear();
                    Log.ErrorFormat("Cannot Get Vehicle Search {0}", ex);
                    throw new DALException("Cannot VehicleSearch", ex);
                }
        }
    }
}