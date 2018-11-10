using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using actividadcomplementaria.Models;

namespace actividadcomplementaria.Models
{
    public class actividadcomplementariaContext : DbContext
    {
        public actividadcomplementariaContext (DbContextOptions<actividadcomplementariaContext> options)
            : base(options)
        {
        }

        public DbSet<actividadcomplementaria.Models.area> area { get; set; }

        public DbSet<actividadcomplementaria.Models.rol> rol { get; set; }
    }
}
