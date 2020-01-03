using AutoMapper;
using Inkript.VR.API.Models;
using entity = Inkript.VR.Models;

namespace Inkript.VR.API.Automapper
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize((config) =>
            {
                #region FileInfo
                config.CreateMap<entity.FileInfo, FileInfoDto>().ReverseMap();
                config.CreateMap<entity.FileInfo, FileInfoOnlyDto>().ReverseMap();
                config.CreateMap<entity.FileInfo, FileInfoForCreateDto>().ReverseMap();
                #endregion

                #region ImportCustoms
                config.CreateMap<entity.ImportCustoms, ImportCustomsDto>().ReverseMap();
                config.CreateMap<entity.ImportCustoms, ImportCustomsForCreateDto>().ReverseMap();
                #endregion

                #region FileInfoInspections
                config.CreateMap<entity.FileInfoInspections, FileInfoInspectionsDto>().ReverseMap();
                config.CreateMap<entity.FileInfoInspections, FileInfoInspectionsForCreationDto>().ReverseMap();
                #endregion

                #region ImportInspections
                config.CreateMap<entity.ImportInspections, ImportInspectionsDto>().ReverseMap();
                config.CreateMap<entity.ImportInspections, ImportInspectionsForCreationDto>().ReverseMap(); 
                #endregion
            });
        }
    }
}