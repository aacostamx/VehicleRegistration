using Inkript.Logging;
using Inkript.VR.API.Models;
using Inkript.VR.Models;
using System;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Inkript.VR.API.Controllers
{
    [Route("api/person")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PersonController : ApiController
    {

        [HttpGet]
        [Route("getallpersonpaged/{pageNumber}/{pageSize}")]
        public IHttpActionResult GetAllPersonPaged(int pageNumber, int pageSize)
        {
            PersonApiBLO apiBiz = new PersonApiBLO();

            try
            {
                return Ok(apiBiz.GetAllPersonPaged(pageNumber, pageSize));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("getpersonbyids/{id}")]
        public IHttpActionResult GetPersonByIds(int id)
        {
            PersonApiBLO apiBiz = new PersonApiBLO();

            try
            {
                return Ok(apiBiz.GetPersonByIds(id));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("getpersonbydrivinglicense/{id}")]
        public IHttpActionResult GetPersonByDrivingLicense(int id)
        {
            PersonApiBLO apiBiz = new PersonApiBLO();

            try
            {
                return Ok(apiBiz.GetPersonByDrivingLicense(id));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("getpersonbynationality/{id}")]
        public IHttpActionResult GetPersonByNationality(int id)
        {
            PersonApiBLO apiBiz = new PersonApiBLO();

            try
            {
                return Ok(apiBiz.GetPersonByNationality(id));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("personfilter/{search}")]
        public IHttpActionResult PersonFilter(string search)
        {
            PersonApiBLO apiBiz = new PersonApiBLO();

            try
            {
                return Ok(apiBiz.PersonFilter(search));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        [Route("createperson")]
        public IHttpActionResult CreatePerson([FromBody] PersonCustom person)
        {
            PersonApiBLO apiBiz = new PersonApiBLO();
            ObjectResult<Person> output = new ObjectResult<Person>();

            try
            {
                if (!ModelState.IsValid)
                {
                    output.Message = "INVALID_CONTENT: A Required Field Or Parameter For The Resource Has Not Been Set";
                    return Content((HttpStatusCode)422, output);
                }
                return Content(HttpStatusCode.Created, apiBiz.CreatePerson(person));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpPut]
        [Route("updateperson/{personId}")]
        public IHttpActionResult UpdatePerson(int personId, [FromBody] PersonCustom person)
        {
            PersonApiBLO apiBiz = new PersonApiBLO();
            ObjectResult<Person> output = new ObjectResult<Person>();

            try
            {
                if (!ModelState.IsValid)
                {
                    output.Message = "INVALID_CONTENT: A Required Field Or Parameter For The Resource Has Not Been Set";
                    return Content((HttpStatusCode)422, output);
                }
                return Ok(apiBiz.UpdatePerson(personId, person));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }

        }
    }
}
