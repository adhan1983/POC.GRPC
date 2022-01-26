using Microsoft.Extensions.DependencyInjection;
using Repo.POC.GRPC.Server.Repository.Interfaces;
using Repo.POC.GRPC.Server.Repository.Repositories;

namespace Repo.POC.GRPC.Server.GrpcService.Extensions
{
    public static class RegisterDependencyManager
    {
        public static void RegisterDependencies(this IServiceCollection services)
        {            
            
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

        }
    }
}
