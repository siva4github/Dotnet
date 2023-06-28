using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AspNetCoreRazor.Models;

namespace AspNetCoreRazor.Data
{
    public class AspNetCoreRazorContext : DbContext
    {
        public AspNetCoreRazorContext (DbContextOptions<AspNetCoreRazorContext> options)
            : base(options)
        {
        }

        public DbSet<AspNetCoreRazor.Models.Movie> Movie { get; set; } = default!;
    }
}
