using Company.Business.Interfaces;

namespace Company.Business.Services;

public class EmployeeService : IEmployeeService
{

    public void Create(string name, string surname, string email, string phoneNumber, double salary, int departmentId, string departmentName)
    {
        if (String.IsNullOrEmpty(name)) throw new ArgumentNullException();
    }

    public void ChangeDepartment(int employeeId, string newDepartmentName)
    {
        throw new NotImplementedException();
    }


    public void Delete(int Id)
    {
        throw new NotImplementedException();
    }
}
