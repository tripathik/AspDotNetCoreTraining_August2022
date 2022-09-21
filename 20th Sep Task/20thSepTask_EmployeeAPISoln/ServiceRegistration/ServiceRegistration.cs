using EmployeeDataCore.Abctractions;
using EmployeeDataService;
using EmployeeDomainModel;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDataDependencyInjection
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, string connectionString)
        {
            return services.AddDbContextPool<EmployeeDataContext>(options =>
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
            services.TryAddScoped<ISkillService, SkillService>();
            return services;
        }
    }
}
