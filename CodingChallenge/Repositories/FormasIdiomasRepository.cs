using CodingChallenge.DTO;
using CodingChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingChallenge.Repositories
{
    public class FormasIdiomasRepository
    {
        public static List<FormasIdiomasDTO> ListadoFormasIdiomas()
        {
            List<FormasIdiomasDTO> formasIdiomasDTOs = new List<FormasIdiomasDTO>();
        
            using (var db = new CodingChallengeContext())
            {
                var formasIdiomas = db.FormasIdiomas.ToList();
                foreach (var item in formasIdiomas)
                {
                    FormasIdiomasDTO forIdioma = new FormasIdiomasDTO();
                    forIdioma.Id = item.Id;
                    forIdioma.IdIdioma = item.IdIdioma;
                    forIdioma.Idioma = db.Idiomas.FirstOrDefault(i => i.Id == item.IdIdioma).Idioma1;
                    forIdioma.IdForma = item.IdForma;
                    //forIdioma.Forma = db.Formas.FirstOrDefault(f => f.Id == item.IdForma).Forma1;
                    forIdioma.Singular = item.Singular;
                    forIdioma.Plural = item.Plural;
        
                    formasIdiomasDTOs.Add(forIdioma);
                }
                return formasIdiomasDTOs;
            }
        }
        
        public static bool NuevaFormaIdioma(FormasIdiomasDTO formasIdiomasDTO)
        {
            bool alta = false;
            try
            {
                using (var db = new CodingChallengeContext())
                {
                    if (!db.FormasIdiomas.Any(f => f.IdIdioma == formasIdiomasDTO.IdIdioma && f.IdForma == formasIdiomasDTO.IdForma))
                    {
                        FormasIdioma nuevaFormaIdioma = new FormasIdioma();
        
                        int id = db.FormasIdiomas.Max(f => f.Id) > 0 ? db.FormasIdiomas.Max(f => f.Id) + 1 : 1;
                        nuevaFormaIdioma.Id = id;
                        nuevaFormaIdioma.IdIdioma = formasIdiomasDTO.IdIdioma > 0 ? formasIdiomasDTO.IdIdioma :
                            db.Idiomas.FirstOrDefault(f => f.Idioma1.Trim().ToLower() == formasIdiomasDTO.Idioma.Trim().ToLower()).Id;
                        //nuevaFormaIdioma.IdForma = formasIdiomasDTO.IdForma > 0 ? formasIdiomasDTO.IdForma :
                        //    db.Formas.FirstOrDefault(f => f.Forma1.Trim().ToLower() == formasIdiomasDTO.Forma.Trim().ToLower()).Id;
                        nuevaFormaIdioma.Singular = formasIdiomasDTO.Singular;
                        nuevaFormaIdioma.Plural = formasIdiomasDTO.Plural;
                        db.FormasIdiomas.Add(nuevaFormaIdioma);
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
        
        public static bool ActualizarFormasIdiomas(FormasIdiomasDTO formasIdiomasDTO)
        {
            bool update = false;
            try
            {
                using (var db = new CodingChallengeContext())
                {
                    FormasIdioma formaIdiomaRegistrada = db.FormasIdiomas.Where(f => f.IdIdioma == formasIdiomasDTO.IdIdioma && f.IdForma == formasIdiomasDTO.IdForma).FirstOrDefault();
                    if (formaIdiomaRegistrada != null)
                    {
                        formaIdiomaRegistrada.IdIdioma = formasIdiomasDTO.IdIdioma > 0 ? formasIdiomasDTO.IdIdioma :
                            db.Idiomas.FirstOrDefault(f => f.Idioma1.Trim().ToLower() == formasIdiomasDTO.Idioma.Trim().ToLower()).Id;
                        //formaIdiomaRegistrada.IdForma = formasIdiomasDTO.IdForma > 0 ? formasIdiomasDTO.IdForma :
                        //    db.Formas.FirstOrDefault(f => f.Forma1.Trim().ToLower() == formasIdiomasDTO.Forma.Trim().ToLower()).Id;
                        formaIdiomaRegistrada.Singular = formasIdiomasDTO.Singular;
                        formaIdiomaRegistrada.Plural = formasIdiomasDTO.Plural;
        
                        db.FormasIdiomas.Update(formaIdiomaRegistrada);
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
        
        internal static string TraducirForma(int tipo, int cantidad, int idioma)
        {
            string forma = "";
            using (var db = new CodingChallengeContext())
            {
                var fdb = db.FormasIdiomas.FirstOrDefault(f => f.IdIdioma == idioma && f.IdForma == tipo);
                forma = cantidad > 1 ? fdb.Plural : fdb.Singular;
            }
            return forma;
        }
    }
}
