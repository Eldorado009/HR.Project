namespace Company.Business.Interfaces;

public interface IEmployeeService
{
    void Create(string name, string surname, string email, string phoneNumber, double salary, int departmentId, string departmentName);
    void Delete(int  Id);
    void ChangeDepartment(int employeeId, string newDepartmentName);
}
