using CodingChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingChallenge.DTO
{
    public class TraduccionesDTO
    {
        public int Id { get; set; }
        public int IdIdioma { get; set; }
        public string Idioma { get; set; }
        public string ListaVacia { get; set; }
        public string ReporteDeFormas { get; set; }
        public string Total { get; set; }
        public string Perimetro { get; set; }
        public string Area { get; set; }

    }
}
