using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProiectPrelucaAnca.Models;

namespace ProiectPrelucaAnca.Data
{
    public class ProiectPrelucaAncaContext : DbContext
    {
        public ProiectPrelucaAncaContext (DbContextOptions<ProiectPrelucaAncaContext> options)
            : base(options)
        {
        }

        public DbSet<ProiectPrelucaAnca.Models.Judet> Judet { get; set; }

        public DbSet<ProiectPrelucaAnca.Models.Localitate> Localitate { get; set; }

        public DbSet<ProiectPrelucaAnca.Models.Functie> Functie { get; set; }

        public DbSet<ProiectPrelucaAnca.Models.Departament> Departament { get; set; }

        public DbSet<ProiectPrelucaAnca.Models.Angajat> Angajat { get; set; }
    }
}
