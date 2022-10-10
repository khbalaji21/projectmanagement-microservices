using Employees.API.Data.Interfaces;
using Employees.API.Entities;
using MongoDB.Driver;

namespace Employees.API.Data
{
    public class EmployeeContext : IEmployeeContext
    {
        public EmployeeContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("ProjectManagementDatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("ProjectManagementDatabaseSettings:DatabaseName"));

            Employees = database.GetCollection<Employee>(configuration.GetValue<string>("ProjectManagementDatabaseSettings:EmployeesCollectionName"));
            EmployeeContextSeed.SeedData(Employees);
        }

        public IMongoCollection<Employee> Employees { get; }
    }
}
