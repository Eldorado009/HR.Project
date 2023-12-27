
using Company.Business.Interfaces;
using Company.Business.Utilities.Exceptions;
using Company.Core.Entities;
using Company.DataAccess.Contexts;

namespace Company.Business.Services;

public class EmployeeService : IEmployeeService
{
    private IDepartmentService departmentService { get; }
    public EmployeeService()
    {
        departmentService= new DepartmentService();
    }
    public void Create(string name, string surname, string email, string phoneNumber, int salary, int departmentId, string departmentName)
    {
        if (String.IsNullOrEmpty(name)) throw new ArgumentNullException();
        Department? department = departmentService.GetByName(departmentName);
        if (department is null) throw new NotFiniteNumberException($"{departmentName} is not exist");
        if (department.EmployeeLimit == department.CurrentEmployeeCount)
        {
            throw new DepartmentIsFullExcepction($"{department.Name} is already full");
        }
        Employee employee = new(name,surname,email,phoneNumber,salary,departmentId);
        CompanyDbContext.Employees.Add(employee);
        department.CurrentEmployeeCount++;
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
