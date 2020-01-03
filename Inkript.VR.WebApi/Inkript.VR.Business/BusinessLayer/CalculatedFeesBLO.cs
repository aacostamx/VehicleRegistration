using System;
using System.Collections.Generic;
using Inkript.VR.Business.DataAccessLayer;
using Inkript.VR.Models;

namespace Inkript.VR.Business.BusinessLayer
{
    public class CalculatedFeesBLO
    {
        #region Variables
        private CalculatedFeesDAO _da { get; set; }
        #endregion

        #region Methods
        public CalculatedFeesBLO()
        {
            _da = new CalculatedFeesDAO();
        }

        public void SaveCalculatedFees(List<CalculatedFees> calculatedFees)
        {
            _da.SaveCalculatedFees(calculatedFees);
        }

        #endregion

    }
}
