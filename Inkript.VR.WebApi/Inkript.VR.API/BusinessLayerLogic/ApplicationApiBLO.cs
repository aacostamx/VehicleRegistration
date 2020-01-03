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
    public class ApplicationApiBLO
    {
        public ObjectResult<int> CreateApplication(ApplicationCustom application)
        {

            StatusBLO statusBiz = new StatusBLO();
            ApplicationBLO biz = new ApplicationBLO();
            ObjectResult<int> output = new ObjectResult<int>();

            try
            {
                if (!statusBiz.StatusExist(application.StatusId))
                {
                    output.Message = string.Format("Status Id {0} Not Found", application.StatusId);
                    return output;
                }

                output.Result = biz.CreateApplication(InkriptMapper.Mapper.Map<Application>(application));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = 0;
                output.Success = false;
                output.Message = "Failed to Create Application";
            }
            return output;
        }

        public ObjectResult<List<Application>> GetAllApplication()
        {
            ApplicationBLO biz = new ApplicationBLO();
            ObjectResult<List<Application>> output = new ObjectResult<List<Application>>();

            try
            {
                output.Result = biz.GetAllApplication();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to Get All Applications";
            }
            return output;
        }

        public ObjectResult<Application> UpdateApplicationStatus(int applicationId, int statusId)
        {
            StatusBLO statusBiz = new StatusBLO();
            ApplicationBLO biz = new ApplicationBLO();
            ObjectResult<Application> output = new ObjectResult<Application>();

            try
            {

                if (!biz.ApplicationExist(applicationId))
                {
                    output.Message = string.Format("Application Id {0} Not Found", applicationId);
                    return output;
                }

                if (!statusBiz.StatusExist(statusId))
                {
                    output.Message = string.Format("Status Id {0} Not Found", statusId);
                    return output;
                }

                Application draftApp = biz.GetApplication(applicationId);
                draftApp.Status.StatusId = statusId;
                biz.UpdateApplication(draftApp);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to Update Application Id " + applicationId;
            }
            return output;
        }

        public ObjectResult<bool> UpdateApplication(int applicationId, ApplicationCustom application)
        {
            ApplicationBLO biz = new ApplicationBLO();
            ObjectResult<bool> output = new ObjectResult<bool>();

            try
            {

                if (!biz.ApplicationExist(applicationId))
                {
                    output.Message = string.Format("Application Id {0} Not Found", applicationId);
                    return output;
                }

                Application draftApp = InkriptMapper.Mapper.Map<Application>(application);
                draftApp.ApplicationId = applicationId;
                output.Result = biz.UpdateApplication(draftApp);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = false;
                output.Success = false;
                output.Message = "Failed to Update Application Id " + applicationId;
            }
            return output;
        }

        public ObjectResult<List<Application>> GetApplications
            (int? statusId, bool? dateFlag, int? userId, int? branchId, int? sectionId)
        {
            DateTime? lastUpdated = null;
            ApplicationBLO biz = new ApplicationBLO();
            ObjectResult<List<Application>> output = new ObjectResult<List<Application>>();

            try
            {
                if (dateFlag.HasValue && dateFlag.Value)
                {
                    int days = Convert.ToInt32(WebConfigurationManager.AppSettings["days"]) * -1;
                    lastUpdated = DateTime.Now.Date.AddDays(days);
                }

                output.Result = biz.GetApplications(statusId, lastUpdated, userId, branchId, sectionId);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to Get Applications by Params";
            }
            return output;
        }

        public ObjectResult<int> CommitApplication(int applicationId)
        {
            ApplicationBLO biz = new ApplicationBLO();
            ObjectResult<int> output = new ObjectResult<int>();
            AppConfigCommitBLO appConfigCommitBiz = new AppConfigCommitBLO();

            try
            {
                if (!biz.ApplicationExist(applicationId))
                {
                    output.Message = string.Format("Application Id {0} Not Found", applicationId);
                    return output;
                }

                Application app = biz.GetApplication(applicationId);

                if (string.IsNullOrEmpty(app.BusinessProcess))
                {
                    output.Message = string.Format("Invalid Business Processes related to Application Id {0}", applicationId);
                    return output;
                }

                JsonBP businessProcesses = BPDeserialize.DeserializeObject(app.BusinessProcess);

                if (businessProcesses.BPList == null
                    || businessProcesses.BPList.Count == 0)
                {
                    output.Message = string.Format("Invalid Business Processes related to Application Id {0}", applicationId);
                    return output;
                }

                List<AppConfigCommit> appConfigCommit = appConfigCommitBiz.GetAppConfigCommit(businessProcesses.BPList);

                if (app.CarDetails == null)
                {
                    output.Message = string.Format("Invalid Car Details related to Application Id {0}", applicationId);
                    return output;
                }

                if (appConfigCommit == null
                    || appConfigCommit.Count == 0)
                {
                    output.Message = string.Format("Invalid Application Configuration for Commite related to Application Id {0}", applicationId);
                    return output;
                }

                VehicleDetails carDetails = JsonConvert.DeserializeObject<VehicleDetailsApplication>(app.CarDetails).NewVehicleDetails;

                NameValueCollection section = ConfigurationManager.GetSection("commit") as NameValueCollection;
                int roadUsageFees = Convert.ToInt32(section["RoadUsageFees"]);
                int vrHoldsNew = Convert.ToInt32(section["VRHoldsNew"]);
                int vrHoldsUpdate = Convert.ToInt32(section["VRHoldsUpdate"]);


                if (appConfigCommit.Any(c => c.SectionId == roadUsageFees))
                {
                    //TODO Implamenting the privateLogRufPayment flow
                    //PrivateLogRUFPayment privateLogRUFPayment = biz.GetPrivateLogRUFPayment(applicationId);
                    PrivateLogRUFPayment privateLogRUFPayment = new PrivateLogRUFPayment
                    {
                        //ApplicationNumber = app.ApplicationId,
                        //CUN = app.CarUniqueNumber.ToString(),
                        //CarNumber = carDetails.PlateNumber,
                        ApplicationNumber = 54871,
                        CUN = "2354654",
                        CarNumber = "258099",
                        CarCode = "B",
                        OwnerName = "مهدي جمال الدين بكراكي",
                        MOFReceiptId = "74785",
                        SourceReceiptId = "1",
                        Agent = new Agent() { BranchName = "Inkript", Username = "Roy" }
                    };
                    var taxes = new List<Tax>()
                    {
                        new Tax { TaxId = 1, TaxName = "TaxName1", TaxValue = 3.1, Year = "2018" },
                        new Tax { TaxId = 2, TaxName = "TaxName2", TaxValue = 2.5, Year = "2018" }
                    };
                    privateLogRUFPayment.PaymentsInfo = new PaymentsInfo() { TotalFees = 1.1, CurrentYearIncluded = 2, DiscountPercentage = "0.3", Discounts = 0.15, FeesBreakdown = new FeesBreakdown { Taxes = taxes } };

                    NameValueCollection sectionRUF = ConfigurationManager.GetSection("privateRUF") as NameValueCollection;

                    string baseUrl = sectionRUF["BaseUrl"];
                    string resource = sectionRUF["Resource"];

                    RestClient client = new RestClient(baseUrl);

                    RestRequest request = new RestRequest(resource, Method.POST);
                    string json = JsonConvert.SerializeObject(privateLogRUFPayment);
                    request.AddObject(privateLogRUFPayment);

                    IRestResponse<ApiResponse<string>> response = client.Execute<ApiResponse<string>>(request);

                    List<string> privateRUFResult = sectionRUF["PrivateRUFResult"].Split('-').ToList<string>();

                    if (privateRUFResult.Contains(response.Data.Flag, StringComparer.OrdinalIgnoreCase))
                    {
                        output.Result = (int)FlagStatusCode.Success;
                    }
                    else
                    {
                        Log.Error(response.Data.Message);
                        output.Result = (int)FlagStatusCode.Failure;
                        output.Message = response.Data.Message;
                        return output;
                    }
                }

                if (appConfigCommit.Any(c => c.SectionId == vrHoldsNew))
                {
                    NameValueCollection sectionVehicleHolds = ConfigurationManager.GetSection("vehicleHolds") as NameValueCollection;

                    string baseUrl = sectionVehicleHolds["BaseUrl"];
                    string resource = sectionVehicleHolds["ResourceNew"];
                    string dateFormat = sectionVehicleHolds["DateFormat"];
                    string holdType = sectionVehicleHolds["HoldType"];
                    string lockCategory = sectionVehicleHolds["LockCategory"];
                    string source = sectionVehicleHolds["Source"];

                    VehicleHolds vehicleHolds = new VehicleHolds
                    {
                        CarUniqueNumber = carDetails.CarUniqueNumber.ToString(),
                        CarPlateNumber = carDetails.PlateNumber,
                        CarPlateCode = carDetails.PlateCodeId.ToString(),
                        ReferenceNumber = Guid.NewGuid().ToString("N").ToUpper(),
                        HoldType = holdType,
                        LockCategory = lockCategory,
                        Source = source,
                        ReferenceDate = DateTime.Now.ToString("yyyy-MM-ddThh:mm:ss"),
                        EffectiveDate = DateTime.Now.ToString("yyyy-MM-ddThh:mm:ss"),
                        Description = "None",
                        Status = "1",
                        AgentName = "Antonio",
                        AgentCode = "1"
                    };

                    RestClient client = new RestClient(baseUrl);

                    RestRequest request = new RestRequest
                    {
                        Resource = resource,
                        Method = Method.POST,
                        DateFormat = dateFormat,
                        RequestFormat = DataFormat.Json,
                    };
                    string json = JsonConvert.SerializeObject(vehicleHolds);
                    request.AddObject(vehicleHolds);

                    IRestResponse<ApiResponse<string>> response = client.Execute<ApiResponse<string>>(request);

                    List<string> vehicleHoldsResult = sectionVehicleHolds["VehicleHoldsResult"].Split('-').ToList<string>();

                    if (vehicleHoldsResult.Contains(response.Data.StatusCode, StringComparer.OrdinalIgnoreCase))
                    {
                        output.Result = (int)FlagStatusCode.Success;
                    }
                    else
                    {
                        Log.Error(response.Data.StatusMessage);
                        output.Result = (int)FlagStatusCode.Failure;
                        output.Message = response.Data.StatusMessage;
                        return output;
                    }
                }

                if (appConfigCommit.Any(c => c.SectionId == vrHoldsUpdate))
                {
                    NameValueCollection sectionVehicleHolds = ConfigurationManager.GetSection("vehicleHolds") as NameValueCollection;

                    string baseUrl = sectionVehicleHolds["BaseUrl"];
                    string resource = sectionVehicleHolds["ResourceUpdate"];
                    string dateFormat = sectionVehicleHolds["DateFormat"];
                    string holdType = sectionVehicleHolds["HoldType"]; ;
                    string lockCategory = sectionVehicleHolds["LockCategory"];
                    string source = sectionVehicleHolds["Source"];

                    VehicleHolds vehicleHolds = new VehicleHolds
                    {
                        CarUniqueNumber = carDetails.CarUniqueNumber.ToString(),
                        CarPlateNumber = carDetails.PlateNumber,
                        CarPlateCode = carDetails.PlateCodeId.ToString(),
                        ReferenceNumber = Guid.NewGuid().ToString("N").ToUpper(),
                        HoldType = holdType,
                        LockCategory = lockCategory,
                        Source = source,
                        ReferenceDate = DateTime.Now.ToString("yyyy-MM-ddThh:mm:ss"),
                        EffectiveDate = DateTime.Now.ToString("yyyy-MM-ddThh:mm:ss"),
                        Description = "None",
                        Status = "1",
                        AgentName = "Antonio",
                        AgentCode = "1"
                    };

                    RestClient client = new RestClient(baseUrl);

                    RestRequest request = new RestRequest
                    {
                        Resource = resource,
                        Method = Method.POST,
                        DateFormat = dateFormat,
                        RequestFormat = DataFormat.Json,
                    };
                    string json = JsonConvert.SerializeObject(vehicleHolds);
                    request.AddObject(vehicleHolds);

                    IRestResponse<ApiResponse<string>> response = client.Execute<ApiResponse<string>>(request);

                    List<string> vehicleHoldsResult = sectionVehicleHolds["VehicleHoldsResult"].Split('-').ToList<string>();

                    if (vehicleHoldsResult.Contains(response.Data.StatusCode, StringComparer.OrdinalIgnoreCase))
                    {
                        output.Result = (int)FlagStatusCode.Success;
                    }
                    else
                    {
                        Log.Error(response.Data.StatusMessage);
                        output.Result = (int)FlagStatusCode.Failure;
                        output.Message = response.Data.StatusMessage;
                        return output;
                    }
                }

                output.Result = biz.CommitApplication(applicationId, string.Join(",", businessProcesses.BPList));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = (int)FlagStatusCode.Failure;
                output.Success = false;
                output.Message = "Failed to Commit Application";
            }
            return output;
        }

        public ObjectResult<Application> GetApplication(int applicationId)
        {
            ApplicationBLO biz = new ApplicationBLO();
            ObjectResult<Application> output = new ObjectResult<Application>();

            try
            {
                if (!biz.ApplicationExist(applicationId))
                {
                    output.Message = string.Format("Application Id {0} Not Found", applicationId);
                    return output;
                }

                output.Result = biz.GetApplication(applicationId);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to Get Application Filter";
            }
            return output;
        }

        public ObjectResult<List<Application>> ApplicationFilter(int statusId, string userId = null)
        {
            ApplicationBLO biz = new ApplicationBLO();
            ObjectResult<List<Application>> output = new ObjectResult<List<Application>>();

            try
            {
                output.Result = biz.ApplicationFilter(statusId, userId);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to Get Application Filter";
            }
            return output;
        }

        public ObjectResult<bool> DeleteApplication(int applicationId)
        {
            ObjectResult<bool> output = new ObjectResult<bool>();
            ApplicationBLO biz = new ApplicationBLO();

            try
            {
                if (!biz.ApplicationExist(applicationId))
                {
                    output.Message = string.Format("Application Id {0} Not Found", applicationId);
                    return output;
                }
                output.Result = biz.DeleteApplication(applicationId);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = false;
                output.Success = false;
                output.Message = "Unable to delete application Id:" + applicationId;
            }
            return output;
        }
    }
}