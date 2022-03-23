using CodingChallenge.Classes;
using CodingChallenge.DTO;
using CodingChallenge.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CodingChallenge.Controllers
{
    [ApiController]
    [Route("api/FormaGeometrica")]
    public class FormaGeometricaController : Controller
    {
        [HttpPost]
        [Route("Impresion")]
        public IActionResult Impresion(List<FormasGeometricasDTO> formasGeometricasDTOs, string idioma)
        {
            var ListadoFormasGeometricas = new List<FormaGeometrica>();
            
            foreach (var item in formasGeometricasDTOs)
            {
                var idFormaGeometrica = FormasRepository.ObtenerIdForma(item.FormaGeometrica);
            
                var formaGeometrica = new FormaGeometrica(idFormaGeometrica, item.Lado);
                ListadoFormasGeometricas.Add(formaGeometrica);
            }
            
            var idIdioma = IdiomasRepository.ObtenerIdIdioma(idioma);
            
            var resumen = FormaGeometrica.Imprimir(ListadoFormasGeometricas, idIdioma);
            return Ok("Ejecuta");
        }
    }
}
