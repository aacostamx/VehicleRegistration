using Inkript.Logging;
using Inkript.VR.API.Models;
using Inkript.VR.Business.BusinessLayer;
using Inkript.VR.Models;
using System;
using System.Collections.Generic;

namespace Inkript.VR.API
{
    public class PersonApiBLO
    {
        public ObjectResult<List<Person>> GetPersonByIds(int id)
        {
            PersonBLO biz = new PersonBLO();
            ObjectResult<List<Person>> output = new ObjectResult<List<Person>>();

            try
            {
                output.Result = biz.GetPersonByIds(id);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Cannot get person by id " + id;
            }
            return output;
        }

        public object GetAllPersonPaged(int pageNumber, int pageSize)
        {
            PersonBLO biz = new PersonBLO();
            ObjectResult<GenericPagedList<Person>> output = new ObjectResult<GenericPagedList<Person>>();

            try
            {
                output.Result = biz.GetAllPersonPaged(pageNumber, pageSize);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to Get All Person Paged";
            }
            return output;
        }

        public ObjectResult<List<Person>> PersonFilter(string search)
        {
            PersonBLO biz = new PersonBLO();
            ObjectResult<List<Person>> output = new ObjectResult<List<Person>>();

            try
            {
                output.Result = biz.PersonFilter(search);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Cannot get person by filter " + search;
            }
            return output;
        }

        public ObjectResult<Person> GetPersonByNationality(int id)
        {
            PersonBLO biz = new PersonBLO();
            ObjectResult<Person> output = new ObjectResult<Person>();

            try
            {
                if (!biz.NationalityExist(id))
                {
                    output.Message = string.Format("Nationality Id: '{0}' Not Found", id);
                    return output;
                }
                output.Result = biz.GetPersonByNationality(id);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to Get Person By Nationality " + id;
            }
            return output;
        }

        public ObjectResult<Person> GetPersonByDrivingLicense(int id)
        {
            PersonBLO biz = new PersonBLO();
            ObjectResult<Person> output = new ObjectResult<Person>();

            try
            {
                if (!biz.DrivingLicenseExist(id))
                {
                    output.Message = string.Format("Driving License Id: '{0}' Not Found", id);
                    return output;
                }
                output.Result = biz.GetPersonByDrivingLicense(id);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to Get Person By Driving License " + id;
            }
            return output;
        }

        public ObjectResult<Person> CreatePerson(PersonCustom person)
        {
            PersonBLO biz = new PersonBLO();
            ObjectResult<Person> output = new ObjectResult<Person>();

            try
            {
                if (biz.DrivingLicenseExist(person.DrivingLicenseId))
                {
                    output.Message = string.Format("Driving License Id: '{0}' Already Exists", person.DrivingLicenseId);
                    return output;
                }

                if (biz.NationalityExist(person.NationalId))
                {
                    output.Message = string.Format("National Id: '{0}' Already Exists", person.NationalId);
                    return output;
                }

                biz.CreatePerson(InkriptMapper.Mapper.Map<Person>(person));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to Create Person";
            }
            return output;
        }

        public ObjectResult<Person> UpdatePerson(int personId, PersonCustom person)
        {
            PersonBLO biz = new PersonBLO();
            ObjectResult<Person> output = new ObjectResult<Person>();

            try
            {
                if (!biz.PersonExist(personId))
                {
                    output.Message = string.Format("Person Id {0} Not Found", personId);
                    return output;
                }

                Person personDb = biz.GetPersonById(personId);

                if (personDb.DrivingLicenseId != person.DrivingLicenseId
                    && biz.DrivingLicenseExist(person.DrivingLicenseId))
                {
                    output.Message = string.Format("Driving License Id: '{0}' Already Exists", person.DrivingLicenseId);
                    return output;
                }

                if (personDb.NationalId != person.NationalId
                    && biz.NationalityExist(person.NationalId))
                {
                    output.Message = string.Format("National Id: '{0}' Already Exists", person.NationalId);
                    return output;
                }

                Person personEntity = InkriptMapper.Mapper.Map<Person>(person);
                personEntity.PersonId = personId;
                biz.UpdatePerson(personEntity);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to Update Person";
            }
            return output;
        }
    }
}