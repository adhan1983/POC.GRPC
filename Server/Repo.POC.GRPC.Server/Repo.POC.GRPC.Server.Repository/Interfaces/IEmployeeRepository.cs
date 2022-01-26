using Repo.POC.GRPC.Server.Repository.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repo.POC.GRPC.Server.Repository.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<bool> InsertEmployeeAsync(Employee model);

        Task<Employee> GetEmployeeByIdAsync(int id);

        Task<List<Employee>> GetEmployeesAsync();

    }
}
