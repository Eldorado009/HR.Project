using Company.Business.Interfaces;

namespace Company.Business.Services;

public class DepartmentService : IDepartmentServices
{
    public void AddEmployee(string name, int employeeId, int companyId)
    {
        throw new NotImplementedException();
    }
    public void Create(string name, int employeeLimit, int companyId, string companyName)
    {
        throw new NotImplementedException();
    }

    public Core.Entities.Company GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Core.Entities.Company GetByName(string name)
    {
        throw new NotImplementedException();
    }

    public void GetDepartmentEmployees(string departmentName)
    {
        throw new NotImplementedException();
    }

    public void ShowAll()
    {
        throw new NotImplementedException();
    }

    public void UpdateDepartment(string newName, int employeeLimit)
    {
        throw new NotImplementedException();
    }
}
