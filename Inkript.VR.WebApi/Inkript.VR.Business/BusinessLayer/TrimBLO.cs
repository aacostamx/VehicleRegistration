using Inkript.VR.Business.DataAccessLayer;
using Inkript.VR.Models;
using System.Collections.Generic;
using System.Linq;

namespace Inkript.VR.Business.BusinessLayer
{
    public class TrimBLO
    {
        #region Variables
        private TrimDAO _da { get; set; }
        #endregion

        #region Methods
        public TrimBLO()
        {
            _da = new TrimDAO();
        }

        public bool TrimExist(int id)
        {
            return _da.Exist(id);
        }

        public List<TRIM> GetAllTrims()
        {
            return _da.GetAll().ToList();
        }
        #endregion
    }
}