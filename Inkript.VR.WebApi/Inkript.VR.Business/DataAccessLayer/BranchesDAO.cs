using System;
using System.Collections.Generic;
using System.Linq;
using Inkript.Logging;
using Inkript.VR.Business.Helpers;
using Inkript.VR.Models;
using NHibernate;
using NHibernate.Linq;

namespace Inkript.VR.Business.DataAccessLayer
{
    public class BranchesDAO : GenericDAO<Branches>
    {
        public bool BranchNameEnExist(string branchNameEn)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                try
                {
                    return session.Query<Branches>().Any(c => (c.BranchNameEn == branchNameEn));
                }
                catch (Exception ex)
                {
                    session.Clear();
                    Log.ErrorFormat("Cannot check Branch Name English Exist {0}", branchNameEn, ex);
                    throw new DALException("Cannot BranchNameEnExist", ex);
                }
        }

    }
}