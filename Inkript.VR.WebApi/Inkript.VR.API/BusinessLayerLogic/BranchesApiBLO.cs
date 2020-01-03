using Inkript.Logging;
using Inkript.VR.API.Models;
using Inkript.VR.Business.BusinessLayer;
using Inkript.VR.Models;
using System;
using System.Collections.Generic;

namespace Inkript.VR.API
{
    public class BranchesApiBLO
    {
        public ObjectResult<Branches> CreateBranch(BranchesCustom viewModel)
        {
            BranchesBLO biz = new BranchesBLO();
            StatusBLO statusBiz = new StatusBLO();
            ObjectResult<Branches> output = new ObjectResult<Branches>();

            try
            {
                if (!statusBiz.StatusExist(viewModel.StatusId))
                {
                    output.Message = string.Format("Status Id {0} Not Found", viewModel.StatusId);
                    return output;
                }
                if (biz.BranchNameEnExist(viewModel.BranchNameEn))
                {
                    output.Message = string.Format("Branch Name {0} Already Exists", viewModel.BranchNameEn);
                    return output;
                }
                if (biz.BranchNameArExist(viewModel.BranchNameAr))
                {
                    output.Message = string.Format("Branch Name {0} Already Exists", viewModel.BranchNameAr);
                    return output;
                }
                biz.CreateBranch(InkriptMapper.Mapper.Map<Branches>(viewModel));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to Create Branch";
            }
            return output;
        }

        public ObjectResult<List<Branches>> GetAllBranches()
        {
            BranchesBLO biz = new BranchesBLO();
            ObjectResult<List<Branches>> output = new ObjectResult<List<Branches>>();

            try
            {
                output.Result = biz.GetAllBranches();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to Get All Branches";
            }
            return output;
        }

        public ObjectResult<Branches> GetBranch(int id)
        {
            BranchesBLO biz = new BranchesBLO();
            ObjectResult<Branches> output = new ObjectResult<Branches>();

            try
            {
                if (!biz.BranchExist(id))
                {
                    output.Message = string.Format("Branch Id {0} Not Found", id);
                    return output;
                }

                output.Result = biz.GetBranch(id);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to Get Branch by Id " + id;
            }
            return output;
        }

        public ObjectResult<Branches> UpdateBranch(int branchId, BranchesCustom viewModel)
        {
            BranchesBLO biz = new BranchesBLO();
            StatusBLO statusBiz = new StatusBLO();
            ObjectResult<Branches> output = new ObjectResult<Branches>();

            try
            {
                if (!biz.BranchExist(branchId))
                {
                    output.Message = string.Format("Branch Id {0} Not Found" + branchId);
                    return output;
                }
                if (!statusBiz.StatusExist(viewModel.StatusId))
                {
                    output.Message = string.Format("Status Id {0} Not Found" + viewModel.StatusId);
                    return output;
                }

                Branches entity = InkriptMapper.Mapper.Map<Branches>(viewModel);
                entity.BranchId = branchId;
                biz.UpdateBranch(entity);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Unable to updated Branch Id:" + branchId;
            }
            return output;
        }

        public ObjectResult<bool> DeleteBranch(int id)
        {
            ObjectResult<bool> output = new ObjectResult<bool>();
            BranchesBLO biz = new BranchesBLO();

            try
            {
                if (!biz.BranchExist(id))
                {
                    output.Message = string.Format("Branch Id {0} Not Found" + id);
                    return output;
                }
                output.Result = biz.DeleteBranches(id);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = false;
                output.Success = false;
                output.Message = "Unable to delete Branch Id:" + id;
            }
            return output;
        }
    }
}