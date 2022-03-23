using CodingChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingChallenge.Repositories
{
    public class IdiomasRepository
    {
        public static List<Idioma> ListadoIdiomas()
        {
            using (var db = new CodingChallengeContext())
            {
                return db.Idiomas.ToList();
            }
        }
        
        public static bool NuevoIdioma(string idioma)
        {
            bool alta = false;
            try
            {
                using (var db = new CodingChallengeContext())
                {
                    if (!db.Idiomas.Any(i => i.Idioma1.Trim().ToLower() == idioma.Trim().ToLower()))
                    {
                        Idioma nuevoIdioma = new Idioma();
        
                        int id = db.Idiomas.Max(i => i.Id) > 0 ? db.Idiomas.Max(i => i.Id) + 1 : 1;
                        nuevoIdioma.Id = id;
                        nuevoIdioma.Idioma1 = idioma;
                        db.Idiomas.Add(nuevoIdioma);
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
        
        public static bool ActualizarIdioma(Idioma idioma)
        {
            bool update = false;
            try
            {
                using (var db = new CodingChallengeContext())
                {
                    Idioma idiomaRegistrado = db.Idiomas.Where(i => i.Id == idioma.Id).FirstOrDefault();
                    if (idiomaRegistrado != null)
                    {
                        idiomaRegistrado.Idioma1 = idioma.Idioma1;
                        db.Idiomas.Update(idiomaRegistrado);
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
        
        public static int ObtenerIdIdioma(string idioma)
        {
            int idIdioma = 0;
            try
            {
                using (var db = new CodingChallengeContext())
                {
                    idIdioma = db.Idiomas.Where(i => i.Idioma1.Trim().ToLower() == idioma).FirstOrDefault().Id;
                }
                return idIdioma;
            }
            catch (Exception)
            {
                return idIdioma;
            }
        }
    }
}
