using Newtonsoft.Json;

namespace Inkript.VR.API.Models
{
    public class BPSectorVehicleCustom
    {
        [JsonIgnore]
        public int BPSectorVehicleId { get; set; }
        [JsonIgnore]
        public int BPId { get; set; }
        public int SectorId { get; set; }
        public int VehicleTypeId { get; set; }
    }
}