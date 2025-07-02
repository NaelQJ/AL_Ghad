using AutoMapper;
using Moe.Core.Extensions;
using Moe.Core.Models.DTOs;
using Moe.Core.Models.Entities;

namespace Moe.Core.Helpers
{
    public class AutoMapperFamilyProfile : Profile
    {

        public AutoMapperFamilyProfile()
        {
            CreateMap<Family, FamilyDTO>()
           .ForMember(dest => dest.Father, opt => opt.MapFrom(src => src))
           .ForMember(dest => dest.Mother, opt => opt.MapFrom(src => src))
           .ForMember(dest => dest.CurrentHousing, opt => opt.MapFrom(src => src))
           .ForMember(dest => dest.PreviousHousing, opt => opt.MapFrom(src => src))
           .ForMember(dest => dest.Income, opt => opt.MapFrom(src => src))
           .ForMember(dest => dest.Project, opt => opt.MapFrom(src => src))
           .ForMember(dest => dest.Documents, opt => opt.MapFrom(src => src.Documents.Select(d => d.FilePath)))
           .ForMember(dest => dest.Orphans, opt => opt.MapFrom(src => src.Orphans))
           .ForMember(dest => dest.Warehouses, opt => opt.MapFrom(src => src.Warehouses));

            CreateMap<Family, FamilySimpleDTO>()
               .ForMember(dest => dest.SponsorName,
                   opt => opt.MapFrom(src => src.SponsorShips.Where(s => s.status == Status.Active).Select(s => s.Sponsor.FullName)
                       .FirstOrDefault() ?? null));

            CreateMap<FamilyFormDTO, Family>()
                .IncludeMembers(src => src.Father, src => src.Mother, src => src.CurrentHousing,
                                src => src.PreviousHousing, src => src.Income, src => src.Project)
                .ForMember(dest => dest.Orphans, opt => opt.Ignore())
                  .ForMember(dest => dest.FamilyDevices, opt => opt.MapFrom(src => src.Device))
                .ForMember(dest => dest.Documents, opt => opt.MapFrom(src => src.Documents.Select(doc => new Document { FilePath = doc })))
              
                .ForMember(dest => dest.Notes, opt => opt.MapFrom(src => src.Notes));
           
            CreateMap<FamilyUpdateDTO, Family>()
                .IgnoreNullAndEmptyGuids();
            CreateMap<FamilyDeviceDTO, FamilyDevice>();

            CreateMap<FatherInfoDTO, Family>();
            CreateMap<MotherInfoDTO, Family>();
            CreateMap<CurrentHousingDTO, Family>();
            CreateMap<PreviousHousingDTO, Family>();
            CreateMap<IncomeInfoDTO, Family>();
            CreateMap<ProjectInfoDTO, Family>();
            CreateMap<Family, FatherInfoDTO>();
            CreateMap<Family, MotherInfoDTO>();
            CreateMap<Family, CurrentHousingDTO>();
            CreateMap<Family, PreviousHousingDTO>();
            CreateMap<Family, IncomeInfoDTO>();
            CreateMap<Family, ProjectInfoDTO>();

          
            CreateMap<Orphan, OrphanFamilyDTO>();
            CreateMap<Warehouse, WarehouseFamilyDTO>();



            CreateMap<FamilyUpdateDTO, Family>()
           .IncludeMembers(src => src.Father, src => src.Mother, src => src.CurrentHousing,
                           src => src.PreviousHousing, src => src.Income, src => src.Project)
           .ForMember(dest => dest.Documents, opt => opt.Ignore())
          
           .AfterMap((src, dest, ctx) =>
           {
               if (src.Father != null)
                   ctx.Mapper.Map(src.Father, dest);
               if (src.Mother != null)
                   ctx.Mapper.Map(src.Mother, dest);
               if (src.CurrentHousing != null)
                   ctx.Mapper.Map(src.CurrentHousing, dest);
               if (src.PreviousHousing != null)
                   ctx.Mapper.Map(src.PreviousHousing, dest);
               if (src.Income != null)
                   ctx.Mapper.Map(src.Income, dest);
               if (src.Project != null)
                   ctx.Mapper.Map(src.Project, dest);
           })
           .IgnoreNullAndEmptyGuids();


            CreateMap<FatherInfoUpdateDTO, Family>();
            CreateMap<MotherInfoUpdateDTO, Family>();
            CreateMap<CurrentHousingUpdateDTO, Family>();
            CreateMap<PreviousHousingUpdateDTO, Family>();
            CreateMap<IncomeInfoUpdateDTO, Family>();
            CreateMap<ProjectInfoUpdateDTO, Family>();




        }
    }
}
