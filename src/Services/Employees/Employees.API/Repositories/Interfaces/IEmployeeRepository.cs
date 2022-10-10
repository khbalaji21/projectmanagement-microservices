using Employees.API.Entities;

namespace Employees.API.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetEmployees();
        Task<Employee> GetEmployee(string id);
        Task<IEnumerable<Employee>> GetEmployeeByName(string name);

        Task CreateEmployee(Employee employee);
        Task<bool> UpdateEmployee(Employee employee);
        Task<bool> DeleteEmployee(string id);
    }
}
