using System;
using Inkript.VR.Business.DataAccessLayer;
using Inkript.VR.Models;

namespace Inkript.VR.Business.BusinessLayer
{
    public class UtilizationBLO
    {
        private UtilizationDAO _da { get; set; }

        public UtilizationBLO()
        {
            _da = new UtilizationDAO();
        }

        public bool UtilizationExist(int utilizationId)
        {
            return _da.Exist(utilizationId);
        }

        public Utilization GetUtilizationById(int utilizationId)
        {
            return _da.GetById(utilizationId);
        }

        public int GetUtilizationby(int sectorId, int vehicleTypeId)
        {
            return _da.GetUtilizationby(sectorId, vehicleTypeId);
        }
    }
}