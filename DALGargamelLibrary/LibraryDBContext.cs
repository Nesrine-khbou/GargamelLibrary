using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BLGargamelLibrary;
namespace DALGargameLibrary
{
    

    public class LibraryContext : DbContext
    {
        public DbSet<Book>? Books { get; set; }
        public DbSet<SpellBook>? SpellBooks { get; set; }
        public DbSet<RecipeBook>? RecipeBooks { get; set; }
        public DbSet<Client>? Clients { get; set; }
        public DbSet<Smurf>? Smurfs { get; set; }
        public DbSet<Ingredient>? Ingredients { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-TLMO0GV ;Database =GargmelLibraryDB; Trusted_Connection = True; TrustServerCertificate=True");
        }
    }
}
