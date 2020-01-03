using System;
using Inkript.Logging;
using Inkript.VR.API.Models;
using Inkript.VR.Business.BusinessLayer;
using Inkript.VR.Models;

namespace Inkript.VR.API
{
    public class CarUniqueNumberApiBLO
    {
        public ObjectResult<int> GenerateCarUniqueNumber(CarUniqueNumberCustom carUniqueNumber)
        {
            TrimBLO trimBiz = new TrimBLO();
            ModelBLO modelBiz = new ModelBLO();
            BrandBLO brandBiz = new BrandBLO();
            CarUniqueNumberBLO biz = new CarUniqueNumberBLO();
            RegisteredVehiclesBLO registeredCarsBiz = new RegisteredVehiclesBLO();
            ObjectResult<int> output = new ObjectResult<int>();

            try
            {
                if (carUniqueNumber.TrimId.HasValue && !trimBiz.TrimExist(carUniqueNumber.TrimId.Value))
                {
                    output.Message = string.Format("Trim Id: {0} Not Exist", carUniqueNumber.TrimId);
                    return output;
                }

                if (!modelBiz.ModelExist(carUniqueNumber.ModelId))
                {
                    output.Message = string.Format("Model Id: {0} Not Exist", carUniqueNumber.ModelId);
                    return output;
                }

                if (!brandBiz.BrandExist(carUniqueNumber.BrandId))
                {
                    output.Message = string.Format("Brand Id: {0} Not Exist", carUniqueNumber.BrandId);
                    return output;
                }

                int carUniqueNumberId = biz.GenerateCarUniqueNumber(InkriptMapper.Mapper.Map<CarUniqueNumber>(carUniqueNumber));
                if (registeredCarsBiz.CarUniqueNumberExist(carUniqueNumberId))
                    output.Message = string.Format("Car Unique Number {0} is already registered", carUniqueNumberId);

                output.Result = carUniqueNumberId;
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = 0;
                output.Success = false;
                output.Message = "Failed to Generate Car Unique Number";
            }
            return output;
        }

        public ObjectResult<int> GetCarUniqueNumberByChassisNumber(string chassisNumber)
        {
            CarUniqueNumberBLO biz = new CarUniqueNumberBLO();
            ObjectResult<int> output = new ObjectResult<int>();

            try
            {
                output.Result = biz.GetCarUniqueNumberByChassisNumber(chassisNumber);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = 0;
                output.Success = false;
                output.Message = "Failed to Get Car Unique Number by Chassis Number " + chassisNumber;
            }
            return output;
        }
    }
}