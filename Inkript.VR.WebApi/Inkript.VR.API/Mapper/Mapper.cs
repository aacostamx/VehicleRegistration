using Inkript.VR.API.Models;
using Inkript.VR.Models;

namespace Inkript.VR.API
{
    public static class Mapper
    {
        public static void Initialize()
        {
            InkriptMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<LockedCategory, LockedCategoryCustom>();
                cfg.CreateMap<Model, ModelCustom>()
                .ForMember(p => p.StatusId, r => r.MapFrom(s => s.Status.StatusId))
                .ReverseMap();
                cfg.CreateMap<Organization, OrganizationCustom>()
                .ForMember(p => p.StatusId, r => r.MapFrom(s => s.Status.StatusId))
                .ReverseMap();
                cfg.CreateMap<OutputGroup, OutputGroupCustom>();
                cfg.CreateMap<OwnerType, OwnerTypeCustom>();
                cfg.CreateMap<Person, PersonCustom>();
                cfg.CreateMap<PlateCodes, PlateCodesCustom>();
                cfg.CreateMap<PlateNumberPool, PlateNumberPoolCustom>();
                cfg.CreateMap<PlateRanges, PlateRangesCustom>().ReverseMap()
                .ForMember(p => p.PlateNumberPool, r => r.Ignore());
                cfg.CreateMap<Regions, RegionsCustom>();
                cfg.CreateMap<RegisteredVehicles, RegisteredVehicles>()
                .ReverseMap();
                cfg.CreateMap<Section, SectionCustom>();
                cfg.CreateMap<Sectors, SectorsCustom>();
                cfg.CreateMap<SectorWarningLimit, SectorWarningLimitCustom>();
                cfg.CreateMap<ServerMessages, ServerMessagesCustom>();
                cfg.CreateMap<Status, StatusCustom>();
                cfg.CreateMap<ThirdParties, ThirdPartiesCustom>();
                cfg.CreateMap<TRIM, TRIMCustom>();
                cfg.CreateMap<TrunkType, TrunkTypeCustom>()
                .ForMember(p => p.StatusId, r => r.MapFrom(s => s.Status.StatusId))
                .ReverseMap();
                cfg.CreateMap<Utilization, UtilizationCustom>();
                cfg.CreateMap<VehicleCategory, VehicleCategoryCustom>();
                cfg.CreateMap<VehicleHold, VehicleHoldCustom>();
                cfg.CreateMap<VehicleTypes, VehicleTypesCustom>();
                cfg.CreateMap<AppDocInputs, AppDocInputsCustom>();
                cfg.CreateMap<ApplicationDocuments, ApplicationDocumentsCustom>();
                cfg.CreateMap<Bank, BankCustom>();
                cfg.CreateMap<BPFee, BPFeeCustom>();
                cfg.CreateMap<BPOutput, BPOutputCustom>();
                cfg.CreateMap<BPOutputRel, BPOutputRelCustom>();
                cfg.CreateMap<BPRelationships, BPRelationshipsCustom>();
                cfg.CreateMap<Branches, BranchesCustom>()
                .ForMember(p => p.StatusId, r => r.MapFrom(s => s.Status.StatusId))
                .ReverseMap();
                cfg.CreateMap<Brand, BrandCustom>()
                .ForMember(p => p.StatusId, r => r.MapFrom(s => s.Status.StatusId))
                .ReverseMap();
                cfg.CreateMap<BusinessProcesses, BusinessProcessesCustom>();
                cfg.CreateMap<VehicleOwnership, VehicleOwnershipCustom>();
                cfg.CreateMap<CarStatus, CarStatusCustom>();
                cfg.CreateMap<CarUniqueNumber, CarUniqueNumberCustom>()
                .ForMember(p => p.TrimId, r => r.MapFrom(s => s.TRIM.TrimId))
                .ForMember(p => p.ModelId, r => r.MapFrom(s => s.Model.ModelId))
                .ForMember(p => p.BrandId, r => r.MapFrom(s => s.Brand.BrandId))
                .ReverseMap();
                cfg.CreateMap<Cities, CitiesCustom>();
                cfg.CreateMap<Colors, ColorsCustom>()
                .ForMember(p => p.StatusId, r => r.MapFrom(s => s.Status.StatusId))
                .ReverseMap();
                cfg.CreateMap<CompanyCategory, CompanyCategoryCustom>();
                cfg.CreateMap<CompanyClass, CompanyClassCustom>();
                cfg.CreateMap<CustomsOffices, CustomsOfficesCustom>();
                cfg.CreateMap<Districts, DistrictsCustom>();
                cfg.CreateMap<DocumentInput, DocumentInputCustom>();
                cfg.CreateMap<DocumentProcessRelationship, DocumentProcessRelationshipCustom>();
                cfg.CreateMap<Documents, DocumentsCustom>();
                cfg.CreateMap<Application, ApplicationCustom>()
                .ForMember(p => p.StatusId, r => r.MapFrom(s => s.Status.StatusId))
                .ReverseMap();
                cfg.CreateMap<ExemptedFees, ExemptedFeesCustom>();
                cfg.CreateMap<ExemptionCategories, ExemptionCategoriesCustom>();
                cfg.CreateMap<Fees, FeesCustom>()
                .ForMember(p => p.StatusId, r => r.MapFrom(s => s.Status.StatusId))
                .ForMember(p => p.FeeCategoryId, r => r.MapFrom(s => s.FeeCategory.FeeCategoryId))
                .ReverseMap();
                cfg.CreateMap<FileInfoCustoms, FileInfoCustomsCustom>();
                cfg.CreateMap<FileInfoInspections, FileInfoInspectionsCustom>();
                cfg.CreateMap<FORM, FORMCustom>();
                cfg.CreateMap<FuelTypes, FuelTypesCustom>();
                cfg.CreateMap<Governate, GovernateCustom>();
                cfg.CreateMap<HoldTypeCategRel, HoldTypeCategRelCustom>();
                cfg.CreateMap<HoldTypes, HoldTypesCustom>();
                cfg.CreateMap<ImportCustoms, ImportCustomsCustom>().ReverseMap();
                cfg.CreateMap<ImportCustoms, ImportCustomFilter>().ReverseMap();
                cfg.CreateMap<ImportInspections, ImportInspectionsCustom>()
                .ForMember(p => p.FileInfoInspectionId, r => r.MapFrom(s => s.FileInfoInspections.FileInfoInspectionId))
                .ReverseMap();
                cfg.CreateMap<Insurance, InsuranceCustom>();
                cfg.CreateMap<InvoiceNumber, InvoiceNumberCustom>();
                cfg.CreateMap<LicenseOwnership, LicenseOwnershipCustom>();
                cfg.CreateMap<Fees, CalculatedFees>()
                .ForMember(p => p.StatusId, r => r.MapFrom(s => s.Status.StatusId))
                .ForMember(p => p.FeeCategoryId, r => r.MapFrom(s => s.FeeCategory.FeeCategoryId))
                .ReverseMap();
                cfg.CreateMap<BPSectorVehicle, BPSectorVehicleCustom>();
                cfg.CreateMap<RegisteredVehicles, RegisteredVehiclesPlain>()
                .ForMember(p => p.CarUniqueNumber, r => r.MapFrom(s => s.CarUniqueNumber.CarUniqueNumberVal))
                .ForMember(p => p.PlateCodeId, r => r.MapFrom(s => s.PlateCodes.PlateCodeId))
                .ForMember(p => p.FormId, r => r.MapFrom(s => s.FORM.FormId))
                .ForMember(p => p.ColorId, r => r.MapFrom(s => s.Colors.ColorId))
                .ForMember(p => p.UtilizationId, r => r.MapFrom(s => s.Utilization.UtilizationId))
                .ForMember(p => p.TrunkTypeId, r => r.MapFrom(s => s.TrunkType.TrunkTypeId))
                .ForMember(p => p.FuelTypeId, r => r.MapFrom(s => s.FuelTypes.FuelTypeId))
                .ForMember(p => p.VehicleCategoryId, r => r.MapFrom(s => s.VehicleCategory.VehicleCategoryId))
                .ForMember(p => p.SectorId, r => r.MapFrom(s => s.Sectors.SectorId))
                .ForMember(p => p.VehicleTypeId, r => r.MapFrom(s => s.VehicleTypes.VehicleTypeId))
                .ForMember(p => p.StatusId, r => r.MapFrom(s => s.Status.StatusId))
                .ReverseMap();
            });
        }
    }
}