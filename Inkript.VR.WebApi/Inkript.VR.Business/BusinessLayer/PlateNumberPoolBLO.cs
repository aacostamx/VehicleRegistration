using System;
using Inkript.VR.Business.DataAccessLayer;

namespace Inkript.VR.Business.BusinessLayer
{
    public class PlateNumberPoolBLO
    {
        private PlateNumberPoolDAO _da { get; set; }

        public PlateNumberPoolBLO()
        {
            _da = new PlateNumberPoolDAO();
        }

        public bool ActivatePlateNumberPool(string plateNumber)
        {
            return _da.ActivatePlateNumberPool(plateNumber);
        }

        public bool PlateNumberPoolExist(string plateNumber)
        {
            return _da.PlateNumberPoolExist(plateNumber);
        }
    }
}
