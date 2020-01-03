using Inkript.Logging;
using Inkript.VR.API.Models;
using Inkript.VR.Models;
using System;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Inkript.VR.API.Controllers
{
    [Route("api/servermessages")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ServerMessagesController : ApiController
    {
        #region Methods
        [HttpGet]
        [Route("getallservermessagespaged/{pageNumber}/{pageSize}")]
        public IHttpActionResult GetAllServerMessagesPaged(int pageNumber, int pageSize)
        {
            ServerMessagesApiBLO apiBiz = new ServerMessagesApiBLO();

            try
            {
                return Ok(apiBiz.GetAllServerMessagesPaged(pageNumber, pageSize));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }

        [Route("getallservermessages")]
        public IHttpActionResult GetAllServerMessages()
        {
            ServerMessagesApiBLO apiBiz = new ServerMessagesApiBLO();

            try
            {
                return Ok(apiBiz.GetAllServerMessages());
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("getservermessagesbycode/{code}")]
        public IHttpActionResult GetByMesssgeCode(string code)
        {
            ServerMessagesApiBLO apiBiz = new ServerMessagesApiBLO();

            try
            {
                return Ok(apiBiz.GetByMesssgeCode(code));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpDelete]
        [Route("deleteservermessage/{serverMessageId}")]
        public IHttpActionResult DeleteMessage(int serverMessageId)
        {
            ServerMessagesApiBLO apiBiz = new ServerMessagesApiBLO();

            try
            {
                return Ok(apiBiz.DeleteMessage(serverMessageId));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        [Route("createservermessage")]
        public IHttpActionResult CreateServerMessage([FromBody] ServerMessagesCustom serverMessage)
        {
            ServerMessagesApiBLO apiBiz = new ServerMessagesApiBLO();
            ObjectResult<ServerMessages> output = new ObjectResult<ServerMessages>();

            try
            {
                if (!ModelState.IsValid)
                {
                    output.Message = "INVALID_CONTENT: A Required Field Or Parameter For The Resource Has Not Been Set";
                    return Content((HttpStatusCode)422, output);
                }
                return Content(HttpStatusCode.Created, apiBiz.CreateServerMessage(serverMessage));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpPut]
        [Route("updateservermessage/{serverMessageId}")]
        public IHttpActionResult UpdateServerMessage(int serverMessageId, [FromBody] ServerMessagesCustom serverMessage)
        {
            ServerMessagesApiBLO apiBiz = new ServerMessagesApiBLO();
            ObjectResult<ServerMessages> output = new ObjectResult<ServerMessages>();

            try
            {
                if (!ModelState.IsValid)
                {
                    output.Message = "INVALID_CONTENT: A Required Field Or Parameter For The Resource Has Not Been Set";
                    return Content((HttpStatusCode)422, output);
                }
                return Ok(apiBiz.UpdateServerMessage(serverMessageId, serverMessage));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }
        #endregion
    }
}
