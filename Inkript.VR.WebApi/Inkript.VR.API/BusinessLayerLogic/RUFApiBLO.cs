using Inkript.Logging;
using Inkript.VR.API.Helpers;
using Inkript.VR.API.Models;
using Inkript.VR.Business.BusinessLayer;
using Inkript.VR.Models;
using InkriptRest;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Web.Configuration;

namespace Inkript.VR.API
{
    public class RUFApiBLO
    {
        public ObjectResult<PrivateRUFResult> GetRUFDues(int applicationId, int currentYearIncluded)
        {
            ApplicationBLO applicationBiz = new ApplicationBLO();
            ObjectResult<PrivateRUFResult> output = new ObjectResult<PrivateRUFResult>();

            try
            {
                if (!applicationBiz.ApplicationExist(applicationId))
                {
                    output.Message = string.Format("ApplicationId {0} Not Found", applicationId);
                    return output;
                }

                if (currentYearIncluded != 0 && currentYearIncluded != 1)
                {
                    output.Message = string.Format("CurrentYearIncluded Value {0} Not Valid", currentYearIncluded);
                    return output;
                }

                return CallPrivateRUF(applicationId, currentYearIncluded);

            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = String.Format("Failed to Get RUF Dues");
            }
            return output;
        }

        private ObjectResult<PrivateRUFResult> CallPrivateRUF(int applicationId, int currentYearIncluded)
        {
            PrivateRUFObject privateRUFObject = CreatePrivateRUFObject(applicationId, currentYearIncluded);
            PrivateRUFResult privateRUFResult = new PrivateRUFResult();
            ObjectResult<PrivateRUFResult> objectResult = new ObjectResult<PrivateRUFResult>();

            NameValueCollection section = ConfigurationManager.GetSection("privateRUFDues") as NameValueCollection;
            string baseUrl = section["BaseUrl"];
            string resource = section["Resource"];
            string dateFormat = section["DateFormat"];
            string successResult = section["SuccessResult"];

            RestClient client = new RestClient(baseUrl);

            var request = new RestRequest
            {
                Resource = resource,
                Method = Method.POST,
                DateFormat = dateFormat,
                RequestFormat = DataFormat.Json
            };

            request.AddBody(privateRUFObject);

            IRestResponse<ApiResponse<string>> response = client.Execute<ApiResponse<string>>(request);

            if (response.Data.Flag != successResult)
            {
                Log.Error(string.Format("Api Message: {0}", response.Data.Message));
                Log.Error(string.Format("Api RequestId: {0}", response.Data.RequestId));
                objectResult.Message = response.Data.Message;
                return objectResult;
            }

            objectResult.Result = JsonConvert.DeserializeObject<PrivateRUFResult>(response.Data.Result);

            return objectResult;
        }

        private PrivateRUFObject CreatePrivateRUFObject(int applicationId, int currentYearIncluded)
        {
            ApplicationBLO applicationBiz = new ApplicationBLO();
            PlateCodesBLO plateCodesBiz = new PlateCodesBLO();
            SectorsBLO sectorsBiz = new SectorsBLO();
            UtilizationBLO utilizationBiz = new UtilizationBLO();
            BrandBLO brandBiz = new BrandBLO();
            ModelBLO modelBiz = new ModelBLO();
            VehicleTypesBLO vehicleTypeBiz = new VehicleTypesBLO();
            FuelTypesBLO fuelTypesBiz = new FuelTypesBLO();
            BranchesBLO branchesBiz = new BranchesBLO();
            BusinessProcessesBLO businessProcessesBiz = new BusinessProcessesBLO();

            Application application = applicationBiz.GetApplication(applicationId);

            if (JsonHelper.JsonIsNull(application.CarDetails))
            {
                throw new Exception(String.Format("Vehicle Details for Application Id {0} Not Found", applicationId));
            }

            VehicleDetails carDetails = JsonConvert.DeserializeObject<VehicleDetailsApplication>(application.CarDetails).NewVehicleDetails;

            PrivateRUFObject privateRUFObject = new PrivateRUFObject();
            privateRUFObject.CarDetails.ApplicationNumber = applicationId;
            privateRUFObject.CarDetails.CUN = application.CarUniqueNumber.ToString();
            privateRUFObject.CarDetails.ProductionYear = carDetails.ProductionYear.ToString();
            if (JsonHelper.JsonIsNull(application.CarPlateInfo))
            {
                throw new Exception(String.Format("Car Plate Info for Application Id {0} Not Found", applicationId));
            }
            NewVehiclePlate carPlateInfo = JsonConvert.DeserializeObject<CarPlateInfo>(application.CarPlateInfo).NewVehiclePlate;
            if (!plateCodesBiz.PlateCodeExist(carPlateInfo.PlateCodeId))
            {
                throw new Exception(String.Format("PlateCodeId {0} Not Found", carDetails.PlateCodeId.Value));
            }
            privateRUFObject.CarDetails.CarCode = plateCodesBiz.GetById(carPlateInfo.PlateCodeId).CodeDescEn;
            privateRUFObject.CarDetails.CarPlateNumber = carPlateInfo.PlateNumber;
            if (!sectorsBiz.SectorExist(carDetails.SectorId.Value))
            {
                throw new Exception(String.Format("SecotrId {0} Not Found", carDetails.SectorId.Value));
            }
            privateRUFObject.CarDetails.Sector = sectorsBiz.GetBySectorId(carDetails.SectorId.Value).SectorNameEn;
            if (!utilizationBiz.UtilizationExist(carDetails.UtilizationId.Value))
            {
                throw new Exception(String.Format("UtilizationId {0} Not Found", carDetails.UtilizationId.Value));
            }
            privateRUFObject.CarDetails.UtilizationId = carDetails.UtilizationId.Value;
            privateRUFObject.CarDetails.UtilizationDesc = utilizationBiz.GetUtilizationById(carDetails.UtilizationId.Value).UtilizationDesc;
            if (!brandBiz.BrandExist(carDetails.BrandId.Value))
            {
                throw new Exception(String.Format("BrandId {0} Not Found", carDetails.BrandId.Value));
            }
            privateRUFObject.CarDetails.BrandDesc = brandBiz.GetBrand(carDetails.BrandId.Value).BrandNameEN;
            if (!modelBiz.ModelExist(carDetails.ModelId.Value))
            {
                throw new Exception(String.Format("ModelId {0} Not Found", carDetails.ModelId.Value));
            }
            privateRUFObject.CarDetails.ModelDesc = modelBiz.GetModel(carDetails.ModelId.Value).ModelName;
            privateRUFObject.CarDetails.AcquisitionDate = carDetails.DateRegistered.Value;
            if (!vehicleTypeBiz.VehicleTypeExist(carDetails.VehicleTypeId.Value))
            {
                throw new Exception(String.Format("VehicleTypeId {0} Not Found", carDetails.VehicleTypeId.Value));
            }
            privateRUFObject.CarDetails.VehicleType = vehicleTypeBiz.GetByVehicleTypeId(carDetails.VehicleTypeId.Value).VehicleTypeNameEn;
            if (!fuelTypesBiz.FuelTypeExist(carDetails.FuelTypeId.Value))
            {
                throw new Exception(String.Format("FuelTypeId {0} Not Found", carDetails.FuelTypeId.Value));
            }
            privateRUFObject.CarDetails.FuelType = fuelTypesBiz.GetFuelTypesById(carDetails.FuelTypeId.Value).FuelNameEn;
            if (carDetails.VehicleTypeId == (int)FlagVehicleType.Truck)
            {
                privateRUFObject.CarDetails.TrunkTypeId = carDetails.TrunkTypeId.Value;
            }
            privateRUFObject.CarDetails.HorsePower = carDetails.HorsePower.Value;
            privateRUFObject.CarDetails.NumberOfCylinders = carDetails.Cylinders.Value;
            privateRUFObject.CarDetails.TotalSeats = carDetails.Seats.Value;
            privateRUFObject.CarDetails.SeatsNextToDriver = carDetails.SeatsNextDriver.Value;
            privateRUFObject.CarDetails.EmptyWeight = carDetails.EmptyWeight.Value;
            privateRUFObject.CarDetails.NetWeight = carDetails.NetWeight.Value;
            privateRUFObject.CarDetails.TotalWeight = carDetails.TotalWeight.Value;

            if (JsonHelper.JsonIsNull(application.OwnersInfo))
            {
                throw new Exception(string.Format("OwnersInfo for Application Id {0} Not Found", application.ApplicationId));
            }

            if (application.OwnerType == (int)FlagOwnerTypes.Persons)
            {
                Person owner = JsonConvert.DeserializeObject<List<Person>>(application.OwnersInfo)[0];
                PrivateRUFOwners RUFowner = new PrivateRUFOwners();
                RUFowner.OwnerType = Enum.GetName(typeof(FlagOwnerTypes), (int)FlagOwnerTypes.Persons);
                RUFowner.OwnerName = owner.FirstName + " " + owner.LastName;
                privateRUFObject.CarDetails.Owners.Add(RUFowner);
            }
            else
            {
                Organization ownersO = JsonConvert.DeserializeObject<List<Organization>>(application.OwnersInfo)[0];
                PrivateRUFOwners RUFowner = new PrivateRUFOwners();
                RUFowner.OwnerType = Enum.GetName(typeof(FlagOwnerTypes), (int)FlagOwnerTypes.Company);
                RUFowner.OwnerName = ownersO.OrganizationName;
                privateRUFObject.CarDetails.Owners.Add(RUFowner);
            }

            if (!branchesBiz.BranchExist(application.BranchId))
            {
                throw new Exception(String.Format("BranchId {0} Not Found", application.BranchId));
            }
            privateRUFObject.Agent.BranchName = branchesBiz.GetBranch(application.BranchId).BranchNameEn;
            privateRUFObject.Agent.Username = application.ProcessedBy;
            privateRUFObject.CurrYearIncluded = currentYearIncluded;

            if (JsonHelper.JsonIsNull(application.BusinessProcess))
            {
                throw new Exception(string.Format("BusinessProcess for Application Id {0} Not Found", application.ApplicationId));
            }

            JsonBP jsonBP = JsonConvert.DeserializeObject<JsonBP>(application.BusinessProcess);
            string BPName = businessProcessesBiz.GetByBusinessProcessId(jsonBP.PrimaryBusinessProcess.BPId).BPNameEn;
            BPName = BPName.Replace(" ", string.Empty);
            int paymentType;
            NameValueCollection section = ConfigurationManager.GetSection("bpRUFDues") as NameValueCollection;
            try
            {
                paymentType = Int16.Parse(section[BPName]);
            }
            catch
            {
                throw new Exception(string.Format("Business Process {0} not allowed", jsonBP.PrimaryBusinessProcess.BPId));
            }
            privateRUFObject.PaymentType = paymentType;

            return privateRUFObject;
        }
    }
}
