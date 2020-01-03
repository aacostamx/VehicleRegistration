using System;
using System.Collections.Generic;
using System.Linq;
using Inkript.VR.Business.DataAccessLayer;
using Inkript.VR.Models;

namespace Inkript.VR.Business.BusinessLayer
{
    public class OrganizationBLO
    {
        private OrganizationDAO _da { get; set; }

        public OrganizationBLO()
        {
            _da = new OrganizationDAO();
        }

        public List<Organization> GetAllOrganizations()
        {
            return _da.GetAll().ToList();
        }

        public List<Organization> FilterOrganizationsByRegisterNumberRegion(string registrationNumber, int? regionId)
        {
            return _da.FilterOrganizationsByRegisterNumberRegion(registrationNumber, regionId);
        }

        public void CreateOrganization(Organization organization)
        {
            _da.SaveOrUpdate(organization, string.Empty);
        }

        public void UpdateOrganization(Organization entity)
        {
            _da.SaveOrUpdate(entity, string.Empty);
        }

        public bool OrganizationExist(int organizationId)
        {
            return _da.Exist(organizationId);
        }

        public bool OrganizationNameExist(string name)
        {
            return _da.NameExist(name);
        }

        public Organization GetByOrganizationId(int organizationId)
        {
            return _da.GetById(organizationId);
        }

        public bool DeleteOrganization(int organizationId)
        {
            return _da.Delete(GetByOrganizationId(organizationId));
        }

        public List<Organization> OrganizationFilter(string search)
        {
            return _da.OrganizationFilter(search).ToList();
        }

        public List<Organization> GetOrganizationsByCategory(int companycategoryId)
        {
            return _da.GetOrganizationsByCategory(companycategoryId);
        }

        public List<Organization> GetOrganization(string search)
        {
            return _da.GetOrganization(search);
        }
    }
}
