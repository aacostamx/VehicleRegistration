using Inkript.Logging;
using Inkript.VR.API.Models;
using Inkript.VR.Business;
using Inkript.VR.Business.BusinessLayer;
using Inkript.VR.Models;
using InkriptRest;
using Newtonsoft.Json;
using System;
using System.Collections.Specialized;
using System.Configuration;

namespace Inkript.VR.API
{
    public class PlatesApiBLO
    {
        public ObjectResult<int> GetPlatesNumberToDeliver(int carUniqueNumber, int vehicleTypeId, int? trunkTypeId = null)
        {
            VehicleBLO biz = new VehicleBLO();
            TrunkTypeBLO trunkTypeBiz = new TrunkTypeBLO();
            VehicleTypesBLO vehicleTypeBiz = new VehicleTypesBLO();
            CarUniqueNumberBLO carUniqueNumberBiz = new CarUniqueNumberBLO();

            ObjectResult<int> output = new ObjectResult<int>();

            try
            {
                int allowedPlates = 0;
                NameValueCollection section = new NameValueCollection();

                if (vehicleTypeId == (int)FlagVehicleType.Truck)
                {
                    if (!trunkTypeId.HasValue)
                    {
                        output.Message = string.Format("TrunkTypeId is required");
                        return output;
                    }
                    if (!trunkTypeBiz.TrunkTypeExist(trunkTypeId.Value))
                    {
                        output.Message = string.Format("TrunkTypeId: {0} Not Exists", trunkTypeId);
                        return output;
                    }
                    section = ConfigurationManager.GetSection("allowedPlatesTrucks") as NameValueCollection;
                    allowedPlates = Int32.Parse(section[Enum.GetName(typeof(FlagTruckType), trunkTypeId)]);
                }
                else
                {
                    section = ConfigurationManager.GetSection("allowedPlatesVehicles") as NameValueCollection;
                    allowedPlates = Int32.Parse(section[Enum.GetName(typeof(FlagVehicleType), vehicleTypeId)]);
                }

                section = ConfigurationManager.GetSection("activePlatesAPI") as NameValueCollection;

                string baseUrl = section["BaseUrl"];
                string resource = section["Resource"];
                string successResult = section["SuccessResult"];
                string nameParameter = section["NameParameter"];

                RestClient client = new RestClient(baseUrl);
                RestRequest request = new RestRequest { Resource = resource, Method = Method.GET };
                request.AddQueryParameter(nameParameter, carUniqueNumber.ToString());

                IRestResponse<ApiResponse<string>> response = client.Execute<ApiResponse<string>>(request);

                if (response.Data.Flag == successResult)
                {
                    int plateCount = 0;
                    plateCount = JsonConvert.DeserializeObject<dynamic>(response.Data.Result).PlatesCount;

                    if (plateCount >= 0)
                    {
                        int plates = allowedPlates - plateCount;
                        plates = plates <= -1 ? 0 : plates;
                        output.Result = plates;
                    }
                    else
                    {
                        output.Result = plateCount;
                        output.Message = response.Data.Message;
                    }
                }
                else
                {
                    output.Message = response.Data.Message;
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = 0;
                output.Message = "Failed to Get Plates Number To Deliver";
            }
            return output;
        }

        public ObjectResult<GenerateRandomNumber> GenerateRandomNumber(int branchId, int sectorId, int vehicleTypeId)
        {
            SectorsBLO sectorsBiz = new SectorsBLO();
            BranchesBLO branchesBiz = new BranchesBLO();
            PlateCodesBLO plateCodesBiz = new PlateCodesBLO();
            PlateRangesBLO plateRangesBiz = new PlateRangesBLO();
            VehicleTypesBLO vehicleTypesBiz = new VehicleTypesBLO();
            ObjectResult<GenerateRandomNumber> output = new ObjectResult<GenerateRandomNumber>();

            try
            {
                if (!sectorsBiz.SectorExist(sectorId))
                {
                    output.Message = string.Format("Sector Id {0} Not Found", sectorId);
                    return output;
                }

                if (!vehicleTypesBiz.VehicleTypeExist(vehicleTypeId))
                {
                    output.Message = string.Format("Vehicle Type Id {0} Not Found", vehicleTypeId);
                    return output;
                }

                if (!branchesBiz.BranchExist(branchId))
                {
                    output.Message = string.Format("Branch Id {0} Not Found", branchId);
                    return output;
                }

                output.Result = plateRangesBiz.GenerateRandomNumber(branchId, sectorId, vehicleTypeId);
                if (output.Result.Code == null
                    || output.Result.RandomNumber == null)
                {
                    output.Message = string.Format("No Pools Available!");
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = default(GenerateRandomNumber);
                output.Success = false;
                output.Message = "Failed to Generate Random Number";
            }
            return output;
        }

    }
}