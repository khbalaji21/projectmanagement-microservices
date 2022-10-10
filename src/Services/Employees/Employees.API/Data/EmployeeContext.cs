using Employees.API.Data.Interfaces;
using Employees.API.Entities;
using MongoDB.Driver;

namespace Employees.API.Data
{
    public class EmployeeContext : IEmployeeContext
    {
        public EmployeeContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

            Employees = database.GetCollection<Employee>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));
            EmployeeContextSeed.SeedData(Employees);
        }

        public IMongoCollection<Employee> Employees { get; }
    }
}
