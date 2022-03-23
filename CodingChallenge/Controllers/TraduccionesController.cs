using CodingChallenge.DTO;
using CodingChallenge.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingChallenge.Controllers
{
    /// <summary>
    /// Traducciones contiene textos utilizados en la impresión de Reporte.
    /// </summary>
    /// <returns></returns>
    /// 
    [ApiController]
    [Route("api/Traducciones")]
    public class TraduccionesController : Controller
    {
        /// <summary>
        /// Listado de Traducciones utilizadas en Reporte de Impresión.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Listado")]
        public IActionResult Listado()
        {
            var traducciones = TraduccionesRepository.ListadoTraducciones();
            return Ok(traducciones);
        }
        
        [HttpPost]
        [Route("Nueva")]
        public IActionResult Nueva(TraduccionesDTO traduccion)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest();
        
                if (TraduccionesRepository.NuevaTraduccion(traduccion)) return Ok();
        
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpPut]
        [Route("Actualizar")]
        public IActionResult Actualizar(TraduccionesDTO traduccion)
        {
            try
            {
                if (TraduccionesRepository.ActualizarTraduccion(traduccion)) return Ok();
        
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
