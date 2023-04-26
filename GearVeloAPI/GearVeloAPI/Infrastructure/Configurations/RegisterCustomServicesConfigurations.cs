using GearVeloAPI.Admin.Services.Concretes;
using GearVeloAPI.Admin.Services.Services;
using GearVeloAPI.Helper.Services.Concretes;
using GearVeloAPI.Helper.Services.Services;

namespace GearVeloAPI.Infrastructure.Configurations;

public static class RegisterCustomServicesConfigurations
{
    public static void RegisterCustomServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<IEndpointService, EndpointService>();
        services.AddScoped<INavbarService, NavbarService>();
        services.AddScoped<ISubnavbarService, SubnavbarService>();

        //services.AddSingleton<IFileService, FileService>();
        //services.AddScoped<IFeedbackSevice, FeedbackService>();
        //services.AddScoped<IDiscoverMenuService, DiscoverMenuService>();
        //services.AddScoped<IShortInfoService, ShortInfoService>();
        //services.AddScoped<IWelcomeSliderService, WelcomeSliderService>();
        //services.AddScoped<IPaymentBenefitsService, PaymentBenefitsService>();
        //services.AddScoped<IOurHistoryService, OurHistoryService>();
        //services.AddScoped<ISizeService, SizeService>();
        //services.AddScoped<ITagService, TagService>();
        //services.AddScoped<IEmailService, SMTPService>();
        //services.AddScoped<IUserService, UserService>();
        //services.AddScoped<IUserActivationService, UserActivationService>();
        //services.AddScoped<IDrinkCategoryService, DrinkCategoryService>();
        //services.AddScoped<IDrinkService, DrinkService>();
        //services.AddScoped<IFoodCategoryService, FoodCategoryService>();
        //services.AddScoped<IBasketService, BasketService>();
        //services.AddScoped<INotificationService, NotificationService>();
        //services.AddScoped<IFoodService, FoodService>();
        //services.AddScoped<Client.Services.Concretes.IHomeService, Client.Services.Services.HomeService>();
        //services.AddScoped<Client.Services.Concretes.IAuthenticationService, Client.Services.Services.AuthenticationService>();
        //services.AddScoped<Admin.Services.Concretes.IOrderService, Admin.Services.Services.OrderService>();
        //services.AddScoped<Services.Concretes.IOrderService, Services.Services.OrderService>();
        //services.AddScoped<IsAuthenticated>();
    }
}