using Inkript.VR.Business.DataAccessLayer;
using Inkript.VR.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Inkript.VR.Business.BusinessLayer
{
    public class AppConfigCommitBLO
    {
        private AppConfigCommitDAO _da { get; set; }

        public AppConfigCommitBLO()
        {
            _da = new AppConfigCommitDAO();
        }

        public List<AppConfigCommit> GetAllAppConfigCommit()
        {
            return _da.GetAll().ToList();
        }

        public List<AppConfigCommit> GetAppConfigCommit(List<int> bpList)
        {
            return _da.GetAppConfigCommit(bpList).ToList();
        }
    }
}
