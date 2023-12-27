using Company.Core.Entities;

namespace Company.DataAccess.Contexts;

public static class CompanyDbContext
{
    public static List<Company.Core.Entities.Company> Companies { get; set; } = new List<Core.Entities.Company>();
    public static List<Department> Departaments { get; set; } = new List<Department>();
    public static List<Employee> Employees { get; set; } = new List<Employee>();
}
