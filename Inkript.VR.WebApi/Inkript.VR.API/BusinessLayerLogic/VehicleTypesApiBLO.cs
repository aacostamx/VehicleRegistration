using Inkript.Logging;
using Inkript.VR.API.Models;
using Inkript.VR.Business.BusinessLayer;
using Inkript.VR.Models;
using System;
using System.Collections.Generic;

namespace Inkript.VR.API
{
    public class VehicleTypesApiBLO
    {
        public ObjectResult<GenericPagedList<VehicleTypes>> GetAllVehicleTypesPaged(int pageNumber, int pageSize)
        {
            VehicleTypesBLO biz = new VehicleTypesBLO();
            ObjectResult<GenericPagedList<VehicleTypes>> output = new ObjectResult<GenericPagedList<VehicleTypes>>();

            try
            {
                output.Result = biz.GetAllVehicleTypesPaged(pageNumber, pageSize);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to Get All Vehicle Types Paged";
            }
            return output;
        }

        public ObjectResult<VehicleTypes> GetByVehicleTypeId(int vehicleTypeId)
        {
            VehicleTypesBLO biz = new VehicleTypesBLO();
            ObjectResult<VehicleTypes> output = new ObjectResult<VehicleTypes>();

            try
            {
                if (!biz.VehicleTypeExist(vehicleTypeId))
                {
                    output.Message = string.Format("Vehicle Type Id {0} Not Found", vehicleTypeId);
                    return output;
                }
                output.Result = biz.GetByVehicleTypeId(vehicleTypeId);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to Get Vehicle Type Id " + vehicleTypeId;
            }
            return output;
        }

        public ObjectResult<List<VehicleTypes>> GetAllVehicleTypes()
        {
            VehicleTypesBLO biz = new VehicleTypesBLO();
            ObjectResult<List<VehicleTypes>> output = new ObjectResult<List<VehicleTypes>>();

            try
            {
                output.Result = biz.GetAllVehicleTypes();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed To Get All Vehicle Types";
            }
            return output;
        }

        public ObjectResult<List<VehicleTypes>> VehicleTypeFilter(string search)
        {
            VehicleTypesBLO biz = new VehicleTypesBLO();
            ObjectResult<List<VehicleTypes>> output = new ObjectResult<List<VehicleTypes>>();

            try
            {
                output.Result = biz.VehicleTypeFilter(search);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed To Search Vehicle Types " + search;
            }
            return output;
        }

        public ObjectResult<VehicleTypes> CreateVehicleType(VehicleTypesCustom vehicleType)
        {
            VehicleTypesBLO biz = new VehicleTypesBLO();
            ObjectResult<VehicleTypes> output = new ObjectResult<VehicleTypes>();

            try
            {
                if (biz.DescEnExist(vehicleType.VehicleTypeNameEn))
                {
                    output.Message = string.Format("English Vehicle Type Description: '{0}' Already Exists", vehicleType.VehicleTypeNameEn);
                    return output;
                }

                if (biz.DescArExist(vehicleType.VehicleTypeNameAr))
                {
                    output.Message = string.Format("Arabic Vehicle Type Description: '{0}' Already Exists", vehicleType.VehicleTypeNameAr);
                    return output;
                }

                biz.CreateVehicleType(InkriptMapper.Mapper.Map<VehicleTypes>(vehicleType));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to Create Vehicle Type";
            }
            return output;
        }

        public ObjectResult<VehicleTypes> UpdateVehicleType(int vehicleTypeId, VehicleTypesCustom vehicleType)
        {
            VehicleTypesBLO biz = new VehicleTypesBLO();
            ObjectResult<VehicleTypes> output = new ObjectResult<VehicleTypes>();

            try
            {
                if (!biz.VehicleTypeExist(vehicleTypeId))
                {
                    output.Message = string.Format("Vehicle Type Id {0} Not Found", vehicleTypeId);
                    return output;
                }

                if (!biz.ValidateDescEn(vehicleTypeId, vehicleType.VehicleTypeNameEn))
                {
                    if (biz.DescEnExist(vehicleType.VehicleTypeNameEn))
                    {
                        output.Message = string.Format("English Vehicle Type Description: '{0}' Already Exists", vehicleType.VehicleTypeNameEn);
                        return output;
                    }
                }

                if (!biz.ValidateDescAr(vehicleTypeId, vehicleType.VehicleTypeNameAr))
                {
                    if (biz.DescArExist(vehicleType.VehicleTypeNameAr))
                    {
                        output.Message = string.Format("Arabic Vehicle Type Description: '{0}' Already Exists", vehicleType.VehicleTypeNameAr);
                        return output;
                    }
                }

                VehicleTypes entity = InkriptMapper.Mapper.Map<VehicleTypes>(vehicleType);
                entity.VehicleTypeId = vehicleTypeId;
                biz.UpdateVehicleType(entity);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to Update Vehicle Type Id " + vehicleTypeId;
            }
            return output;
        }

        public ObjectResult<bool> DeleteVehicleType(int vehicleTypeId)
        {
            VehicleTypesBLO biz = new VehicleTypesBLO();
            ObjectResult<bool> output = new ObjectResult<bool>();
            
            try
            {
                if (!biz.VehicleTypeExist(vehicleTypeId))
                {
                    output.Message = string.Format("Vehicle Type Id {0} Not Found", vehicleTypeId);
                    return output;
                }
                output.Result = biz.DeleteVehicleType(vehicleTypeId);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = false;
                output.Success = false;
                output.Message = "Failed to Delete Vehicle Type Id " + vehicleTypeId;
            }
            return output;
        }
    }
}