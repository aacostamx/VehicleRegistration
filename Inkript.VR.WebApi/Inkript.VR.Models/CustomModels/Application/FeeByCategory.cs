using System.Collections.Generic;

namespace Inkript.VR.Models
{
    public class FeeByCategory
    {
        public string FeeCategoryName { get; set; }
        public int FeeCategoryId { get; set; }
        public List<Fees> Fees { get; set; }
    }
}
