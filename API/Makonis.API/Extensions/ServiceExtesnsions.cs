using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Makonis.API.Extensions
{
    public static class ServiceExtesnsions
    {
        public static void ConfigureCors(this IServiceCollection service)
        {
            service.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                {
                    //builder.WithOrigins("http://localhost:4200,https://localhost:4200");
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });

            });
        }
    }
}
