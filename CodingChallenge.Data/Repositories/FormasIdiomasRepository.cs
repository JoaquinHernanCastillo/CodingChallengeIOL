using CodingChallenge.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Repositories
{
    public class FormasIdiomasRepository
    {
        internal static string TraducirForma(int tipo, int cantidad, int idioma)
        {
            string forma = "";
            using (var db = new CodingChallengeEntities())
            {
                var fdb = db.FormasIdiomas.FirstOrDefault(f => f.IdIdioma == idioma && f.IdForma == tipo);
                forma = cantidad > 1 ? fdb.Plural : fdb.Singular;
            }
            return forma;
        }
    }
}
