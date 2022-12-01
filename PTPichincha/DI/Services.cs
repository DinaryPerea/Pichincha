using PTPichincha.Bussiness.Bussines;
using PTPichincha.Bussiness.Interfaces;
using PTPichincha.Infraestructure.Persistance.Repository.IRepository;
using PTPichincha.Infraestructure.Persistance.Repository;

namespace PTPichincha.WebAPI.DI
{
    public static class Services
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<ICustomerBussines, CustomerBussines>()
                .AddScoped<IAccountBussines, AccountBussines>()
                .AddScoped<IActivityBussines, ActivityBussines>()
                .AddScoped<IReporteBussines, ReporteBussines>();
        }
        public static void AddUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

    }
}
