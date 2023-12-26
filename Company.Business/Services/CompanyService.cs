using Company.Business.Interfaces;
using Company.Business.Utilities.Exceptions;
using Company.DataAccess.Contexts;

namespace Company.Business.Services;

public class CompanyService : ICompanyService
{
    public void Create(string? name, string description)
    {
        if (String.IsNullOrEmpty(name)) throw new ArgumentNullException();
        Company.Core.Entities.Company? dbCompany=
            CompanyDbContext.Companies.Find (c=>c.Name.ToLower()==name.ToLower());
        if (dbCompany is not null ) 
            throw new AlreadyExistException($"{dbCompany.Name} is already exist");
        Company.Core.Entities.Company company = new(name,description);
        CompanyDbContext.Companies.Add(company);
    }
    public void Activated(string name, bool isActive = false)
    {
        throw new NotImplementedException();
    }

    public void Delete(string name)
    {
        throw new NotImplementedException();
    }

    public void GetAllDepartment(string departmentName)
    {
        throw new NotImplementedException();
    }

    public Core.Entities.Company GetCompany(int Id)
    {
        throw new NotImplementedException();
    }

    public void GetDepartmentIncluded(string departmentName)
    {
        throw new NotImplementedException();
    }
}
