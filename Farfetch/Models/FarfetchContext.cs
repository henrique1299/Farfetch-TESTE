using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Farfetch.Models
{
    public class FarfetchContext : DbContext
    {
        public FarfetchContext(DbContextOptions<FarfetchContext> options)
            : base(options)
        {
        }

        public DbSet<Item> Itens { get; set; }
    }
}
