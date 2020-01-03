using Inkript.VR.Business.DataAccessLayer;
using Inkript.VR.Models;
using System.Collections.Generic;
using System.Linq;

namespace Inkript.VR.Business.BusinessLayer
{
    public class TrunkTypeBLO
    {
        #region Properties
        private TrunkTypeDAO _da { get; set; } 
        #endregion

        #region Methods
        public TrunkTypeBLO()
        {
            _da = new TrunkTypeDAO();
        }

        public List<TrunkType> GetAllTrunkTypes()
        {
            return _da.GetAll().ToList();
        }

        public bool TrunkTypeExist(int trunkTypeId)
        {
            return _da.Exist(trunkTypeId);
        }
        #endregion
    }
}
