using Inkript.VR.Business.DataAccessLayer;
using Inkript.VR.Models;
using System.Collections.Generic;
using System.Linq;

namespace Inkript.VR.Business.BusinessLayer
{
    public class InvoiceNumberBLO
    {
        private InvoiceNumberDAO _da { get; set; }

        public InvoiceNumberBLO()
        {
            _da = new InvoiceNumberDAO();
        }

        public string GenerateInvoiceNumber(int branchId, int feeCategoryId)
        {
            return _da.GenerateInvoiceNumber(branchId, feeCategoryId);
        }
    }
}
