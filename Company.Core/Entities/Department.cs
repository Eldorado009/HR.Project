﻿using Company.Core.Interfaces;

namespace Company.Core.Entities;

public class Department : IEntity
{
    public int Id { get; }
    public string Name { get; set; }
    public int EmployeeLimit { get; set; }
    public int CompanyId { get; set; }
    public Company Company { get; set; }
    public bool IsActive { get; set; }
    private static int _id;
    public Department(string name, int employeeLimit, int companyId, Company company)
    {
        Id = _id++;
        Name = name;
        EmployeeLimit = employeeLimit;
        CompanyId = companyId;
        Company = company;

    }
}