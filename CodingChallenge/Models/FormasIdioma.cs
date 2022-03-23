using System;
using System.Collections.Generic;

#nullable disable

namespace CodingChallenge.Models
{
    public partial class FormasIdioma
    {
        public int Id { get; set; }
        public int IdForma { get; set; }
        public int IdIdioma { get; set; }
        public string Singular { get; set; }
        public string Plural { get; set; }
    }
}
