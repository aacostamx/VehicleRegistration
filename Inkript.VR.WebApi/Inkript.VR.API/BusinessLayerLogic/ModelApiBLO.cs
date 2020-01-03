using Inkript.Logging;
using Inkript.VR.API.Models;
using Inkript.VR.Business.BusinessLayer;
using Inkript.VR.Models;
using System;
using System.Collections.Generic;

namespace Inkript.VR.API
{
    public class ModelApiBLO
    {
        public ObjectResult<Model> CreateModel(ModelCustom viewModel)
        {
            ModelBLO biz = new ModelBLO();
            BrandBLO brandBiz = new BrandBLO();
            StatusBLO statusBiz = new StatusBLO();

            ObjectResult<Model> output = new ObjectResult<Model>();

            try
            {
                if (biz.ModelNameExist(viewModel.ModelName))
                {
                    output.Message = string.Format("Model Name '{0}' Already Exist", viewModel.ModelName);
                    return output;
                }
                if (!brandBiz.BrandExist(viewModel.BrandId))
                {
                    output.Message = string.Format("Brand id {0} Not Exist" + viewModel.BrandId);
                    return output;
                }
                if (!statusBiz.StatusExist(viewModel.StatusId))
                {
                    output.Message = string.Format("Status Id '{0}' Not Exist", viewModel.StatusId);
                    return output;
                }

                biz.CreateModel(InkriptMapper.Mapper.Map<Model>(viewModel));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to Create Model";
            }
            return output;
        }

        public ObjectResult<List<Model>> GetAllModels()
        {
            ModelBLO biz = new ModelBLO();
            ObjectResult<List<Model>> output = new ObjectResult<List<Model>>();

            try
            {
                output.Result = biz.GetAllModel();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to Get All Models";
            }
            return output;
        }

        public ObjectResult<Model> GetModel(int id)
        {
            ModelBLO biz = new ModelBLO();
            ObjectResult<Model> output = new ObjectResult<Model>();

            try
            {
                if (!biz.ModelExist(id))
                {
                    output.Message = string.Format("Model Id: '{0}' Not Found", id);
                    return output;
                }

                output.Result = biz.GetModel(id);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to Get Model by Id " + id;
            }
            return output;
        }

        public ObjectResult<bool> DeleteModel(int id)
        {
            ObjectResult<bool> output = new ObjectResult<bool>();
            ModelBLO biz = new ModelBLO();

            try
            {
                if (!biz.ModelExist(id))
                {
                    output.Message = string.Format("Model Id: '{0}' Not Found", id);
                    return output;
                }
                output.Result = biz.DeleteModel(id);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = false;
                output.Success = false;
                output.Message = "Unable to delete Model Id:" + id;
            }
            return output;
        }

        public ObjectResult<Model> UpdateModel(int id, ModelCustom viewModel)
        {
            ModelBLO biz = new ModelBLO();
            BrandBLO brandBiz = new BrandBLO();
            StatusBLO statusBiz = new StatusBLO();

            ObjectResult<Model> output = new ObjectResult<Model>();

            try
            {
                if (!biz.ModelExist(id))
                {
                    output.Message = string.Format("Model Id: '{0}' Not Found", id);
                    return output;
                }

                Model model = biz.GetModel(id);

                if (model.ModelName != viewModel.ModelName
                    && biz.ModelNameExist(viewModel.ModelName))
                {
                    output.Message = string.Format("Model Name: '{0}' Already Exists", viewModel.ModelName);
                    return output;
                }

                if (!brandBiz.BrandExist(viewModel.BrandId))
                {
                    output.Message = string.Format("Brand id {0} Not Exist", viewModel.BrandId);
                    return output;
                }
                if (!statusBiz.StatusExist(viewModel.StatusId))
                {
                    output.Message = string.Format("Status Id '{0}' Not Exist", viewModel.StatusId);
                    return output;
                }

                Model entity = InkriptMapper.Mapper.Map<Model>(viewModel);
                entity.ModelId = id;
                biz.UpdateModel(entity);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to Update Model Id " + id;
            }
            return output;
        }
    }
}