using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLGargamelLibrary
{
    public class Client
    {
        public int Id { get; set; } // Identifiant unique du client
        public string Name { get; set; } // Nom du client
        public Speciality Speciality { get; set; } // Spécialité du client
        public LevelOfMagic LevelOfMagic { get; set; } // Niveau de magie du client

    }
}
