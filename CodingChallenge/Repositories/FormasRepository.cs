using CodingChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingChallenge.Repositories
{
    public class FormasRepository
    {
        public static List<Forma> ListadoFormas()
        {
            using (var db = new CodingChallengeContext())
            {
                return db.Formas.ToList();
            }
        }
        
        public static bool NuevaForma(Forma forma)
        {
            bool alta = false;
            try
            {
                using (var db = new CodingChallengeContext())
                {
                    if (!db.Formas.Any(i => i.Forma1.Trim().ToLower() == forma.Forma1.Trim().ToLower()))
                    {
                        Forma nuevaForma = new Forma();
        
                        int id = db.Formas.Max(i => i.Id) > 0 ? db.Formas.Max(i => i.Id) + 1 : 1;
                        nuevaForma.Id = id;
                        nuevaForma.Forma1 = forma.Forma1;
                        nuevaForma.CalculoArea = forma.CalculoArea;
                        nuevaForma.CalculoPerimetro = forma.CalculoPerimetro;
                        db.Formas.Add(nuevaForma);
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
        
        public static bool ActualizarForma(Forma forma)
        {
            bool update = false;
            try
            {
                using (var db = new CodingChallengeContext())
                {
                    Forma formaRegistrada = db.Formas.Where(i => i.Id == forma.Id).FirstOrDefault();
                    if (formaRegistrada != null)
                    {
                        formaRegistrada.Forma1 = forma.Forma1;
                        formaRegistrada.CalculoArea = forma.CalculoArea;
                        formaRegistrada.CalculoPerimetro = forma.CalculoPerimetro;
                        db.Formas.Update(formaRegistrada);
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
        
        public static int ObtenerIdForma(string forma)
        {
            int idForma = 0;
            try
            {
                using (var db = new CodingChallengeContext())
                {
                    idForma = db.Formas.Where(f => f.Forma1.Trim().ToLower() == forma).FirstOrDefault().Id;
                }
                return idForma;
            }
            catch (Exception)
            {
                return idForma;
            }
        }
    }
}
