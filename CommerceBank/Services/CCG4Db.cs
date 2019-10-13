using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using CommerceBank.Models.Database;

namespace CommerceBank.Services
{
    public class CCG4Db : CCG4DbEntities
    {
        public readonly IConfiguration config;

        //config will be provided via dependency injection
        public CCG4Db(IConfiguration config)
        {
            this.config = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(config.GetConnectionString("DevelopementDbConnectionString"));
        }
    }
}
