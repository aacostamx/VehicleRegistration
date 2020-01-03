using Inkript.Logging;
using Inkript.VR.API.Models;
using Inkript.VR.Business.BusinessLayer;
using Inkript.VR.Models;
using System;
using System.Collections.Generic;

namespace Inkript.VR.API
{
    public class FileInfoCustomsApiBLO
    {
        public ObjectResult<GenericPagedList<FileInfoCustoms>> GetAllFileInfoCustomsPaged(int pageNumber, int pageSize)
        {
            FileInfoCustomsBLO fileInfoBLO = new FileInfoCustomsBLO();
            ObjectResult<GenericPagedList<FileInfoCustoms>> output = new ObjectResult<GenericPagedList<FileInfoCustoms>>();

            try
            {
                output.Result = fileInfoBLO.GetAllFileInfoCustomsPaged(pageNumber, pageSize);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to Get All File Info Paged";
            }
            return output;

        }

        public ObjectResult<FileInfoCustoms> GetByFileInfoCustomId(int fileInfoCustomId)
        {
            FileInfoCustomsBLO fileInfo = new FileInfoCustomsBLO();
            ObjectResult<FileInfoCustoms> output = new ObjectResult<FileInfoCustoms>();

            try
            {
                if (!fileInfo.FileInfoCustomsExist(fileInfoCustomId))
                {
                    output.Message = string.Format("File Info of Id {0} Not Found", fileInfoCustomId);
                    return output;
                }
                output.Result = (fileInfo.GetByFileInfoCustomsId(fileInfoCustomId));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to Get File Info by ID";
            }
            return output;
        }

        public ObjectResult<List<FileInfoCustoms>> GetByFileInfoCustomName(string name)
        {
            FileInfoCustomsBLO fileInfo = new FileInfoCustomsBLO();
            ObjectResult<List<FileInfoCustoms>> output = new ObjectResult<List<FileInfoCustoms>>();

            try
            {
                output.Result = fileInfo.GetByFileInfoCustomsName(name);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Cannot get the file Info having the name :" + name;
            }
            return output;
        }

        public ObjectResult<bool> DeleteFileInfo(int fileInfoCustomId)
        {
            FileInfoCustomsBLO biz = new FileInfoCustomsBLO();
            ObjectResult<bool> output = new ObjectResult<bool>();

            try
            {
                if (!biz.FileInfoCustomsExist(fileInfoCustomId))
                {
                    output.Message = string.Format("File Info Id {0} Not Found", fileInfoCustomId);
                    return output;
                }
                output.Result = biz.DeleteFileInfoCustoms(fileInfoCustomId);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = false;
                output.Success = false;
                output.Message = "Cannot Delete file Info of ID :" + fileInfoCustomId;
            }
            return output;
        }

        public ObjectResult<FileInfoCustoms> CreateFileInfoCustom(FileInfoCustomsCustom custom)
        {
            FileInfoCustomsBLO biz = new FileInfoCustomsBLO();
            ObjectResult<FileInfoCustoms> output = new ObjectResult<FileInfoCustoms>();

            try
            {
                FileInfoCustoms fileInfo = InkriptMapper.Mapper.Map<FileInfoCustoms>(custom);

                if (!biz.ValidImportCustomType(fileInfo))
                {
                    output.Message = string.Format("Import Custom Type invalid (Must be 'NEW' or 'MODIFY')");
                    return output;
                }

                fileInfo = biz.CreateFileInfoCustoms(biz.CheckDuplicateCertifications(fileInfo));
                output.Message = fileInfo.MessageError;
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Unable to create File info object";
            }
            return output;

        }

        public ObjectResult<FileInfoCustoms> UpdateFileInfoCustom(FileInfoCustoms fileInfo)
        {
            FileInfoCustomsBLO biz = new FileInfoCustomsBLO();
            ObjectResult<FileInfoCustoms> output = new ObjectResult<FileInfoCustoms>();

            try
            {
                if (!biz.FileInfoCustomsExist(fileInfo.FileInfoCustomId))
                {
                    output.Message = string.Format("File Info Id {0} Not Found", fileInfo.FileInfoCustomId);
                    return output;
                }
                biz.UpdateFileInfoCustoms(fileInfo);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Unable to update file Info of Id :" + fileInfo.FileInfoCustomId;
            }
            return output;

        }
    }
}