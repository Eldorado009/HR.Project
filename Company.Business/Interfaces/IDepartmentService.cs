using Company.Core.Entities;

namespace Company.Business.Interfaces;

public interface IDepartmentService
{
    void Create(string name, int employeeLimit, string companyName);
    public Department? GetById(int departmenId);
    public Department? GetByName(string name);
    void AddEmployee(string name, int employeeId, int companyId );
    void UpdateDepartment(string newName, int employeeLimit);
    void GetDepartmentEmployees(string departmentName);
    void ShowAll();
    
}
