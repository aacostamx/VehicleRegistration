using Inkript.VR.Business.DataAccessLayer;
using Inkript.VR.Models;
using System.Collections.Generic;
using System.Linq;

namespace Inkript.VR.Business.BusinessLayer
{
    public class PersonBLO
    {
        private PersonDAO _da { get; set; }

        public PersonBLO()
        {
            _da = new PersonDAO();
        }

        public List<Person> GetPersonByIds(int id)
        {
            return _da.GetPersonByIds(id);
        }

        public List<Person> PersonFilter(string search)
        {
            return _da.PersonFilter(search).ToList();
        }

        public void CreatePerson(Person person)
        {
            _da.SaveOrUpdate(person, string.Empty);
        }

        public void UpdatePerson(Person person)
        {
            _da.SaveOrUpdate(person, string.Empty);
        }

        public bool DrivingLicenseExist(int drivingLicenseId)
        {
            return _da.DrivingLicenseExist(drivingLicenseId);
        }

        public bool NationalityExist(int nationalId)
        {
            return _da.NationalityExist(nationalId);
        }

        public bool PersonExist(int personId)
        {
            return _da.Exist(personId);
        }

        public GenericPagedList<Person> GetAllPersonPaged(int pageNumber, int pageSize)
        {
            return _da.GetAllPaged(pageNumber, pageSize);
        }

        public Person GetPersonByDrivingLicense(int drivingLicenceId)
        {
            return _da.GetPersonByDrivingLicense(drivingLicenceId);
        }

        public Person GetPersonByNationality(int nationalId)
        {
            return _da.GetPersonByNationality(nationalId);
        }

        public Person GetPersonById(int personId)
        {
            return _da.GetById(personId);
        }
    }
}
