using Hakaton.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hakaton.App
{
    public static class WebHostExstension
    {
        public static IWebHost SeedingData(this IWebHost webHost)
        {
            using (var serviceScope = webHost.Services.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<DataContext>();
                var hostingEnvironment = serviceScope.ServiceProvider.GetService<IHostingEnvironment>();

                DataSeed.InitData(context);
                
            }

            return webHost;
        }
    }
}
