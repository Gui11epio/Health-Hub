using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Health_Hub.Infrastructure.Context;

namespace MottuFind_C_.Infrastructure.Context
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

            
            

            optionsBuilder.UseOracle("User Id=rm554894;Password=020306;Data Source=oracle.fiap.com.br/ORCL");

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
