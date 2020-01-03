using System;
using System.Collections.Generic;
using System.Linq;
using Inkript.VR.Business.DataAccessLayer;
using Inkript.VR.Models;

namespace Inkript.VR.Business.BusinessLayer
{
    public class FuelTypesBLO
    {
        private FuelTypesDAO _da { get; set; }

        public FuelTypesBLO()
        {
            _da = new FuelTypesDAO();
        }

        public List<FuelTypes> GetAllFuelTypes()
        {
            return _da.GetAll().ToList();
        }

        public bool FuelTypeExist(int fuelTypeId)
        {
            return _da.Exist(fuelTypeId);
        }

        public FuelTypes GetFuelTypesById(int fuelTypeId)
        {
            return _da.GetById(fuelTypeId);
        }
    }
}
