
using Company.Business.Interfaces;
using Company.Business.Utilities.Exceptions;
using Company.Core.Entities;
using Company.DataAccess.Contexts;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace Company.Business.Services;

public class EmployeeService : IEmployeeService
{
    private IDepartmentService departmentService { get; }
    public EmployeeService()
    {
        departmentService= new DepartmentService();
    }
    public void Create(string name, string surname, string email, string phoneNumber, int salary, string departmentName)
    {
        if (String.IsNullOrEmpty(name)) throw new ArgumentNullException();
        Department? department = departmentService.GetByName(departmentName);
        if (department is null) throw new NotFiniteNumberException($"{departmentName} is not exist");
        if (department.EmployeeLimit == department.CurrentEmployeeCount)
        {
            throw new DepartmentIsFullExcepction($"{department.Name} is already full");
        }
        Employee employee = new(name,surname,email,phoneNumber,salary,department);
        CompanyDbContext.Employees.Add(employee);
        department.CurrentEmployeeCount++;
    }

    public void ChangeDepartment(int employeeId, string newDepartmentName)
    {
        var employee = CompanyDbContext.Employees.Find(x => x.Id == employeeId);
        if (employee is null) throw new NotFoundException("Employee Not Found");

        if (String.IsNullOrEmpty(newDepartmentName)) throw new ArgumentNullException();
        var department = CompanyDbContext.Departaments.Find(x => x.Name.ToLower() == newDepartmentName.ToLower());
        if (department is null) throw new NotFoundException("Department Not Found");

        Delete(employee.Id);

        Create(employee.Name, employee.Surname, employee.Email, department.Name, employee.Salary, employee.PhoneNumber);
    }


    public void Delete(int Id)
    {
        var employee = CompanyDbContext.Employees.Find(x => x.Id == Id);
        if (employee is null) throw new NotFoundException("Employee Not Found");
        employee.IsDelete = true;
        if (employee.Department.CurrentEmployeeCount > 5)
        {
            employee.Department.CurrentEmployeeCount--;
        }
        else departmentService.Delete(employee.Department.Name);
    }
    public void ShowAll()
    {
        foreach (var item in CompanyDbContext.Employees)
        {
            if (item.IsDelete==false)
            {

                Console.WriteLine($"Id: {item.Id}\n" +
                                  $"Name: {item.Name}\n" +
                                  $"Surname: {item.Surname}\n" +
                                  $"Email: {item.Email}\n" +
                                  $"Phone Number: {item.PhoneNumber}\n" +
                                  $"Salary: {item.Salary}");
            }
        }
    }
}
