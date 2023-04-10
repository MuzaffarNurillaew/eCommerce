using eCommerce.Service.Interfaces;
using eCommerce.Service.Services;

namespace eCommerce.Web.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IProductSearchTagService, ProductSearchTagService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ISearchTagService, SearchTagService>();
            services.AddScoped<IUserService, UserService>();
        }
    }
}
