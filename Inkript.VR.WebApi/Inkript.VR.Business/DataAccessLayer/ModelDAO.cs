using System;
using Inkript.VR.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using Inkript.VR.Business.Helpers;
using NHibernate.Linq;
using Inkript.Logging;

namespace Inkript.VR.Business.DataAccessLayer
{
    public class ModelDAO : GenericDAO<Model>
    {
        public bool ModelNameExist(string modelName)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                try
                {
                    return session.Query<Model>().Any(c => (c.ModelName == modelName));
                }
                catch (Exception ex)
                {
                    session.Clear();
                    Log.ErrorFormat("Cannot find model name {0}", modelName, ex);
                    throw new DALException("Cannot ModelNameExist", ex);
                }
        }
    }
}