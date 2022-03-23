/*
 * Refactorear la clase para respetar principios de programación orientada a objetos. Qué pasa si debemos soportar un nuevo idioma para los reportes, o
 * agregar más formas geométricas?
 *
 * Se puede hacer cualquier cambio que se crea necesario tanto en el código como en los tests. La única condición es que los tests pasen OK.
 *
 * TODO: Implementar Trapecio/Rectangulo, agregar otro idioma a reporting.
 * */

using CodingChallenge.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CodingChallenge.Classes
{
    public class FormaGeometrica
    {
        
        private readonly decimal _lado;
        
        public int Tipo { get; set; }
        
        public FormaGeometrica(int tipo, decimal ancho)
        {
            Tipo = tipo;
            _lado = ancho;
        }
        
        public static string Imprimir(List<FormaGeometrica> formas, int idioma)
        {
            var sb = new StringBuilder();
        
            if (!formas.Any() || formas == null)
            {
                var mje = TraduccionesRepository.ListaVacia(idioma);
                sb.Append(mje);
            }
            else
            {
                // Hay por lo menos una forma
                // HEADER
                var mje = TraduccionesRepository.ReporteFormas(idioma);
                sb.Append(mje);
        
                var cantidadDeFormas = (from f in formas
                                        group f by f.Tipo into fGroup
                                        select new
                                        {
                                            IdForma = fGroup.Key,
                                            Cantidad = fGroup.Count(),
                                            TotalArea = 0,
                                            TotalPerimetro = 0
                                        });
        
                List<FormasCalculos> ListadoFormasCalculos = new List<FormasCalculos>();
        
                foreach (var item in cantidadDeFormas)
                {
                    FormasCalculos f = new FormasCalculos();
                    f.IdForma = item.IdForma;
                    f.Cantidad = item.Cantidad;
                    f.TotalArea = CalcularAreaDeForma(formas.FindAll(ff => ff.Tipo == item.IdForma), item.IdForma);
                    f.TotalPerimetro = CalcularPerimetroDeForma(formas.FindAll(ff => ff.Tipo == item.IdForma), item.IdForma);
        
                    ListadoFormasCalculos.Add(f);
                }
        
                foreach (var item in ListadoFormasCalculos)
                {
                    sb.Append(ObtenerLinea(item.Cantidad, item.TotalArea, item.TotalPerimetro, item.IdForma, idioma));
                }
        
                // FOOTER
                mje = TraduccionesRepository.Total(idioma);
                sb.Append(mje);
        
                mje = TraduccionesRepository.TotalFormas(idioma, formas.Count);
                sb.Append(mje);
                
                mje = TraduccionesRepository.TotalPerimetro(idioma, ListadoFormasCalculos.Select(dd => dd.TotalPerimetro).Sum());
                sb.Append(mje);
        
                mje = TraduccionesRepository.TotalArea(idioma, ListadoFormasCalculos.Select(dd => dd.TotalArea).Sum());
                sb.Append(mje);
            }
        
            return sb.ToString();
        }
        
        private static decimal CalcularAreaDeForma(List<FormaGeometrica> formasGeometricas, int idForma)
        {
            DataTable dt = new DataTable();
            decimal area = 0;
        
            string formulaCalculoAreaString = FormasRepository.FormulaCalculoArea(idForma);
            
            foreach (var item in formasGeometricas)
            {
                formulaCalculoAreaString = formulaCalculoAreaString.Replace("_lado", item._lado.ToString());
                decimal formulaCalculoArea = (decimal) dt.Compute(formulaCalculoAreaString, "");
                area += formulaCalculoArea;
            }
        
            return area;
        }
        
        private static decimal CalcularPerimetroDeForma(List<FormaGeometrica> formasGeometricas, int idForma)
        {
            DataTable dt = new DataTable();
            decimal perimetro = 0;
        
            string formulaCalculoPerimetroString = FormasRepository.FormulaCalculoPerimetro(idForma);
            
            foreach (var item in formasGeometricas)
            {
                formulaCalculoPerimetroString = formulaCalculoPerimetroString.Replace("_lado", item._lado.ToString());
                decimal formulaCalculoPerimetro = (decimal)dt.Compute(formulaCalculoPerimetroString, "");
                perimetro += formulaCalculoPerimetro;
            }
        
            return perimetro;
        }
        
        private static string ObtenerLinea(int cantidad, decimal area, decimal perimetro, int tipo, int idioma)
        {
            if (cantidad > 0)
            {
                return $"{cantidad} {TraducirForma(tipo, cantidad, idioma)} | " +
                    $"{TraduccionesRepository.Area(idioma)} {area:#.##} | " +
                    $"{TraduccionesRepository.Perimetro(idioma)} {perimetro:#.##} <br/>";
            }
        
            return string.Empty;
        }
        
        private static string TraducirForma(int tipo, int cantidad, int idioma)
        {
            return FormasIdiomasRepository.TraducirForma(tipo, cantidad, idioma);
        }

        
    }
}
