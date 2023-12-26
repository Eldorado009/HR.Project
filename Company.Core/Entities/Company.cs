﻿using Company.Core.Interfaces;

namespace Company.Core.Entities;

public class Company : IEntity
{
    public int Id { get; }
    public string Name { get; set; }
    public string Description { get; set; }
    private static int _id;
    public Company(string name, string description)
    {
        Id = _id++;
        Name = name;
        Description = description;

    }
}
