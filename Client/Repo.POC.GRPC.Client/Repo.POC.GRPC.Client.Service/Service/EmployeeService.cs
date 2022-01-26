using Grpc.Net.Client;
using GrpcGreeterClient;
using Repo.POC.GRPC.Client.Service.Dtos;
using Repo.POC.GRPC.Client.Service.Interface;
using System.Threading.Tasks;

namespace Repo.POC.GRPC.Client.Service.Service
{
    public class EmployeeService : IEmployeeService
    {        
        public async Task<EmployeeInsertReply> InsertEmployee(EmployeeInsertDto employeeInsertDto)
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            
            var client = new Greeter.GreeterClient(channel);

            var reply = await client.InsertAsync(new EmployeeInsertRequest { Name = employeeInsertDto.Name, Email = employeeInsertDto.Email });

            return reply;
        }
    }
}
