using Inkript.VR.Business.DataAccessLayer;
using Inkript.VR.Models;
using System.Collections.Generic;
using System.Linq;

namespace Inkript.VR.Business.BusinessLayer
{
    public class PlateCodesBLO
    {
        public PlateCodesDAO _da { get; set; }

        public PlateCodesBLO()
        {
            _da = new PlateCodesDAO();
        }

        public bool PlateCodeExist(int plateCodeId)
        {
            return _da.Exist(plateCodeId);
        }

        public List<PlateCodes> GetAllPlateCodes()
        {
            return _da.GetAll().ToList();
        }

        public PlateCodes GetById(int plateCodeId)
        {
            return _da.GetById(plateCodeId);
        }
    }
}
