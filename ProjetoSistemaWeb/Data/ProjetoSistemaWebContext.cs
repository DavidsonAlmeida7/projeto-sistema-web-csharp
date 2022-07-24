using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjetoSistemaWeb.Models;

namespace ProjetoSistemaWeb.Data
{
    public class ProjetoSistemaWebContext : DbContext
    {
        public ProjetoSistemaWebContext (DbContextOptions<ProjetoSistemaWebContext> options)
            : base(options)
        {
        }

        public DbSet<Department> Department { get; set; } = default!;
        public DbSet<Seller> Seller { get; set; } = default!;
        public DbSet<SalesRecord> SalesRecord { get; set; } = default!;
    }
}
