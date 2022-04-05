/*
 * Refactorear la clase para respetar principios de programación orientada a objetos. Qué pasa si debemos soportar un nuevo idioma para los reportes, o
 * agregar más formas geométricas?
 *
 * Se puede hacer cualquier cambio que se crea necesario tanto en el código como en los tests. La única condición es que los tests pasen OK.
 *
 * TODO: Implementar Trapecio/Rectangulo, agregar otro idioma a reporting.
 * */

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;

namespace CodingChallenge.Data.Classes
{
    public class FormaGeometrica
    {
        #region Formas

        public const int Cuadrado = 1;
        public const int TrianguloEquilatero = 2;
        public const int Circulo = 3;
        public const int TrapecioRectangulo = 4;

        #endregion

        #region Idiomas

        public const int Castellano = 1;
        public const int Ingles = 2;
        public const int Frances = 3;

        #endregion

        private readonly decimal _lado;
        private readonly decimal _altura;
        private static int _idioma;

        public int Tipo { get; set; }

        public FormaGeometrica(int tipo, decimal ancho, decimal altura)
        {
            Tipo = tipo;
            _lado = ancho;
            _altura = altura;
        }

        public static string Imprimir(List<FormaGeometrica> formas, int idioma)
        {
            _idioma = idioma;

            var sb = new StringBuilder();

            //Controla existencia de formas para continuar.
            if (!formas.Any()) return MensajeListaVacia(sb).ToString();

            // Hay por lo menos una forma, se puede continuar.
            // HEADER
            TituloReporteDeFormas(sb);

            //Inicializa variables
            int numeroCuadrados, numeroCirculos, numeroTrapecios, numeroTriangulos;
            decimal areaCuadrados, areaCirculos, areaTriangulos, areaTrapecios, perimetroCuadrados, perimetroCirculos, perimetroTrapecios, perimetroTriangulos;
            InicializarVariables(out numeroCuadrados, out numeroCirculos, out numeroTriangulos, out numeroTrapecios, out areaCuadrados, out areaCirculos, out areaTriangulos, out areaTrapecios, out perimetroCuadrados, out perimetroCirculos, out perimetroTriangulos, out perimetroTrapecios);

            //Recorre listado de formulas y obtiene la cantidad, area y perimetro total.
            for (var i = 0; i < formas.Count; i++)
            {
                if (formas[i].Tipo == Cuadrado)
                {
                    numeroCuadrados++;
                    areaCuadrados += formas[i].CalcularArea();
                    perimetroCuadrados += formas[i].CalcularPerimetro();
                }
                if (formas[i].Tipo == Circulo)
                {
                    numeroCirculos++;
                    areaCirculos += formas[i].CalcularArea();
                    perimetroCirculos += formas[i].CalcularPerimetro();
                }
                if (formas[i].Tipo == TrianguloEquilatero)
                {
                    numeroTriangulos++;
                    areaTriangulos += formas[i].CalcularArea();
                    perimetroTriangulos += formas[i].CalcularPerimetro();
                }
                if (formas[i].Tipo == TrapecioRectangulo)
                {
                    numeroTrapecios++;
                    areaTrapecios += formas[i].CalcularArea();
                    perimetroTrapecios += formas[i].CalcularPerimetro();
                }
            }

            //Obtiene las lineas correspondientes a cada Forma
            sb.Append(ObtenerLinea(numeroCuadrados, areaCuadrados, perimetroCuadrados, Cuadrado));
            sb.Append(ObtenerLinea(numeroCirculos, areaCirculos, perimetroCirculos, Circulo));
            sb.Append(ObtenerLinea(numeroTriangulos, areaTriangulos, perimetroTriangulos, TrianguloEquilatero));
            sb.Append(ObtenerLinea(numeroTrapecios, areaTrapecios, perimetroTrapecios, TrapecioRectangulo));

            // FOOTER
            sb.Append("TOTAL:<br/>");
            sb.Append(numeroCuadrados + numeroCirculos + numeroTriangulos + numeroTrapecios + " " + ObtenerTraduccionFomas() + " ");
            sb.Append(ObtenerTraduccionPerimetro() + " " + (perimetroCuadrados + perimetroTriangulos + perimetroCirculos + perimetroTrapecios).ToString("#.##") + " ");
            sb.Append(ObtenerTraduccionArea() + " " + (areaCuadrados + areaCirculos + areaTriangulos + areaTrapecios).ToString("#.##"));

            return sb.ToString();
        }

        private static string ObtenerTraduccionPerimetro()
        {
            string f = "";
            switch (_idioma)
            {
                case Castellano:
                    f = "Perimetro";
                    break;
                case Frances:
                    f = "Périmètre";
                    break;
                default:
                    f = "Perimeter";
                    break;
            }
            return f;
        }

        private static string ObtenerTraduccionArea()
        {
            string f = "";
            switch (_idioma)
            {
                case Castellano:
                    f = "Area";
                    break;
                case Frances:
                    f = "Région";
                    break;
                default:
                    f = "Area";
                    break;
            }
            return f;
        }

        private static string ObtenerTraduccionFomas()
        {
            string f = "";
            switch (_idioma)
            {
                case Castellano:
                    f = "formas";
                    break;
                case Frances:
                    f = "formes";
                    break;
                default:
                    f = "shapes";
                    break;
            }
            return f;
        }

        private static void InicializarVariables(out int numeroCuadrados, out int numeroCirculos, out int numeroTriangulos, out int numeroTrapecios, out decimal areaCuadrados, out decimal areaCirculos, out decimal areaTriangulos, out decimal areaTrapecios, out decimal perimetroCuadrados, out decimal perimetroCirculos, out decimal perimetroTriangulos, out decimal perimetroTrapecios)
        {
            numeroCuadrados = 0;
            numeroCirculos = 0;
            numeroTriangulos = 0;
            numeroTrapecios = 0;
            areaCuadrados = 0m;
            areaCirculos = 0m;
            areaTriangulos = 0m;
            areaTrapecios = 0m;
            perimetroCuadrados = 0m;
            perimetroCirculos = 0m;
            perimetroTriangulos = 0m;
            perimetroTrapecios = 0m;
        }

        private static void TituloReporteDeFormas(StringBuilder sb)
        {
            switch (_idioma)
            {
                case Castellano:
                    sb.Append("<h1>Reporte de Formas</h1>");
                    break;
                case Frances:
                    sb.Append("<h1>Rapport de formes géométriques</h1>");
                    break;
                default:
                    sb.Append("<h1>Shapes report</h1>");
                    break;
            }
        }

        private static StringBuilder MensajeListaVacia(StringBuilder sb)
        {
            StringBuilder mje;
            switch (_idioma)
            {
                case Castellano:
                    mje = sb.Append("<h1>Lista vacía de formas!</h1>");
                    break;
                case Frances:
                    mje = sb.Append("<h1>Liste vide de formes géométriques!</h1>");
                    break;
                default:
                    mje = sb.Append("<h1>Empty list of shapes!</h1>");
                    break;
            }
            return mje;
        }

        private static string ObtenerLinea(int cantidad, decimal area, decimal perimetro, int tipo)
        {
            if (cantidad <= 0) return string.Empty;

            return cantidad == 1 ? TraducirFormaLineaCompleta(tipo, area, perimetro) : TraducirFormasLineaCompleta(tipo, area, perimetro, cantidad);
        }
        private static string TraducirFormaLineaCompleta(int tipo, decimal area, decimal perimetro)
        {
            string f = "";
            switch (tipo)
            {
                case Cuadrado:
                    f = "Square";
                    if (_idioma == Castellano) f = "Cuadrado";
                    if (_idioma == Frances) f = "Carré";
                    break;
                case Circulo:
                    f = "Circle";
                    if (_idioma == Castellano) f = "Circulo";
                    if (_idioma == Frances) f = "Cercle";
                    break;
                case TrianguloEquilatero:
                    f = "Triangle";
                    if (_idioma == Castellano) f = "Triangulo";
                    if (_idioma == Frances) f = "Triangle";
                    break;
                case TrapecioRectangulo:
                    f = "Trapeze";
                    if (_idioma == Castellano) f = "Trapecio";
                    if (_idioma == Frances) f = "Trapèze";
                    break;
                default:
                    break;
            }

            return String.Format("{0} {1} | {2} {3:#.##} | {4} {5:#.##} <br/>", 1, f, ObtenerTraduccionArea(), area, ObtenerTraduccionPerimetro(), perimetro);
        }
        private static string TraducirFormasLineaCompleta(int tipo, decimal area, decimal perimetro, int cantidad)
        {
            string f = "";
            switch (tipo)
            {
                case Cuadrado:
                    f = "Squares";
                    if (_idioma == Castellano) f = "Cuadrados";
                    if (_idioma == Frances) f = "Carrés";
                    break;
                case Circulo:
                    f = "Circles";
                    if (_idioma == Castellano) f = "Círculos";
                    if (_idioma == Frances) f = "Cercles";
                    break;
                case TrianguloEquilatero:
                    f = "Triangles";
                    if (_idioma == Castellano) f = "Triángulos";
                    if (_idioma == Frances) f = "Triangles";
                    break;
                case TrapecioRectangulo:
                    f = "Trapezes";
                    if (_idioma == Castellano) f = "Trapecios";
                    if (_idioma == Frances) f = "Trapèzes";
                    break;
                default:
                    break;
            }

            return String.Format("{0} {1} | {2} {3:#.##} | {4} {5:#.##} <br/>", cantidad, f, ObtenerTraduccionArea(), area, ObtenerTraduccionPerimetro(), perimetro);
        }

        public decimal CalcularArea()
        {
            switch (Tipo)
            {
                case Cuadrado: return _lado * _lado;
                case Circulo: return (decimal)Math.PI * (_lado / 2) * (_lado / 2);
                case TrianguloEquilatero: return ((decimal)Math.Sqrt(3) / 4) * _lado * _lado;
                case TrapecioRectangulo: return _lado * _altura;
                default:
                    throw new ArgumentOutOfRangeException(@"Forma desconocida");
            }
        }

        public decimal CalcularPerimetro()
        {
            switch (Tipo)
            {
                case Cuadrado: return _lado * 4;
                case Circulo: return (decimal)Math.PI * _lado;
                case TrianguloEquilatero: return _lado * 3;
                case TrapecioRectangulo: return _lado * 2 + _altura * 2;
                default:
                    throw new ArgumentOutOfRangeException(@"Forma desconocida");
            }
        }
    }
}
