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
        
        CreateMap<Device,DeviceDTO>();
        CreateMap<DeviceFormDTO,Device>();
        CreateMap<DeviceUpdateDTO,Device>()
            .IgnoreNullAndEmptyGuids();
        
        CreateMap<Warehouse,WarehouseDTO>();
        CreateMap<Warehouse, WarehouseSimpleDTO>()
            .ForMember(dest => dest.FamilyName, opt => opt.MapFrom(src => src.Family.FatherName));
        CreateMap<Warehouse, WarehouseOutDTO>();
        CreateMap<WarehouseFormDTO,Warehouse>()
         .ForMember(dest => dest.Type, opt => opt.MapFrom(src => ItemType.In));
        CreateMap<WarehouseFormOutDTO, Warehouse>();
        CreateMap<WarehouseFormOutDTO, WarehouseOutDTO>();
        CreateMap<WarehouseUpdateDTO,Warehouse>()
            .IgnoreNullAndEmptyGuids();


        //Warehouse Beneficiary and donation Mapping
        CreateMap<Family, BeneficiaryDTO>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.FatherName));
        CreateMap<Orphan, BeneficiaryDTO>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.FullName));
        CreateMap<Warehouse, WarehouseDTO>()
            .ForMember(dest => dest.Donation, opt => opt.MapFrom(src => src))
            .ForMember(dest => dest.beneficiary, opt => opt.Ignore()) 
            .AfterMap((src, dest, ctx) =>
            {
                if (src.Family != null)
                    dest.beneficiary = ctx.Mapper.Map<BeneficiaryDTO>(src.Family);
                else if (src.Orphan != null)
                    dest.beneficiary = ctx.Mapper.Map<BeneficiaryDTO>(src.Orphan);
            });

        CreateMap<Warehouse, DonationDTO>();




        CreateMap<Support, SupportDTO>();
        CreateMap<SupportFormDTO, Support>();
        CreateMap<SupportUpdateDTO, Support>()
            .IgnoreNullAndEmptyGuids();
        CreateMap<SponsorShip, SponsorShipDTO>()
       .ForMember(dest => dest.Sponsor, opt => opt.MapFrom(src => src.Sponsor))
       .ForMember(dest => dest.Orphan, opt => opt.MapFrom(src => src.Orphan))
       .ForMember(dest => dest.Family, opt => opt.MapFrom(src => src.Family));

        CreateMap<Sponsor, SponsorDetailsDTO>()
            .ForMember(dest => dest.SponsoredFor, opt => opt.MapFrom(src =>
                src.SponsorShips.Any(s => s.OrphanId != null) ? "Orphan" :
                src.SponsorShips.Any(s => s.FamilyId != null) ? "Family" : null));
        CreateMap<Orphan, OrphanDetailsDTO>();
        CreateMap<Family, FamilyDetailsDTO>();

        CreateMap<SponsorShipFormDTO, SponsorShip>();
        CreateMap<SponsorShipUpdateDTO, SponsorShip>()
            .IgnoreNullAndEmptyGuids();


        CreateMap<Sponsor, SponsorDTO>();
        CreateMap<Sponsor, SponsorSimplDTO>();
        CreateMap<SponsorFormDTO, Sponsor>();
        CreateMap<SponsorUpdateDTO, Sponsor>()
            .IgnoreNullAndEmptyGuids();

        CreateMap<Campaign, CampaignDTO>();
        CreateMap<CampaignFormDTO, Campaign>();
        CreateMap<CampaignUpdateDTO, Campaign>()
            .IgnoreNullAndEmptyGuids();

        CreateMap<News, NewsDTO>();
        CreateMap<News, NewsSimpleDTO>();
        CreateMap<NewsFormDTO, News>();
        CreateMap<NewsUpdateDTO, News>()
            .IgnoreNullAndEmptyGuids();

   


 


        CreateMap<SystemSettings, SystemSettingsDTO>();
        CreateMap<SystemSettingsFormDTO, SystemSettings>();
        CreateMap<SystemSettingsUpdateDTO, SystemSettings>()
            .IgnoreNullAndEmptyGuids();
        CreateMap<Permission, PermissionDTO>();

        CreateMap<Role, RoleDTO>();
        CreateMap<RoleFormDTO, Role>();
        CreateMap<RoleUpdateDTO, Role>()
            .IgnoreNullAndEmptyGuids();
    }
}