using Grpc.Core;
using Microsoft.Extensions.Logging;
using Repo.POC.GRPC.Server.Repository.Interfaces;
using Repo.POC.GRPC.Server.Repository.Models;
using System.Threading.Tasks;

namespace Repo.POC.GRPC.Server.GrpcService
{
    public class GreeterService : Greeter.GreeterBase
    {
        private readonly ILogger<GreeterService> _logger;

        private readonly IEmployeeRepository _employeeRepository;

        public GreeterService(ILogger<GreeterService> logger, IEmployeeRepository employeeRepository)
        {
            _logger = logger;
            _employeeRepository = employeeRepository;
        }

        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            return Task.FromResult(new HelloReply
            {
                Message = "Hello " + request.Name
            });
        }

        public override async Task<EmployeeInsertReply> Insert(EmployeeInsertRequest request, ServerCallContext context)
        {
            var model = new Employee { Name = request.Name, Email = request.Email };

            var inserted = await _employeeRepository.InsertEmployeeAsync(model);

            var reply = new EmployeeInsertReply { Inserted = inserted };
            
            return reply;
                
        }
    }
}
