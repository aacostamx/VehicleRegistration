using System;
using Inkript.Logging;
using Inkript.VR.Business.Helpers;
using Inkript.VR.Models;
using NHibernate;
using NHibernate.Transform;

namespace Inkript.VR.Business.DataAccessLayer
{
    public class VehicleRegistrationDAO
    {
        public VehicleRegistration NewVehicleRegistration(string certificateId)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                try
                {
                    return session.GetNamedQuery("NewVehicleRegistration")
                        .SetString("CertificateId", certificateId)
                        .SetResultTransformer(Transformers.AliasToBean(typeof(VehicleRegistration)))
                        .UniqueResult<VehicleRegistration>();
                }
                catch (Exception ex)
                {
                    session.Clear();
                    Log.ErrorFormat("Cannot Add New Vehicle Registration", ex);
                    throw new DALException("Cannot NewVehicleRegistration", ex);
                }
        }

        public VehicleRegistrationFee NewVehicleRegistrationFee(string certificateId)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                try
                {
                    return session.GetNamedQuery("NewVehicleRegistrationFee")
                        .SetString("CertificateId", certificateId)
                        .SetResultTransformer(Transformers.AliasToBean(typeof(VehicleRegistrationFee)))
                        .UniqueResult<VehicleRegistrationFee>();
                }
                catch (Exception ex)
                {
                    session.Clear();
                    Log.ErrorFormat("Cannot Add New Vehicle Registraion Fees", ex);
                    throw new DALException("Cannot NewVehicleRegistrationFee", ex);
                }
        }
    }
}
