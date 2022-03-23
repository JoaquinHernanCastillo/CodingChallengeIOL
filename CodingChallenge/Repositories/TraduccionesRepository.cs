using CodingChallenge.DTO;
using CodingChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingChallenge.Repositories
{
    public class TraduccionesRepository
    {
        public static List<TraduccionesDTO> ListadoTraducciones()
        {
            List<TraduccionesDTO> traduccionesDTOs = new List<TraduccionesDTO>();
        
            using (var db = new CodingChallengeContext())
            {
                var traducciones = db.Traducciones.ToList();
                foreach (var item in traducciones)
                {
                    TraduccionesDTO trd = new TraduccionesDTO();
                    trd.Id = item.Id;
                    trd.IdIdioma = item.IdIdioma;
                    trd.Idioma = db.Idiomas.FirstOrDefault(i => i.Id == item.IdIdioma).Idioma1;
                    trd.ListaVacia = item.ListaVacia;
                    trd.ReporteDeFormas = item.ReporteDeFormas;
                    trd.Total = item.Total;
                    trd.Perimetro = item.Perimetro;
                    trd.Area = item.Area;
        
                    traduccionesDTOs.Add(trd);
                }
                return traduccionesDTOs;
            }
        }
        
        public static bool NuevaTraduccion(TraduccionesDTO traduccionDTO)
        {
            bool alta = false;
            try
            {
                using (var db = new CodingChallengeContext())
                {
                    if (!db.Traducciones.Any(t => t.IdIdioma == traduccionDTO.IdIdioma))
                    {
                        Traduccione nuevaTraduccion = new Traduccione();
        
                        int id = db.Traducciones.Max(i => i.Id) > 0 ? db.Traducciones.Max(i => i.Id) + 1 : 1;
                        nuevaTraduccion.Id = id;
                        nuevaTraduccion.IdIdioma = traduccionDTO.IdIdioma > 0 ? traduccionDTO.IdIdioma :
                            db.Idiomas.FirstOrDefault(i => i.Idioma1.Trim().ToLower() == traduccionDTO.Idioma.Trim().ToLower()).Id;
                        nuevaTraduccion.ListaVacia = traduccionDTO.ListaVacia;
                        nuevaTraduccion.ReporteDeFormas = traduccionDTO.ReporteDeFormas;
                        nuevaTraduccion.Total = traduccionDTO.Total;
                        nuevaTraduccion.Perimetro = traduccionDTO.Perimetro;
                        nuevaTraduccion.Area = traduccionDTO.Area;
        
                        db.Traducciones.Add(nuevaTraduccion);
                        db.SaveChanges();
        
                        alta = true;
                    }
                }
                return alta;
            }
            catch (Exception)
            {
                return alta;
            }
        }
        
        public static bool ActualizarTraduccion(TraduccionesDTO traduccionesDTO)
        {
            bool update = false;
            try
            {
                using (var db = new CodingChallengeContext())
                {
                    Traduccione traduccionRegistrada = db.Traducciones.Where(i => i.Id == traduccionesDTO.Id).FirstOrDefault();
                    if (traduccionRegistrada != null)
                    {
                        traduccionRegistrada.IdIdioma = traduccionesDTO.IdIdioma;
                        traduccionRegistrada.ListaVacia = traduccionesDTO.ListaVacia;
                        traduccionRegistrada.ReporteDeFormas = traduccionesDTO.ReporteDeFormas;
                        traduccionRegistrada.Total = traduccionesDTO.Total;
                        traduccionRegistrada.Perimetro = traduccionesDTO.Perimetro;
                        traduccionRegistrada.Area = traduccionesDTO.Area;
                        
                        db.Traducciones.Update(traduccionRegistrada);
                        db.SaveChanges();
        
                        update = true;
                    }
                }
                return update;
            }
            catch (Exception)
            {
                return update;
            }
        }
    }
}
