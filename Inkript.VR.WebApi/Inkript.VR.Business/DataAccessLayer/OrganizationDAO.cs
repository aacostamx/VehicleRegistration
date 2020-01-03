using System;
using System.Collections.Generic;
using System.Linq;
using Inkript.Logging;
using Inkript.VR.Business.Helpers;
using Inkript.VR.Models;
using NHibernate;
using NHibernate.Linq;
using NHibernate.Transform;

namespace Inkript.VR.Business.DataAccessLayer
{
    public class OrganizationDAO : GenericDAO<Organization>
    {
        public List<Organization> FilterOrganizationsByRegisterNumberRegion(string registrationNumber, int? regionId)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                try
                {
                    if (regionId.HasValue)
                    {
                        return session.Query<Organization>()
                            .Where(c => c.RegistrationNumber == registrationNumber && c.RegionId == regionId)
                            .ToList();
                    }
                    else
                    {
                        return session.Query<Organization>()
                            .Where(c => c.RegistrationNumber == registrationNumber)
                            .ToList();
                    }
                }
                catch (Exception ex)
                {
                    session.Clear();
                    Log.ErrorFormat("Cannot Filter Organizations By Register Number Region {0}", registrationNumber, ex);
                    throw new DALException("Cannot FilterOrganizationsByRegisterNumberRegion", ex);
                }
        }

        public bool NameExist(string Name)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                try
                {
                    return session.Query<Organization>().Any(c => c.OrganizationName == Name);
                }
                catch (Exception ex)
                {
                    session.Clear();
                    Log.ErrorFormat("Cannot verify if {0} name exist", Name, ex);
                    throw new DALException("Cannot verify NameExist", ex);
                }
        }

        public List<Organization> GetOrganization(string search)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                try
                {
                    return session.Query<Organization>()
                        .Where(c => c.MOFNumber == search || c.RegistrationNumber == search)
                        .ToList();
                }
                catch (Exception ex)
                {
                    session.Clear();
                    Log.ErrorFormat("Cannot get organization", ex);
                    throw new DALException("Cannot GetOrganization", ex);
                }
        }

        public List<Organization> GetOrganizationsByCategory(int companycategoryId)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                try
                {
                    return session.Query<Organization>()
                        .Where(c => c.CompanyCategoryId == companycategoryId)
                        .ToList();
                }
                catch (Exception ex)
                {
                    session.Clear();
                    Log.ErrorFormat("Cannot Get Organization by Company Category {0}", companycategoryId, ex);
                    throw new DALException("Cannot GetOrganizationsByCategory", ex);
                }
        }

        public IList<Organization> OrganizationFilter(string search)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                try
                {
                    return session.GetNamedQuery("OrganizationFilter")
                        .SetString("search", search)
                        .List<Organization>();
                }
                catch (Exception ex)
                {
                    session.Clear();
                    Log.ErrorFormat("Cannot Get Organization by Filter {0}", search, ex);
                    throw new DALException("Cannot OrganizationFilter", ex);
                }
        }
    }
}
