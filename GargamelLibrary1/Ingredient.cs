using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLGargamelLibrary
{
    public class Ingredient
    {
        [Key] // Définit la clé primaire
        public int Id { get; set; }

        public string Name { get; set; }
        public string Type { get; set; } // Example: "Herb", "Mineral", "Magic"
        public string Location { get; set; } // Where to find it
        public string Color { get; set; } // Ingredient color
    }

}
