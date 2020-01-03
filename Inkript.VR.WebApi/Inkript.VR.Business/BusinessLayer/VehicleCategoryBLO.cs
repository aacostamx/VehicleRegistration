using Inkript.VR.Business.DataAccessLayer;
using Inkript.VR.Models;
using System.Collections.Generic;
using System.Linq;

namespace Inkript.VR.Business.BusinessLayer
{
    public class VehicleCategoryBLO
    {
        private VehicleCategoryDAO _da { get; set; }

        public VehicleCategoryBLO()
        {
            _da = new VehicleCategoryDAO();
        }

        public List<VehicleCategory> GetAllTrims()
        {
            return _da.GetAll().ToList();
        }
    }
}
