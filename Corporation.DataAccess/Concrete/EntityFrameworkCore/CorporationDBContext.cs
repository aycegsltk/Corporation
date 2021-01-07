using Corporation.Core.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Corporation.DataAccess.Concrete.EntityFrameworkCore
{
    public class CorporationDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder 
            optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CorporationDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Rank> Ranks { get; set; }
    }
}
