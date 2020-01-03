using Inkript.VR.Business.DataAccessLayer;
using Inkript.VR.Models;
using System.Collections.Generic;
using System.Linq;

namespace Inkript.VR.Business.BusinessLayer
{
    public class FormBLO
    {
        #region Variables
        public FormDAO _da { get; set; }
        #endregion

        #region Methods
        public FormBLO()
        {
            _da = new FormDAO();
        }

        public List<FORM> GetAllForms()
        {
            return _da.GetAll().ToList();
        }
        #endregion
    }
}
