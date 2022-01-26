using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Repo.POC.GRPC.Server.Repository.Context;
using Repo.POC.GRPC.Server.Repository.Interfaces;
using Repo.POC.GRPC.Server.Repository.Models;

namespace Repo.POC.GRPC.Server.Repository.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        protected EmployeeGRPCServerContext _employeeGRPCServerContext;

        public EmployeeRepository(EmployeeGRPCServerContext employeeGRPCServerContext) => _employeeGRPCServerContext = employeeGRPCServerContext;

        public async Task<bool> InsertEmployeeAsync(Employee model)
        {

            await _employeeGRPCServerContext.Employees.AddAsync(model);

            bool inserted = Convert.ToBoolean(_employeeGRPCServerContext.SaveChangesAsync());
            
            return inserted;
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            var model = await _employeeGRPCServerContext.
                            Employees.
                            FirstAsync(m => m.Id == id);

            return model;
        }

        public async Task<List<Employee>> GetEmployeesAsync()
        {
            var models = await _employeeGRPCServerContext.
                                Employees.
                                ToListAsync();

            return models;

        }
        
    }
}
