using System;
using System.Text;
using System.Collections.Generic;


namespace Inkript.VR.Models {
    
    public class Model {
        public virtual int ModelId { get; set; }
        public virtual int BrandId { get; set; }
        public virtual string ModelName { get; set; }
        public virtual Status Status { get; set; }
    }
}
