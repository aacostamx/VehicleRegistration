using Inkript.Logging;
using Inkript.VR.API.Models;
using Inkript.VR.Business.BusinessLayer;
using Inkript.VR.Models;
using System;

namespace Inkript.VR.API
{
    public class FileInfoInspectionsApiBLO
    {
        public ObjectResult<GenericPagedList<FileInfoInspections>> GetAllFileInspectionsPaged(int pageNumber, int pageSize)
        {
            FileInfoInspectionsBLO biz = new FileInfoInspectionsBLO();
            ObjectResult<GenericPagedList<FileInfoInspections>> output = new ObjectResult<GenericPagedList<FileInfoInspections>>();

            try
            {
                output.Result = biz.GetAllFileInspectionsPaged(pageNumber, pageSize);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to Get All File Info Inspections Paged";
            }
            return output;
        }

        public ObjectResult<FileInfoInspections> GetByFileInspectionsId(int fileInspectionsId)
        {
            FileInfoInspectionsBLO biz = new FileInfoInspectionsBLO();
            ObjectResult<FileInfoInspections> output = new ObjectResult<FileInfoInspections>();

            try
            {
                if (!biz.FileInspectionsExist(fileInspectionsId))
                {
                    output.Message = string.Format("File Info Inspections Id {0} Not Found", fileInspectionsId);
                    return output;
                }
                output.Result = biz.GetByFileInspectionsId(fileInspectionsId);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to Get File Info Inspection by Id: " + fileInspectionsId;
            }
            return output;
        }

        public ObjectResult<FileInfoInspections> DeleteFileInspections(int fileInspectionsId)
        {
            ObjectResult<FileInfoInspections> output = new ObjectResult<FileInfoInspections>();
            FileInfoInspectionsBLO biz = new FileInfoInspectionsBLO();

            try
            {
                if (!biz.FileInspectionsExist(fileInspectionsId))
                {
                    output.Message = string.Format("File Info Inspections Id {0} Not Found", fileInspectionsId);
                    return output;
                }
                biz.DeleteFileInspections(fileInspectionsId);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to Delete File Info Inspection Id: " + fileInspectionsId;
            }
            return output;
        }

        public ObjectResult<FileInfoInspections> CreateFileInfoInspections(FileInfoInspectionsCustom fileInfo)
        {
            FileInfoInspectionsBLO biz = new FileInfoInspectionsBLO();
            ObjectResult<FileInfoInspections> output = new ObjectResult<FileInfoInspections>();

            try
            {
                biz.CreateFileInfoInspections(InkriptMapper.Mapper.Map<FileInfoInspections>(fileInfo));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to Create File Info Inspection";
            }
            return output;
        }
    }
}