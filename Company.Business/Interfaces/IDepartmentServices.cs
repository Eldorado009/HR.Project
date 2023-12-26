using Company.Core.Entities;

namespace Company.Business.Interfaces;

public interface IDepartmentServices
{
    void Create(string name, int employeeLimit, int companyId, string companyName);
    Department GetById(int departmenId);
    Department GetByName(string name);
    void AddEmployee(string name, int employeeId, int companyId );
    void UpdateDepartment(string newName, int employeeLimit);
    void GetDepartmentEmployees(string departmentName);
    void ShowAll();
    //asdasdasd
}
