using Inkript.Logging;
using Inkript.VR.API.Models;
using Inkript.VR.Business.BusinessLayer;
using Inkript.VR.Models;
using System;
using System.Collections.Generic;

namespace Inkript.VR.API
{
    public class BrandApiBLO
    {
        public ObjectResult<Brand> CreateBrand(BrandCustom viewModel)
        {
            BrandBLO biz = new BrandBLO();
            StatusBLO statusBiz = new StatusBLO();
            ObjectResult<Brand> output = new ObjectResult<Brand>();

            try
            {
                if (!statusBiz.StatusExist(viewModel.StatusId))
                {
                    output.Message = string.Format("Status Id {0} Not Found", viewModel.StatusId);
                    return output;
                }

                if (biz.BrandNameEnExist(viewModel.BrandNameEN))
                {
                    output.Message = string.Format("Brand Name {0} Already Exists", viewModel.BrandNameEN);
                    return output;
                }

                if (biz.BrandNameArExist(viewModel.BrandNameAR))
                {
                    output.Message = string.Format("Brand Name {0} Already Exists", viewModel.BrandNameAR);
                    return output;
                }

                biz.CreateBrand(InkriptMapper.Mapper.Map<Brand>(viewModel));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to Create Brand";
            }
            return output;
        }

        public ObjectResult<List<Brand>> GetAllBrands()
        {
            BrandBLO biz = new BrandBLO();
            ObjectResult<List<Brand>> output = new ObjectResult<List<Brand>>();

            try
            {
                output.Result = biz.GetAllBrand();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to Get All Brand";
            }
            return output;
        }

        public ObjectResult<Brand> GetBrand(int id)
        {
            BrandBLO biz = new BrandBLO();
            ObjectResult<Brand> output = new ObjectResult<Brand>();

            try
            {
                if (!biz.BrandExist(id))
                {
                    output.Message = string.Format("Brand Id {0} Not Found", id);
                    return output;
                }

                output.Result = biz.GetBrand(id);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to Get Brand by Id " + id;
            }
            return output;
        }

        public ObjectResult<bool> DeleteBrand(int id)
        {
            ObjectResult<bool> output = new ObjectResult<bool>();
            BrandBLO biz = new BrandBLO();

            try
            {
                if (!biz.BrandExist(id))
                {
                    output.Message = string.Format("Brand Id {0} Not Found" + id);
                    return output;
                }
                output.Result = biz.DeleteBrand(id);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = false;
                output.Success = false;
                output.Message = "Unable to delete Brand Id:" + id;
            }
            return output;
        }
    }
}