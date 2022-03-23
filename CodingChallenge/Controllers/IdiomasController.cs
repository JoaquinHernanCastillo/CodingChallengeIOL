using CodingChallenge.Models;
using CodingChallenge.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CodingChallenge.Controllers
{
    [ApiController]
    [Route("api/Idiomas")]
    public class IdiomasController : Controller
    {
        [HttpGet]
        [Route("Listado")]
        public IActionResult Listado()
        {
            var idiomas = IdiomasRepository.ListadoIdiomas();
            return Ok(idiomas);
        }
        
        [HttpPost]
        [Route("Nuevo")]
        public IActionResult Nuevo(string idioma)
        {
            try
            {
                if (IdiomasRepository.NuevoIdioma(idioma))  return Ok();
        
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpPut]
        [Route("Actualizar")]
        public IActionResult Actualizar(Idioma idioma)
        {
            try
            {
                if (IdiomasRepository.ActualizarIdioma(idioma)) return Ok();
        
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
