﻿using Company.Core.Interfaces;

namespace Company.Core.Entities;

public class Employee: IEntity
{
    public int Id { get; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public double Salary { get; set; }
    public int DepartmentId { get; set;}
    public Department Department { get; set; }
    private static int _id;
    public Employee(string name, string surname, string email, string phoneNumber, double salary, int departmentId )
    {
        Id = _id++;
        Name = name;
        Surname = surname;
        Email = email;
        PhoneNumber = phoneNumber;
        Salary = salary;
        DepartmentId = departmentId;
    }
}