using Inkript.Logging;
using Inkript.VR.Business.Helpers;
using Inkript.VR.Models;
using NHibernate;
using NHibernate.Linq;
using NHibernate.Transform;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Inkript.VR.Business.DataAccessLayer
{
    public class InvoiceNumberDAO : GenericDAO<InvoiceNumber>
    {
        public string GenerateInvoiceNumber(int branchId, int feeCategoryId)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                try
                {
                    return session.GetNamedQuery("GenerateInvoiceNumber")
                        .SetParameter("BranchId", branchId)
                        .SetParameter("FeeCategoryId", feeCategoryId)                        
                        .UniqueResult<String>();
                }
                catch (Exception ex)
                {
                    session.Clear();
                    Log.ErrorFormat("Cannot Generate Invoice Number", ex);
                    throw new DALException("Cannot GenerateInvoiceNumber", ex);
                }
        }
    }
}