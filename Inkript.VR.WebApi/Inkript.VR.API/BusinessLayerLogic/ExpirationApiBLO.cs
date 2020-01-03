using Inkript.Logging;
using Inkript.VR.API.Models;
using System;
using System.Configuration;

namespace Inkript.VR.API
{
    public class ExpirationApiBLO
    {
        public ObjectResult<bool> DateExpired(DateTime date, string verificationMethod)
        {
            ObjectResult<bool> output = new ObjectResult<bool>();

            try
            {            
                DateTime currentDate = DateTime.Now;

                switch (verificationMethod)
                {
                    case "EndOfMonthExpiry":
                        {
                            int monthsToExpiry = Int32.Parse(ConfigurationManager.AppSettings[verificationMethod]);
                            date = date.AddMonths(monthsToExpiry - 1);
                            int lastDay = DateTime.DaysInMonth(date.Year, date.Month);
                            DateTime lastDayOfMonth = new DateTime(date.Year,date.Month,lastDay);
                            if (lastDayOfMonth < currentDate)
                            {
                                output.Result = true;
                            }
                            break;
                        }
                    case "SpecificDaysExpiry":
                        {
                            int daysToExpiry = Int32.Parse(ConfigurationManager.AppSettings[verificationMethod]);
                            if (currentDate > date.AddDays(daysToExpiry))
                            {
                                output.Result = true;
                            }
                            break;
                        }
                    default:
                        {
                            output.Message = string.Format("Verification Method '{0}' Not Found", verificationMethod);
                            break;
                        }
                }

                return output;

            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = false;
                output.Success = false;
                output.Message = "Failed to Get If Date Has Expired";
            }
            return output;
        }

        private bool verificationMethodExist(string verificationMethod)
        {
            if (string.IsNullOrEmpty(ConfigurationManager.AppSettings[verificationMethod]))
            {
                return false;
            }
            return true;
        }
    }
}