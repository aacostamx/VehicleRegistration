using Inkript.Logging;
using Inkript.VR.Models;
using System;
using System.Configuration.Assemblies;

namespace Inkript.VR.Business.BusinessLayer
{
    public class BlueBookBLO
    {
        public BlueBook GetBlueBookValue()
        {
            BlueBook book = new BlueBook();
            Random random = new Random();
            try
            {
                //book.Value = random.Next(500000, 100000000);
                //book.MarginRate = Math.Round(random.NextDouble() * (0.99 - 0.01), 2);

                book.Value = Configuration.ConfigurationManager.Get<int>("blueBookValue");
                book.MarginRate = Configuration.ConfigurationManager.Get<float>("MarginRate");

            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
            return book;
        }

        private double NextDouble(Random rnd, double min, double max)
        {
            return rnd.NextDouble() * (max - min) + min;
        }
    }
}
