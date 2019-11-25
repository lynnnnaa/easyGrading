using easyGrading.Services;
using easyGrading.Services.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace easyGrading.Infrastructure
{
    public static class DependencyInjection
    {
        public static void setup(IServiceCollection services) {

            services.AddScoped<IAccountServices, AccountServices>();

            services.AddTransient<IDbQueries, DbQueries>();
        }
    }
}
