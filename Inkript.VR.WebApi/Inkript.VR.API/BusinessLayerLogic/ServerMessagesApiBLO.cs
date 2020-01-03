using Inkript.Logging;
using Inkript.VR.API.Models;
using Inkript.VR.Business.BusinessLayer;
using Inkript.VR.Models;
using System;
using System.Collections.Generic;

namespace Inkript.VR.API
{
    public class ServerMessagesApiBLO
    {

        public ObjectResult<GenericPagedList<ServerMessages>> GetAllServerMessagesPaged(int pageNumber, int pageSize)
        {
            ServerMessagesBLO biz = new ServerMessagesBLO();
            ObjectResult<GenericPagedList<ServerMessages>> output = new ObjectResult<GenericPagedList<ServerMessages>>();

            try
            {
                output.Result = biz.GetAllServerMessagesPaged(pageNumber, pageSize);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to Get All Server Messages Paged";
            }
            return output;
        }

        public ObjectResult<ServerMessages> GetByMesssgeCode(string code)
        {
            ServerMessagesBLO biz = new ServerMessagesBLO();
            ObjectResult<ServerMessages> output = new ObjectResult<ServerMessages>();

            try
            {
                if (!biz.MessageCodeExist(code))
                {
                    output.Message = string.Format("Code: {0} Not Found", code);
                    return output;
                }
                output.Result = biz.GetByCode(code);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to Get Server Message by Code";
            }
            return output;
        }

        public ObjectResult<List<ServerMessages>> GetAllServerMessages()
        {
            ServerMessagesBLO biz = new ServerMessagesBLO();
            ObjectResult<List<ServerMessages>> output = new ObjectResult<List<ServerMessages>>();

            try
            {
                output.Result = biz.GetAllServerMessages();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to Get All Server Messages";
            }
            return output;
        }

        public ObjectResult<bool> DeleteMessage(int serverMessageId)
        {
            ServerMessagesBLO biz = new ServerMessagesBLO();
            ObjectResult<bool> output = new ObjectResult<bool>();

            try
            {
                if (!biz.MessageIdExist(serverMessageId))
                {
                    output.Message = string.Format("Message Id: {0} Not Found", serverMessageId);
                    return output;
                }
                output.Result = biz.DeleteServerMessage(serverMessageId);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = false;
                output.Success = false;
                output.Message = "Failed to Delete Server Message " + serverMessageId;
            }
            return output;
        }

        public ObjectResult<ServerMessages> CreateServerMessage(ServerMessagesCustom serverMessage)
        {
            ServerMessagesBLO biz = new ServerMessagesBLO();
            ObjectResult<ServerMessages> output = new ObjectResult<ServerMessages>();

            try
            {
                if (biz.MessageCodeExist(serverMessage.Code))
                {
                    output.Message = string.Format("The Server Code: '{0}' Already Exists", serverMessage.Code);
                    return output;
                }
                biz.CreateServerMessage(InkriptMapper.Mapper.Map<ServerMessages>(serverMessage));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to Create Server Message";
            }
            return output;
        }

        public ObjectResult<ServerMessages> UpdateServerMessage(int serverMessageId, ServerMessagesCustom serverMessage)
        {
            ServerMessagesBLO biz = new ServerMessagesBLO();
            ObjectResult<ServerMessages> output = new ObjectResult<ServerMessages>();

            try
            {
                if (!biz.MessageIdExist(serverMessageId))
                {
                    output.Message = string.Format("Message Id: {0} Not Found", serverMessageId);
                    return output;
                }

                ServerMessages entity = InkriptMapper.Mapper.Map<ServerMessages>(serverMessage);
                entity.ServerMessagesId = serverMessageId;
                biz.UpdateServerMessage(entity);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to Create Server Message";
            }
            return output;
        }
    }
}