using CodingChallenge.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Repositories
{
    public class FormasRepository
    {
        public static string FormulaCalculoArea(int idForma)
        {
            using (var db = new CodingChallengeEntities())
            {
                return db.Formas.Where(f => f.Id == idForma).FirstOrDefault().CalculoArea;
            }
        }
        public static string FormulaCalculoPerimetro(int idForma)
        {
            using (var db = new CodingChallengeEntities())
            {
                return db.Formas.Where(f => f.Id == idForma).FirstOrDefault().CalculoPerimetro;
            }
        }

    }
}
