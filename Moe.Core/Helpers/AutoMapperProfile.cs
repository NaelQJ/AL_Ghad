using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Moe.Core.Data;
using Moe.Core.Models.DTOs;
using Moe.Core.Models.DTOs.User;
using Moe.Core.Models.Entities;
using Moe.Core.Extensions;
using Moe.Core.Models.DTOs.LocalizedContent;
using Moe.Core.Translations;
using Moe.Core.Models.DTOs.Auth;

namespace Moe.Core.Helpers;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<User, UserDTO>()
     .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.StaticRole));


        CreateMap<User, LoginDTO>();


        CreateMap<UserFormDTO, User>();
        CreateMap<UserUpdateDTO, User>()
            .IgnoreNullAndEmptyGuids();

        CreateMap<Country, CountryDTO>();
        CreateMap<CountryFormDTO, Country>();
        CreateMap<CountryUpdateDTO, Country>()
            .IgnoreNullAndEmptyGuids();

        CreateMap<City, CityDTO>();
        CreateMap<CityFormDTO, City>();
        CreateMap<CityUpdateDTO, City>()
            .IgnoreNullAndEmptyGuids();

        CreateMap<LocalizedContent, LocalizedContentDTO>();
        CreateMap<LocalizedContentFormDTO, LocalizedContent>();
        CreateMap<LocalizedContentUpdateDTO, LocalizedContent>()
            .IgnoreNullAndEmptyGuids();

        CreateMap<Notification, NotificationDTO>();
        CreateMap<Notification, NotificationDTOSimplified>();
        CreateMap<NotificationForm, Notification>();


        //{{INSERTION_POINT}}
        
        CreateMap<Support,SupportDTO>();
        CreateMap<SupportFormDTO,Support>();
        CreateMap<SupportUpdateDTO,Support>()
            .IgnoreNullAndEmptyGuids();
        CreateMap<SponsorShip, SponsorShipDTO>()
       .ForMember(dest => dest.Sponsor, opt => opt.MapFrom(src => src.Sponsor))
       .ForMember(dest => dest.Orphan, opt => opt.MapFrom(src => src.Orphan))
       .ForMember(dest => dest.Family, opt => opt.MapFrom(src => src.Family));

        CreateMap<Sponsor, SponsorSympleDto>()
            .ForMember(dest => dest.SponsoredFor, opt => opt.MapFrom(src =>
                src.SponsorShips.Any(s => s.OrphanId != null) ? "Orphan" :
                src.SponsorShips.Any(s => s.FamilyId != null) ? "Family" : null));
           

        CreateMap<Orphan, OrphanSympleDto>();
        CreateMap<Family, FamliySympleDto>();

        CreateMap<SponsorShipFormDTO, SponsorShip>();
        CreateMap<SponsorShipUpdateDTO, SponsorShip>()
            .IgnoreNullAndEmptyGuids();

        
        CreateMap<Sponsor,SponsorDTO>();
        CreateMap<Sponsor, SponsorSimplDTO>();
        CreateMap<SponsorFormDTO,Sponsor>();
        CreateMap<SponsorUpdateDTO,Sponsor>()
            .IgnoreNullAndEmptyGuids();
        
        CreateMap<Campaign,CampaignDTO>();
        CreateMap<CampaignFormDTO,Campaign>();
        CreateMap<CampaignUpdateDTO,Campaign>()
            .IgnoreNullAndEmptyGuids();
        
        CreateMap<News,NewsDTO>();
        CreateMap<NewsFormDTO,News>();
        CreateMap<NewsUpdateDTO,News>()
            .IgnoreNullAndEmptyGuids();
        
        CreateMap<Orphan,OrphanDTO>();
        CreateMap<Orphan, OrphanSimplDTO>()
              .ForMember(dest => dest.SponsorName,
           opt => opt.MapFrom(src => src.SponsorShips
               .Where(s => s.status == Status.Active)
               .Select(s => s.Sponsor.FullName)
               .FirstOrDefault() ?? "لا يوجد كفيل"))
              .ForMember(dest => dest.FatherName,
              opt => opt.MapFrom(src => src.Family.FatherName ?? "لا يوجد "));

        CreateMap<OrphanFormDTO,Orphan>();
        CreateMap<OrphanUpdateDTO,Orphan>()
            .IgnoreNullAndEmptyGuids();
        CreateMap<Orphan, Document>()
                   .ForMember(dest => dest.OrphanId, opt => opt.MapFrom(src => src.Id))
                   .ForMember(dest => dest.FilePath, opt => opt.MapFrom(src => src.Documents));


        CreateMap<Family, FamilyDTO>();
        CreateMap<Family, FamilySimpleDTO>()
       .ForMember(dest => dest.SponsorName,
           opt => opt.MapFrom(src => src.SponsorShips
               .Where(s => s.status == Status.Active)
               .Select(s => s.Sponsor.FullName)
               .FirstOrDefault() ?? "لا يوجد كفيل"));
        CreateMap<FamilySimpleDTO, Family>();
        CreateMap<FamilyFormDTO, Family>()
        .ForMember(dest => dest.Orphans, opt => opt.Ignore())
                 .ForMember(dest => dest.Documents, opt => opt.MapFrom(src =>
                src.Documents.Select(documentName => new Document { FilePath = documentName }).ToList())) 
            .ForMember(dest => dest.Devices, opt => opt.MapFrom(src =>
                src.Devices.Select(deviceName => new Device { DevicePath = deviceName }).ToList())); 
        
      
        CreateMap<FamilyUpdateDTO,Family>()
            .IgnoreNullAndEmptyGuids();
        CreateMap<Family, Document>()
       .ForMember(dest => dest.FamilyId, opt => opt.MapFrom(src => src.Id))
       .ForMember(dest => dest.FilePath, opt => opt.MapFrom(src => string.Join(",", src.Documents)));


        CreateMap<Family, Device>()
       .ForMember(dest => dest.FamilyId, opt => opt.MapFrom(src => src.Id))
       .ForMember(dest => dest.DevicePath, opt => opt.MapFrom(src => string.Join(",", src.Devices)));


        CreateMap<SystemSettings,SystemSettingsDTO>();
        CreateMap<SystemSettingsFormDTO,SystemSettings>();
        CreateMap<SystemSettingsUpdateDTO,SystemSettings>()
            .IgnoreNullAndEmptyGuids();
        CreateMap<Permission,PermissionDTO>();
        
        CreateMap<Role,RoleDTO>();
        CreateMap<RoleFormDTO,Role>();
        CreateMap<RoleUpdateDTO,Role>()
            .IgnoreNullAndEmptyGuids();
    }
}