using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using zadaniePiekarniaMVC.Models;

namespace zadaniePiekarniaMVC.Data
{
    public class zadaniePiekarniaMVCContext : DbContext
    {
        public zadaniePiekarniaMVCContext (DbContextOptions<zadaniePiekarniaMVCContext> options)
            : base(options)
        {
        }

        public DbSet<zadaniePiekarniaMVC.Models.Piekarnia> Piekarnia { get; set; } = default!;
    }
}
