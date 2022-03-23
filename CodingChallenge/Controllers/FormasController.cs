using CodingChallenge.Models;
using CodingChallenge.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CodingChallenge.Controllers
{
    [ApiController]
    [Route("api/Formas")]
    public class FormasController : Controller
    {
        [HttpGet]
        [Route("Listado")]
        public IActionResult Listado()
        {
            var formas = FormasRepository.ListadoFormas();
            return Ok(formas);
        }
        
        [HttpPost]
        [Route("Nueva")]
        public IActionResult Nueva(Forma forma)
        {
            try
            {
                if (FormasRepository.NuevaForma(forma)) return Ok();
        
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpPut]
        [Route("Actualizar")]
        public IActionResult Actualizar(Forma forma)
        {
            try
            {
                if (FormasRepository.ActualizarForma(forma)) return Ok();
        
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
