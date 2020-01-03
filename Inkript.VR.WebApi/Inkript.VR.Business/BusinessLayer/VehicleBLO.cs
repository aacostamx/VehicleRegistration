using Inkript.Logging;
using Inkript.VR.Business.DataAccessLayer;
using Inkript.VR.Models;
using System;

namespace Inkript.VR.Business.BusinessLayer
{
    public class VehicleBLO
    {
        #region Variables
        private VehicleDAO _da { get; set; }
        #endregion

        #region Methods
        public VehicleBLO()
        {
            _da = new VehicleDAO();
        }

        /// TODO Change logic into Stored Procedure and add blue book implementation
        public VehicleDetails GetVehicleValue(VehicleDetails vehicleInfo)
        {
            double percentage = 0.15;
            int currentYear = DateTime.Now.Year;
            BlueBookBLO blueBookBLO = new BlueBookBLO();
            ImportCustomsBLO importCustoms = new ImportCustomsBLO();

            try
            {
                switch (vehicleInfo.IsRegistered)
                {
                    case (int)FlagRegistered.New:
                        double taxes = vehicleInfo.Taxes ?? 0;
                        double totalValue = vehicleInfo.Value + taxes +
                                (percentage * (vehicleInfo.Value + taxes));

                        if (vehicleInfo.ProductionYear > currentYear - 3)
                        {
                            vehicleInfo.Value = RoundMillion(totalValue);
                            vehicleInfo.MarginRate = 0;
                        }
                        else
                        {
                            if (vehicleInfo.Discounted != 0)
                            {
                                vehicleInfo.Value = RoundMillion(totalValue);
                                vehicleInfo.MarginRate = 0;
                            }
                            else
                            {
                                BlueBook blueBook = blueBookBLO.GetBlueBookValue();
                                if (totalValue > blueBook.Value)
                                {
                                    vehicleInfo.Value = RoundMillion(totalValue);
                                    vehicleInfo.MarginRate = 0;
                                }
                                else
                                {
                                    vehicleInfo.Value = RoundMillion(blueBook.Value);
                                    vehicleInfo.MarginRate = blueBook.MarginRate;
                                }
                            }
                        }
                        break;

                    case (int)FlagRegistered.Register:
                        if (vehicleInfo.YearMake <= currentYear - 3)
                        {
                            BlueBook blueBook = blueBookBLO.GetBlueBookValue();
                            vehicleInfo.Value = RoundMillion(blueBook.Value);
                            vehicleInfo.MarginRate = blueBook.MarginRate;
                        }
                        else
                        {
                            CustomsInfo customsInfo = importCustoms.GetCustomsInfo(vehicleInfo.Chassis);
                            vehicleInfo.Value = customsInfo.Value + customsInfo.Taxes +
                                (percentage * (customsInfo.Value + customsInfo.Taxes));
                            vehicleInfo.Value = RoundMillion(vehicleInfo.Value);
                            vehicleInfo.MarginRate = 0;
                        }
                        break;

                    default:
                        throw new Exception("Registered Value Not Valid");
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw new Exception(ex.Message);
            }

            return vehicleInfo;
        }

        public VehicleSearch VehicleSearch(int? carUniqueNumber, string certificateId)
        {
            int can = carUniqueNumber ?? 0;
            string certificate = certificateId ?? "NULL";
            return _da.VehicleSearch(can, certificate);
        }

        private double RoundMillion(double value)
        {
            if (value > 1000000)
                value = Math.Round(value / 1000000) * 1000000;

            return value;
        }
        #endregion
    }
}