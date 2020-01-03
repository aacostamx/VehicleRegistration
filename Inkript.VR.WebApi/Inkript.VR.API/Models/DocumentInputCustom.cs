using System;
using System.Text;
using System.Collections.Generic;


namespace Inkript.VR.API.Models {
    
    public class DocumentInputCustom {
        public DocumentInputCustom() { }
        public int DocumentInputId { get; set; }
        public int DocumentId { get; set; }
        public string InputType { get; set; }
        public string InputNameEn { get; set; }
        public string InputNameAr { get; set; }
        public string InputRequired { get; set; }
    }
}
