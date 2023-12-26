namespace Company.Business.Interfaces;

public interface IDepartmentServices
{
    void Create(string name, int employeeLimit, int companyId, string companyName);
    Company.Core.Entities.Company GetById(int id);
    Company.Core.Entities.Company GetByName(string name);
    void AddEmployee(string name, int employeeId, int companyId );
    void UpdateDepartment(string newName, int employeeLimit);
    void GetDepartmentEmployees(string departmentName);
    void ShowAll();
}
