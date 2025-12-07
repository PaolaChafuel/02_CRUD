using _02_CRUD.Modelos;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Configuration;

namespace _02_CRUD.Config
{
    public class sqlServer_dbcontext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var cn = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
                optionsBuilder.UseSqlServer(cn);
            }
        }
        public DbSet<ClienteModel> Clientes { get; set; }
    }
}