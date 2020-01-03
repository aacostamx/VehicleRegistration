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
using System.Threading.Tasks;

namespace Inkript.VR.API
{
    public class FeesApiBLO
    {
        public ObjectResult<GenericPagedList<Fees>> GetAllFeesPaged(int pageNumber, int pageSize)
        {
            FeesBLO biz = new FeesBLO();
            ObjectResult<GenericPagedList<Fees>> output = new ObjectResult<GenericPagedList<Fees>>();

            try
            {
                output.Result = biz.GetAllFeesPaged(pageNumber, pageSize);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to Get All Fees Paged";
            }
            return output;
        }

        public ObjectResult<Fees> GetByFeeId(int feeId)
        {
            FeesBLO biz = new FeesBLO();
            ObjectResult<Fees> output = new ObjectResult<Fees>();

            try
            {
                if (!biz.FeeExist(feeId))
                {
                    output.Message = string.Format("Fee Id {0} Not Found", feeId);
                    return output;
                }
                output.Result = biz.GetByFeeId(feeId);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to Get Fee by Id: " + feeId;
            }
            return output;
        }

        public ObjectResult<List<Fees>> GetAllFees()
        {
            FeesBLO biz = new FeesBLO();
            ObjectResult<List<Fees>> output = new ObjectResult<List<Fees>>();

            try
            {
                output.Result = biz.GetAllFees();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to Get All Fees";
            }
            return output;
        }

        public ObjectResult<List<Fees>> FeesFilter(string search)
        {
            FeesBLO biz = new FeesBLO();
            ObjectResult<List<Fees>> output = new ObjectResult<List<Fees>>();

            try
            {
                output.Result = biz.FeesFilter(search);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to Get Fees by search: " + search;
            }
            return output;
        }

        public ObjectResult<Fees> CreateFee(FeesCustom fee)
        {
            FeesBLO biz = new FeesBLO();
            StatusBLO statusBiz = new StatusBLO();
            SectorsBLO sectorsBiz = new SectorsBLO();
            FeeCategoryBLO feeCategoryBiz = new FeeCategoryBLO();
            VehicleTypesBLO vehicleTypesBiz = new VehicleTypesBLO();
            BusinessProcessesBLO businessProcessesBiz = new BusinessProcessesBLO();
            ObjectResult<Fees> output = new ObjectResult<Fees>();

            try
            {
                if (!String.IsNullOrEmpty(fee.FeeNameEn) && biz.FeeNameEnExist(fee.FeeNameEn))
                {
                    output.Message = string.Format("English Fee Name: '{0}' Already Exists", fee.FeeNameEn);
                    return output;
                }

                if (!String.IsNullOrEmpty(fee.FeeNameAr) && biz.FeeNameArExist(fee.FeeNameAr))
                {
                    output.Message = string.Format("Arabic Fee Name: '{0}' Already Exists", fee.FeeNameAr);
                    return output;
                }

                if (!feeCategoryBiz.FeeCategoryExist(fee.FeeCategoryId))
                {
                    output.Message = string.Format("FeeCategoryId: {0} Not Exists", fee.FeeCategoryId);
                    return output;
                }

                if (!statusBiz.StatusExist(fee.StatusId))
                {
                    output.Message = string.Format("StatusId: {0} Not Exists", fee.StatusId);
                    return output;
                }

                if (fee.FeeType == (int)FlagFeeTypes.StoredProcedure && string.IsNullOrEmpty(fee.FeeSP))
                {
                    output.Message = string.Format("Fee Type: {0} must be related to Stored Procedure", fee.FeeType);
                    return output;
                }

                if (fee.FeeType == (int)FlagFeeTypes.Api && string.IsNullOrEmpty(fee.Api))
                {
                    output.Message = string.Format("Fee Type: {0} must be related to an API", fee.FeeType);
                    return output;
                }

                Fees entity = InkriptMapper.Mapper.Map<Fees>(fee);

                foreach (var item in fee.BPFee)
                {
                    if (!businessProcessesBiz.BusinessProcessExist(item.BPId))
                    {
                        output.Message = string.Format("Business Process Id {0} Not Found", item.BPId);
                        return output;
                    }

                    if (!sectorsBiz.SectorExist(item.SectorId))
                    {
                        output.Message = string.Format("Sector Id {0} Not Found", item.SectorId);
                        return output;
                    }

                    if (!vehicleTypesBiz.VehicleTypeExist(item.VTId))
                    {
                        output.Message = string.Format("Vehicle Type Id {0} Not Found", item.VTId);
                        return output;
                    }
                }

                biz.CreateFee(InkriptMapper.Mapper.Map<Fees>(fee));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to Create Fee";
            }
            return output;
        }

        public ObjectResult<List<string>> StoredProceduresFees()
        {
            FeesBLO biz = new FeesBLO();
            ObjectResult<List<string>> output = new ObjectResult<List<string>>();

            try
            {
                output.Result = biz.StoredProceduresFees();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to Get Stored Procedures For Fees ";
            }
            return output;
        }

        public ObjectResult<Fees> UpdateFee(int feeId, Fees fee)
        {
            FeesBLO biz = new FeesBLO();
            BPFeeBLO bpFeeBiz = new BPFeeBLO();
            SectorsBLO sectorsBiz = new SectorsBLO();
            VehicleTypesBLO vehicleTypesBiz = new VehicleTypesBLO();
            ExemptedFeesBLO exemptedFeesBiz = new ExemptedFeesBLO();
            BusinessProcessesBLO businessProcessBiz = new BusinessProcessesBLO();
            ObjectResult<Fees> output = new ObjectResult<Fees>();

            try
            {
                if (!biz.FeeExist(feeId))
                {
                    output.Message = string.Format("Fee Id {0} Not Found", feeId);
                    return output;
                }

                if (!biz.ValidateFeeNameEn(feeId, fee.FeeNameEn))
                {
                    if (biz.FeeNameEnExist(fee.FeeNameEn))
                    {
                        output.Message = string.Format("English Fee Name: '{0}' Already Exists", fee.FeeNameEn);
                        return output;
                    }
                }

                if (!biz.ValidateFeeNameAr(feeId, fee.FeeNameAr))
                {
                    if (biz.FeeNameArExist(fee.FeeNameAr))
                    {
                        output.Message = string.Format("Arabic Fee Name: '{0}' Already Exists", fee.FeeNameAr);
                        return output;
                    }
                }

                foreach (var item in fee.BPFee)
                {
                    if (!bpFeeBiz.BPFeeExist(item.BPFeeId))
                    {
                        output.Message = string.Format("Business Process Fee Id {0} Not Found", item.BPFeeId);
                        return output;
                    }

                    if (!businessProcessBiz.BusinessProcessExist(item.BPId))
                    {
                        output.Message = string.Format("Business Process Id {0} Not Found", item.BPId);
                        return output;
                    }

                    if (!sectorsBiz.SectorExist(item.SectorId))
                    {
                        output.Message = string.Format("Sector Id {0} Not Found", item.SectorId);
                        return output;
                    }

                    if (!vehicleTypesBiz.VehicleTypeExist(item.VTId))
                    {
                        output.Message = string.Format("Vehicle Type Id {0} Not Found", item.VTId);
                        return output;
                    }
                }

                foreach (var item in fee.ExemptedFees)
                {
                    if (!exemptedFeesBiz.ExemptedFeeExist(item.ExemptedFeeId))
                    {
                        output.Message = string.Format("Exempted Fee Id {0} Not Found", item.ExemptedFeeId);
                        return output;
                    }
                }

                fee.FeeId = feeId;
                biz.UpdateFee(fee);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to Update Fee Id: " + feeId;
            }
            return output;
        }

        public ObjectResult<List<Fees>> CalculateFees(int applicationId, bool saveFee)
        {
            FeesBLO biz = new FeesBLO();
            BPFeeBLO bpFeeBiz = new BPFeeBLO();
            ApplicationBLO appBiz = new ApplicationBLO();
            CalculatedFeesBLO calculatedFeesBiz = new CalculatedFeesBLO();
            ObjectResult<List<Fees>> output = new ObjectResult<List<Fees>>();

            try
            {
                if (!appBiz.ApplicationExist(applicationId))
                {
                    output.Message = string.Format("Application Id {0} Not Found", applicationId);
                    return output;
                }

                Application app = appBiz.GetApplication(applicationId);

                if (string.IsNullOrEmpty(app.BusinessProcess)
                    || !JsonHelper.IsValidJson(app.BusinessProcess))
                {
                    output.Message = string.Format("Business Processes Data Not Valid for Application {0}",
                        applicationId);
                    return output;
                }

                if (string.IsNullOrEmpty(app.CarDetails)
                    || !JsonHelper.IsValidJson(app.CarDetails))
                {
                    output.Message = string.Format("Car Details Data Not Valid for Application {0}",
                        applicationId);
                    return output;
                }

                if (!app.CarDetails.Contains("Sector"))
                {
                    output.Message = string.Format("Invalid Sector Id for Application {0}", applicationId);
                    return output;
                }

                if (!app.CarDetails.Contains("VehicleType"))
                {
                    output.Message = string.Format("Invalid Vehicle Type Id for Application {0}", applicationId);
                    return output;
                }

                JsonBP businessProcesses = JsonConvert.DeserializeObject<JsonBP>(app.BusinessProcess);
                //TODO validate if the New Vehicle Details Exists
                VehicleDetails carDetails = JsonConvert.DeserializeObject<VehicleDetailsApplication>(app.CarDetails).NewVehicleDetails;

                if (carDetails.SectorId != null && carDetails.VehicleTypeId != null)
                {
                    List<BPFee> bpFees = bpFeeBiz.GetBPFees(businessProcesses, (int)carDetails.SectorId, (int)carDetails.VehicleTypeId);

                    if (bpFees == null || bpFees.Count == 0)
                    {
                        output.Message = string.Format("There isn't any Business Process Related to Fees");
                        return output;
                    }

                    List<Fees> fees = biz.GetFees(bpFees);

                    foreach (var item in fees)
                    {
                        if (!string.IsNullOrEmpty(item.Api))
                        {
                            switch (item.Api)
                            {
                                case "StampFee":
                                    StampFee(item, carDetails);
                                    break;
                                default:
                                    break;
                            }
                        }
                    }

                    output.Result = biz.CalculateFees(fees, applicationId);

                    if (saveFee)
                    {
                        if (output.Result != null && output.Result.Count > 0)
                        {
                            List<CalculatedFees> calculatedFees =
                                InkriptMapper.Mapper.Map<List<CalculatedFees>>(output.Result);
                            calculatedFees.ForEach(c => c.ApplicationId = applicationId);
                            calculatedFeesBiz.SaveCalculatedFees(calculatedFees);
                        }
                    }
                }
                else
                {
                    output.Message = string.Format("Invalid JSON configuration for Application {0}", applicationId);
                    return output;
                }

            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to Calculate Fees by Application Id: " + applicationId;
            }
            return output;
        }

        private void StampFee(Fees item, VehicleDetails app)
        {
            try
            {
                NameValueCollection section = ConfigurationManager.GetSection("stampFee") as NameValueCollection;
                string baseUrl = section["BaseUrl"];
                string resource = section["Resource"];

                RestClient client = new RestClient(baseUrl);

                RestRequest request = new RestRequest(resource, Method.POST);
                VehicleDetails vehicle = new VehicleDetails
                {
                    CertificateId = app.CertificateId,
                    BrandId = app.BrandId,
                    ModelId = app.ModelId,
                    ProductionYear = app.ProductionYear,
                    ColorId = app.ColorId,
                    Chassis = app.Chassis,
                    MotorNumber = app.MotorNumber,
                    Cylinders = app.Cylinders,
                    Taxes = app.Taxes,
                    Discounted = app.Discounted,
                    CarUniqueNumber = app.CarUniqueNumber,
                    TrimId = app.TrimId,
                    PlateNumber = app.PlateNumber,
                    PlateCodeId = app.PlateCodeId,
                    FormId = app.FormId,
                    TrunkTypeId = app.TrunkTypeId,
                    FuelTypeId = app.FuelTypeId,
                    HorsePower = app.HorsePower,
                    CapacityCC = app.CapacityCC,
                    Seats = app.Seats,
                    SeatsNextDriver = app.SeatsNextDriver,
                    PassengersNo = app.PassengersNo,
                    EmptyWeight = app.EmptyWeight,
                    NetWeight = app.NetWeight,
                    YearMake = app.YearMake,
                    VehicleCategoryId = app.VehicleCategoryId,
                    SectorId = app.SectorId,
                    TotalWeight = app.TotalWeight,
                    VehicleTypeId = app.VehicleTypeId,
                    InServiceDate = app.InServiceDate,
                    DateRegistered = app.DateRegistered,
                    CarStatusId = app.CarStatusId,
                    ExemptionCategory = app.ExemptionCategory,
                    IsRegistered = app.IsRegistered,
                    MarginRate = app.MarginRate
                };
                request.AddObject(vehicle);
                request.AddParameter("calledFromUI", (int)FlagCalledFrom.Backend);

                IRestResponse<ObjectResult<StampFee>> response =
                    client.Execute<ObjectResult<StampFee>>(request);

                if (response.IsSuccessful &&
                    response.Data.Result != null)
                {
                    item.FeeValue = response.Data.Result.FeeValue ?? null;
                    item.FeeTotal = response.Data.Result.FeeTotal ?? null;
                }
                else
                {
                    item.FeeId = -1;
                    Log.Error("Failed to call the Web API: " + baseUrl + resource);
                }
            }
            catch (Exception ex)
            {
                item.FeeId = -1;
                Log.Error(ex);
            }
        }

        public ObjectResult<bool> DeleteFee(int feeId)
        {
            FeesBLO biz = new FeesBLO();
            ObjectResult<bool> output = new ObjectResult<bool>();

            try
            {
                if (!biz.FeeExist(feeId))
                {
                    output.Message = string.Format("Fee Id {0} Not Found", feeId);
                    return output;
                }
                output.Result = biz.DeleteFee(feeId);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = false;
                output.Success = false;
                output.Message = "Failed to Delete Fee Id: " + feeId;
            }
            return output;
        }

        public ObjectResult<StampFee> StampFee(VehicleDetails vehicleInfo, int calledFromUI)
        {
            FeesBLO biz = new FeesBLO();
            VehicleBLO vehicleInfoBiz = new VehicleBLO();
            ObjectResult<StampFee> output = new ObjectResult<StampFee>();

            try
            {
                output.Result = biz.StampFee(vehicleInfoBiz.GetVehicleValue(vehicleInfo).Value, calledFromUI);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to Get Stamp Fee";
            }
            return output;
        }
    }
}