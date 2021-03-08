using Microsoft.Extensions.DependencyInjection;
using Olimpia.Business.Interface;
using Olimpia.Business.Services;

namespace Olimpia.WebApi.Extension
{
    public static class InicializeBusinessServices
    {
        public static void ConfigureBusinessServices(this IServiceCollection services)
        {
            services.AddTransient<IInvoiceServices, InvoiceServices>();
        }
    }
}