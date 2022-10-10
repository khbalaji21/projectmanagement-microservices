using Employees.API.Entities;
using MongoDB.Driver;

namespace Employees.API.Data.Interfaces
{
    public interface IEmployeeContext
    {
        IMongoCollection<Employee> Employees { get; }
    }
}
