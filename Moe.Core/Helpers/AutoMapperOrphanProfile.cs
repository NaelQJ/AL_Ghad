using AutoMapper;
using Moe.Core.Extensions;
using Moe.Core.Models.DTOs;
using Moe.Core.Models.Entities;

namespace Moe.Core.Helpers
{
    public class AutoMapperOrphanProfile : Profile
    {
        public AutoMapperOrphanProfile()
        {
            CreateMap<Orphan, OrphanDTO>()
    .ForMember(dest => dest.General, opt => opt.MapFrom(src => src))
    .ForMember(dest => dest.Medical, opt => opt.MapFrom(src => src))
    .ForMember(dest => dest.School, opt => opt.MapFrom(src => src))
    .ForMember(dest => dest.Talent, opt => opt.MapFrom(src => src))
    .ForMember(dest => dest.Documents, opt => opt.MapFrom(src => src.Documents.Select(d => d.FilePath)));

            CreateMap<Orphan, GeneralInfoDTO>();
            CreateMap<Orphan, MedicalInfoDTO>();
            CreateMap<Orphan, SchoolInfoDTO>();
            CreateMap<Orphan, TalentInfoDTO>();

            CreateMap<Orphan, OrphanSimplDTO>()
                .ForMember(dest => dest.SponsorName,
                    opt => opt.MapFrom(src => src.SponsorShips
                        .Where(s => s.status == Status.Active)
                        .Select(s => s.Sponsor.FullName)
                        .FirstOrDefault() ?? null))
                .ForMember(dest => dest.FatherName,
                    opt => opt.MapFrom(src => src.Family.FatherName ?? null));


            CreateMap<OrphanFormDTO, Orphan>()
                .IncludeMembers(src => src.General, src => src.Medical, src => src.School, src => src.Talent)
                .ForMember(dest => dest.Documents, opt => opt.MapFrom(src =>
                    src.Documents.Select(path => new Document { FilePath = path })));
            CreateMap<GeneralInfoDTO, Orphan>();
            CreateMap<MedicalInfoDTO, Orphan>();
            CreateMap<SchoolInfoDTO, Orphan>();
            CreateMap<TalentInfoDTO, Orphan>();


            CreateMap<OrphanUpdateDTO, Orphan>()
          .ForMember(dest => dest.Documents, opt => opt.Ignore())
          .AfterMap((src, dest, ctx) =>
          {
              if (src.General != null)
                  ctx.Mapper.Map(src.General, dest);
              if (src.Medical != null)
                  ctx.Mapper.Map(src.Medical, dest);
              if (src.School != null)
                  ctx.Mapper.Map(src.School, dest);
              if (src.Talent != null)
                  ctx.Mapper.Map(src.Talent, dest);
          })
          .IgnoreNullAndEmptyGuids();

            CreateMap<GeneralInfoUpdateDTO, Orphan>();
            CreateMap<MedicalInfoUpdateDTO, Orphan>();
            CreateMap<SchoolInfoUpdateDTO, Orphan>();
            CreateMap<TalentInfoUpdateDTO, Orphan>();




        }
    }
}
