
using Company.Business.Interfaces;
using Company.Core.Entities;

namespace Company.Business.Services;

public class EmployeeService : IEmployeeService
{
    private IDepartmentService departmentService { get; }
    public EmployeeService()
    {
        departmentService= new DepartmentService();
    }
    public void Create(string name, string surname, string email, string phoneNumber, double salary, int departmentId, string departmentName)
    {
        if (String.IsNullOrEmpty(name)) throw new ArgumentNullException();
        Department? department = departmentService.GetByName(departmentName);
        if (department is null) throw new NotFiniteNumberException($"{departmentName} is not exist");
        Employee employee = new( name);


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
