using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;


namespace RecettesGourmandes.Models
{
    public class RecettesGourmandesContext : DbContext
    {
        public RecettesGourmandesContext():base("name = recettesgourmandesDB") { }
        public DbSet<Recette> Recettes { get; set; }
    }
}