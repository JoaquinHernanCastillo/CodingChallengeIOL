using CodingChallenge.DTO;
using CodingChallenge.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CodingChallenge.Controllers
{
    [ApiController]
    [Route("api/FormasIdiomas")]
    public class FormasIdiomasController : Controller
    {
        [HttpGet]
        [Route("Listado")]
        public IActionResult Listado()
        {
            var formasIdiomas = FormasIdiomasRepository.ListadoFormasIdiomas();
            return Ok(formasIdiomas);
        }
        
        
        [HttpPost]
        [Route("Nueva")]
        public IActionResult Nueva(FormasIdiomasDTO formasIdiomasDTO)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest();
        
                if (FormasIdiomasRepository.NuevaFormaIdioma(formasIdiomasDTO)) return Ok();
        
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpPut]
        [Route("Actualizar")]
        public IActionResult Actualizar(FormasIdiomasDTO formasIdiomasDTO)
        {
            try
            {
                if (FormasIdiomasRepository.ActualizarFormasIdiomas(formasIdiomasDTO)) return Ok();
        
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
