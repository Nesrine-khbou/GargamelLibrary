using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLGargamelLibrary
{
    public class Book
    {
        public int Id { get; set; }
        public int Serial { get; set; }

        public string? Title { get; set; }

    }
}
