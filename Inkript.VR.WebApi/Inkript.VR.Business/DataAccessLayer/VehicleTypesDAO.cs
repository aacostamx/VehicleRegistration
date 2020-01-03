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
    public class VehicleTypesDAO : GenericDAO<VehicleTypes>
    {
        public bool DescArExist(string vTDescAR)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                try
                {
                    return session.Query<VehicleTypes>().Any(c => (c.VehicleTypeNameAr == vTDescAR));
                }
                catch (Exception ex)
                {
                    session.Clear();
                    Log.ErrorFormat("Cannot Check If DescAr exist {0}", vTDescAR, ex);
                    throw new DALException("Cannot DescArExist", ex);
                }
        }

        public bool DescEnExist(string vTDescEn)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                try
                {
                    return session.Query<VehicleTypes>().Any(c => (c.VehicleTypeNameEn == vTDescEn));
                }
                catch (Exception ex)
                {
                    session.Clear();
                    Log.ErrorFormat("Cannot Check If DescEn exist {0}", vTDescEn, ex);
                    throw new DALException("Cannot DescEnExist", ex);
                }
        }

        public bool ValidateDescEn(int vehicleTypeId, string vTDescEn)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                try
                {
                    return session.Query<VehicleTypes>().Any(c => (c.VehicleTypeId == vehicleTypeId && c.VehicleTypeNameEn == vTDescEn));
                }
                catch (Exception ex)
                {
                    session.Clear();
                    Log.ErrorFormat("Cannot Validate If vTDescEn exist {0} for Vehicle type Id {1}", vTDescEn, vehicleTypeId, ex);
                    throw new DALException("Cannot ValidateDescEn", ex);
                }
        }

        public bool ValidateDescAr(int vehicleTypeId, string vTDescAR)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                try
                {
                    return session.Query<VehicleTypes>().Any(c => (c.VehicleTypeId == vehicleTypeId && c.VehicleTypeNameAr == vTDescAR));
                }
                catch (Exception ex)
                {
                    session.Clear();
                    Log.ErrorFormat("Cannot Validate If vTDescAR exist {0} for Vehicle type Id {1}", vTDescAR, vehicleTypeId, ex);
                    throw new DALException("Cannot ValidateDescAr", ex);
                }
        }

        public IList<VehicleTypes> VehicleTypeFilter(string search)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                try
                {
                    return session.GetNamedQuery("VehicleTypesFilter")
                         .SetString("search", search)
                         .SetResultTransformer(Transformers.AliasToBean(typeof(VehicleTypes))).List<VehicleTypes>();
                }
                catch (Exception ex)
                {
                    session.Clear();
                    Log.ErrorFormat("Cannot Get Vehicle Type by Filter {0}", search, ex);
                    throw new DALException("Cannot VehicleTypeFilter", ex);
                }
        }
    }
}
