using Company.Business.Interfaces;
using Company.Business.Utilities.Exceptions;
using Company.Core.Entities;
using Company.DataAccess.Contexts;

namespace Company.Business.Services;

public class CompanyService : ICompanyService
{
    public void Create(string? name, string? description)
    {
        if (String.IsNullOrEmpty(name)) throw new ArgumentNullException();
        Company.Core.Entities.Company? dbCompany=
            CompanyDbContext.Companies.Find (c=>c.Name.ToLower()==name.ToLower());
        if (dbCompany is not null ) 
            throw new AlreadyExistException($"{dbCompany.Name} is already exist");
        Company.Core.Entities.Company company = new(name,description);
        CompanyDbContext.Companies.Add(company);
    }
    public void Activated(string name)
    {
        if (String.IsNullOrEmpty(name)) throw new ArgumentNullException();
        Company.Core.Entities.Company? dbCompany =
            CompanyDbContext.Companies.Find(c => c.Name.ToLower() == name.ToLower());
        if (dbCompany is null)
            throw new NotFoundException($"{name} company not found");
        dbCompany.IsActive = true;
    }

    public void Delete(string name)
    {
        if (String.IsNullOrEmpty(name)) throw new ArgumentNullException();
        Company.Core.Entities.Company? dbCompany =
            CompanyDbContext.Companies.Find(c => c.Name.ToLower() == name.ToLower());
        if (dbCompany is null)
            throw new NotFoundException($"{name} company not found");
        dbCompany.IsActive = false;
    }

    public void GetAllDepartment(string departmentName)
    {
        throw new NotImplementedException();
    }

    public void GetCompany(string name)
    {
        if (String.IsNullOrEmpty(name)) throw new ArgumentNullException();
        Company.Core.Entities.Company? dbCompany =
            CompanyDbContext.Companies.Find(c => c.Name.ToLower() == name.ToLower());
        if (dbCompany is null)
            throw new NotFoundException($"{name} company not found");
        Console.WriteLine($" Id: {dbCompany.Id}\n" +
                          $" Company name: {dbCompany.Name}\n" +
                          $" Company Description: {dbCompany.Description}");
        GetDepartmentIncluded(dbCompany.Name);
    }

    public void GetDepartmentIncluded(string name)
    {
        foreach (var department in CompanyDbContext.Departaments)
        {
            if (department.Company.Name.ToLower() == name.ToLower())
            {
                Console.WriteLine($"Id: {department.Id}; Department name: {department.Name}");
            }
        }
    }

    public Core.Entities.Company? FindCompanyByName(string name)
    {
        if (String.IsNullOrEmpty(name)) throw new ArgumentNullException();
        return CompanyDbContext.Companies.Find(c => c.Name.ToLower() == name.ToLower());
    }

    public void ShowAll()
    {
        foreach (var company in CompanyDbContext.Companies)
        { 
            if (company.IsActive == true)
            {
                Console.WriteLine($"id: {company.Id}; Company name: {company.Name}");
            }
        }
    }

    public bool IsCompanyExist()
    {
        foreach (var item in CompanyDbContext.Companies)
        {
            if (item is not null && item.IsActive == true)
            {
                return true;
            }
        }
        return false;
    }
}
