using Inkript.VR.Business.DataAccessLayer;
using Inkript.VR.Models;
using System.Collections.Generic;
using System.Linq;

namespace Inkript.VR.Business.BusinessLayer
{
    public class ServerMessagesBLO
    {
        #region Variables
        private ServerMessagesDAO _da { get; set; }
        #endregion

        public ServerMessagesBLO()
        {
            _da = new ServerMessagesDAO();
        }

        public List<ServerMessages> GetAllServerMessages()
        {
            return _da.GetAll().ToList();
        }

        public bool MessageCodeExist(string code)
        {
            return _da.MessageCodeExist(code);
        }

        public GenericPagedList<ServerMessages> GetAllServerMessagesPaged(int pageNumber, int pageSize)
        {
            return _da.GetAllPaged(pageNumber, pageSize);
        }

        public ServerMessages GetByCode(string code)
        {
            return _da.GetByCode(code);
        }

        public bool MessageIdExist(int serverMessageId)
        {
            return _da.MessageIdExist(serverMessageId);
        }

        public bool DeleteServerMessage(int serverMessageId)
        {
            return _da.Delete(GetByServerMessageId(serverMessageId));
        }

        public void CreateOrUpdateServerMessage(ServerMessages serverMessages)
        {
            _da.CreateOrUpdateServerMessage(serverMessages);
        }

        public void CreateServerMessage(ServerMessages serverMessages)
        {
            _da.CreateServerMessage(serverMessages);
        }

        public ServerMessages GetByServerMessageId(int serverMessageId)
        {
            return _da.GetById(serverMessageId);
        }

        public void UpdateServerMessage(ServerMessages entity)
        {
            _da.SaveOrUpdate(entity, string.Empty);
        }
    }
}
