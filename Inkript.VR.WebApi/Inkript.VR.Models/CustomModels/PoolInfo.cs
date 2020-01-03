using System.Collections.Generic;

namespace Inkript.VR.Models
{
    public class PoolInfo
    {
        public PoolInfo()
        {
            LimitsAllowed = new List<SectorWarningLimit>();
        }
        public int TotalPlates { get; set; }
        public int PlatesUsed { get; set; }
        public int PlatesAvailable { get; set; }
        public List<SectorWarningLimit> LimitsAllowed { get; set; }
    }
}