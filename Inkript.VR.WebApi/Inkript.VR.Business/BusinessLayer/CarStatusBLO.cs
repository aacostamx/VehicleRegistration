using Inkript.VR.Business.DataAccessLayer;

namespace Inkript.VR.Business.BusinessLayer
{
    public class CarStatusBLO
    {
        #region Variables
        private CarStatusDAO _da { get; set; } 
        #endregion

        #region Methods
        public CarStatusBLO()
        {
            _da = new CarStatusDAO();
        }

        public bool CarStatusExist(int carStatusId)
        {
            return _da.Exist(carStatusId);
        } 
        #endregion
    }
}
