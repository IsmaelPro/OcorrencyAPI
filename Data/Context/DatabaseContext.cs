using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Models.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {

        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<Ocorrência> Ocorrência { get; set; }
        public DbSet<Pedido> Pedido { get; set; }

        
    }
}
