using Employees.API.Data.Interfaces;
using Employees.API.Entities;
using MongoDB.Driver;

namespace Employees.API.Repositories
{
    public class EmployeeRepository
    {
        private readonly IEmployeeContext _context;

        public EmployeeRepository(IEmployeeContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _context
                            .Employees
                            .Find(e => true)
                            .ToListAsync();
        }

        public async Task<Employee> GetEmployee(string id)
        {
            return await _context
                           .Employees
                           .Find(e => e.Id == id)
                           .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Employee>> GetEmployeeByName(string name)
        {
            FilterDefinition<Employee> filter = Builders<Employee>.Filter.ElemMatch(e => e.Name, name);

            return await _context
                            .Employees
                            .Find(filter)
                            .ToListAsync();
        }

        public async Task CreateEmployee(Employee employee)
        {
            await _context.Employees.InsertOneAsync(employee);
        }

        public async Task<bool> UpdateEmployee(Employee employee)
        {
            var updateResult = await _context
                                        .Employees
                                        .ReplaceOneAsync(filter: e => e.Id == employee.Id, replacement: employee);

            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;
        }

        public async Task<bool> DeleteEmployee(string id)
        {
            FilterDefinition<Employee> filter = Builders<Employee>.Filter.Eq(e => e.Id, id);

            DeleteResult deleteResult = await _context
                                                .Employees
                                                .DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }
    }
}
