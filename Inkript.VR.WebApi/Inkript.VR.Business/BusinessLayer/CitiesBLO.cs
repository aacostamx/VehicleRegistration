using Inkript.VR.Business.DataAccessLayer;
using Inkript.VR.Models;
using System.Collections.Generic;
using System.Linq;

namespace Inkript.VR.Business.BusinessLayer
{
    public class CitiesBLO
    {
        private CitiesDAO _da { get; set; }

        public CitiesBLO()
        {
            _da = new CitiesDAO();
        }

        public List<Cities> GetAllCities()
        {
            return _da.GetAll().ToList();
        }

        public Cities GetByCityId(int cityId)
        {
            return _da.GetById(cityId);
        }
    }
}
