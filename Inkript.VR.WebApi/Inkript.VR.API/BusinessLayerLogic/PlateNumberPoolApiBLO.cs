using Inkript.Logging;
using Inkript.VR.API.Models;
using Inkript.VR.Business;
using Inkript.VR.Business.BusinessLayer;
using Inkript.VR.Models;
using System;

namespace Inkript.VR.API
{
    public class PlateNumberPoolApiBLO
    {
        public ObjectResult<bool> ActivatePlateNumberPool(string plateNumber)
        {
            ObjectResult<bool> output = new ObjectResult<bool>();
            PlateNumberPoolBLO biz = new PlateNumberPoolBLO();

            try
            {
                if (!biz.PlateNumberPoolExist(plateNumber))
                {
                    output.Message = string.Format("Plate Number {0} Not Found", plateNumber);
                    return output;
                }
                output.Result = biz.ActivatePlateNumberPool(plateNumber);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = false;
                output.Success = false;
                output.Message = "Unable to Activate Plate Number:" + plateNumber;
            }
            return output;
        }

        public ObjectResult<PoolInfo> PlateNumberPoolInfo(int? plateRangeId, string rangeName)
        {
            PlateRangesBLO biz = new PlateRangesBLO();
            ObjectResult<PoolInfo> output = new ObjectResult<PoolInfo>();

            try
            {
                if (plateRangeId.HasValue && !biz.PlateRangeIdExist(plateRangeId.Value))
                {
                    output.Message = string.Format("Plate Range Id: '{0}' Not Exists", plateRangeId);
                    return output;
                }

                if (!string.IsNullOrEmpty(rangeName) && !biz.PlateRangeExist(rangeName))
                {
                    output.Message = string.Format("Plate Range Name: '{0}' Not Exists", rangeName);
                    return output;
                }

                output.Result = biz.PlateNumberPoolInfo(plateRangeId, rangeName);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to Get Pool Info";
            }
            return output;
        }
    }
}