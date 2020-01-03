using Inkript.Logging;
using Inkript.VR.API.Helpers;
using Inkript.VR.API.Models;
using Inkript.VR.Business;
using Inkript.VR.Business.BusinessLayer;
using Inkript.VR.Models;
using InkriptRest;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;

namespace Inkript.VR.API
{
    public class PaymentSubmitApiBLO
    {
        public ObjectResult<bool> PaymentSubmit(List<SubmitOrder> paymentOrder)
        {
            ObjectResult<bool> output = new ObjectResult<bool>();

            try
            {
                NameValueCollection section = ConfigurationManager.GetSection("paymentOrder") as NameValueCollection;
                string baseUrl = section["BaseUrl"];
                string resource = section["Resource"];
                string dateFormat = section["DateFormat"];
                string paymentResult = section["PaymentResult"];

                RestClient client = new RestClient(baseUrl);

                var request = new RestRequest
                {
                    Resource = resource,
                    Method = Method.POST,
                    DateFormat = dateFormat,
                    RequestFormat = DataFormat.Json,
                };

                request.AddBody(paymentOrder);

                IRestResponse<ApiResponse<string>> response = client.Execute<ApiResponse<string>>(request);

                if (response.Data.Flag == paymentResult)
                {
                    output.Result = true;
                }
                else
                {
                    Exception ee = new Exception(string.Format("Fail to request: {0}", request.Parameters[0]));
                    Log.Error(ee);
                    output.Result = false;
                    output.Message = response.Data.Message;
                }

                return output;
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = false;
                output.Message = "Failed to PaymentSubmit";
                return output;
            }
        }

        public ObjectResult<SubmitOrder> CreateGeneralSubmit(Application application)
        {
            ObjectResult<SubmitOrder> output = new ObjectResult<SubmitOrder>();
            GovernateBLO governateBiz = new GovernateBLO();
            RegionsBLO regionsBiz = new RegionsBLO();
            DistrictsBLO districtsBiz = new DistrictsBLO();
            CitiesBLO citiesBiz = new CitiesBLO();
            PlateCodesBLO plateCodesBiz = new PlateCodesBLO();
            PlateRangesBLO plateRangesBiz = new PlateRangesBLO();

            SubmitOrder submitOrder = new SubmitOrder();
            submitOrder.OrderNumber = 0;
            submitOrder.Fees = new List<SubmitOrderFee>();
            submitOrder.ApplicationId = application.ApplicationId.ToString();
            submitOrder.OrderExpiryDate =
                (DateTime.Now.AddDays(Int32.Parse(ConfigurationManager.AppSettings["SpecificDaysExpiry"])));

            if (JsonHelper.JsonIsNull(application.CarDetails))
            {
                output.Message = string.Format("Vehicle Details for Application Id {0} Not Found", application.ApplicationId);
                return output;
            }

            bool isDiesel = false;
            VehicleDetails carDetails;
            try
            {
                carDetails = JsonConvert.DeserializeObject<VehicleDetailsApplication>(application.CarDetails).NewVehicleDetails;
                if (carDetails.FuelTypeId.HasValue)
                {
                    isDiesel = (int)carDetails.FuelTypeId == (int)FlagFuelType.Diesel ? true : false;
                }
                submitOrder.ProductionYear = carDetails.ProductionYear;
                submitOrder.NumberOfHorses = carDetails.HorsePower;
                submitOrder.NetWeight = carDetails.NetWeight;
                submitOrder.VehicleTypeCode = carDetails.VehicleTypeId;
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Message = ("CarDetails object in Application is not correct");
                return output;
            }

            if (JsonHelper.JsonIsNull(application.CarPlateInfo))
            {
                output.Message = string.Format("CarPlateInfo for Application Id {0} Not Found", application.ApplicationId);
                return output;
            }

            CarPlateInfo carPlateInfo;
            try
            {
                carPlateInfo = JsonConvert.DeserializeObject<CarPlateInfo>(application.CarPlateInfo);

                if (carPlateInfo.NumberGeneration == (int)FlagNumberGeneration.Automatic)
                {
                    submitOrder.PlateNumber = plateRangesBiz.GenerateRandomNumber(
                    application.BranchId, carDetails.SectorId.Value, carDetails.VehicleTypeId.Value).RandomNumber;
                }
                else
                {
                    submitOrder.PlateNumber = carPlateInfo.NewVehiclePlate.PlateNumber;
                }

                submitOrder.PlateCode = plateCodesBiz.GetById(carPlateInfo.NewVehiclePlate.PlateCodeId).CodeDescEn;
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Message = ("CarPlateInfo object in Application is not correct");
                return output;
            }

            if (JsonHelper.JsonIsNull(application.Documents))
            {
                output.Message = string.Format("Documents for Application Id {0} Not Found", application.ApplicationId);
                return output;
            }

            try
            {
                DocumentsApplication documents =
                JsonConvert.DeserializeObject<DocumentsApplication>(application.Documents,
                new IsoDateTimeConverter { DateTimeFormat = Configuration.ConfigurationManager.Get<string>("DateFormat") });

                if (documents.Insurance == null)
                {
                    output.Message = string.Format("Insurances Documents for Application Id {0} Not Found", application.ApplicationId);
                    return output;
                }

                InsuranceApplication insurance = documents.Insurance[0];

                submitOrder.InsuranceCompanyCode = insurance.InsuranceCompanyCode;
                submitOrder.InsuranceNumber = insurance.InsuranceNumber;
                submitOrder.InsuranceVignette = insurance.InsuranceVignette;
                submitOrder.InsuranceDate = insurance.InsuranceDate;
                submitOrder.InsuranceExpiryDate = insurance.InsuranceExpiryDate;
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Message = ("Document object in Application is not correct");
                return output;
            }

            string ownerFloor = null;
            string ownerDistrict = null;
            string ownerTelephoneOne = null;
            string ownerTelephoneTwo = null;
            string ownerRegion = string.Empty;
            string counterParty = string.Empty;
            string ownerTown = string.Empty;
            string ownerArea = string.Empty;

            if (JsonHelper.JsonIsNull(application.OwnersInfo))
            {
                output.Message = string.Format("OwnersInfo for Application Id {0} Not Found", application.ApplicationId);
                return output;
            }

            try
            {
                if (application.OwnerType == (int)FlagOwnerTypes.Persons)
                {
                    Person owner = JsonConvert.DeserializeObject<List<Person>>(application.OwnersInfo)[0];
                    counterParty = owner.FirstName + " " + owner.LastName;

                    Cities city = citiesBiz.GetByCityId(owner.CityId);
                    Governate governate = governateBiz.GetByGovernateId(city.Districts.GovernateId);

                    ownerDistrict = city.Districts.DistrictNameAr;
                    ownerFloor = owner.Floor.ToString();
                    ownerTelephoneOne = owner.NumberOfRegistry;
                    ownerTelephoneTwo = owner.Phone;
                    ownerRegion = governate.GovernateNameAR;
                    ownerTown = city.CityNameEn;
                    ownerArea = owner.Street;
                }
                else
                {
                    Organization ownersO = JsonConvert.DeserializeObject<List<Organization>>(application.OwnersInfo)[0];
                    counterParty = ownersO.OrganizationName;

                    Regions region = regionsBiz.GetByRegionId(ownersO.RegionId);
                    Governate governate = governateBiz.GetByGovernateId(region.Districts.GovernateId);
                    ownerRegion = governate.GovernateNameAR;
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Message = ("Owner object in Application is not correct");
                return output;
            }

            submitOrder.CounterParty = counterParty;
            submitOrder.Diesel = isDiesel;
            submitOrder.Region = ownerRegion;
            submitOrder.District = ownerDistrict;
            submitOrder.TownName = ownerTown;
            submitOrder.AreaName = ownerArea;
            submitOrder.FloorNumber = ownerFloor;
            submitOrder.TelephoneOne = ownerTelephoneOne;
            submitOrder.TelephoneTwo = ownerTelephoneTwo;
            submitOrder.RFID_TID = null;
            submitOrder.ForRent = null;

            output.Result = submitOrder;

            return output;
        }

        public ObjectResult<SubmitOrder> CompleteSubmitOrder(SubmitOrder submitOrder, List<Fees> fees, InvoiceNumberApplication invoiceObject)
        {
            ObjectResult<SubmitOrder> output = new ObjectResult<SubmitOrder>();
            submitOrder.OrderNumber = Int64.Parse(invoiceObject.InvoiceNumber.Replace("-", string.Empty));

            if (fees == null)
            {
                output.Message = string.Format("Fee Category Fees for Application Id {0} Not Found", submitOrder.ApplicationId);
                return output;
            }
            submitOrder.Fees = new List<SubmitOrderFee>();

            foreach (Fees fee in fees)
            {
                submitOrder.Fees.Add(new SubmitOrderFee()
                {
                    FeeCode = fee.FeeCode,
                    FeeAmount = fee.FeeTotal ?? 0
                });
            }

            output.Result = submitOrder;

            return output;
        }
    }
}
