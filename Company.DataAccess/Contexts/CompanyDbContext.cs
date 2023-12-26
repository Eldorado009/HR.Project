using Company.Core.Entities;

namespace Company.DataAccess.Contexts;

public static class CompanyDbContext
{
    public static List<Company.Core.Entities.Company> Companies { get; set; }
    public static List<Department> Departaments { get; set; }
    public static List<Employee> Employees { get; set; }
}
