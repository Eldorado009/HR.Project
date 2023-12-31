using Company.Business.Interfaces;
using Company.Business.Utilities.Exceptions;
using Company.Core.Entities;
using Company.DataAccess.Contexts;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Linq;

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

    public void GetDepartmentEmployees(string name)
    {
        foreach (var item in CompanyDbContext.Employees)
        {
            if (item.Department.Name.ToLower() == name.ToLower())
            {
                if (item.IsDelete == false)
                {
                    Console.WriteLine($"ID: {item.Id}\n" +
                                      $"Name: {item.Name}\n" +
                                      $"Surname: {item.Surname}\n" +
                                      $"Email: {item.Email}\n" +
                                      $"Phone Number: {item.PhoneNumber}\n" +
                                      $"Salary: {item.Salary}");
                }
            }
        }
    }

    public void GetAllDepartment()
    {
        foreach (var department in CompanyDbContext.Departaments)
        {
            if (department.IsActive == true)
            {
                Console.WriteLine($"Id: {department.Id}; Department name: {department.Name}");
            }
        }
    }


    public void Delete(string name)
    {
        if (string.IsNullOrEmpty(name)) throw new ArgumentNullException();
        var isDepartment = CompanyDbContext.Departaments.Find(x => x.Name.ToLower() == name.ToLower());
        if (isDepartment is null) throw new NotFoundException($"{name} not found department");
        isDepartment.IsActive = false;
    }

    public void Activete(string name)
    {
        if (string.IsNullOrEmpty(name)) throw new ArgumentNullException();
        var isDepartment = CompanyDbContext.Departaments.Find(x => x.Name.ToLower() == name.ToLower());
        if (isDepartment is null) throw new NotFoundException($"{name} not found department");
        isDepartment.IsActive = true;
    }

    public void UpdateDepartment(string oldDepartmentName, string newDepartmentName, int newDepartmentEmployeeLimit)
    {
        if (string.IsNullOrEmpty(oldDepartmentName)) throw new ArgumentNullException();
        var byDepartment = CompanyDbContext.Departaments.Find(x => x.Name.ToLower() == oldDepartmentName.ToLower());
        if (byDepartment is null) throw new NotFoundException($"{oldDepartmentName} not found department");


        if (string.IsNullOrEmpty(newDepartmentName)) throw new ArgumentNullException();
        byDepartment.Name = newDepartmentName;
        byDepartment.EmployeeLimit = newDepartmentEmployeeLimit;
    }

    public bool isDepartmentExist()
    {
        foreach (var item in CompanyDbContext.Departaments)
        {
            if (item is not null && item.IsActive==true)
            {
                return true;
            }
        }
        return false;
    }

    public void moveEmployee(int employeeId)
    {
        throw new NotImplementedException();
    }
}