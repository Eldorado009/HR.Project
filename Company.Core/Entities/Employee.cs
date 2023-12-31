using Company.Core.Interfaces;

namespace Company.Core.Entities;

public class Employee: IEntity
{
    public int Id { get; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public int Salary { get; set; }
    public bool IsDelete { get; set; } = false;
    public Department Department { get; set; }
    private static int _id;
    public Employee(string name, string surname, string email, string phoneNumber, int salary, Department departmentName )
    {
        Id = _id++;
        Name = name;
        Surname = surname;
        Email = email;
        PhoneNumber = phoneNumber;
        Salary = salary;
        IsDelete = false;
        Department = departmentName;
    }
}
