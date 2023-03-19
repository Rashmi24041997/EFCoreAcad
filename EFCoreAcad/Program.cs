//Installing EFVore Tools : tool insyall --global  dotnet-ef
//creating migrations : dotnet ef migrations add <name of migrn>
//to create the database structure fromn existing db
//dotnet ef dbcontext scaffold <"FileName=EFCoreAcad.DB"/Connectionstring to ur db server> MS.EFCore.Sqlite

using EFCoreAcad;
using Microsoft.EntityFrameworkCore;

var options = new DbContextOptionsBuilder<AppDBContext>().UseSqlite().Options;

var dbContxt = new AppDBContext(options);

dbContxt.Database.Migrate();