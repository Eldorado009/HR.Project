﻿using Company.Core.Interfaces;

namespace Company.Core.Entities;

public class Department : IEntity
{
    public int Id { get; }
    public string Name { get; set; }
    public int EmployeeLimit { get; set; }
    public int CurrentEmployeeCount { get; set; }
    public Company Company { get; set; }
    public bool IsActive { get; set; } = true;
    private static int _id;
    public Department(string name, int employeeLimit,  Company company)
    {
        Id = _id++;
        Name = name;
        EmployeeLimit = employeeLimit;
        Company = company;

    }
}
