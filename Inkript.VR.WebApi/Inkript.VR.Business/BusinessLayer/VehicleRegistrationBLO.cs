using Inkript.VR.Business.DataAccessLayer;
using Inkript.VR.Models;

namespace Inkript.VR.Business.BusinessLayer
{
    public class VehicleRegistrationBLO
    {
        public VehicleRegistrationDAO _da { get; set; }

        public VehicleRegistrationBLO()
        {
            _da = new VehicleRegistrationDAO();
        }

        public VehicleRegistration NewVehicleRegistration(string certificateId)
        {
            return _da.NewVehicleRegistration(certificateId);
        }

        public VehicleRegistrationFee NewVehicleRegistrationFee(string certificateId)
        {
            return _da.NewVehicleRegistrationFee(certificateId);
        }
    }
}
