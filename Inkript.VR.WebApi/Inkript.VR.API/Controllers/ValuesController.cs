using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Inkript.VR.Business.BusinessLayer;
using Inkript.VR.Models.Models;

namespace Inkript.VR.API.Controllers
{
    
    public class ValuesController : ApiController
    {
        // GET api/values
        [Route("api/Values/Test")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        public User Get(int id)
        {
            return new UserBLO().GetById(id);
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}