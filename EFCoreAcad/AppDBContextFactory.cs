using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreAcad
{
    //Used to create object AppDbContext
    public class AppDBContextFactory : IDesignTimeDbContextFactory<AppDBContext>
    {
        public AppDBContext CreateDbContext(string[] args)
        {
            var opnsBldr = new DbContextOptionsBuilder<AppDBContext>();
            opnsBldr.UseSqlite("Filenmae=EFCoreAcad.db");

            return new AppDBContext(opnsBldr.Options);
        }
    }
}
