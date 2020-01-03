using Inkript.VR.Business.DataAccessLayer;
using Inkript.VR.Models;
using System.Collections.Generic;
using System.Linq;

namespace Inkript.VR.Business.BusinessLayer
{
    public class DistrictsBLO
    {
        private DistrictsDAO _da { get; set; }

        public DistrictsBLO()
        {
            _da = new DistrictsDAO();
        }

        public List<Districts> GetAllDistricts()
        {
            return _da.GetAll().ToList();
        }

        public Districts GetByDistrictId(int districtId)
        {
            return _da.GetById(districtId);
        }
    }
}
