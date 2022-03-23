using System;
using System.Collections.Generic;

#nullable disable

namespace CodingChallenge.Models
{
    public partial class Traduccione
    {
        public int Id { get; set; }
        public int IdIdioma { get; set; }
        public string ListaVacia { get; set; }
        public string ReporteDeFormas { get; set; }
        public string Total { get; set; }
        public string Perimetro { get; set; }
        public string Area { get; set; }
        public string Formas { get; set; }
    }
}
