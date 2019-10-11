using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            //use the connection string provided in the appsettings.Develoment.json file
            optionsBuilder.UseSqlServer(config.GetConnectionString("DevelopmentConnectionString"));
        }
    }
}
