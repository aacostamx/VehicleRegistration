using System;
using System.Collections.Generic;
using System.Linq;
using Inkript.VR.Business.DataAccessLayer;
using Inkript.VR.Models;

namespace Inkript.VR.Business.BusinessLayer
{
    public class VehicleTypesBLO
    {
        private VehicleTypesDAO _da { get; set; }

        public VehicleTypesBLO()
        {
            _da = new VehicleTypesDAO();
        }

        public GenericPagedList<VehicleTypes> GetAllVehicleTypesPaged(int pageNumber, int pageSize)
        {
            return _da.GetAllPaged(pageNumber, pageSize);
        }

        public bool VehicleTypeExist(int vehicleTypeId)
        {
            return _da.Exist(vehicleTypeId);
        }

        public VehicleTypes GetByVehicleTypeId(int vehicleTypeId)
        {
            return _da.GetById(vehicleTypeId);
        }

        public bool DescEnExist(string vTDescEn)
        {
            return _da.DescEnExist(vTDescEn);
        }

        public bool DescArExist(string vTDescAR)
        {
            return _da.DescArExist(vTDescAR);
        }

        public void CreateVehicleType(VehicleTypes vehicleType)
        {
            _da.SaveOrUpdate(vehicleType, string.Empty);
        }

        public bool ValidateDescEn(int vehicleTypeId, string vTDescEn)
        {
            return _da.ValidateDescEn(vehicleTypeId, vTDescEn);
        }

        public bool ValidateDescAr(int vehicleTypeId, string vTDescAR)
        {
            return _da.ValidateDescAr(vehicleTypeId, vTDescAR);
        }

        public void UpdateVehicleType(VehicleTypes vehicleType)
        {
            _da.SaveOrUpdate(vehicleType, string.Empty);
        }

        public bool DeleteVehicleType(int vehicleTypeId)
        {
            return _da.Delete(GetByVehicleTypeId(vehicleTypeId));
        }

        public List<VehicleTypes> VehicleTypeFilter(string search)
        {
            return _da.VehicleTypeFilter(search).ToList();
        }

        public List<VehicleTypes> GetAllVehicleTypes()
        {
            return _da.GetAll().ToList();
        }
    }
}
