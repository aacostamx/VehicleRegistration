using Inkript.Logging;
using Inkript.VR.API.Models;
using Inkript.VR.Business.BusinessLayer;
using Inkript.VR.Models;
using System;
using System.Collections.Generic;

namespace Inkript.VR.API
{
    public class RegisteredVehiclesApiBLO
    {
        public ObjectResult<CarStatus> GetRegisteredVehicleStatus(int carUniqueNumber)
        {
            RegisteredVehiclesBLO biz = new RegisteredVehiclesBLO();
            CarUniqueNumberBLO carUniqueNumberBiz = new CarUniqueNumberBLO();
            ObjectResult<CarStatus> output = new ObjectResult<CarStatus>();

            try
            {
                if (!carUniqueNumberBiz.CarUniqueNumberExist(carUniqueNumber))
                {
                    output.Message = string.Format("Car Unique Number: '{0}' Not Exists", carUniqueNumber);
                    return output;
                }

                output.Result = biz.GetRegisteredVehicleStatus(carUniqueNumber);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to Get Registered Car Status";
            }
            return output;
        }

        public ObjectResult<RegisteredVehicles> GetRegisteredVehicleBy
            (int? plateNumber, int? plateCodeId, int? carUniqueNumber, int? carStatusId)
        {
            RegisteredVehiclesBLO biz = new RegisteredVehiclesBLO();
            ObjectResult<RegisteredVehicles> output = new ObjectResult<RegisteredVehicles>();

            try
            {
                output.Result = biz.GetRegisteredVehicleBy(plateNumber, plateCodeId, carUniqueNumber, carStatusId);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to Get Registered Vehicles By Params";
            }
            return output;
        }

        public ObjectResult<GenericPagedList<RegisteredVehicles>> GetAllRegisteredVehiclesPaged(int pageNumber, int pageSize)
        {
            RegisteredVehiclesBLO biz = new RegisteredVehiclesBLO();
            ObjectResult<GenericPagedList<RegisteredVehicles>> output = new ObjectResult<GenericPagedList<RegisteredVehicles>>();

            try
            {
                output.Result = biz.GetAllRegisteredVehiclesPaged(pageNumber, pageSize);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to Get All Registered Vehicles Paged";
            }
            return output;
        }

        public ObjectResult<List<RegisteredVehicles>> GetRegisteredVehicles(int? carUniqueNumber, string plateNumber, int? plateCodeId)
        {
            RegisteredVehiclesBLO biz = new RegisteredVehiclesBLO();
            ObjectResult<List<RegisteredVehicles>> output = new ObjectResult<List<RegisteredVehicles>>();

            try
            {
                output.Result = biz.GetRegisteredVehicles(carUniqueNumber, plateNumber, plateCodeId);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to Get All Registered Vehicles";
            }
            return output;
        }
    }
}