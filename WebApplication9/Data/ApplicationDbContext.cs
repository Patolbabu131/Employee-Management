//using Microsoft.EntityFrameworkCore;
//using WebApplication9.Models;

//namespace WebApplication9.Data
//{
//    public class ApplicationDbContext
//    {
//    }
//}
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebApplication9.Models;

namespace WebApplication9.Data;


public class ApplicationDbContext : DbContext
{
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    public DbSet<Employee> Employes { get; set; }
    public DbSet<Salary> Salaries { get; set; }
   

}
