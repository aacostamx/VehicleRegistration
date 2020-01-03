using Inkript.VR.Business.DataAccessLayer;

namespace Inkript.VR.Business.BusinessLayer
{
    public class BPSectorVehicleBLO
    {
        #region Variables
        private BPSectorVehicleDAO _da { get; set; }
        #endregion

        #region Methods
        public BPSectorVehicleBLO()
        {
            _da = new BPSectorVehicleDAO();
        }
        #endregion
    }
}
