﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebAPI.Models
{
    public class Department
    { 
        public int Id { get; set; }
        public string Name { get; set; }

        public string? ManagerName { get; set; }


        public virtual List<Employee>? Employees { get; set; }
    }
}

// Configuration: Models/DepartmentConfiguration.cs
namespace WebAPI.Models
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.Property(d => d.Name).IsRequired().HasMaxLength(50);
            builder.Property(d => d.ManagerName).HasMaxLength(50);
            
        }
    }
}