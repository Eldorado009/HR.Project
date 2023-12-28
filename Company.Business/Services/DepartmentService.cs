using Company.Business.Interfaces;
using Company.Business.Utilities.Exceptions;
using Company.Core.Entities;
using Company.DataAccess.Contexts;

namespace Company.Business.Services;

public class DepartmentService : IDepartmentService
{
    private ICompanyService companyService { get; }
    public DepartmentService()
    {
        companyService = new CompanyService();
    }
    public void Create(string name, int employeeLimit, string companyName)
    {
        if (String.IsNullOrEmpty(name)) throw new ArgumentNullException();
        Department dbDepartment =
            CompanyDbContext.Departaments.Find(c => c.Name.ToLower() == name.ToLower());
        if (dbDepartment is not null)
            throw new AlreadyExistException($"{dbDepartment.Name} is already exist");
        if (employeeLimit < 5)
            throw new MinCountException("Minimum employee count requirement is 5");
        Company.Core.Entities.Company? company = companyService.FindCompanyByName(companyName);
        if (company is null) throw new NotFiniteNumberException($"{companyName} is not exist");
        Department department = new(name, employeeLimit, company);
        CompanyDbContext.Departaments.Add(department);

    }
    public void AddEmployee(string name, int employeeId, int companyId)
    {
        throw new NotImplementedException();
    }
    public Department? GetById(int departmenId)
    {
        throw new NotSupportedException();
    }
    public Department? GetByName(string name)
    {
        if (String.IsNullOrEmpty(name)) throw new ArgumentNullException();
        return CompanyDbContext.Departaments.Find(d => d.Name.ToLower() == name.ToLower());
    }

    public void GetDepartmentEmployees(string departmentName)
    {
        throw new NotImplementedException();
    }

    public void ShowAll()
    {
        foreach (var department in CompanyDbContext.Departaments)
        {
            if (department.Company.Name=="Furniture")
            {
                    Console.WriteLine($"Id: {department.Id}; Department name: {department.Name}");
            
            }     
        }
    }

    public void UpdateDepartment(string newName, int employeeLimit)
    {
        throw new NotImplementedException();
    }
}