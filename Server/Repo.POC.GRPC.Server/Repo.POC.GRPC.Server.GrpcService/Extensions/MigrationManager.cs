using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Repo.POC.GRPC.Server.Repository.Context;
using System;

namespace Repo.POC.GRPC.Server.GrpcService.Extensions
{
    public static class MigrationManager
    {
        public static IHost MigrateDatabase(this IHost webHost)
        {
            using (var scope = webHost.Services.CreateScope())
            {
                using (var appContext = scope.ServiceProvider.GetRequiredService<EmployeeGRPCServerContext>())
                {
                    try
                    {

                        appContext.Database.Migrate();                        
                    }
                    catch (Exception ex)
                    {                        
                        throw;
                    }
                }
            }

            return webHost;
        }
    }
}

