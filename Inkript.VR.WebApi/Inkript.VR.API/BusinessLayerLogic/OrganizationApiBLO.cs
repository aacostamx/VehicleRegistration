using Inkript.Logging;
using Inkript.VR.API.Models;
using Inkript.VR.Business.BusinessLayer;
using Inkript.VR.Models;
using System;
using System.Collections.Generic;

namespace Inkript.VR.API
{
    public class OrganizationApiBLO
    {
        public ObjectResult<List<Organization>> GetAllOrganizations()
        {
            OrganizationBLO biz = new OrganizationBLO();
            ObjectResult<List<Organization>> output = new ObjectResult<List<Organization>>();

            try
            {
                output.Result = biz.GetAllOrganizations();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to Get All Organizations";
            }
            return output;
        }

        public ObjectResult<List<Organization>> FilterOrganizationsByRegisterNumberRegion(string registrationNumber, int? regionId)
        {
            OrganizationBLO biz = new OrganizationBLO();
            ObjectResult<List<Organization>> output = new ObjectResult<List<Organization>>();

            try
            {
                output.Result = biz.FilterOrganizationsByRegisterNumberRegion(registrationNumber, regionId);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to Filter Organizations By Register Number {0} and Region {1}";
            }
            return output;
        }

        public ObjectResult<Organization> CreateOrganization(OrganizationCustom organization)
        {
            OrganizationBLO biz = new OrganizationBLO();
            ObjectResult<Organization> output = new ObjectResult<Organization>();

            try
            {
                if (biz.OrganizationNameExist(organization.OrganizationName))
                {
                    output.Message = string.Format("The Organization Name: '{0}' Already Exist", organization.OrganizationName);
                    return output;
                }
                biz.CreateOrganization(InkriptMapper.Mapper.Map<Organization>(organization));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to Create Organization";
            }
            return output;
        }

        public ObjectResult<List<Organization>> GetOrganizationsByCategory(int companycategoryId)
        {
            OrganizationBLO biz = new OrganizationBLO();
            CompanyCategoryBLO companyCategoryBiz = new CompanyCategoryBLO();
            ObjectResult<List<Organization>> output = new ObjectResult<List<Organization>>();

            try
            {
                if (!companyCategoryBiz.CompanyCategoryExist(companycategoryId))
                {
                    output.Message = string.Format("Company Category Id {0} Not Found", companycategoryId);
                    return output;
                }
                output.Result = biz.GetOrganizationsByCategory(companycategoryId);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Cannot get Organizations by Company Category Id" + companycategoryId;
            }
            return output;
        }

        public ObjectResult<Organization> UpdateOrganization(int organizationId, OrganizationCustom organization)
        {
            OrganizationBLO biz = new OrganizationBLO();
            ObjectResult<Organization> output = new ObjectResult<Organization>();

            try
            {
                if (!biz.OrganizationExist(organizationId))
                {
                    output.Message = string.Format("Organization Id {0} Not Found", organizationId);
                    return output;
                }                

                Organization entity = InkriptMapper.Mapper.Map<Organization>(organization);
                entity.OrganizationId = organizationId;
                biz.UpdateOrganization(entity);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to Update Orgnanization Id " + organizationId;
            }
            return output;
        }

        public ObjectResult<bool> DeleteOrganization(int organizationId)
        {
            OrganizationBLO biz = new OrganizationBLO();
            ObjectResult<bool> output = new ObjectResult<bool>();

            try
            {
                if (!biz.OrganizationExist(organizationId))
                {
                    output.Message = string.Format("Organization Id {0} Not Found", organizationId);
                    return output;
                }
                output.Result = biz.DeleteOrganization(organizationId);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = false;
                output.Success = false;
                output.Message = "Failed to Delete Organization Id " + organizationId;
            }
            return output;
        }

        public ObjectResult<List<Organization>> GetOrganization(string search)
        {
            OrganizationBLO biz = new OrganizationBLO();
            ObjectResult<List<Organization>> output = new ObjectResult<List<Organization>>();

            try
            {
                output.Result = biz.GetOrganization(search);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to Get Orgnanization";
            }
            return output;
        }

        public ObjectResult<List<Organization>> OrganizationFilter(string search)
        {
            OrganizationBLO biz = new OrganizationBLO();
            ObjectResult<List<Organization>> output = new ObjectResult<List<Organization>>();

            try
            {
                output.Result = biz.OrganizationFilter(search);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Cannot get organizations by filter " + search;
            }
            return output;
        }
    }
}