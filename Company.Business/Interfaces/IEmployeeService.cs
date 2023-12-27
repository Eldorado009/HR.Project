namespace Company.Business.Interfaces;

public interface IEmployeeService
{
    void Create(string name, string surname, string email, string phoneNumber, int salary, int departmentId, string departmentName);
    void Delete(int  Id);
    void ChangeDepartment(int employeeId, string newDepartmentName);
}
