using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inkript.VR.Models
{
    public class VehicleCategTypeSect
    {
        public virtual int Id { get; set; }
        public virtual int VehicleCategoryId { get; set; }
        public virtual int SectorId { get; set; }
        public virtual int VehicleTypeId { get; set; }
    }
}
