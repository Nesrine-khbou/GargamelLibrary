using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLGargamelLibrary
{
    public class Smurf
    {

        public int Id { get; set; }


        public string Name { get; set; }


        public double Height { get; set; } // Taille en centimètres


        public SmurfDescription Description { get; set; } // Trait de personnalité


    }
}
