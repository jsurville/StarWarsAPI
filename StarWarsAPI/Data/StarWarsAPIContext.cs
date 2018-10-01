using StarWarsAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StarWarsAPI.Data
{
    public class StarWarsAPIContext:DbContext
    {
        public DbSet<Perso> Persos { get; set; }
        //public DbSet<Planete> Planetes { get; set; }
        //public DbSet<Episode> Episodes { get; set; }
    }
}