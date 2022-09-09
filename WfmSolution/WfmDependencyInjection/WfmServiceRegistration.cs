using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Graph;
using WfmDataContext;
using WfmService;
using WfmCore.Abstraction;

namespace WfmDependencyInjection
{
    public static class WfmServiceRegistration
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, string connectionString)
        {
            return services.AddDbContextPool<WfmDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
        }

        public static IServiceCollection AddWFM_DB(this IServiceCollection services, 
                                                  IConfiguration configuration)
        {
            // Micrsofot
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
           
            //Service
            services.TryAddScoped<IEmployeeService, EmployeeService>();
            services.TryAddScoped<ISoftlockService, SoftlockService>();
            services.TryAddScoped<IUsersService, UsersService>();
            return services;
        }
    }
}

