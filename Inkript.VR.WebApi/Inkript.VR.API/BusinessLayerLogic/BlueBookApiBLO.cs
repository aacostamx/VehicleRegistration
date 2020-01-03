using Inkript.Logging;
using Inkript.VR.API.Models;
using Inkript.VR.Business.BusinessLayer;
using Inkript.VR.Models;
using System;

namespace Inkript.VR.API
{
    public class BlueBookApiBLO
    {

        public ObjectResult<BlueBook> GetBlueBookValue()
        {
            BlueBookBLO biz = new BlueBookBLO();
            ObjectResult<BlueBook> output = new ObjectResult<BlueBook>();

            try
            {
                output.Result = biz.GetBlueBookValue();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to Get Blue Book Value";
            }
            return output;
        }

        public static BlueBook GetBlueBookValueLogic()
        {
            BlueBook book = new BlueBook();
            Random random = new Random();
            book.Value = random.Next(500000, 100000000);
            book.MarginRate = Math.Round(random.NextDouble() * (0.99 - 0.01), 2);
            return book;
        }

        private double NextDouble(Random rnd, double min, double max)
        {
            return rnd.NextDouble() * (max - min) + min;
        }
    }
}