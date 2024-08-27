using AutoMapper;
using Ecommerce.Application.Dto;
using Ecommerce.Application.Dto.Ticket;

using Ecommerce.Application.Handlers.Configuration.Commands;

using Ecommerce.Application.Handlers.PortfolioCategory.Commands;

using Ecommerce.Application.Handlers.TicketBooking.Commands;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Identity.Entities;
using Ecommerce.Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace Ecommerce.Application.Mapping;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        #region Booking
      //  CreateMap<CreateBookingCommand, Booking>();
       // CreateMap<UpdateCategoryCommand, Category>();
       // CreateMap<UpdateCategoryCommand, CategoryDto>().ReverseMap();
        CreateMap<BookingDto, Booking>().ReverseMap();
        #endregion
        #region TicketBook
      //  CreateMap<CreateBookingCommand, Booking>();
        // CreateMap<UpdateCategoryCommand, Category>();
        // CreateMap<UpdateCategoryCommand, CategoryDto>().ReverseMap();
        CreateMap<TicketBookDto, TicketBook>().ReverseMap();
        #endregion



        #region CategoryPortfolio
        CreateMap<PortfolioCategoryCommand, PortfolioCategory>();
        CreateMap<UpdatePortfolioCategoryCommand, PortfolioCategory>();
       CreateMap<UpdatePortfolioCategoryCommand, PortfolioCategoryDto>().ReverseMap();
        CreateMap<PortfolioCategoryDto, PortfolioCategory>().ReverseMap();
        #endregion

      
        #region TicketBooking
        CreateMap<CreateTicketBookingCommand, TicketBook>();
        CreateMap<UpdateTicketBookingCommand, TicketBook>();
       // CreateMap<PortfolioDto, Portfolio>().ReverseMap();
        #endregion
      
        #region Configuration
        CreateMap<GeneralConfigurationDto, GeneralConfiguration>().ReverseMap();
        CreateMap<UpdateGeneralConfigurationCommand, GeneralConfiguration>().ReverseMap();

        CreateMap<SocialProfileDto, SocialProfile>().ReverseMap();
        CreateMap<UpdateSocialConfigurationCommand, SocialProfileDto>().ReverseMap();

        CreateMap<HeaderSliderDto, HeaderSlider>().ReverseMap();
        CreateMap<DealOfTheDayDto, DealOfTheDay>().ReverseMap();
        CreateMap<BannerDto, Banner>().ReverseMap();
        CreateMap<UpdateDealOfTheDayConfigCommand, DealOfTheDayDto>().ReverseMap();

        CreateMap<FeatureProductConfigurationDto, FeatureProductConfiguration>().ReverseMap();

        CreateMap<StockConfigurationDto, StockConfiguration>().ReverseMap();
        CreateMap<UpdateStockConfigurationCommand, StockConfigurationDto>().ReverseMap();

        CreateMap<TopCategoriesConfiguration, TopCategoriesConfigurationDto>().ReverseMap();

        CreateMap<BasicSeoConfiguration, BasicSeoConfigurationDto>().ReverseMap();

        CreateMap<SmtpConfiguration, SmtpConfigurationDto>().ReverseMap();
        CreateMap<UpdateSmtpConfigurationCommand, SmtpConfigurationDto>().ReverseMap();

        CreateMap<SecurityConfiguration, SecurityConfigurationDto>().ReverseMap();
        CreateMap<UpdateSecurityConfigurationCommand, SecurityConfigurationDto>().ReverseMap();

        CreateMap<AdvancedConfiguration, AdvancedConfigurationDto>().ReverseMap();
        CreateMap<UpdateAdvancedConfigurationCommand, AdvancedConfigurationDto>().ReverseMap();
        #endregion

     

        CreateMap<ApplicationUser, EditProfileDto>().ReverseMap();

        CreateMap<IdentityRole, RoleDto>();
        CreateMap<IdentityRole, AddEditRoleDto>().ReverseMap();

      

        CreateMap<ApplicationUser, UserDto>();
        CreateMap<ApplicationUser, AddEditUserDto>().ReverseMap();
        CreateMap<IdentityRole, ManageRoleDto>();

        CreateMap<CustomerDto, Customer>().ReverseMap();
     
        //CreateMap<User, CustomerRegisterDto>().ReverseMap();

        CreateMap<ApplicationUser, UserDto>()
            .ForMember(dest => dest.Customer, opt => opt.MapFrom(src => src.Customer)).ReverseMap();


    }
}