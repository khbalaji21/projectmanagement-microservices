using Employees.API.Entities;
using MongoDB.Driver;

namespace Employees.API.Data
{
    public class EmployeeContextSeed
    {
        public static void SeedData(IMongoCollection<Employee> employeeCollection)
        {
            bool existEmployee = employeeCollection.Find(e => true).Any();
            if (!existEmployee)
            {
                employeeCollection.InsertManyAsync(GetPreconfiguredEmployees());
            }
        }

        private static IEnumerable<Employee> GetPreconfiguredEmployees()
        {
            return new List<Employee>()
            {
                new Employee
                {
                    Id = "63411f3fe6186a9936248c43",
                    MemberId = "595959",
                    Name = "Swaroop Sing",
                    Experience = 11,
                    Skills = new [] { "Electrical Engineer",
                      "Communications Engineer",
                      "Awesome Programming Skills",
                      "Leader" },
                    AdditionalInfo = "Currently working at Qualcomm",
                    ProjectStartDate = DateTime.Parse("2011-10-08 06:55:36.955", System.Globalization.CultureInfo.InvariantCulture),
                    ProjectEndDate = DateTime.Parse("2042-10-08 06:55:36.955", System.Globalization.CultureInfo.InvariantCulture),
                    AllocationPercentage = 50
                }
            };
        }
    }
}
