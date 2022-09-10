using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Studio.Models
{
    public class StudioDbContext : DbContext
    {
        public StudioDbContext(DbContextOptions<StudioDbContext> options) : base(options)
        {

        }

        public DbSet<Reservation> Reservations { get; set; }
    }
}
