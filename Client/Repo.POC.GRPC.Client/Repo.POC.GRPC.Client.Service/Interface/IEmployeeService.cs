using GrpcGreeterClient;
using Repo.POC.GRPC.Client.Service.Dtos;
using System.Threading.Tasks;

namespace Repo.POC.GRPC.Client.Service.Interface
{
    public interface IEmployeeService
    {
        Task<EmployeeInsertReply> InsertEmployee(EmployeeInsertDto employeeInsertDto);
    }
}
