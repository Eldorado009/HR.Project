using Company.Core.Entities;

namespace Company.Business.Interfaces;

public interface IDepartmentService
{
    void Create(string name, int employeeLimit, string companyName);
    public Department? GetById(int departmenId);
    public Department? GetByName(string name);
    void AddEmployee(string name, int employeeId, int companyId );
    void UpdateDepartment(string oldDepartmentName,string newDepartmentName, int newDepartmentEmployeeLimit);
    void GetDepartmentEmployees(string Name);
    void GetAllDepartment();
    void Delete(string name);
    void Activete(string name);
    bool isDepartmentExist();
    void moveEmployee(int employeeId);
    
}
