using System;
using System.Linq;
using Inkript.VR.Models;
using System.Collections.Generic;
using Inkript.VR.Business.DataAccessLayer;

namespace Inkript.VR.Business.BusinessLayer
{
    public class BranchesBLO
    {
        #region Variables
        private BranchesDAO _da { get; set; }
        #endregion

        #region Methods
        public BranchesBLO()
        {
            _da = new BranchesDAO();
        }

        public void CreateBranch(Branches entity)
        {
            _da.SaveOrUpdate(entity, string.Empty);
        }

        public List<Branches> GetAllBranches()
        {
            return _da.GetAll().ToList();
        }

        public bool BranchExist(int id)
        {
            return _da.Exist(id);
        }

        public Branches GetBranch(int id)
        {
            return _da.GetById(id);
        }

        public bool BranchNameEnExist(string branchNameEn)
        {
            return _da.RecordExist(nameof(Branches), nameof(Branches.BranchNameEn), branchNameEn);

        }

        public bool BranchNameArExist(string branchNameAr)
        {
            return _da.RecordExist(nameof(Branches), nameof(Branches.BranchNameAr), branchNameAr);
        }

        public void UpdateBranch(Branches entity)
        {
            _da.SaveOrUpdate(entity, string.Empty);
        }

        public bool DeleteBranches(int id)
        {
            return _da.Delete(GetBranch(id));
        }
        #endregion
    }
}
