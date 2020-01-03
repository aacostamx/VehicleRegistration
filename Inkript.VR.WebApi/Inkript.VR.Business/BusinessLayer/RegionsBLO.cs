using Inkript.VR.Business.DataAccessLayer;
using Inkript.VR.Models;
using System.Collections.Generic;
using System.Linq;

namespace Inkript.VR.Business.BusinessLayer
{
    public class RegionsBLO
    {
        private RegionsDAO _da { get; set; }

        public RegionsBLO()
        {
            _da = new RegionsDAO();
        }

        public List<Regions> GetAllRegions()
        {
            return _da.GetAll().ToList();
        }

        public Regions GetByRegionId(int regionId)
        {
            return _da.GetById(regionId);
        }
    }
}
