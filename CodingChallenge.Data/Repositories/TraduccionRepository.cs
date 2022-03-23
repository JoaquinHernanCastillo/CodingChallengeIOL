using CodingChallenge.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Repositories
{
    public class TraduccionRepository
    {
        public static string ListaVacia(int idioma)
        {
            string lvacia = "";
            using (var db = new CodingChallengeEntities())
            {
                var mje = db.Traducciones.Where(t => t.IdIdioma == idioma).FirstOrDefault().ListaVacia;
                lvacia = $"<h1>{mje}</h1>";
            }
            return lvacia;
        }

        public static string ReporteFormas(int idioma)
        {
            string reporte = "";
            using (var db = new CodingChallengeEntities())
            {
                 var mje = db.Traducciones.Where(t => t.IdIdioma == idioma).FirstOrDefault().ReporteDeFormas;
                reporte = $"<h1>{mje}</h1>";
            }
            return reporte;
        }
        
        public static string Perimetro(int idioma)
        {
            string perimetro = "";
            using (var db = new CodingChallengeEntities())
            {
                perimetro = db.Traducciones.Where(t => t.IdIdioma == idioma).FirstOrDefault().Perimetro;
            }
            return perimetro;
        }

        public static string Area(int idioma)
        {
            string area = "";
            using (var db = new CodingChallengeEntities())
            {
                area = db.Traducciones.Where(t => t.IdIdioma == idioma).FirstOrDefault().Area;
            }
            return area;
        }
        public static string Total(int idioma)
        {
            string total = "";
            using (var db = new CodingChallengeEntities())
            {
                total = db.Traducciones.Where(t => t.IdIdioma == idioma).FirstOrDefault().Total + ":< br />";
            }
            return total;
        }

        public static string TotalFormas(int idioma, int cantidad)
        {
            string formas = "";
            using (var db = new CodingChallengeEntities())
            {
                string traduccionFormas = db.Traducciones.Where(t => t.IdIdioma == idioma).FirstOrDefault().Formas;

                formas = String.Format("{0} {1} ", cantidad, traduccionFormas);
            }
            return formas;
        }

        internal static string TotalPerimetro(int idioma, decimal totalPerimetro)
        {
            string tPerimetro = "";
            using (var db = new CodingChallengeEntities())
            {
                tPerimetro = String.Format("{0} {1:#.##} ", Perimetro(idioma), totalPerimetro);
            }
            return tPerimetro;
        }

        internal static string TotalArea(int idioma, decimal totalArea)
        {
            string tArea = "";
            using (var db = new CodingChallengeEntities())
            {
                tArea = String.Format("{0} {1:#.##} ", Area(idioma), totalArea);
            }
            return tArea;
        }
    }
}
