using System;
using Inkript.VR.Business.DataAccessLayer;
using Inkript.VR.Models;

namespace Inkript.VR.Business.BusinessLayer
{
    public class CarUniqueNumberBLO
    {
        #region Variables
        private CarUniqueNumberDAO _da { get; set; }
        #endregion

        #region Methods
        public CarUniqueNumberBLO()
        {
            _da = new CarUniqueNumberDAO();
        }

        public bool CarUniqueNumberExist(int carUniqueNumberId)
        {
            return _da.Exist(carUniqueNumberId);
        }

        public CarUniqueNumber GetCarUniqueNumber(int CarUniqueNumber)
        {
            return _da.GetById(CarUniqueNumber);
        }

        public int GetCarUniqueNumber(string chassisNumber)
        {
            return _da.GetCarUniqueNumber(chassisNumber);
        }

        public int GenerateCarUniqueNumber(CarUniqueNumber carUniqueNumber)
        {
            int carUniqueNumberId = 0;
            carUniqueNumberId = GetCarUniqueNumber(carUniqueNumber.Chassis);

            if (carUniqueNumberId == 0)
            {
                carUniqueNumberId = _da.GenerateCarUniqueNumber(carUniqueNumber);
            }

            return carUniqueNumberId;
        }

        public int GetCarUniqueNumberByChassisNumber(string chassisNumber)
        {
            return _da.GetCarUniqueNumber(chassisNumber);
        }
        #endregion

    }
}
