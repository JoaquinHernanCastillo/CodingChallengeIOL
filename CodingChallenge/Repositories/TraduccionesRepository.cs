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
        
        public static string ListaVacia(int idioma)
        {
            string lvacia = "";
            using (var db = new CodingChallengeContext())
            {
                var mje = db.Traducciones.Where(t => t.IdIdioma == idioma).FirstOrDefault().ListaVacia;
                lvacia = $"<h1>{mje}</h1>";
            }
            return lvacia;
        }
        
        public static string ReporteFormas(int idioma)
        {
            string reporte = "";
            using (var db = new CodingChallengeContext())
            {
                var mje = db.Traducciones.Where(t => t.IdIdioma == idioma).FirstOrDefault().ReporteDeFormas;
                reporte = $"<h1>{mje}</h1>";
            }
            return reporte;
        }
        
        public static string Perimetro(int idioma)
        {
            string perimetro = "";
            using (var db = new CodingChallengeContext())
            {
                perimetro = db.Traducciones.Where(t => t.IdIdioma == idioma).FirstOrDefault().Perimetro;
            }
            return perimetro;
        }
        
        public static string Area(int idioma)
        {
            string area = "";
            using (var db = new CodingChallengeContext())
            {
                area = db.Traducciones.Where(t => t.IdIdioma == idioma).FirstOrDefault().Area;
            }
            return area;
        }
        public static string Total(int idioma)
        {
            string total = "";
            using (var db = new CodingChallengeContext())
            {
                total = db.Traducciones.Where(t => t.IdIdioma == idioma).FirstOrDefault().Total + ":< br />";
            }
            return total;
        }
        
        public static string TotalFormas(int idioma, int cantidad)
        {
            string formas = "";
            //using (var db = new CodingChallengeContext())
            //{
            //    string traduccionFormas = db.Traducciones.Where(t => t.IdIdioma == idioma).FirstOrDefault().Formas;
            //
            //    formas = String.Format("{0} {1} ", cantidad, traduccionFormas);
            //}
            return formas;
        }
        
        internal static string TotalPerimetro(int idioma, decimal totalPerimetro)
        {
            string tPerimetro = "";
            using (var db = new CodingChallengeContext())
            {
                tPerimetro = String.Format("{0} {1:#.##} ", Perimetro(idioma), totalPerimetro);
            }
            return tPerimetro;
        }
        
        internal static string TotalArea(int idioma, decimal totalArea)
        {
            string tArea = "";
            using (var db = new CodingChallengeContext())
            {
                tArea = String.Format("{0} {1:#.##} ", Area(idioma), totalArea);
            }
            return tArea;
        }
    }
}
